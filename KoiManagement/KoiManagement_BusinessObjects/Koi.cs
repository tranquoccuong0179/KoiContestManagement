namespace KoiManagement_BusinessObjects
{
    public partial class Koi : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Variety { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public double Size { get; set; }
        public string Image { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
        public virtual ICollection<CompetitionRound> CompetitionRounds { get; set; } = new List<CompetitionRound>();
        public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
        //public virtual ICollection<Result> Results { get; set; } = new List<Result>();
        public virtual User? User { get; set; }
    }
}
