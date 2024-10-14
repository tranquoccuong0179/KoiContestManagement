using KoiManagementBusiness;

namespace KoiManagement_Business;

public partial class CompetitionCategory
{
	public Guid Id { get; set; }

	public Guid CompetitionId { get; set; }

	public Guid CategoryId { get; set; }

	public DateTime? CreateAt { get; set; }

	public DateTime? UpdateAt { get; set; }

	public DateTime? DeleteAt { get; set; }

	public bool Active { get; set; }

	public virtual Category Category { get; set; } = null!;

	public virtual Competition Competition { get; set; } = null!;

	public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
