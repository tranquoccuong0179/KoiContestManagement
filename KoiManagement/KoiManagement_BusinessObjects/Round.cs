namespace KoiManagement_BusinessObjects;

public partial class Round : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<CompetitionRound> CompetitionRounds { get; set; } = new List<CompetitionRound>();
}
