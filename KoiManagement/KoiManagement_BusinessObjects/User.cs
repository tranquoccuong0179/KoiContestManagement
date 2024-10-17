
namespace KoiManagement_BusinessObjects;

public partial class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public virtual ICollection<Koi> Kois { get; set; } = new List<Koi>();
    public virtual ICollection<Prediction> Predictions { get; set; } = new List<Prediction>();
    public virtual ICollection<RefereeMark> RefereeMarks { get; set; } = new List<RefereeMark>();
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
