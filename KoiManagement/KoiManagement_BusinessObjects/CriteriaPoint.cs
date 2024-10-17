namespace KoiManagement_BusinessObjects;

public partial class CriteriaPoint : BaseEntity
{
    public string CriteriaId { get; set; } = string.Empty;
    public string RefereeMarkId { get; set; } = string.Empty;
    public double Point { get; set; }
    public virtual CriteriaPoint? Criteria { get; set; } 
    public virtual RefereeMark? RefereeMark { get; set; } 
}
