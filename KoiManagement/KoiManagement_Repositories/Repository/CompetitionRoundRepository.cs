using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Repositories.Repository
{
    public class CompetitionRoundRepository : ICompetitionRoundRepository
    {
        public List<CompetitionRound> GetAll() => CompetitionRoundDAO.Instance.GetAll();
   
        public CompetitionRound? GetById(string id) => CompetitionRoundDAO.Instance.GetById(id);
   
        public bool AddCompetitionRound(CompetitionRound competitionRound) => CompetitionRoundDAO.Instance.AddCompetitionRound(competitionRound);

        public bool UpdateCompetitionRound(CompetitionRound competitionRound) => CompetitionRoundDAO.Instance.UpdateCompetitionRound(competitionRound);

        public bool DeleteCompetitionRound(CompetitionRound competitionRound) => CompetitionRoundDAO.Instance.DeleteCompetitionRound(competitionRound);

    }
}
