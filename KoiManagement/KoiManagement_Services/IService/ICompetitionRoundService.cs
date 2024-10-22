using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Services.IService
{
    public interface ICompetitionRoundService
    {
        public List<CompetitionRound> GetAll();

        public CompetitionRound? GetById(string id);

        public bool AddCompetitionRound(CompetitionRound competitionRound);

        public bool UpdateCompetitionRound(CompetitionRound competitionRound);

        public bool DeleteCompetitionRound(CompetitionRound competitionRound);
    }
}
