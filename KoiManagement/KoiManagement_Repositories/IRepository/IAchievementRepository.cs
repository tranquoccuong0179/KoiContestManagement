using KoiManagement_BusinessObjects;

namespace KoiManagement_Repositories.IRepository
{
    public interface IAchievementRepository
    {
        public List<Achievement> GetAll();
        public Achievement? GetById(string id);
        public bool AddAchievement(Achievement achievement);
        public bool UpdateAchievement(Achievement achievement);
        public bool DeleteAchievement(Achievement achievement);
    }
}
