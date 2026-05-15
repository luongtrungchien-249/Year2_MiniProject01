import numpy as np
from collections import Counter
import concurrent.futures
from itertools import product

class Node:
    def __init__(self, feature=None, threshold=None, left=None, right=None,
                 value=None, samples=None, class_counts = None):
        self.feature = feature          # Chỉ số cột dùng để chia
        self.threshold = threshold      # Giá trị để so sánh
        self.left = left                # Node Con trái
        self.right = right              # Node Con phải
        self.value = value
        # Kết quả dữ đoán
        # VD: value=1 → "tại đây dự đoán class 1"
        # Node phân nhánh: value = None
        self.samples = samples
        # Số lương dữ liệu đi vào Node này
        # Dùng để Debug và tính Important
        self.class_counts = class_counts

class DecisionTree:
    def __init__(self, max_depth=10, min_samples_split=2, criterion='gini', max_features=None, random_state=42):   # (Độ xâu của cây, số mẫu tối thiểu để chia, cách tính tốt của split "gini/ entropy", để tất cả chạy lại giống nhau)
        self.max_depth = max_depth                      # Độ xâu của cây
        self.min_samples_split = min_samples_split      # Số mẫu tối thiểu để chia
        self.criterion = criterion                      # Tính Độ Hỗn Loạn dữ liệu của split "gini/ entropy"
        self.random_state = random_state                # Để tất cả chạy lại giống nhau
        self.feature_importances_ = None                 # Độ ưu tiên của từng feature
        self.max_features = max_features                # Số feature được sét tại mỗi Node khi tìm Split
        self.classes_ = None                            # Danh sách Class duy nhất
        self.n_samples_root_ = None                     # Tổng Số Mẫu Train --> Lưu tham chiếu
        self.root = None                                # Node gốc
        self.rng = np.random.RandomState(random_state)
    
    @property
    def feature_importances(self):
        return self.feature_importances_

    def _weighted_class_counts(self, y, sample_weight):
        """Tính weighted count cho từng class — vectorized O(n)"""
        classes, y_enc = np.unique(y, return_inverse=True)
        counts = np.bincount(y_enc, weights=sample_weight, minlength=len(classes))
        return dict(zip(classes, counts))

    def fit(self, X, y, sample_weight=None):                                # Huẩn luyện Cây
        self.classes_ = np.unique(y)                    # Lấy danh sách class không trùng lặp : # VD: y=[0,1,0,1,1] → classes_=[0,1]
        self.n_samples_root_ = X.shape[0]               # Lấy tổng số mẫu của tập dữ liệu
        self.feature_importances_ = np.zeros(X.shape[1]) # Tạo ma trận 0 : Lưu độ quan trọng của từng Feature

        if sample_weight is None:
          sample_weight = np.ones(X.shape[0])
        else:
          sample_weight = np.asarray(sample_weight)
          sample_weight = sample_weight / np.sum(sample_weight) * X.shape[0]

        self.root = self._build_tree(X, y, sample_weight, depth=0)     # Xây cây từ Node Gốc

        total = np.sum(self.feature_importances_)        
        if total > 0:
            self.feature_importances_ /= total             
        # Chuẩn hóa về [0,1]: chia tất cả cho tổng
        # VD: [300, 100, 600] → [0.3, 0.1, 0.6]
        # Tổng = 1.0 → dễ so sánh feature nào quan trọng hơn

        return self # Trả về self → có thể viết: tree.fit(X,y).predict(X)


    def _build_tree(self, X, y, sample_weight, depth):
        n_samples, n_features = X.shape   # Số dòng, Số cột
        n_classes = len(np.unique(y))     # Loại nhãn

        weighted_n_samples = np.sum(sample_weight)

        # Điều kiện dừng
        if (depth >= self.max_depth  or
            weighted_n_samples  < self.min_samples_split or
            n_classes == 1 ):      # Dừng khi cây sâu + dữ liệu quá ít + chỉ còn 1 class
                      # Đếm Class
            counter    = self._weighted_class_counts(y, sample_weight)
            leaf_value = max(counter, key=counter.get) if counter else 0
            return Node(value=leaf_value, samples=int(weighted_n_samples), class_counts=counter)
            # Tao Nhãn lá với nhãn dữ đoán và phần phối Class
        # Lưu split tốt nhất
        best_gain = -float('inf')
        best_feature = None
        best_threshold = None
        # khởi tạo biến tìm Split
        # Chọn random feature (Embedding)

        if self.max_features is None:
          feature_indices = np.arange(n_features)
          # Gán chỉ số cho số lượng Feature
        else:
          feature_indices = self.rng.choice(
        n_features, self.max_features, replace=False)
        # Chọn ngấu nhiên trong max Feature , không trùng lặp
        # VD: n_features=10, max_features=3 → [2, 7, 5]
        # Đây là Embedded Method: mỗi node dùng tập feature khác nhau
        

        # Vòng lặp Split tốt nhất
        for feature_idx in feature_indices:
            feature_values = X[:, feature_idx]                                    # Lấy toàn bộ giá trị của một cột
            sorted_values = np.sort(np.unique(feature_values))                    # Xóa Trùng lặp và sắp xếp
            thresholds = (sorted_values[:-1] + sorted_values[1:]) / 2             # Ngưỡng = (mảng - giá trị cuối) - (mảng - giá trị đầu) / 2
                                                                                  # Lấy Ngưỡng Giữa ( Nằm Giữa Hai Giá Trị thực) --> Tổng Quát
            for threshold in thresholds:                # Duyệt qua các ngưỡng
                left_mask = feature_values < threshold     # Trái < Ngưỡng
                right_mask = ~left_mask                    # Phải >= Ngưỡng

                w_left = np.sum(sample_weight[left_mask])
                w_right = np.sum(sample_weight[right_mask])

                if w_left == 0 or w_right == 0:
                    continue

                gain = self._information_gain(y, y[left_mask], y[right_mask], sample_weight, sample_weight[left_mask], sample_weight[right_mask])   # Tính IG cuỷa từng Split

                if gain > best_gain:                    # Chọn Ngưỡng tốt nhất
                    best_gain = gain
                    best_feature = feature_idx
                    best_threshold = threshold

        # Nếu không tìm được split tốt
        if best_feature is None:
            counter    = self._weighted_class_counts(y, sample_weight)
            leaf_value = max(counter, key=counter.get) if counter else 0
            return Node(value=leaf_value, samples=int(weighted_n_samples), class_counts=counter)

        # Sau khi tìm được best_feature, best_gain
        if best_gain > 0:
          self.feature_importances_[best_feature] += best_gain * weighted_n_samples

        # Tích lũy important cho  từng Feature
        # đánh trọng số cho từng feature

        # Chia dữ liệu
        left_mask = X[:, best_feature] < best_threshold
        right_mask = ~left_mask
        # chia dữ liệu theo từng Split tốt nhất

        left_subtree = self._build_tree(X[left_mask], y[left_mask], sample_weight[left_mask], depth + 1)
        right_subtree = self._build_tree(X[right_mask], y[right_mask], sample_weight[right_mask], depth + 1)
        # Xây cây dưa trên ngưỡng đã chia tăng độ xâu cây
        return Node(feature=best_feature, threshold=best_threshold,
                   left=left_subtree, right=right_subtree, samples=int(weighted_n_samples))
        # Trả lại Node phân nhánh

    def _entropy(self, y, sample_weight=None):
        if sample_weight is None:
            sample_weight = np.ones(len(y))
        total_weight = np.sum(sample_weight)
        if total_weight == 0:
            return 0.0
        classes      = np.unique(y)
        entropy      = 0.0
        for c in classes:
            w = np.sum(sample_weight[y == c])
            if w > 0:
                p = w / total_weight
                entropy -= p * np.log2(p)
        return entropy
    def _gini(self, y, sample_weight):
        total_weight = np.sum(sample_weight)
        if total_weight == 0:
            return 0.0
        _, y_enc = np.unique(y, return_inverse=True)   #  vectorized
        weight_per_class = np.bincount(y_enc, weights=sample_weight, minlength=len(np.unique(y)))
        probs = weight_per_class / total_weight
        return 1.0 - np.sum(probs ** 2)

    def _information_gain(self, y_parent, y_left, y_right,
                          w_parent, w_left, w_right):
        w_p = np.sum(w_parent)
        w_l = np.sum(w_left)
        w_r = np.sum(w_right)
        if w_l == 0 or w_r == 0:
            return 0.0
        if self.criterion == 'entropy':
            parent_val = self._entropy(y_parent, w_parent)
            left_val   = self._entropy(y_left,   w_left)
            right_val  = self._entropy(y_right,  w_right)
        else:
            parent_val = self._gini(y_parent, w_parent)
            left_val   = self._gini(y_left,   w_left)
            right_val  = self._gini(y_right,  w_right)
        weighted_val = (w_l / w_p) * left_val + (w_r / w_p) * right_val
        return parent_val - weighted_val
    def predict(self, X):
        return np.array([self._traverse(x, self.root) for x in X])
    def _traverse(self, x, node):
        if node.value is not None:
            return node.value
        if x[node.feature] < node.threshold:
            return self._traverse(x, node.left)
        return self._traverse(x, node.right)
    def predict_proba(self, X):
        proba = []
        for x in X:
            leaf   = self._find_leaf(x, self.root)
            counts = leaf.class_counts
            total  = sum(counts.values())
            probs  = [
                counts.get(c, 0) / total if total > 0 else 1 / len(self.classes_)
                for c in self.classes_
            ]
            proba.append(probs)
        return np.array(proba)
    def _find_leaf(self, x, node):
        if node.value is not None:
            return node
        if x[node.feature] < node.threshold:
            return self._find_leaf(x, node.left)
        return self._find_leaf(x, node.right)
    def select_features(self, threshold=0.01):
        return np.where(self.feature_importances_ > threshold)[0]

