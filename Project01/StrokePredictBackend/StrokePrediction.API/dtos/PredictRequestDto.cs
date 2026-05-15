using System.ComponentModel.DataAnnotations;

namespace StrokePrediction.API.dtos;

/// <summary>
/// DTO đầu vào từ Frontend — validation tích hợp
/// </summary>
public class PredictRequestDto
{
    public string? FullName { get; set; }

    [Required(ErrorMessage = "Gender là bắt buộc")]
    [RegularExpression("^(Male|Female|Other)$", ErrorMessage = "Gender phải là: Male, Female, Other")]
    public string Gender { get; set; } = string.Empty;

    [Required]
    [Range(0, 120, ErrorMessage = "Age phải từ 0 đến 120")]
    public double Age { get; set; }

    [Required]
    [Range(0, 1, ErrorMessage = "Hypertension phải là 0 hoặc 1")]
    public int Hypertension { get; set; }

    [Required]
    [Range(0, 1, ErrorMessage = "HeartDisease phải là 0 hoặc 1")]
    public int HeartDisease { get; set; }

    [Required]
    [RegularExpression("^(Yes|No)$", ErrorMessage = "EverMarried phải là: Yes hoặc No")]
    public string EverMarried { get; set; } = string.Empty;

    [Required]
    [RegularExpression("^(Private|Self_employed|Govt_job|Children|Never_worked|children)$",
        ErrorMessage = "WorkType không hợp lệ")]
    public string WorkType { get; set; } = string.Empty;

    [Required]
    [RegularExpression("^(Urban|Rural)$", ErrorMessage = "ResidenceType phải là: Urban hoặc Rural")]
    public string ResidenceType { get; set; } = string.Empty;

    [Required]
    [Range(50, 300, ErrorMessage = "AvgGlucoseLevel phải từ 50 đến 300")]
    public double AvgGlucoseLevel { get; set; }

    [Range(0.1, 1000, ErrorMessage = "BMI phải lớn hơn 0")]
    public double? Bmi { get; set; }    // Nullable — sẽ fill bằng median

    [Required]
    [RegularExpression("^(Formerly_smoked|Never_smoked|Smokes|Unknown|formerly_smoked|never_smoked|smokes)$",
        ErrorMessage = "SmokingStatus không hợp lệ")]
    public string SmokingStatus { get; set; } = string.Empty;

    /// <summary>Model muốn sử dụng</summary>
    public string ModelName { get; set; } = "stacking";
}
