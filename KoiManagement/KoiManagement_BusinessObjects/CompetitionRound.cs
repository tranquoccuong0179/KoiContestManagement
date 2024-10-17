
namespace KoiManagement_BusinessObjects;

public partial class CompetitionRound : BaseEntity
{
    public string KoiId { get; set; } = string.Empty;
    public string CompetitionId { get; set; } = string.Empty;
    public string RoundId { get; set; } = string.Empty;
    public virtual Competition? Competition { get; set; } 
    public virtual Koi? Koi { get; set; }
    public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();
    public virtual ICollection<Prediction> Predictions { get; set; } = new List<Prediction>();
    public virtual ICollection<RefereeMark> RefereeMarks { get; set; } = new List<RefereeMark>();
    public virtual Round? Round { get; set; }
}
