using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Services.IService
{
    public interface ICompetitionCategoryService
    {
        List<CompetitionCategory> GetCompetitionCategories();
        CompetitionCategory? GetCompetitionCategory(string id);
        bool AddCompetitionCategory(CompetitionCategory competitionCategory);
        bool UpdateCompetitionCategory(CompetitionCategory competitionCategory);
        bool DeleteCompetitionCategory(CompetitionCategory competitionCategory);
    }
}
