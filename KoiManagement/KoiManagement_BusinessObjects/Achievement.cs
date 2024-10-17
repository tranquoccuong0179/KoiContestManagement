namespace KoiManagement_BusinessObjects;

public partial class Achievement : BaseEntity
{
    public string KoiId { get; set; } = string.Empty;
    public string ResultId { get; set; } = string.Empty;
    public string Name { get; set; } = null!;
    public virtual Koi? Koi { get; set; }
    public virtual Result? Result { get; set; } 
}
