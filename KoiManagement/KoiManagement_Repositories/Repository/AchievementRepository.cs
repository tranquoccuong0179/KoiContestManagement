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
    public class AchievementRepository : IAchievementRepository
    {
        public List<Achievement> GetAll() => AchievementDAO.Instance.GetAll();
        public Achievement? GetById(string id) => AchievementDAO.Instance.GetById(id);
        public bool AddAchievement(Achievement achievement) => AchievementDAO.Instance.AddAchievement(achievement);
        public bool UpdateAchievement(Achievement achievement) => AchievementDAO.Instance.UpdateAchievement(achievement);   
        public bool DeleteAchievement(Achievement achievement) => AchievementDAO.Instance.DeleteAchievement(achievement);   
    }
}
