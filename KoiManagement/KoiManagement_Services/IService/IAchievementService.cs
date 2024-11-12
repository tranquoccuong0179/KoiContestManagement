using KoiManagement_BusinessObjects;

namespace KoiManagement_Services.IService
{
    public interface IAchievementService
    {
        public List<Achievement> GetAll();
        public Achievement? GetById(string id);
        public bool AddAchievement(Achievement achievement);
        public bool UpdateAchievement(Achievement achievement);
        public bool DeleteAchievement(Achievement achievement);
    }
}
