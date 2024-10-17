namespace KoiManagement_BusinessObjects;

public partial class CriteriaPoint
{
    public string CriteriaId { get; set; } = string.Empty;
    public string RefereeMarkId { get; set; } = string.Empty;
    public double Point { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeleteAt { get; set; }
    public virtual Criteria? Criteria { get; set; } 
    public virtual RefereeMark? RefereeMark { get; set; } 
}
