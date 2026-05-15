import sys
import json
import joblib
import pandas as pd
import numpy as np
import os
import warnings

# Thêm đường dẫn để load được file models.py
CURRENT_DIR = os.path.dirname(os.path.abspath(__file__))
if CURRENT_DIR not in sys.path:
    sys.path.append(CURRENT_DIR)

from models import *

# ── HACK: Inject custom classes into __main__ for joblib/pickle compatibility
import __main__
__main__.GridSearch = GridSearch
__main__.SMOTE = SMOTE
__main__.DecisionTree = DecisionTree
__main__.AdaBoost = AdaBoost
__main__.RandomForest = RandomForest
__main__.KNN = KNN
__main__.LogisticRegressionScratch = LogisticRegressionScratch
__main__.StackingClassifier = StackingClassifier

warnings.filterwarnings('ignore')

"""
Python Bridge Script for Local Prediction (Bundled Version)
"""

# Cấu hình đường dẫn
CURRENT_DIR = os.path.dirname(os.path.abspath(__file__))
MODEL_PATH = os.path.join(CURRENT_DIR, '..', 'exported_models', 'stroke_model_full_scratch.pkl')

def load_artifacts():
    if not os.path.exists(MODEL_PATH):
        raise FileNotFoundError(f"Không tìm thấy file: {MODEL_PATH}")
    
    # Mở rương bảo bối (Dictionary)
    artifacts = joblib.load(MODEL_PATH)
    return artifacts

def preprocess(payload, artifacts):
    # Chuẩn hóa dữ liệu từ C# (đảm bảo khớp với format model yêu cầu)
    mapping = {
        "formerly_smoked": "formerly smoked",
        "never_smoked": "never smoked",
        "Self_employed": "Self-employed"
    }
    
    clean_payload = {}
    # Danh sách các key cần viết hoa/thường đặc biệt để khớp với model
    special_keys = {
        'residence_type': 'Residence_type'
    }

    for k, v in payload.items():
        low_k = k.lower().strip()
        # Lấy tên key chuẩn (ví dụ: residence_type -> Residence_type)
        final_k = special_keys.get(low_k, low_k)
        
        if isinstance(v, str):
            clean_payload[final_k] = mapping.get(v, v)
        else:
            clean_payload[final_k] = v

    df_input = pd.DataFrame([clean_payload])
    feature_cols = artifacts['feature_cols']
    stats = artifacts['scaling_stats']
    
    # 1. One-hot Encoding
    df_encoded = pd.get_dummies(df_input)
    
    # 2. Đồng bộ cột
    for col in feature_cols:
        if col not in df_encoded.columns:
            df_encoded[col] = 0
            
    # 3. Scaling (Sử dụng stats từ trong rương)
    X = df_encoded[feature_cols].copy()
    numeric_cols = ['age', 'avg_glucose_level', 'bmi']
    for col in numeric_cols:
        if col in stats:
            s = stats[col]
            denom = s['max'] - s['min']
            X[col] = (X[col] - s['min']) / denom if denom > 0 else 0
            
    return X.values

def get_risk_level(prob):
    if prob < 0.30: return "Low"
    if prob < 0.60: return "Medium"
    return "High"

def get_advice(prob):
    if prob < 0.30:
        return "Sức khỏe tốt. Hãy duy trì chế độ sinh hoạt và tập luyện hiện tại."
    if prob < 0.60:
        return "Nguy cơ trung bình. Bạn nên điều chỉnh chế độ ăn uống, giảm muối và đường. Nên đi khám kiểm tra sức khỏe định kỳ."
    return "CẢNH BÁO NGUY CƠ CAO: Bạn cần đến ngay cơ sở y tế để thực hiện tầm soát đột quỵ chuyên sâu và kiểm tra huyết áp, tim mạch."

def main():
    try:
        # Nhận đường dẫn file từ tham số dòng lệnh
        if len(sys.argv) > 1:
            file_path = sys.argv[1]
            with open(file_path, 'r', encoding='utf-8') as f:
                line = f.read()
        else:
            line = sys.stdin.read()

        if not line: return
        
        # Remove BOM and whitespace safely
        clean_line = line.strip().lstrip('\ufeff')
        if not clean_line: return

        try:
            data = json.loads(clean_line)
            payload = data.get('input', data)
        except Exception as json_e:
            err_msg = f"JSON Parse Error: {str(json_e)}. Raw line repr: {repr(line)}"
            result = {"success": False, "error": err_msg, "prediction": -1}
            print(json.dumps(result))
            return

        
        # Mở rương và dự đoán
        artifacts = load_artifacts()
        model = artifacts['model']
        
        X = preprocess(payload, artifacts)
        
        prob = float(model.predict_proba(X)[0][1])
        
        # Ngưỡng mới theo yêu cầu: 0.6
        threshold = data.get('threshold')
        if threshold is None or threshold <= 0:
            threshold = 0.6
            
        label = 1 if prob >= threshold else 0
        risk = get_risk_level(prob)
        
        result = {
            "success": True,
            "prediction": label,
            "probability": round(prob, 4),
            "risk_level": risk,
            "message": get_advice(prob)
        }
    except Exception as e:
        result = {
            "success": False,
            "error": str(e),
            "prediction": -1
        }
    
    print(json.dumps(result))

if __name__ == "__main__":
    main()
