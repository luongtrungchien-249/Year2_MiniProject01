namespace StrokePrediction.Core.entities;

public class MlModelInfo
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Threshold { get; set; }
    public bool IsActive { get; set; }
}
