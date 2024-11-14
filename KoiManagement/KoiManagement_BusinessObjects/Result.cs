namespace KoiManagement_BusinessObjects;

public partial class Result : BaseEntity
{
    public string RegistrationId { get; set; } = string.Empty;
    //public string KoiId { get; set; } = string.Empty;
    public double FinalMark { get; set; }
    public int Ranking { get; set; }
    //public virtual Koi? Koi { get; set; }
    public virtual Registration? Registration { get; set; }
}
