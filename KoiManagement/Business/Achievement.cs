namespace KoiManagement_Business;

public partial class Achievement
{
	public Guid Id { get; set; }

	public Guid KoiId { get; set; }

	public Guid ResultId { get; set; }

	public string Name { get; set; } = null!;

	public DateTime? CreateAt { get; set; }

	public DateTime? UpdateAt { get; set; }

	public DateTime? DeleteAt { get; set; }

	public bool Active { get; set; }

	public virtual Koi Koi { get; set; } = null!;

	public virtual Result Result { get; set; } = null!;
}
