-- ══════════════════════════════════════════════════════════════
-- STROKE PREDICTION SYSTEM — PostgreSQL Schema (Production)
-- Dự án: Mini Project Backend - AI/ML Engineer
-- Updated: 2026-05-01
-- ══════════════════════════════════════════════════════════════

-- ── Reset (chạy khi cần tạo lại từ đầu) ─────────────────────
DROP TABLE IF EXISTS audit_logs        CASCADE;
DROP TABLE IF EXISTS predictions       CASCADE;
DROP TABLE IF EXISTS patients          CASCADE;
DROP TABLE IF EXISTS ml_models         CASCADE;
DROP TABLE IF EXISTS users             CASCADE;

DROP TYPE IF EXISTS user_role_enum     CASCADE;
DROP TYPE IF EXISTS gender_enum        CASCADE;
DROP TYPE IF EXISTS married_enum       CASCADE;
DROP TYPE IF EXISTS work_type_enum     CASCADE;
DROP TYPE IF EXISTS residence_enum     CASCADE;
DROP TYPE IF EXISTS smoking_enum       CASCADE;
DROP TYPE IF EXISTS strategy_enum      CASCADE;
DROP TYPE IF EXISTS model_name_enum    CASCADE;
DROP TYPE IF EXISTS risk_level_enum    CASCADE;
DROP TYPE IF EXISTS audit_action_enum  CASCADE;

-- ── ENUM Types ───────────────────────────────────────────────
CREATE TYPE user_role_enum    AS ENUM ('admin', 'doctor', 'patient');
CREATE TYPE gender_enum       AS ENUM ('Male', 'Female', 'Other');
CREATE TYPE married_enum      AS ENUM ('Yes', 'No');
CREATE TYPE work_type_enum    AS ENUM ('Private', 'Self_employed', 'Govt_job', 'children', 'Never_worked');
CREATE TYPE residence_enum    AS ENUM ('Urban', 'Rural');
CREATE TYPE smoking_enum      AS ENUM ('formerly_smoked', 'never_smoked', 'smokes', 'Unknown');
CREATE TYPE strategy_enum     AS ENUM ('SMOTE', 'Class_weight', 'SMOTE_Class_weight');
CREATE TYPE model_name_enum   AS ENUM ('DecisionTree', 'RandomForest', 'KNN', 'AdaBoost', 'Stacking');
CREATE TYPE risk_level_enum   AS ENUM ('Low', 'Medium', 'High', 'Very_High');
CREATE TYPE audit_action_enum AS ENUM ('LOGIN', 'LOGOUT', 'PREDICT', 'VIEW_HISTORY',
                                       'CREATE_PATIENT', 'UPDATE_PATIENT', 'DELETE_PATIENT',
                                       'SWITCH_MODEL', 'EXPORT_DATA');