class RandomForest:
    """
    Random Forest — API chuẩn sklearn 
    (Đã Tối ưu hóa Siêu tốc độ: Multi-threading + OOB Batching)
    """

    def __init__(self, n_estimators=100, max_depth=10,
                 min_samples_split=2, max_features='sqrt',
                 oob_score=False, random_state=42, n_jobs=-1): # Thêm n_jobs=-1
        self.n_estimators      = n_estimators
        self.max_depth         = max_depth
        self.min_samples_split = min_samples_split
        self.max_features      = max_features
        self.oob_score         = oob_score
        self.random_state      = random_state
        self.n_jobs            = n_jobs
        self.trees             = []
        self.rng               = np.random.RandomState(random_state)

    def _train_single_tree(self, seed, X, y, max_features, n_samples):
        """Hàm con để train 1 cây (Phục vụ cho chạy Đa luồng)"""
        rng = np.random.RandomState(seed)
        indices = rng.choice(n_samples, n_samples, replace=True)
        
        X_sample = X[indices]
        y_sample = y[indices]

        tree = DecisionTree(
            max_depth=self.max_depth,
            min_samples_split=self.min_samples_split,
            max_features=max_features,
            random_state=seed
        )
        tree.fit(X_sample, y_sample)
        
        oob_preds_dict = {}
        if self.oob_score:
            # Lấy các index KHÔNG có mặt trong tập mẫu (Out-of-bag)
            oob_indices = np.where(np.bincount(indices, minlength=n_samples) == 0)[0]
            
            # TỐI ƯU 1: BATCH PREDICTION. Predict 1 cục data thay vì từng dòng
            if len(oob_indices) > 0:
                preds = tree.predict(X[oob_indices])
                oob_preds_dict = {idx: p for idx, p in zip(oob_indices, preds)}
                
        return tree, tree.feature_importances_, oob_preds_dict

    def fit(self, X, y):
        self.trees             = []
        n_samples, n_features  = X.shape
        self.classes_          = np.unique(y)
        self.n_features_in_    = n_features
        self.feature_importances_ = np.zeros(n_features)

        if self.max_features == 'sqrt':
            max_features = int(np.sqrt(n_features))
        elif self.max_features is None:
            max_features = n_features
        else:
            max_features = self.max_features

        if self.oob_score:
            oob_votes = [Counter() for _ in range(n_samples)]

        # TỐI ƯU 2: MULTI-THREADING (Train nhiều cây cùng lúc)
        workers = None if self.n_jobs == -1 else self.n_jobs
        with concurrent.futures.ThreadPoolExecutor(max_workers=workers) as executor:
            # Tạo các Task train cây
            futures = [
                executor.submit(
                    self._train_single_tree, 
                    self.rng.randint(0, 100000), X, y, max_features, n_samples
                )
                for _ in range(self.n_estimators)
            ]
            
            # Thu thập kết quả khi các cây train xong
            for future in concurrent.futures.as_completed(futures):
                tree, fi, oob_preds_dict = future.result()
                
                self.trees.append(tree)
                self.feature_importances_ += fi
                
                if self.oob_score:
                    for idx, pred in oob_preds_dict.items():
                        oob_votes[idx][pred] += 1

        # Chuẩn hóa độ quan trọng của đặc trưng
        total = np.sum(self.feature_importances_)
        if total > 0:
            self.feature_importances_ /= total

        # Tính toán điểm OOB Score
        if self.oob_score:
            oob_preds, oob_true = [], []
            for i in range(n_samples):
                if len(oob_votes[i]) > 0:
                    oob_preds.append(oob_votes[i].most_common(1)[0][0])
                    oob_true.append(y[i])
            self.oob_score_ = np.mean(np.array(oob_preds) == np.array(oob_true))

        return self

    def predict(self, X):
        return self.classes_[np.argmax(self.predict_proba(X), axis=1)]

    def predict_proba(self, X):
        probas = np.array([tree.predict_proba(X) for tree in self.trees])
        return np.mean(probas, axis=0)

    def score(self, X, y):
        return np.mean(self.predict(X) == y)

    def select_features(self, threshold=0.01):
        return np.where(self.feature_importances_ > threshold)[0]

