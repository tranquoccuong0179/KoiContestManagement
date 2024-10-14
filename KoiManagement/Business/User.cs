using KoiManagementBusiness;

namespace KoiManagement_Business;

public partial class User
{
	public Guid Id { get; set; }

	public string Username { get; set; } = null!;

	public string Pasword { get; set; } = null!;

	public string FullName { get; set; } = null!;

	public bool Active { get; set; }

	public DateTime? CreateAt { get; set; }

	public DateTime? UpdateAt { get; set; }

	public DateTime? DeleteAt { get; set; }

	public virtual ICollection<Koi> Kois { get; set; } = new List<Koi>();

	public virtual ICollection<Prediction> Predictions { get; set; } = new List<Prediction>();

	public virtual ICollection<RefereeMark> RefereeMarks { get; set; } = new List<RefereeMark>();

	public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
