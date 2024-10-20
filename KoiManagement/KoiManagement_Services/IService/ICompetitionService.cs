using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Services.IService
{
    public interface ICompetitionService
    {
        List<Competition> GetCompetitions();
        Competition? GetCompetition(string id);
        bool AddCompetition(Competition competition);
        bool UpdateCompetition(Competition competition);
        bool DeleteCompetition(Competition competition);
    }
}