class KNN:
    """
    KNN — Đã tối ưu hóa siêu tốc bằng Vectorization và Argpartition O(N)
    """
    def __init__(self, n_neighbors=5, metric='euclidean', weights='uniform'):
        self.n_neighbors = n_neighbors
        self.metric      = metric
        self.weights     = weights

    def fit(self, X, y):
        self.X_train      = np.asarray(X, dtype=float)
        self.y_train      = np.asarray(y)
        self.classes_     = np.unique(y)
        self.n_features_in_ = self.X_train.shape[1]   
        self._is_fitted   = True
        return self

    def _check_is_fitted(self):
        if not getattr(self, '_is_fitted', False):
            raise AttributeError("KNN chưa fit. Gọi fit(X, y) trước.")

    def _compute_distances(self, X):
        X = np.asarray(X, dtype=float)
        
        if self.metric == 'euclidean':
            # Phép nhân ma trận (Matrix Multiplication - BLAS) chạy ngang ngửa C++
            X2 = np.sum(X ** 2, axis=1).reshape(-1, 1)
            Y2 = np.sum(self.X_train ** 2, axis=1)
            XY = X @ self.X_train.T
            return np.sqrt(np.maximum(0.0, X2 - 2 * XY + Y2))

        elif self.metric == 'manhattan':
            Y = self.X_train
            distances = np.empty((X.shape[0], Y.shape[0]), dtype=float)
            for i in range(X.shape[0]):
                distances[i] = np.sum(np.abs(Y - X[i]), axis=1)
            return distances

        else:
            raise ValueError(f"Unsupported metric: '{self.metric}'.")

    def _get_weights(self, distances):
        if self.weights == 'uniform':
            return np.ones_like(distances)
        elif self.weights == 'distance':
            return 1.0 / (distances + 1e-8)
        else:
            raise ValueError(f"Unsupported weights: '{self.weights}'.")

    def predict_proba(self, X):
        self._check_is_fitted()
        distances = self._compute_distances(X)
        
        n_test = distances.shape[0]
        n_classes = len(self.classes_)

        # TỐI ƯU 1: np.argpartition O(N) thay vì np.argsort O(N log N)
        # argpartition chỉ đẩy K phần tử nhỏ nhất về đầu mảng (ko tốn tgian sort phần còn lại)
        k_indices = np.argpartition(distances, self.n_neighbors - 1, axis=1)[:, :self.n_neighbors]
        
        # Lấy nhãn và khoảng cách tương ứng (Vectorized Fancy Indexing)
        k_labels = self.y_train[k_indices]
        k_distances = np.take_along_axis(distances, k_indices, axis=1)
        
        # Tính trọng số
        weights = self._get_weights(k_distances)
        
        # Encode nhãn thành 0, 1, 2... để dùng bincount
        k_labels_enc = np.searchsorted(self.classes_, k_labels)
        
        # TỐI ƯU 2: Loại bỏ Dictionary Python, thay bằng Ma trận NumPy + bincount
        proba = np.zeros((n_test, n_classes))
        
        for i in range(n_test):
            counts = np.bincount(k_labels_enc[i], weights=weights[i], minlength=n_classes)
            proba[i] = counts / np.sum(counts)

        return proba

    def predict(self, X):
        return self.classes_[np.argmax(self.predict_proba(X), axis=1)]

    def score(self, X, y):
        return np.mean(self.predict(X) == np.asarray(y))

