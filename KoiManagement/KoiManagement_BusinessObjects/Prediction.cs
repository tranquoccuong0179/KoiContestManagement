
namespace KoiManagement_BusinessObjects;

public partial class Prediction : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public string CompetitionRoundId { get; set; } = string.Empty;
    public double Point { get; set; }
    public virtual CompetitionRound? CompetitionRound { get; set; } 
    public virtual User? User { get; set; } 
}
