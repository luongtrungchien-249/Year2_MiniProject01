import os
import json
import joblib
import numpy as np
import pandas as pd
import warnings
from flask import Flask, request, jsonify
from models import * # Import các class StackingClassifier, etc.

# Tắt các cảnh báo phiền phức
warnings.filterwarnings('ignore')

app = Flask(__name__)

# Khởi tạo hàm giả để lừa thư viện Joblib trong quá trình load file .pkl
def SMOTE(*args, **kwargs):
    pass

# Đường dẫn tới file model
EXPORT_DIR = os.path.join(os.path.dirname(__file__), '..', 'exported_models')
MODEL_PATH = os.path.join(EXPORT_DIR, 'stroke_model_full_scratch.pkl')

_cache = None

def load_artifacts():
    global _cache
    if _cache is None:
        if not os.path.exists(MODEL_PATH):
            return None
        _cache = joblib.load(MODEL_PATH)
    return _cache

def preprocess(input_data: dict, artifacts: dict) -> np.ndarray:
    df = pd.DataFrame([input_data])
    
    # 1. Điền khuyết BMI
    if 'bmi' not in df.columns or pd.isna(df['bmi'].values[0]) or df['bmi'].values[0] == '':
        df['bmi'] = artifacts['bmi_median']
        
    # 2. Xử lý Outlier
    for col, bounds in artifacts['outlier_report'].items():
        if col in df.columns:
            df[col] = np.clip(df[col], bounds['lower'], bounds['upper'])
            
    # 3. Min-Max Scaling
    for col, stats in artifacts['scaling_stats'].items():
        if col in df.columns:
            col_min = stats['min']
            col_max = stats['max']
            denom = col_max - col_min
            df[col] = (df[col] - col_min) / denom if denom != 0 else 0.0
            
    # 4. Chuẩn hóa chuỗi (đổi khoảng trắng thành gạch dưới để khớp feature_cols lúc train)
    for col in df.select_dtypes(include=['object']).columns:
        df[col] = df[col].str.replace(' ', '_')

    # 5. Mã hóa One-Hot
    df_encoded = pd.get_dummies(df)
    
    # 6. Đồng bộ hóa feature_cols
    for col in artifacts['feature_cols']:
        if col not in df_encoded.columns:
            df_encoded[col] = 0
            
    df_final = df_encoded[artifacts['feature_cols']]
    return df_final.values.astype(float)

def get_risk_level(prob: float) -> str:
    if prob < 0.3: return "Thấp"
    elif prob < 0.6: return "Trung bình"
    elif prob < 0.8: return "Cao"
    return "Rất cao"

@app.route('/health', methods=['GET'])
def health():
    artifacts = load_artifacts()
    if artifacts:
        return jsonify({"status": "ready", "model": "stacking_scratch"}), 200
    return jsonify({"status": "error", "message": "Model not found"}), 500

@app.route('/predict', methods=['POST'])
def predict():
    try:
        payload = request.get_json()
        if not payload:
            return jsonify({"error": "No JSON payload"}), 400
            
        # Payload từ C# có dạng: { "model_name": "...", "input": { ... } }
        input_data = payload.get('input')
        if not input_data:
            return jsonify({"error": "Missing 'input' data"}), 422

        artifacts = load_artifacts()
        if not artifacts:
            return jsonify({"error": "Model file not loaded"}), 500

        model = artifacts['model']
        best_thresh = artifacts['best_threshold']
        
        X = preprocess(input_data, artifacts)
        proba_matrix = model.predict_proba(X)
        probability = float(proba_matrix[0, 1])
        
        prediction = 1 if probability >= best_thresh else 0

        return jsonify({
            "prediction" : prediction,
            "probability": round(probability, 6),
            "risk_level" : get_risk_level(probability),
            "message"    : "Có nguy cơ đột quỵ!" if prediction == 1 else "Không có nguy cơ đột quỵ.",
            "model_used" : "stroke_model_full_scratch",
            "error"      : None
        })

    except Exception as e:
        return jsonify({"error": str(e)}), 500

if __name__ == '__main__':
    # Chạy trên port 5000 để khớp với các script Ngrok mặc định
    print("🚀 Stroke Prediction AI Server is starting...")
    app.run(host='0.0.0.0', port=5000, debug=False)