class AdaBoost:
    """
    AdaBoost — API chuẩn sklearn 
    (Đã Tối ưu hóa siêu tốc bằng NumPy Vectorization cho Decision Stumps)
    """
    def __init__(self, n_estimators=50, learning_rate=1.0,
                 algorithm='SAMME', base_estimator=None, random_state=42):
        self.n_estimators    = n_estimators
        self.learning_rate   = learning_rate
        self.algorithm       = algorithm
        self.random_state    = random_state
        self.base_estimator  = base_estimator or DecisionTree
        self.rng             = np.random.RandomState(random_state)

        self.estimators_        = []
        self.estimator_weights_ = []
        self.classes_           = None
        self.n_features_in_     = None
        self._is_fitted         = False

    def _fast_stump_predict(self, stump, X):
        """TỐI ƯU SIÊU TỐC: Bỏ qua hàm predict chậm chạp của DecisionTree nếu là Stump"""
        if getattr(stump, 'max_depth', None) == 1:
            if stump.root.value is not None:
                # Trường hợp cây không thể chia nhánh (trả về 1 nhãn duy nhất)
                return np.full(X.shape[0], stump.root.value)
            else:
                # Bóc tách trực tiếp logic của Node và vector hóa bằng np.where
                feature = stump.root.feature
                threshold = stump.root.threshold
                left_val = stump.root.left.value
                right_val = stump.root.right.value
                return np.where(X[:, feature] < threshold, left_val, right_val)
        else:
            # Nếu không phải stump (max_depth > 1), buộc phải dùng predict cũ
            return stump.predict(X)

    def fit(self, X, y, sample_weight=None):                  
        if X.shape[0] != y.shape[0]:
            raise ValueError("X và y phải cùng số dòng")

        self.classes_       = np.unique(y)
        self.n_features_in_ = X.shape[1]  

        if len(self.classes_) != 2:
            raise ValueError(f"AdaBoost chỉ support binary. Got {len(self.classes_)} classes")

        n_samples             = X.shape[0]
        y_binary              = np.where(y == self.classes_[0], -1, 1)
        
        # Hỗ trợ sample_weight từ ngoài truyền vào (như AdaBoostV2)
        weights = np.ones(n_samples) / n_samples
        if sample_weight is not None:
            weights = weights * sample_weight
            weights = weights / np.sum(weights)

        self.estimators_        = []
        self.estimator_weights_ = []

        # TÍNH RA SỐ LƯỢNG FEATURE LÀ SỐ NGUYÊN TỪ TRƯỚC
        max_feats = int(np.sqrt(self.n_features_in_))

        for m in range(self.n_estimators):
            # TỐI ƯU 1: Giới hạn max_features='sqrt' (Đã sửa truyền vào số nguyên)
            weak_learner = self.base_estimator(   
                max_depth=1, 
                min_samples_split=1,
                max_features=max_feats, # <--- ĐÃ FIX Ở ĐÂY: Truyền biến chứa số nguyên
                random_state=self.rng.randint(0, 2**31 - 1)
            )
            weak_learner.fit(X, y, sample_weight=weights)

            # TỐI ƯU 2: Bỏ qua python loop, dùng NumPy vectorized cho tốc độ C++
            y_pred = self._fast_stump_predict(weak_learner, X)
            
            y_pred_binary = np.where(y_pred == self.classes_[0], -1, 1)

            errors     = (y_pred_binary != y_binary).astype(float)
            error_rate = np.sum(weights * errors)

            if error_rate >= 0.5:              
                break

            if error_rate == 0:
                alpha = self.learning_rate * np.log(n_samples)
            else:
                alpha = self.learning_rate * 0.5 * np.log(
                    (1 - error_rate) / (error_rate + 1e-10)
                )

            weights = weights * np.exp(-alpha * y_binary * y_pred_binary)
            weights = weights / np.sum(weights)

            self.estimators_.append(weak_learner)        
            self.estimator_weights_.append(alpha)        

        print(f" AdaBoost done: {len(self.estimators_)} weak learners")
        self._is_fitted = True
        return self

    def _check_is_fitted(self):
        if not self._is_fitted:
            raise AttributeError("AdaBoost chưa fit. Gọi fit(X, y) trước.")

    def _raw_predict(self, X):
        self._check_is_fitted()
        predictions = np.zeros(X.shape[0])
        for est, w in zip(self.estimators_, self.estimator_weights_):
            # TỐI ƯU 3: Áp dụng predict siêu tốc cho cả lúc dự đoán tập Test
            y_pred = self._fast_stump_predict(est, X)
            y_pred_binary = np.where(y_pred == self.classes_[0], -1, 1)
            predictions  += w * y_pred_binary
        return predictions

    def predict(self, X):
        raw = self._raw_predict(X)
        return np.where(raw > 0, self.classes_[1], self.classes_[0])

    def predict_proba(self, X):
        raw          = self._raw_predict(X)
        proba_class1 = 1 / (1 + np.exp(-2 * raw))
        return np.column_stack([1 - proba_class1, proba_class1])

    def decision_function(self, X):
        return self._raw_predict(X)

    def score(self, X, y):
        return np.mean(self.predict(X) == np.asarray(y))

    @property
    def feature_importances_(self):           
        self._check_is_fitted()
        importances  = np.zeros(self.n_features_in_)
        total_weight = sum(self.estimator_weights_)
        for est, w in zip(self.estimators_, self.estimator_weights_):
            importances += (w / total_weight) * est.feature_importances_
        return importances

