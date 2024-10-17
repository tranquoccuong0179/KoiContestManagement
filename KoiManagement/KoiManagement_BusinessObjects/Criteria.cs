namespace KoiManagement_BusinessObjects;

public partial class Criteria : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public double Percent { get; set; }
}
