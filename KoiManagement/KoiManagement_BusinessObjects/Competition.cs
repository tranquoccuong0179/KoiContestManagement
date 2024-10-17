
namespace KoiManagement_BusinessObjects;

public partial class Competition : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int MaxApplication { get; set; }
    public string Status { get; set; } = string.Empty;
    public virtual ICollection<CompetitionCategory> CompetitionCategories { get; set; } = new List<CompetitionCategory>();
    public virtual ICollection<CompetitionRound> CompetitionRounds { get; set; } = new List<CompetitionRound>();
}
