using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_DAO
{
    public class AchievementDAO
    {
        private static AchievementDAO instance;
        private KoiManagementContext context;

        public AchievementDAO()
        {
            context = new KoiManagementContext();
        }
        public static AchievementDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AchievementDAO();
                return instance;
            }
        }
        public List<Achievement> GetAll()

        {
            return context.Achievements.ToList();
        }
        public Achievement? GetById(string id)
        {
            return context.Achievements.SingleOrDefault(c => c.Id.Equals(id));
        }
        public bool AddAchievement(Achievement achievement)
        {
            bool result = false;
            Achievement? existAchievement = GetById(achievement.Id);
            try
            {
                if (existAchievement == null)
                {
                    context.Achievements.Add(achievement);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }

        public bool UpdateAchievement(Achievement achievement)
        {
            bool result = false;
            Achievement? existAchievement = GetById(achievement.Id);
            try
            {
                if (existAchievement == null)
                {
                    context.Entry<Achievement>(achievement).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }

        public bool DeleteAchievement(Achievement achievement)
        {
            bool result = false;
            Achievement? existAchievement = GetById(achievement.Id);
            try
            {
                if (existAchievement == null)
                {
                    context.Achievements.Remove(achievement);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
    }
}
