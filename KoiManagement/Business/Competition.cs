using KoiManagement_Business;

namespace KoiManagementBusiness;

public partial class Competition
{
	public Guid Id { get; set; }

	public string Name { get; set; } = null!;

	public string Location { get; set; } = null!;

	public DateTime StartDate { get; set; }

	public DateTime EndDate { get; set; }

	public int MaxApplication { get; set; }

	public string Status { get; set; } = null!;

	public DateTime? CreateAt { get; set; }

	public DateTime? UpdateAt { get; set; }

	public DateTime? DeleteAt { get; set; }

	public bool Active { get; set; }

	public virtual ICollection<CompetitionCategory> CompetitionCategories { get; set; } = new List<CompetitionCategory>();

	public virtual ICollection<CompetitionRound> CompetitionRounds { get; set; } = new List<CompetitionRound>();
}
