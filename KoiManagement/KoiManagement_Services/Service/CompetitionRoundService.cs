using KoiManagement_Repositories.IRepository;
using KoiManagement_Repositories.Repository;
using KoiManagement_Services.IService;
using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiManagement_DAO;

namespace KoiManagement_Services.Service
{
    public class CompetitionRoundService : ICompetitionRoundService
    {
        private ICompetitionRoundRepository _competitionRoundRepository;
        public CompetitionRoundService()
        {
            _competitionRoundRepository = new CompetitionRoundRepository();
        }
        public List<CompetitionRound> GetAll() => _competitionRoundRepository.GetAll();

        public CompetitionRound? GetById(string id) => _competitionRoundRepository.GetById(id);

        public bool AddCompetitionRound(CompetitionRound competitionRound) => _competitionRoundRepository.AddCompetitionRound(competitionRound);

        public bool UpdateCompetitionRound(CompetitionRound competitionRound) => _competitionRoundRepository.UpdateCompetitionRound(competitionRound);

        public bool DeleteCompetitionRound(CompetitionRound competitionRound) => _competitionRoundRepository.DeleteCompetitionRound(competitionRound);
    }
}
