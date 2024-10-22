using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Services.IService
{
    public interface IAchievementService
    {
        public List<Achievement> GetAll();
        public Achievement? GetById(string id) ;
        public bool AddAchievement(Achievement achievement);
        public bool UpdateAchievement(Achievement achievement);
        public bool DeleteAchievement(Achievement achievement);
    }
}
