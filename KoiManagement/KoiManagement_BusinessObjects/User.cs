
using Microsoft.AspNetCore.Identity;

namespace KoiManagement_BusinessObjects;

public partial class User : IdentityUser
{
	public string FullName { get; set; } = string.Empty;
	public bool Active { get; set; } = true;
	public DateTime? CreateAt { get; set; }
	public DateTime? UpdateAt { get; set; }
	public DateTime? DeleteAt { get; set; }
	public virtual ICollection<Koi> Kois { get; set; } = new List<Koi>();
	public virtual ICollection<Prediction> Predictions { get; set; } = new List<Prediction>();
	public virtual ICollection<RefereeMark> RefereeMarks { get; set; } = new List<RefereeMark>();
}
