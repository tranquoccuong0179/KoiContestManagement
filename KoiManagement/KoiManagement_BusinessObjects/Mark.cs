namespace KoiManagement_BusinessObjects;

public partial class Mark : BaseEntity
{
    public string CompetitionRoudId { get; set; } = string.Empty;
    public double Point { get; set; }
    public virtual CompetitionRound? CompetitionRound { get; set; }
    public virtual ICollection<RefereeMark> RefereeMarks { get; set; } = new List<RefereeMark>();
}
