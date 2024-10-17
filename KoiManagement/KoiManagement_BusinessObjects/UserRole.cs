namespace KoiManagement_BusinessObjects;

public partial class UserRole
{
    public string UserId { get; set; } = string.Empty;
    public string RoleId { get; set; } = string.Empty;
    public virtual Role? Role { get; set; }
    public virtual User? User { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeleteAt { get; set; }
}
