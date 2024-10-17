
namespace KoiManagement_BusinessObjects;

public partial class CompetitionCategory : BaseEntity
{
    public string CompetitionId { get; set; } = string.Empty;
    public string CategoryId { get; set; } = string.Empty;
    public virtual Category? Category { get; set; } 
    public virtual Competition? Competition { get; set; } 
    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
