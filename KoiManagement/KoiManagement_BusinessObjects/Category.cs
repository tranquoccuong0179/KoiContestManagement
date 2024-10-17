namespace KoiManagement_BusinessObjects;

public partial class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public double Size { get; set; }
    public string Variety { get; set; } = string.Empty;
    public int Age { get; set; }
    public virtual ICollection<CompetitionCategory> CompetitionCategories { get; set; } = new List<CompetitionCategory>();
}
