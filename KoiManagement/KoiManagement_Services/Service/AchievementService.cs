using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
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
    public class AchievementService : IAchievementService
    {
        private IAchievementRepository _achievementRepository;
        public AchievementService()
        {
            _achievementRepository = new AchievementRepository();
        }
        public List<Achievement> GetAll() => _achievementRepository.GetAll();
        public Achievement? GetById(string id) => _achievementRepository.GetById(id);
        public bool AddAchievement(Achievement achievement) => _achievementRepository.AddAchievement(achievement);
        public bool UpdateAchievement(Achievement achievement) => _achievementRepository.UpdateAchievement(achievement);
        public bool DeleteAchievement(Achievement achievement) => _achievementRepository.DeleteAchievement(achievement);
    }
}
 
