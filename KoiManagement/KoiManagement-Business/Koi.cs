namespace KoiManagement_Business;

public partial class Koi
{
	public Guid Id { get; set; }

	public string Name { get; set; } = null!;

	public string Type { get; set; } = null!;

	public string Variety { get; set; } = null!;

	public DateTime DateOfBirth { get; set; }

	public double Size { get; set; }

	public string Image { get; set; } = null!;

	public Guid UserId { get; set; }

	public DateTime? CreateAt { get; set; }

	public DateTime? UpdateAt { get; set; }

	public DateTime? DeleteAt { get; set; }

	public bool Active { get; set; }

	public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

	public virtual ICollection<CompetitionRound> CompetitionRounds { get; set; } = new List<CompetitionRound>();

	public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();

	public virtual ICollection<Result> Results { get; set; } = new List<Result>();

	public virtual User User { get; set; } = null!;
}
