using KoiManagement_BusinessObjects;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Repositories.Repository;
using KoiManagement_Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Services.Service
{
    public class CompetitionService : ICompetitionService
    {
        private ICompetitionRepository _competitionRepository;
        public CompetitionService()
        {
            _competitionRepository = new CompetitionRepository();
        }
        public List<Competition> GetCompetitions() => _competitionRepository.GetCompetitions();
        public Competition? GetCompetition(string id) => _competitionRepository.GetCompetition(id);
        public bool AddCompetition(Competition competition) => _competitionRepository.AddCompetition(competition);
        public bool UpdateCompetition(Competition competition) => _competitionRepository.UpdateCompetition(competition);
        public bool DeleteCompetition(Competition competition) => _competitionRepository.DeleteCompetition(competition);
    }
}
