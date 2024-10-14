namespace KoiManagement_Business;

public partial class Round
{
	public Guid Id { get; set; }

	public string Name { get; set; } = null!;

	public DateTime? CreateAt { get; set; }

	public DateTime? UpdateAt { get; set; }

	public DateTime? DeleteAt { get; set; }

	public bool Active { get; set; }

	public virtual ICollection<CompetitionRound> CompetitionRounds { get; set; } = new List<CompetitionRound>();
}
