namespace KoiManagement_BusinessObjects;

public partial class Registration : BaseEntity
{
    public string KoiId { get; set; } = string.Empty;
    public string CompetitionCategoryId { get; set; } = string.Empty;
    public bool IsCheckIn { get; set; }
    public DateTime? CheckInTime { get; set; }
    public virtual CompetitionCategory? CompetitionCategory { get; set; } 
    public virtual Koi? Koi { get; set; }
    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