class LogisticRegressionScratch:
    """
    Meta-Learner: Logistic Regression từ scratch 
    (Tối ưu siêu tốc với Early Stopping & Vectorized Loss)
    """
    def __init__(self, lr=0.1, n_iter=1000, tol=1e-5, random_state=42, class_weight=None):
        self.lr = lr
        self.n_iter = n_iter
        self.tol = tol # Độ lệch tối thiểu để dừng sớm (Early Stopping)
        self.random_state = random_state
        self.class_weight = class_weight
        self.rng = np.random.RandomState(random_state)

    def _sigmoid(self, z):
        return 1 / (1 + np.exp(-np.clip(z, -250, 250)))
    
    def _softmax(self, z):
        z_shifted = z - np.max(z, axis=1, keepdims=True)
        exp_z = np.exp(z_shifted)
        return exp_z / np.sum(exp_z, axis=1, keepdims=True)
    
    def fit(self, X, y):
        X = np.asarray(X, dtype=float)
        self.classes_ = np.unique(y)
        n_classes = len(self.classes_)
        n_samples, n_features = X.shape
        
        if n_classes == 2:
            y_bin = (y == self.classes_[1]).astype(float)
            self.W = self.rng.randn(n_features) * 0.01
            self.b = 0.0
            
            if self.class_weight == 'balanced':
                w_0 = n_samples / (2 * np.sum(y == self.classes_[0]))
                w_1 = n_samples / (2 * np.sum(y == self.classes_[1]))
                weights = np.where(y == self.classes_[1], w_1, w_0)
            else:
                weights = np.ones(n_samples)

            prev_loss = float('inf')
            for i in range(self.n_iter):
                z = X @ self.W + self.b
                pred = self._sigmoid(z)
                err = (pred - y_bin) * weights 
                
                # Cập nhật trọng số (Vectorized BLAS - O(1) time)
                self.W -= self.lr * (X.T @ err) / n_samples
                self.b -= self.lr * np.mean(err)

                # TỐI ƯU: Tính Loss để Early Stopping
                # Log-loss (Cross Entropy)
                loss = -np.mean(weights * (y_bin * np.log(pred + 1e-15) + (1 - y_bin) * np.log(1 - pred + 1e-15)))
                if prev_loss - loss < self.tol:
                    # print(f"    [Logistic] Early stopping tại epoch {i}")
                    break
                prev_loss = loss
        else:
            self.W = self.rng.randn(n_classes, n_features) * 0.01
            self.b = np.zeros(n_classes)
            
            for _ in range(self.n_iter):
                z = X @ self.W.T + self.b
                probs = self._softmax(z)
                
                for c in range(n_classes):
                    y_c = (y == self.classes_[c]).astype(float)
                    err = probs[:, c] - y_c
                    self.W[c] -= self.lr * (X.T @ err) / n_samples
                    self.b[c] -= self.lr * np.mean(err)
        return self
    
    def predict_proba(self, X):
        X = np.asarray(X, dtype=float)
        if hasattr(self, 'W') and self.W.ndim == 1:
            p1 = self._sigmoid(X @ self.W + self.b)
            return np.column_stack([1 - p1, p1])
        else:
            z = X @ self.W.T + self.b
            return self._softmax(z)
    
    def predict(self, X):
        return self.classes_[np.argmax(self.predict_proba(X), axis=1)]

