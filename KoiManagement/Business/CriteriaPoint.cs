namespace KoiManagement_Business;

public partial class CriteriaPoint
{
	public Guid Id { get; set; }

	public Guid CriteriaId { get; set; }

	public Guid RefereeMarkId { get; set; }

	public double Point { get; set; }

	public DateTime? CreateAt { get; set; }

	public DateTime? UpdateAt { get; set; }

	public DateTime? DeleteAt { get; set; }

	public bool Active { get; set; }

	public virtual CriteriaPoint Criteria { get; set; } = null!;

	public virtual ICollection<CriteriaPoint> InverseCriteria { get; set; } = new List<CriteriaPoint>();

	public virtual RefereeMark RefereeMark { get; set; } = null!;
}