-- ══════════════════════════════════════════════════════════════
-- 1. USERS — Tài khoản hệ thống
-- ══════════════════════════════════════════════════════════════
CREATE TABLE users (
    id            SERIAL          PRIMARY KEY,
    username      VARCHAR(50)     UNIQUE NOT NULL,
    email         VARCHAR(100)    UNIQUE NOT NULL,
    password_hash VARCHAR(255)    NOT NULL,
    full_name     VARCHAR(100),
    role          user_role_enum  NOT NULL DEFAULT 'patient',
    is_active     BOOLEAN         NOT NULL DEFAULT TRUE,
    last_login_at TIMESTAMP,
    created_at    TIMESTAMP       NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at    TIMESTAMP       NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX idx_users_email    ON users(email);
CREATE INDEX idx_users_username ON users(username);
CREATE INDEX idx_users_role     ON users(role);


-- ══════════════════════════════════════════════════════════════
-- 2. ML_MODELS — Thông tin các model đã train
-- ══════════════════════════════════════════════════════════════
CREATE TABLE ml_models (
    id                  SERIAL          PRIMARY KEY,
    name                model_name_enum NOT NULL,
    version             VARCHAR(20)     NOT NULL DEFAULT '1.0',
    imbalance_strategy  strategy_enum   NOT NULL,

    -- Hyperparameters tốt nhất từ GridSearch
    best_params         JSONB,
    -- VD: {"max_depth": 5, "criterion": "gini", "min_samples_split": 2}

    -- Metrics trên tập Test
    accuracy            DECIMAL(6,4)    CHECK (accuracy    BETWEEN 0 AND 1),
    auc_score           DECIMAL(6,4)    CHECK (auc_score   BETWEEN 0 AND 1),
    f1_score            DECIMAL(6,4)    CHECK (f1_score    BETWEEN 0 AND 1),
    recall_score        DECIMAL(6,4)    CHECK (recall_score    BETWEEN 0 AND 1),
    precision_score     DECIMAL(6,4)    CHECK (precision_score BETWEEN 0 AND 1),
    specificity         DECIMAL(6,4)    CHECK (specificity BETWEEN 0 AND 1),

    -- Confusion Matrix
    confusion_matrix    JSONB,
    -- VD: {"TP": 25, "TN": 680, "FP": 20, "FN": 5}

    -- Threshold đang dùng (mặc định 0.5, có thể tune)
    threshold           DECIMAL(4,2)    NOT NULL DEFAULT 0.50
                        CHECK (threshold BETWEEN 0.01 AND 0.99),

    -- File model
    model_file_path     VARCHAR(500),
    -- VD: "exported_models/stacking_model.pkl"

    -- Metadata AI chuyên sâu
    feature_names       JSONB,          -- Danh sách tên các cột input
    feature_importances JSONB,          -- Trọng số quan trọng của các đặc trưng
    training_dataset_hash VARCHAR(64),  -- Hash của tập dữ liệu dùng để train

    training_samples    INTEGER,        -- Số mẫu train
    training_duration   DECIMAL(10,2),  -- Giây
    is_active           BOOLEAN         NOT NULL DEFAULT FALSE,
    -- Chỉ 1 model is_active=TRUE tại một thời điểm

    trained_at          TIMESTAMP       NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_at          TIMESTAMP       NOT NULL DEFAULT CURRENT_TIMESTAMP,

    UNIQUE (name, imbalance_strategy, version)
);

CREATE INDEX idx_models_active   ON ml_models(is_active) WHERE is_active = TRUE;
CREATE INDEX idx_models_name     ON ml_models(name);
CREATE INDEX idx_models_strategy ON ml_models(imbalance_strategy);

-- Trigger: đảm bảo chỉ 1 model is_active tại một thời điểm
CREATE OR REPLACE FUNCTION enforce_single_active_model()
RETURNS TRIGGER AS $$
BEGIN
    IF NEW.is_active = TRUE THEN
        UPDATE ml_models SET is_active = FALSE
        WHERE id != NEW.id AND is_active = TRUE;
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_single_active_model
    BEFORE INSERT OR UPDATE ON ml_models
    FOR EACH ROW
    WHEN (NEW.is_active = TRUE)
    EXECUTE FUNCTION enforce_single_active_model();


-- ══════════════════════════════════════════════════════════════
-- 3. PATIENTS — Thông tin bệnh nhân (Input Features của Model)
-- ══════════════════════════════════════════════════════════════

-- Sequence riêng để tạo mã PAT-00001, PAT-00002, ...
CREATE SEQUENCE patient_code_seq START 1 INCREMENT 1;

CREATE TABLE patients (
    id                  SERIAL          PRIMARY KEY,
    patient_code        VARCHAR(12)     UNIQUE NOT NULL,
    -- Mã đọc được: PAT-00001, PAT-00042, ...
    -- Tự sinh bởi trigger bên dưới, KHÔNG cần truyền vào khi INSERT

    user_id             INTEGER         REFERENCES users(id) ON DELETE SET NULL,
    -- Doctor nào quản lý bệnh nhân này (NULL nếu tự đăng ký)

    -- ── Thông tin cá nhân ────────────────────────────────────
    full_name           VARCHAR(100),   -- Tên bệnh nhân (optional)
    phone               VARCHAR(20),    -- Số điện thoại (optional)

    -- ── 10 Input Features (giống dataset gốc) ──────────────
    gender              gender_enum     NOT NULL,
    age                 DECIMAL(5,2)    NOT NULL CHECK (age >= 0 AND age <= 120),
    hypertension        SMALLINT        NOT NULL DEFAULT 0 CHECK (hypertension  IN (0, 1)),
    heart_disease       SMALLINT        NOT NULL DEFAULT 0 CHECK (heart_disease IN (0, 1)),
    ever_married        married_enum    NOT NULL,
    work_type           work_type_enum  NOT NULL,
    residence_type      residence_enum  NOT NULL,
    avg_glucose_level   DECIMAL(8,2)    NOT NULL CHECK (avg_glucose_level > 0),
    bmi                 DECIMAL(5,2)    CHECK (bmi > 0 AND bmi <= 100),
    -- BMI có thể NULL → backend sẽ fill bằng median của train
    smoking_status      smoking_enum    NOT NULL,

    -- ── Metadata ────────────────────────────────────────────
    notes               TEXT,           -- Ghi chú thêm của bác sĩ
    created_at          TIMESTAMP       NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at          TIMESTAMP       NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX idx_patients_code     ON patients(patient_code);
CREATE INDEX idx_patients_user_id  ON patients(user_id);
CREATE INDEX idx_patients_age      ON patients(age);
CREATE INDEX idx_patients_created  ON patients(created_at DESC);
CREATE INDEX idx_patients_phone    ON patients(phone) WHERE phone IS NOT NULL;

-- Trigger: Tự sinh patient_code = 'PAT-' + 5 chữ số (PAT-00001)
CREATE OR REPLACE FUNCTION generate_patient_code()
RETURNS TRIGGER AS $$
BEGIN
    NEW.patient_code := 'PAT-' || LPAD(nextval('patient_code_seq')::TEXT, 5, '0');
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_generate_patient_code
    BEFORE INSERT ON patients
    FOR EACH ROW
    WHEN (NEW.patient_code IS NULL)
    EXECUTE FUNCTION generate_patient_code();


-- ══════════════════════════════════════════════════════════════
-- 4. PREDICTIONS — Kết quả dự đoán (Bảng quan trọng nhất)
-- ══════════════════════════════════════════════════════════════
CREATE TABLE predictions (
    id              SERIAL          PRIMARY KEY,
    patient_id      INTEGER         NOT NULL REFERENCES patients(id)  ON DELETE CASCADE,
    model_id        INTEGER         NOT NULL REFERENCES ml_models(id) ON DELETE RESTRICT,
    user_id         INTEGER         REFERENCES users(id) ON DELETE SET NULL,
    -- Ai thực hiện dự đoán (doctor/patient tự predict)

    -- ── Kết quả từ Model ────────────────────────────────────
    prediction      SMALLINT        NOT NULL CHECK (prediction IN (0, 1)),
    -- 0 = Không đột quỵ | 1 = Có nguy cơ đột quỵ

    probability     DECIMAL(6,4)    NOT NULL CHECK (probability BETWEEN 0 AND 1),
    -- Xác suất model trả về (predict_proba)

    threshold_used  DECIMAL(4,2)    NOT NULL DEFAULT 0.50,
    -- Threshold đã dùng khi quyết định prediction

    risk_level      risk_level_enum NOT NULL,
    -- Tự tính từ probability khi INSERT (xem trigger bên dưới)

    -- ── Snapshot Input lúc predict (quan trọng để audit) ────
    input_snapshot  JSONB           NOT NULL,
    -- Lưu nguyên giá trị input đã được xử lý (sau scaling)
    -- VD: {"age": 0.72, "bmi": 0.45, "glucose": 0.89, ...}

    -- ── Giải thích mô hình (Explainability) ──────────────────
    explainability_data JSONB,
    -- Lưu top đặc trưng ảnh hưởng (SHAP/LIME)

    created_at      TIMESTAMP       NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX idx_pred_patient   ON predictions(patient_id);
CREATE INDEX idx_pred_model     ON predictions(model_id);
CREATE INDEX idx_pred_user      ON predictions(user_id);
CREATE INDEX idx_pred_risk      ON predictions(risk_level);
CREATE INDEX idx_pred_created   ON predictions(created_at DESC);

-- Trigger: tự tính risk_level từ probability khi INSERT
CREATE OR REPLACE FUNCTION calc_risk_level()
RETURNS TRIGGER AS $$
BEGIN
    NEW.risk_level := CASE
        WHEN NEW.probability < 0.30 THEN 'Low'::risk_level_enum
        WHEN NEW.probability < 0.60 THEN 'Medium'::risk_level_enum
        WHEN NEW.probability < 0.80 THEN 'High'::risk_level_enum
        ELSE 'Very_High'::risk_level_enum
    END;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_calc_risk_level
    BEFORE INSERT OR UPDATE OF probability ON predictions
    FOR EACH ROW EXECUTE FUNCTION calc_risk_level();


-- ══════════════════════════════════════════════════════════════
-- 5. BATCH_SCANS — Theo dõi xử lý hàng loạt (CSV Import)
-- ══════════════════════════════════════════════════════════════
CREATE TABLE batch_scans (
    id              SERIAL          PRIMARY KEY,
    user_id         INTEGER         REFERENCES users(id) ON DELETE SET NULL,
    file_name       VARCHAR(255)    NOT NULL,
    total_records   INTEGER         NOT NULL DEFAULT 0,
    stroke_detected INTEGER         NOT NULL DEFAULT 0,
    processing_time DECIMAL(10,2),  -- Giây
    status          VARCHAR(20)     NOT NULL DEFAULT 'PENDING', -- 'PENDING', 'PROCESSING', 'COMPLETED', 'FAILED'
    error_message   TEXT,
    created_at      TIMESTAMP       NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX idx_batch_user    ON batch_scans(user_id);
CREATE INDEX idx_batch_status  ON batch_scans(status);
CREATE INDEX idx_batch_created ON batch_scans(created_at DESC);


-- ══════════════════════════════════════════════════════════════
-- 6. AUDIT_LOGS — Ghi lại mọi thao tác (Bảo mật & Tuân thủ)
-- ══════════════════════════════════════════════════════════════
CREATE TABLE audit_logs (
    id          SERIAL            PRIMARY KEY,
    user_id     INTEGER           REFERENCES users(id) ON DELETE SET NULL,
    action      audit_action_enum NOT NULL,
    entity_type VARCHAR(50),      -- 'prediction' | 'patient' | 'model'
    entity_id   INTEGER,          -- ID của record liên quan
    detail      JSONB,            -- Chi tiết thêm
    ip_address  VARCHAR(45),      -- IP của client
    created_at  TIMESTAMP         NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX idx_audit_user    ON audit_logs(user_id);
CREATE INDEX idx_audit_action  ON audit_logs(action);
CREATE INDEX idx_audit_created ON audit_logs(created_at DESC);


-- ══════════════════════════════════════════════════════════════
-- TRIGGERS: Auto update updated_at
-- ══════════════════════════════════════════════════════════════
CREATE OR REPLACE FUNCTION auto_updated_at()
RETURNS TRIGGER AS $$
BEGIN
    NEW.updated_at = CURRENT_TIMESTAMP;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_users_updated_at
    BEFORE UPDATE ON users
    FOR EACH ROW EXECUTE FUNCTION auto_updated_at();

CREATE TRIGGER trg_patients_updated_at
    BEFORE UPDATE ON patients
    FOR EACH ROW EXECUTE FUNCTION auto_updated_at();


-- ══════════════════════════════════════════════════════════════
-- VIEWS — Query nhanh cho Frontend/API
-- ══════════════════════════════════════════════════════════════

-- View: Model đang active
CREATE VIEW v_active_model AS
SELECT id, name, version, imbalance_strategy, threshold,
       accuracy, auc_score, f1_score, recall_score, precision_score,
       model_file_path
FROM ml_models
WHERE is_active = TRUE
LIMIT 1;

-- View: Lịch sử dự đoán của từng bệnh nhân (cho Frontend)
CREATE VIEW v_patient_prediction_history AS
SELECT
    p.id              AS patient_id,
    p.gender, p.age, p.bmi, p.avg_glucose_level,
    pr.id             AS prediction_id,
    pr.prediction,
    pr.probability,
    pr.risk_level,
    pr.threshold_used,
    m.name            AS model_name,
    m.imbalance_strategy,
    u.full_name       AS doctor_name,
    pr.created_at     AS predicted_at
FROM predictions pr
JOIN patients  p ON pr.patient_id = p.id
JOIN ml_models m ON pr.model_id   = m.id
LEFT JOIN users u ON pr.user_id   = u.id
ORDER BY pr.created_at DESC;

-- View: Thống kê risk theo ngày (cho Dashboard)
CREATE VIEW v_daily_risk_stats AS
SELECT
    DATE(created_at)           AS predict_date,
    risk_level,
    COUNT(*)                   AS total,
    ROUND(AVG(probability), 4) AS avg_probability
FROM predictions
GROUP BY DATE(created_at), risk_level
ORDER BY predict_date DESC, risk_level;

-- View: So sánh hiệu suất các model
CREATE VIEW v_model_comparison AS
SELECT
    name, version, imbalance_strategy,
    accuracy, auc_score, f1_score, recall_score, precision_score,
    threshold, is_active,
    trained_at
FROM ml_models
ORDER BY auc_score DESC NULLS LAST;


-- ══════════════════════════════════════════════════════════════
-- SEED DATA — Dữ liệu mẫu ban đầu
-- ══════════════════════════════════════════════════════════════

-- Admin mặc định (đổi password_hash trong thực tế!)
INSERT INTO users (username, email, password_hash, full_name, role)
VALUES ('admin', 'admin@strokepredict.com',
        '123456', 'System Admin', 'admin');

-- Doctor mẫu
INSERT INTO users (username, email, password_hash, full_name, role)
VALUES ('dr_nguyen', 'nguyen@hospital.com',
        '123456', 'BS. Nguyễn Văn A', 'doctor');

-- Model Stacking (tốt nhất) là active
INSERT INTO ml_models (name, version, imbalance_strategy, best_params,
                        accuracy, auc_score, f1_score, recall_score, precision_score,
                        threshold, is_active, model_file_path)
VALUES (
    'Stacking', '1.0', 'SMOTE',
    '{"n_folds": 5, "use_proba": true, "meta_learner": "LogisticRegression"}',
    0.9200, 0.8800, 0.4000, 0.6000, 0.3000,
    0.50, TRUE,
    'exported_models/stacking_model.pkl'
);

-- Model RandomForest (backup)
INSERT INTO ml_models (name, version, imbalance_strategy, best_params,
                        accuracy, auc_score, f1_score, recall_score, precision_score,
                        threshold, is_active, model_file_path)
VALUES (
    'RandomForest', '1.0', 'SMOTE',
    '{"n_estimators": 100, "max_depth": 10, "max_features": "sqrt"}',
    0.9000, 0.8500, 0.3500, 0.5500, 0.2500,
    0.50, FALSE,
    'exported_models/random_forest_model.pkl'
);


-- ══════════════════════════════════════════════════════════════
-- VÍ DỤ: FLOW HOÀN CHỈNH — Nhập Patient Mới → Predict → Lưu
-- ══════════════════════════════════════════════════════════════

/*
-- ── Bước 1: Frontend gửi form, Backend INSERT patient ──────────
-- patient_code = NULL → trigger tự sinh 'PAT-00001'
INSERT INTO patients
    (user_id, full_name, phone,
     gender, age, hypertension, heart_disease,
     ever_married, work_type, residence_type,
     avg_glucose_level, bmi, smoking_status)
VALUES
    (2, 'Nguyễn Văn B', '0901234567',
     'Male', 67, 1, 1,
     'Yes', 'Private', 'Urban',
     228.69, 36.6, 'formerly_smoked')
RETURNING id, patient_code, created_at;
-- Kết quả: id=1, patient_code='PAT-00001', created_at='2026-05-01 ...' 
--  Không cần biết trước ID, PostgreSQL tự sinh!


-- ── Bước 2: Backend chạy ML model → INSERT kết quả ────────────
-- risk_level = NULL → trigger tự tính từ probability
INSERT INTO predictions
    (patient_id, model_id, user_id,
     prediction, probability, threshold_used,
     input_snapshot)
VALUES (
    1,          -- patient_id vừa lấy từ RETURNING ở trên
    1,          -- model_id = Stacking (is_active=TRUE)
    2,          -- user_id = doctor đang đăng nhập
    1,          -- prediction: 1 = có nguy cơ đột quỵ
    0.7243,     -- probability từ model.predict_proba()
    0.50,       -- threshold đang dùng
    '{"age": 0.7234, "bmi": 0.4521, "avg_glucose_level": 0.8932,
      "hypertension": 1, "heart_disease": 1, "gender_Male": 1,
      "ever_married_Yes": 1, "work_type_Private": 1}'::JSONB
)
RETURNING id, risk_level, created_at;
-- Kết quả: id=1, risk_level='High' (trigger tự tính!), created_at='...'


-- ── Bước 3: Xem lại kết quả vừa lưu ───────────────────────────
SELECT
    p.patient_code,         -- PAT-00001
    p.full_name,
    p.age, p.gender,
    pr.prediction,          -- 1
    pr.probability,         -- 0.7243
    pr.risk_level,          -- High
    m.name AS model_name,   -- Stacking
    pr.created_at
FROM predictions pr
JOIN patients  p ON pr.patient_id = p.id
JOIN ml_models m ON pr.model_id   = m.id
WHERE p.patient_code = 'PAT-00001';
*/