class StackingClassifier:
    """
    Stacking Ensemble sử dụng Out-of-Fold (OOF) 
    (Đã chuyển về chạy Tuần tự để bypass lỗi kẹt GIL của Python)
    """
    def __init__(self, base_learners=None, meta_learner=None,
                 n_folds=5, use_proba=True, smote_func=None, 
                 random_state=42, n_jobs=1): 
        self.base_learners  = base_learners
        self.meta_learner   = meta_learner
        self.n_folds        = n_folds
        self.use_proba      = use_proba
        self.smote_func     = smote_func
        self.random_state   = random_state
        self.n_jobs         = n_jobs
        self.rng            = np.random.RandomState(random_state)
        self.fitted_base_learners_ = []
        self.classes_              = None
        self.n_classes_            = None

    def _make_folds(self, n_samples):
        indices = np.arange(n_samples)
        self.rng.shuffle(indices)
        fold_sizes = np.full(self.n_folds, n_samples // self.n_folds)
        fold_sizes[: n_samples % self.n_folds] += 1
        folds, current = [], 0
        for size in fold_sizes:
            val_idx   = indices[current : current + size]
            train_idx = np.concatenate([indices[:current], indices[current + size:]])
            folds.append((train_idx, val_idx))
            current  += size
        return folds

    def _get_meta_features_dim(self):
        return self.n_classes_ if self.use_proba else 1

    def _predict_one_learner(self, model, X):
        return model.predict_proba(X) if self.use_proba else model.predict(X).reshape(-1, 1).astype(float)

    def _train_fold_task(self, name, model_template, X, y, train_idx, val_idx):
        X_fold_train, y_fold_train = X[train_idx], y[train_idx]
        if self.smote_func is not None:
            X_fold_train, y_fold_train = self.smote_func(X_fold_train, y_fold_train)

        model_clone = self._clone_model(name, model_template)
        model_clone.fit(X_fold_train, y_fold_train)
        oof_preds = self._predict_one_learner(model_clone, X[val_idx])
        return val_idx, oof_preds

    def fit(self, X, y):
        X = np.asarray(X)
        y = np.asarray(y)
        self.classes_   = np.unique(y)
        self.n_classes_ = len(self.classes_)
        n_samples       = X.shape[0]
        n_learners      = len(self.base_learners)
        dim_per_learner = self._get_meta_features_dim()

        meta_train = np.zeros((n_samples, n_learners * dim_per_learner))
        folds      = self._make_folds(n_samples)

        print("=" * 55)
        print("  STACKING - Training Base Learners (OOF - Sequential)")
        print("=" * 55)

        # ── Bước 1: Tạo OOF meta-features (CHẠY TUẦN TỰ MƯỢT MÀ) ──
        for learner_idx, (name, model_template) in enumerate(self.base_learners):
            col_start = learner_idx * dim_per_learner
            col_end   = col_start + dim_per_learner
            
            print(f"  > Đang chạy {name}... ", end='')
            for fold_idx, (train_idx, val_idx) in enumerate(folds):
                _, oof_preds = self._train_fold_task(name, model_template, X, y, train_idx, val_idx)
                meta_train[val_idx, col_start:col_end] = oof_preds
                    
            print(f"✓ Hoàn tất {self.n_folds}/{self.n_folds} folds")

        # ── Bước 2: Train Base Learners trên toàn bộ dữ liệu ──
        print("\n" + "=" * 55)
        print("  STACKING - Training Base Learners (Full Data)")
        print("=" * 55)

        if self.smote_func is not None:
            X_full, y_full = self.smote_func(X, y)
        else:
            X_full, y_full = X, y

        self.fitted_base_learners_ = []
        for name, template in self.base_learners:
            print(f"  > Đang train {name} full data... ", end='')
            model_full = self._clone_model(name, template)
            model_full.fit(X_full, y_full)
            self.fitted_base_learners_.append((name, model_full))
            print("✓")

        # ── Bước 3: Train Meta-Learner ──
        print("\n" + "=" * 55)
        print("  STACKING - Training Meta-Learner")
        print("=" * 55)
        meta_X, meta_y = meta_train, y

        if self.smote_func is not None:
            meta_X, meta_y = self.smote_func(meta_train, y)
            
        if self.meta_learner is None:
            self.meta_learner = LogisticRegressionScratch(
                lr=0.1, n_iter=1000, random_state=self.random_state, class_weight='balanced'
            )
        self.meta_learner.fit(meta_X, meta_y)
        print("  Meta-Learner training completed ✓")
        print("=" * 55)
        return self

    def _clone_model(self, name, template):
        cfg = template.__dict__.copy()
        for key in ['root', 'trees', 'X_train', 'y_train', 'estimators', 'estimator_weights',
                    'fitted_base_learners_', 'classes_', 'feature_importances', 'feature_importances_',
                    'n_samples_root_', 'rng', 'oob_score_']:
            cfg.pop(key, None)

        if name == 'DecisionTree':
            return DecisionTree(**{k: v for k, v in cfg.items() if k in ['max_depth','min_samples_split','criterion','max_features','random_state']})
        elif name == 'RandomForest':
            return RandomForest(**{k: v for k, v in cfg.items() if k in ['n_estimators','max_depth','min_samples_split','max_features','oob_score','random_state']})
        elif name == 'KNN':
            return KNN(**{k: v for k, v in cfg.items() if k in ['n_neighbors','metric','weights']})
        elif name == 'AdaBoost':
            return AdaBoost(**{k: v for k, v in cfg.items() if k in ['n_estimators','learning_rate','algorithm','random_state']})
        else:
            raise ValueError(f"Unknown model name: {name}")

    def _build_meta_features(self, X):
        meta_parts = [self._predict_one_learner(model, np.asarray(X)) for _, model in self.fitted_base_learners_]
        return np.hstack(meta_parts)

    def predict(self, X): return self.meta_learner.predict(self._build_meta_features(X))
    def predict_proba(self, X): return self.meta_learner.predict_proba(self._build_meta_features(X))
    def score(self, X, y): return np.mean(self.predict(X) == np.asarray(y))
# ── HELPER FUNCTIONS & METRICS ─────────────────────────────────────────────

def SMOTE(X, y, minority_class=1, k=5, random_state=42):
    rng   = np.random.RandomState(random_state)
    X     = np.asarray(X, dtype=float)
    y     = np.asarray(y)
    X_min = X[y == minority_class]
    X_maj = X[y != minority_class]
    n_min = len(X_min)
    n_maj = len(X_maj)
    n_new = max(0, n_maj - n_min)
    if n_new == 0: return X, y
    k_actual = min(k, n_min - 1) if n_min > 1 else 1
    dists = np.linalg.norm(X_min[:, None] - X_min[None, :], axis=2)
    np.fill_diagonal(dists, np.inf)
    knn_idx = np.argsort(dists, axis=1)[:, :k_actual]
    synthetic = np.empty((n_new, X_min.shape[1]))
    for i_new in range(n_new):
        i = rng.randint(0, n_min)
        nn = knn_idx[i, rng.randint(0, k_actual)]
        gap = rng.rand()
        synthetic[i_new] = X_min[i] + gap * (X_min[nn] - X_min[i])
    return np.vstack((X, synthetic)), np.hstack((y, np.full(n_new, minority_class, dtype=int)))

def confusion_matrix_scratch(y_true, y_pred):
    b = np.bincount(y_true * 2 + y_pred, minlength=4)
    return np.array([[b[0], b[1]], [b[2], b[3]]])

def _f1_scratch(y_true, y_pred, pos_label=1):
    TP = np.sum((y_pred == pos_label) & (y_true == pos_label))
    FP = np.sum((y_pred == pos_label) & (y_true != pos_label))
    FN = np.sum((y_pred != pos_label) & (y_true == pos_label))
    eps = 1e-15
    p  = TP / (TP + FP + eps)
    r  = TP / (TP + FN + eps)
    return 2 * p * r / (p + r + eps)

def _recall_scratch(y_true, y_pred, pos_label=1):
    TP = np.sum((y_pred == pos_label) & (y_true == pos_label))
    FN = np.sum((y_pred != pos_label) & (y_true == pos_label))
    return TP / (TP + FN + 1e-10)

def _accuracy_scratch(y_true, y_pred):
    return np.mean(y_true == y_pred)

def _auc_scratch_fixed(y_true, y_proba):
    desc_idx = np.argsort(y_proba)[::-1]
    y_true_sorted = y_true[desc_idx]
    y_proba_sorted = y_proba[desc_idx]
    distinct_idx = np.where(np.diff(y_proba_sorted))[0]
    thresh_idx = np.r_[distinct_idx, y_true_sorted.size - 1]
    tps = np.cumsum(y_true_sorted)[thresh_idx]
    fps = 1 + thresh_idx - tps
    tps = np.r_[0, tps]
    fps = np.r_[0, fps]
    if tps[-1] == 0 or fps[-1] == 0: return 0.5
    tprs = tps / tps[-1]
    fprs = fps / fps[-1]
    return float(np.trapezoid(tprs, fprs))

def get_sample_weights(y):
    counts = Counter(y)
    n_samples = len(y)
    n_classes = len(counts)
    return np.array([n_samples / (n_classes * counts[val]) for val in y])

class GridSearch:
    def __init__(self, model_class, param_grid, cv=3, scoring='f1',
                 model_name='Model', ada_tree_class=None, smote_func=None,
                 use_class_weight=False, random_state=42, refit=True, verbose=False):
        self.model_class = model_class
        self.param_grid = param_grid
        self.cv = cv
        self.scoring = scoring
        self.model_name = model_name
        self.ada_tree_class = ada_tree_class
        self.smote_func = smote_func
        self.use_class_weight = use_class_weight
        self.random_state = random_state
        self.refit = refit
        self.verbose = verbose
        self.best_estimator_ = None

    @property
    def best_model_(self): return self.best_estimator_

    def predict(self, X): return self.best_estimator_.predict(X)
    def predict_proba(self, X): return self.best_estimator_.predict_proba(X)


