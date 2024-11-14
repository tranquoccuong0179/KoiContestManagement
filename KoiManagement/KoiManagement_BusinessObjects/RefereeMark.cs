namespace KoiManagement_BusinessObjects;

public partial class RefereeMark : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public string CompetitionRoundId { get; set; } = string.Empty;
    public double Point { get; set; }
    public virtual CompetitionRound? CompetitionRound { get; set; }
    public virtual List<CriteriaPoint> CriteriaPoints { get; set; } = new List<CriteriaPoint>();
    public virtual User? User { get; set; }
}
