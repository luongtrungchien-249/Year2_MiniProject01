# Stroke Prediction — Dự đoán Nguy cơ Đột quỵ

Đây là đồ án 1 của mình, xây dựng hệ thống dự đoán nguy cơ đột quỵ cho bệnh nhân. Mô hình sử dụng Stacking Ensemble (Decision Tree, Random Forest, KNN, AdaBoost + Logistic Regression meta-learner) với xử lý mất cân bằng dữ liệu (SMOTE / Class Weight) trên dataset Stroke Prediction từ Kaggle.

> **Đồ Án 1** · Trường Đại Học Sư Phạm Kỹ Thuật Hưng Yên · Khoa Công Nghệ Thông Tin

---

## Mục Lục

- [Giới Thiệu](#giới-thiệu)
- [Kết Quả Mô Hình](#kết-quả-mô-hình)
- [Kiến Trúc Hệ Thống](#kiến-trúc-hệ-thống)
- [Cài Đặt & Khởi Động](#cài-đặt--khởi-động)
- [Hướng Dẫn Sử Dụng](#hướng-dẫn-sử-dụng)
- [API Documentation](#api-documentation)
- [Cơ Sở Dữ Liệu](#cơ-sở-dữ-liệu)
- [Dataset](#dataset)
- [Cấu Trúc Thư Mục](#cấu-trúc-thư-mục)

---

## Giới Thiệu

Đột quỵ là một trong những nguyên nhân gây tử vong và tàn tật hàng đầu thế giới. Phát hiện sớm nguy cơ là yếu tố quan trọng để can thiệp kịp thời. Mình xây dựng hệ thống này để hỗ trợ bác sĩ và nhân viên y tế dự đoán khả năng đột quỵ dựa trên các chỉ số lâm sàng của bệnh nhân:

- **Thông tin cá nhân**: tuổi, giới tính, tình trạng hôn nhân, loại công việc, nơi sinh sống.
- **Chỉ số lâm sàng**: tăng huyết áp, bệnh tim, mức đường huyết trung bình, BMI.
- **Lối sống**: tình trạng hút thuốc lá.

Lý do chọn Stacking Ensemble là vì kết hợp điểm mạnh của nhiều thuật toán khác nhau (Decision Tree xử lý categorical, KNN xử lý khoảng cách, AdaBoost tập trung ca khó) thay vì phụ thuộc vào một mô hình đơn lẻ — đặc biệt hiệu quả với dữ liệu y tế mất cân bằng nặng (chỉ ~4.9% ca đột quỵ).

---

## Kết Quả Mô Hình

| Mô hình | Accuracy | AUC-ROC | F1 Macro | Recall Stroke |
|---|---|---|---|---|
| Decision Tree | ~85% | ~0.79 | ~0.60 | ~0.72 |
| Random Forest | ~94% | ~0.85 | ~0.64 | ~0.65 |
| KNN | ~92% | ~0.82 | ~0.61 | ~0.68 |
| AdaBoost | ~93% | ~0.88 | ~0.68 | ~0.74 |
| **Stacking Ensemble** | **~95%** | **~0.91** | **~0.73** | **~0.80** |

Stacking Ensemble cải thiện so với baseline đơn lẻ: tăng AUC-ROC, tăng Recall lớp thiểu số (stroke), giảm False Negative — yếu tố quan trọng nhất trong bài toán y tế.

### Xử lý mất cân bằng dữ liệu

Dataset gốc chỉ có ~4.9% ca đột quỵ, mình thử nghiệm 3 chiến lược:

| Chiến lược | Mô tả |
|---|---|
| `SMOTE` | Sinh mẫu tổng hợp lớp thiểu số |
| `Class_weight` | Tăng trọng số lớp thiểu số trong hàm loss |
| `SMOTE_Class_weight` | Kết hợp cả hai (hiệu quả nhất) |

---

## Kiến Trúc Hệ Thống

Hệ thống gồm 4 thành phần chính:

| Thành phần | Công nghệ | Vai trò |
|---|---|---|
| Client | C# / WinForms (.NET 8) | Giao diện người dùng Desktop |
| Backend | ASP.NET Core Web API (.NET 8) | Xử lý request, ghi DB, điều phối ML |
| Kết nối ML | Ngrok Tunnel | Cho phép backend kết nối đến Jupyter/Colab qua internet |
| AI Server | Jupyter Notebook + Flask | Chạy mô hình Stacking, trả kết quả predict |
| Database | PostgreSQL (Supabase Cloud) | Lưu users, bệnh nhân, lịch sử dự đoán, audit logs |

### Kiến trúc Backend — Clean Architecture

```
StrokePredictBackend/
├── StrokePrediction.Core          # Business Logic (không phụ thuộc framework nào)
│   ├── entities/                  # PatientInput, PredictionResult, Enums
│   ├── interfaces/                # IPredictionRepository, IMLModelService
│   └── use-cases/                 # PredictStrokeUseCase, GetPredictionHistoryUseCase
│
├── StrokePrediction.Infrastructure # Kết nối DB và dịch vụ ngoài
│   ├── database/                  # AppDbContext (EF Core + Npgsql)
│   ├── repositories/              # PredictionRepository, AuditRepository
│   ├── external-api/              # PythonMLBridgeService (subprocess/HTTP)
│   └── config/                    # AppSettings, ServiceCollectionExtensions
│
└── StrokePrediction.API           # Entry Point
    ├── controllers/               # PredictionController, AuthController, StatsController
    ├── dtos/                      # PredictRequestDto, PredictResponseDto
    ├── middlewares/               # GlobalExceptionMiddleware, RequestLoggingMiddleware
    └── filters/                   # GlobalAuditFilter
```

---

## Cài Đặt & Khởi Động

### Yêu cầu

- Windows 10 / 11 (64-bit)
- .NET 8 SDK (https://dotnet.microsoft.com/download/dotnet/8.0)
- Python 3.9+ (cần có `pandas`, `numpy`, `scikit-learn`, `flask`, `pyngrok`)
- Kết nối internet (để nói chuyện với Supabase và Ngrok)

---

### Bước 1 — Khởi động AI Server trên Jupyter Notebook

> ⚠️ Phải làm bước này trước khi chạy ứng dụng Client, nếu dùng Ngrok.

Notebook sử dụng: `Research_ML (10).ipynb` — mở trong Jupyter hoặc Google Colab, chạy tuần tự từng bước.

---

#### Bước 1.1 — Cài thư viện

```bash
pip install pandas numpy scikit-learn flask pyngrok
```

Hoặc nếu chạy trên Colab:

```python
!pip install flask pyngrok -q
```

---

#### Bước 1.2 — Tải Dataset

> Dataset: [Stroke Prediction Dataset — Kaggle](https://www.kaggle.com/datasets/fedesoriano/stroke-prediction-dataset)

File gốc: `data_stroke.csv`  
Khoảng 4981 bản ghi với 11 đặc trưng đầu vào + 1 nhãn (`stroke`).

---

#### Bước 1.3 — Tiền xử lý & Feature Engineering

| Feature | Kiểu | Mô tả |
|---|---|---|
| `gender` | Categorical | Male / Female |
| `age` | Numeric | Tuổi bệnh nhân |
| `hypertension` | 0\|1 | Có tăng huyết áp |
| `heart_disease` | 0\|1 | Có bệnh tim |
| `ever_married` | Categorical | Yes / No |
| `work_type` | Categorical | Private / Self-employed / Govt_job / children / Never_worked |
| `Residence_type` | Categorical | Urban / Rural |
| `avg_glucose_level` | Numeric | Mức đường huyết trung bình |
| `bmi` | Numeric | Chỉ số khối cơ thể  |
| `smoking_status` | Categorical | formerly smoked / never smoked / smokes / Unknown |

---

#### Bước 1.4 — Train các mô hình

Notebook train và Grid Search tham số tối ưu cho từng mô hình:
- **Decision Tree** — Grid Search + max_depth, criterion, min_samples_split
- **Random Forest** — Grid Search + n_estimators, min_samples_split, max_depth, max_features
- **KNN** — Grid Search + n_neighbors, metric, weights
- **AdaBoost** — Grid Search + n_estimators, learning_rate
- **Logistic Regression** CV folds, base learners, meta-learner

Tất cả đều dùng Stratified K-Fold (k=5) để Cross-Validate, có áp dụng SMOTE trong từng fold để tránh Data Leakage.

---

#### Bước 1.5 — Lưu mô hình

```python
# Notebook tự động export sau khi train xong
import pickle, os
os.makedirs("exported_models", exist_ok=True)
pickle.dump(stacking_model, open("exported_models/stacking_model.pkl", "wb"))
```

---

#### Bước 1.6 — Xác thực Ngrok

1. Vào [https://dashboard.ngrok.com/get-started/your-authtoken](https://dashboard.ngrok.com/get-started/your-authtoken)
2. Đăng ký tài khoản miễn phí nếu chưa có
3. Copy token và dán vào notebook:

```python
from pyngrok import ngrok
ngrok.set_auth_token("your_ngrok_token_here")
```

---

#### Bước 1.7 — Khởi động Flask + Ngrok

Chạy cell Flask trong notebook, sẽ in ra URL dạng:

```
🚀 NGROK URL: https://xxxx-xxxx.ngrok-free.app
Endpoints: /predict  |  /health
```

Copy URL này để điền vào cấu hình Backend ở Bước 2.

---

#### Bước 1.8 — Test API (tùy chọn)

```python
# Test trong notebook
import requests, json

url = "https://xxxx-xxxx.ngrok-free.app/predict"
data = {
    "model_name": "stacking",
    "input": {
        "gender": "Male",
        "age": 67,
        "hypertension": 0,
        "heart_disease": 1,
        "ever_married": "Yes",
        "work_type": "Private",
        "Residence_type": "Urban",
        "avg_glucose_level": 228.69,
        "bmi": 36.6,
        "smoking_status": "formerly smoked"
    }
}
r = requests.post(url, json=data)
print(r.json())
```

**Response mẫu:**
```json
{
  "prediction": 1,
  "probability": 0.87,
  "risk_level": "High",
  "message": "Nguy cơ cao, cần kiểm tra lâm sàng ngay",
  "model_used": "stacking",
  "error": null
}
```

---

### Bước 2 — Cấu hình Backend

Mở file `StrokePredictBackend/StrokePrediction.API/appsettings.json` và cập nhật:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=...supabase.com;Port=5432;Database=postgres;Username=postgres.xxx;Password=YourPassword;SSL Mode=Require;Trust Server Certificate=true"
  },
  "AppSettings": {
    "Python": {
      "NgrokUrl": "https://xxxx-xxxx.ngrok-free.app",
      "TimeoutMs": 15000
    },
    "Models": {
      "DefaultModel": "stacking",
      "AvailableModels": ["decision_tree", "random_forest", "knn", "adaboost", "stacking"]
    }
  }
}
```

> **Lưu ý:** Nếu `NgrokUrl` để trống, Backend sẽ tự động fallback sang chạy subprocess Python local (cần có Python + model file tại `scripts/predict.py`).

---

### Bước 3 — Khởi động Backend API

```bash
cd StrokePredictBackend
dotnet run --project StrokePrediction.API
```

Backend khởi động tại `http://localhost:5000`. Swagger UI tại: `http://localhost:5000/swagger`

---

### Bước 4 — Khởi động Giao diện Desktop

```bash
cd StrokePredictionWinForms
dotnet run
```

Màn hình đăng nhập xuất hiện → Nhập tài khoản từ bảng `users` trên Supabase.

### Tài khoản mặc định

| Vai trò | Tên đăng nhập | Mật khẩu |
|---|---|---|
| Admin | `admin` | `123456` hoặc tài khoản bạn tạo trong Supabase |
| Bác sĩ | `doctor1` | Tùy cấu hình |

> Mật khẩu được lưu dạng **BCrypt hash** trong bảng `users`.

---

## Hướng Dẫn Sử Dụng

### Danh sách chức năng

| Mã UC | Tên chức năng | Phân quyền |
|---|---|---|
| UC01 | Đăng nhập | User / Admin / Doctor |
| UC02 | Kiểm tra bệnh nhân đơn lẻ | User / Admin / Doctor |
| UC03 | Xem lịch sử dự đoán | User / Admin |
| UC04 | Xem thống kê Dashboard | Admin |
| UC05 | Cấu hình Ngrok API | Admin |

### UC02 — Kiểm tra bệnh nhân đơn lẻ

Nhập thông tin bệnh nhân vào giao diện:

| Trường | Kiểu | Giá trị hợp lệ |
|---|---|---|
| `Họ tên` | string | Tùy ý |
| `Giới tính` | Dropdown | Male / Female / Other |
| `Tuổi` | Số thực | 0 – 120 |
| `Tăng huyết áp` | Dropdown | Có / Không |
| `Bệnh tim` | Dropdown | Có / Không |
| `Đã kết hôn` | Dropdown | Yes / No |
| `Loại công việc` | Dropdown | Private / Self-employed / Govt_job / children / Never_worked |
| `Nơi ở` | Dropdown | Urban / Rural |
| `Mức đường huyết` | Số thực | 50 – 300 mg/dL |
| `BMI` | Số thực | 10 – 60 |
| `Hút thuốc` | Dropdown | formerly smoked / never smoked / smokes / Unknown |

Kết quả trả về:
- 🔴 **Nguy cơ đột quỵ** — có khả năng cao bị đột quỵ, cần can thiệp lâm sàng
- 🟢 **Bình thường** — chỉ số trong ngưỡng an toàn
- Xác suất % và mức nguy cơ: Low / Medium / High / Very_High

---

## API Documentation

Base URL: `http://localhost:5000`

### Endpoints

#### Auth
| Method | Endpoint | Mô tả |
|---|---|---|
| POST | `/api/v1/auth/login` | Đăng nhập, trả về thông tin user |

#### Predictions
| Method | Endpoint | Mô tả |
|---|---|---|
| POST | `/api/v1/predictions` | Dự đoán đột quỵ cho 1 bệnh nhân |
| GET | `/api/v1/predictions` | Lấy lịch sử dự đoán (phân trang) |
| GET | `/api/v1/predictions/models` | Danh sách model có sẵn |

#### Stats
| Method | Endpoint | Mô tả |
|---|---|---|
| GET | `/api/v1/stats/dashboard` | Số liệu tổng hợp cho Dashboard |

### Ví dụ — Dự đoán đột quỵ

**Request:**
```json
POST /api/v1/predictions
{
  "fullName": "Nguyễn Văn A",
  "gender": "Male",
  "age": 67,
  "hypertension": 0,
  "heartDisease": 1,
  "everMarried": "Yes",
  "workType": "Private",
  "residenceType": "Urban",
  "avgGlucoseLevel": 228.69,
  "bmi": 36.6,
  "smokingStatus": "formerly smoked",
  "modelName": "stacking"
}
```

**Response:**
```json
{
  "prediction": 1,
  "probability": 0.87,
  "riskLevel": "High",
  "message": "Nguy cơ cao",
  "modelUsed": "stacking",
  "predictedAt": "2026-05-15T14:21:00Z"
}
```

**Kết nối ngưỡng nguy cơ:**
| Probability | RiskLevel |
|---|---|
| < 0.30 | Low |
| 0.30 – 0.50 | Medium |
| 0.50 – 0.70 | High |
| > 0.70 | Very_High |

---

## Cơ Sở Dữ Liệu

Dùng **PostgreSQL trên Supabase Cloud** — không cần cài DB local.

Schema gồm 5 bảng chính:

| Bảng | Mô tả |
|---|---|
| `users` | Tài khoản hệ thống (id, username, email, password_hash, full_name, role, is_active) |
| `ml_models` | Metadata các mô hình đã train (name, version, accuracy, auc_score, f1_score, best_params JSONB) |
| `patients` | Thông tin bệnh nhân (patient_code tự sinh, gender, age, hypertension, heart_disease...) |
| `predictions` | Kết quả dự đoán (prediction, probability, risk_level, input_snapshot JSONB) |
| `audit_logs` | Nhật ký hành động (action, entity_type, detail JSONB, ip_address) |

### Trigger tự động trong Supabase
- `patients.patient_code`: Tự sinh định dạng `PAT-XXXXX`
- `predictions.risk_level`: Tự động tính toán dựa trên `probability`

### Enum Types

```sql
user_role_enum    : admin, doctor, patient
model_name_enum   : DecisionTree, RandomForest, KNN, AdaBoost, Stacking
strategy_enum     : SMOTE, Class_weight, SMOTE_Class_weight
gender_enum       : Male, Female, Other
work_type_enum    : Private, Self_employed, Govt_job, children, Never_worked
risk_level_enum   : Low, Medium, High, Very_High
audit_action_enum : LOGIN, LOGOUT, PREDICT, VIEW_HISTORY, ...
```

---

## Dataset

**Healthcare Dataset — Stroke Prediction** (Kaggle)

> Tải tại đây: [https://www.kaggle.com/datasets/fedesoriano/stroke-prediction-dataset](https://www.kaggle.com/datasets/fedesoriano/stroke-prediction-dataset)

| Thông tin | Chi tiết |
|---|---|
| Số bản ghi | 5,110 |
| Tỉ lệ đột quỵ | ~4.9% (mất cân bằng nặng) |
| Số đặc trưng | 10 features + 1 label |
| Missing value | `bmi` có 201 giá trị null |

| Feature | Kiểu | Mô tả |
|---|---|---|
| `gender` | Categorical | Giới tính |
| `age` | Numeric | Tuổi |
| `hypertension` | Binary | Tăng huyết áp (0/1) |
| `heart_disease` | Binary | Bệnh tim (0/1) |
| `ever_married` | Categorical | Đã kết hôn |
| `work_type` | Categorical | Loại công việc |
| `Residence_type` | Categorical | Nơi sinh sống |
| `avg_glucose_level` | Numeric | Đường huyết trung bình (mg/dL) |
| `bmi` | Numeric | Chỉ số khối cơ thể |
| `smoking_status` | Categorical | Tình trạng hút thuốc |
| **`stroke`** | **Binary** | **Nhãn: 1 = đột quỵ, 0 = bình thường** |

Split: 70% Train / 15% Val / 15% Test (stratified)

---

## Cấu Trúc Thư Mục

```
Mini1/
│
├── StrokePredictBackend/              # Solution Backend C# (.NET 8)
│   ├── StrokePredictBackend.sln
│   ├── StrokePrediction.Core/         # Business Logic
│   │   ├── entities/                  # PatientInput, PredictionResult, Enums
│   │   ├── interfaces/                # IPredictionRepository, IMLModelService
│   │   └── use-cases/                 # PredictStrokeUseCase, GetHistoryUseCase
│   ├── StrokePrediction.Infrastructure/  # Infrastructure
│   │   ├── database/                  # AppDbContext (EF Core + Npgsql)
│   │   ├── repositories/              # PredictionRepository, AuditRepository
│   │   ├── external-api/              # PythonMLBridgeService (Ngrok / subprocess)
│   │   └── config/                    # AppSettings, DI Extensions
│   └── StrokePrediction.API/          # Web API
│       ├── controllers/               # PredictionController, AuthController, StatsController
│       ├── dtos/                      # Request/Response DTOs
│       ├── middlewares/               # GlobalException, RequestLogging
│       └── appsettings.json           # Cấu hình (DB, Ngrok, Models)
│
├── StrokePredictionWinForms/          # Solution Frontend WinForms (.NET 8)
│   ├── StrokePredictionWinForms.sln
│   ├── LoginForm.cs                   # Màn hình đăng nhập
│   ├── MainForm.cs                    # Giao diện chính + Sidebar Navigation
│   ├── ApiClient.cs                   # HTTP Client giao tiếp với Backend
│   ├── UI/
│   │   ├── Colors.cs                  # Bảng màu Dark Theme
│   │   └── ModernUI.cs                # Helper render UI
│   └── Views/
│       ├── DashboardView.cs           # Trang thống kê tổng quan
│       ├── SingleCheckView.cs         # Kiểm tra bệnh nhân đơn lẻ
│       ├── HistoryView.cs             # Lịch sử dự đoán
│       ├── BatchScanView.cs           # Quét hàng loạt (đang phát triển)
│       └── ConfigView.cs              # Cấu hình Ngrok URL
│
├── Research_ML (10).ipynb             # Notebook train + Flask + Ngrok
├── export_models.py                   # Script xuất model ra file .pkl
├── imbalanced_comparison.py           # So sánh chiến lược xử lý mất cân bằng
├── threshold_tuning.py                # Tối ưu threshold phân loại
└── README.md
```

---

## Tham Khảo

- Fedesoriano (2021). *Stroke Prediction Dataset.* Kaggle.
- Breiman, L. (1996). *Stacked Regressions.* Machine Learning.
- Chawla et al. (2002). *SMOTE: Synthetic Minority Over-sampling Technique.* JAIR.
- Entity Framework Core + Npgsql: https://www.npgsql.org/efcore/
- Supabase PostgreSQL: https://supabase.com/docs
- Dataset: [Kaggle — Stroke Prediction](https://www.kaggle.com/datasets/fedesoriano/stroke-prediction-dataset)

---

*Đồ Án 1 · Khoa CNTT · ĐHSPKT Hưng Yên · 2025–2026*
