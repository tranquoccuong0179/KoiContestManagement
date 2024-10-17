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
    public class CompetitionRepository : ICompetitionRepository
    {
        public bool AddCompetition(Competition competition) => CompetitionDAO.Instance.AddCompetition(competition);
        public bool DeleteCompetition(Competition competition) => CompetitionDAO.Instance.DeleteCompetition(competition);
        public Competition? GetCompetition(string id) => CompetitionDAO.Instance.GetCompetition(id);
        public List<Competition> GetCompetitions() => CompetitionDAO.Instance.GetCompetitions();
        public bool UpdateCompetition(Competition competition) => CompetitionDAO.Instance.UpdateCompetition(competition);
    }
}
