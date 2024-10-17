namespace KoiManagement_BusinessObjects;

public partial class Role : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
