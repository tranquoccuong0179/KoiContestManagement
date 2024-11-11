using KoiManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_DAO
{
    public class CompetitionDAO
    {
        private KoiManagementContext context;
        private static CompetitionDAO instance;
        public CompetitionDAO()
        {
            context = new KoiManagementContext();
        }
        public static CompetitionDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CompetitionDAO();
                }
                return instance;
            }
        }
        public List<Competition> GetCompetitions()
        {
            return context.Competitions.OrderByDescending(c => c.CreateAt).ToList();
        }

        public Competition? GetCompetition(string id)
        {
            return context.Competitions.SingleOrDefault(m => m.Id.Equals(id));
        }

        public bool AddCompetition(Competition competition)
        {
            bool result = false;
            Competition? existedCompetition = GetCompetition(competition.Id);
            try
            {
                if (existedCompetition == null)
                {
                    context.Competitions.Add(competition);
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
        public bool UpdateCompetition(Competition competition)
        {
            bool result = false;
            Competition? existedCompetition = GetCompetition(competition.Id);
            try
            {
                if (existedCompetition != null)
                {
                    context.Entry<Competition>(competition).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
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

        public bool DeleteCompetition(Competition competition)
        {
            bool result = false;
            Competition? existedCompetition = GetCompetition(competition.Id);
            try
            {
                if (existedCompetition != null)
                {
                    context.Competitions.Remove(existedCompetition);
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

        public Dictionary<Competition, List<Category?>> GetCompetitionsWithCategories(string? competitionId)
        {
            return context.Competitions
                .Include(c => c.CompetitionCategories)
                .ThenInclude(cc => cc.Category).Where(c => !string.IsNullOrWhiteSpace(competitionId) && c.Id == competitionId)
                .ToList()
                .ToDictionary(
                    competition => competition,
                    competition => competition.CompetitionCategories.Select(cc => cc.Category).ToList()
                );
        }
    }
}
