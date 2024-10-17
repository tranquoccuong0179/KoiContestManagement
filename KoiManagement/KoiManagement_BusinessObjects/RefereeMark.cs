namespace KoiManagement_BusinessObjects;

public partial class RefereeMark : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public string CompetitionRoundId { get; set; } = string.Empty;
    public double Point { get; set; }
    public string MarkId { get; set; } = string.Empty;
    public virtual CompetitionRound? CompetitionRound { get; set; } 
    public virtual ICollection<CriteriaPoint> CriteriaPoints { get; set; } = new List<CriteriaPoint>();
    public virtual Mark? Mark { get; set; } 
    public virtual User? User { get; set; } 
}
