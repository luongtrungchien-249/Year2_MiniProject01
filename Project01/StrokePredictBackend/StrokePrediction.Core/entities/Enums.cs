namespace StrokePrediction.Core.entities
{
    public enum UserRole { admin, doctor, patient }
    public enum ModelName { DecisionTree, RandomForest, KNN, AdaBoost, Stacking }
    public enum Strategy { SMOTE, Class_weight, SMOTE_Class_weight }
    public enum Gender { Male, Female, Other }
    public enum Married { Yes, No }
    public enum WorkType { Private, Self_employed, Govt_job, children, Never_worked }
    public enum Residence { Urban, Rural }
    public enum Smoking { formerly_smoked, never_smoked, smokes, Unknown }
    public enum RiskLevel { Low, Medium, High, Very_High }
    public enum AuditAction
    {
        LOGIN, LOGOUT, PREDICT, VIEW_HISTORY,
        CREATE_PATIENT, UPDATE_PATIENT, DELETE_PATIENT,
        SWITCH_MODEL, EXPORT_DATA
    }
}
