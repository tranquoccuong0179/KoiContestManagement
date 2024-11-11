using KoiManagement_BusinessObjects;

namespace KoiManagement_Repositories.IRepository
{
    public interface ICompetitionRoundRepository
    {
        public List<CompetitionRound> GetAll();

        public CompetitionRound? GetById(string id);

        public bool AddCompetitionRound(CompetitionRound competitionRound);

        public bool UpdateCompetitionRound(CompetitionRound competitionRound);

        public bool DeleteCompetitionRound(CompetitionRound competitionRound);
    }
}
