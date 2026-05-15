import joblib
import sys
import os

# Thêm đường dẫn để nạp models.py
sys.path.append(r"c:\Users\PC ACER\OneDrive\Desktop\AI ML Engineer\Mini1\StrokePredictBackend\StrokePrediction.API\scripts")
from models import *

path = r"c:\Users\PC ACER\OneDrive\Desktop\AI ML Engineer\Mini1\StrokePredictBackend\StrokePrediction.API\exported_models\stroke_model_full_scratch.pkl"
artifacts = joblib.load(path)

print("--- SCALING STATS ---")
print(artifacts['scaling_stats'])

print("\n--- OTHER METADATA ---")
print(f"Threshold: {artifacts.get('best_threshold', 'N/A')}")
print(f"BMI Median: {artifacts.get('bmi_median', 'N/A')}")
