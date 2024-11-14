namespace KoiManagement_BusinessObjects;

public partial class Round : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int OrderNumber { get; set; }
    public virtual ICollection<CompetitionRound> CompetitionRounds { get; set; } = new List<CompetitionRound>();
}
