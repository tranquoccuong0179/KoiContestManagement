using KoiManagement_BusinessObjects;
using KoiManagement_DAO.DTO;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace KoiManagement_DAO
{
    public class CompetitionRoundDAO
    {
        private static CompetitionRoundDAO instance;
        private KoiManagementContext context;

        public CompetitionRoundDAO()
        {
            context = new KoiManagementContext();
        }
        public static CompetitionRoundDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CompetitionRoundDAO();
                return instance;
            }
        }
        public List<CompetitionRound> GetAll()
        {
            return context.CompetitionRounds.Include(c => c.CompetitionCategory).ThenInclude(c => c.Category).Include(c => c.Koi).Include(c => c.Round).ToList();
        }
        public CompetitionRound? GetById(string id)
        {
            return context.CompetitionRounds.Include(c => c.CompetitionCategory).Include(c => c.Koi).Include(c => c.Round).SingleOrDefault(c => c.Id.Equals(id));
        }
        public bool AddCompetitionRound(CompetitionRound competitionRound)
        {
            bool result = false;
            CompetitionRound? existComperitionRound = GetById(competitionRound.Id);
            try
            {
                if (existComperitionRound == null)
                {
                    context.CompetitionRounds.Add(competitionRound);
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

        public string GetCompetitionRoundId(string koiId, string roundId, string competitionCategoryId)
        {
            var competitionRound = context.CompetitionRounds
            .FirstOrDefault(cr =>
                    cr.Koi.Id == koiId &&                
            cr.Round.Id == roundId &&
            cr.CompetitionCategory.Id == competitionCategoryId
                );

            return competitionRound?.Id;
        }

        public bool UpdateCompetitionRound(CompetitionRound competitionRound)
        {
            bool result = false;
            CompetitionRound? existComperitionRound = GetById(competitionRound.Id);
            try
            {
                if (existComperitionRound == null)
                {
                    context.Entry<CompetitionRound>(competitionRound).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public bool DeleteCompetitionRound(CompetitionRound competitionRound)
        {
            bool result = false;
            CompetitionRound? existComperitionRound = GetById(competitionRound.Id);
            try
            {
                if (existComperitionRound != null)
                {
                    context.CompetitionRounds.Remove(competitionRound);
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
        public Dictionary<(CompetitionCategory CompetitionCategory, Round Round), List<Koi>> GetCompetitionRoundWithKoi(string competitionId, string roundId)
        {

            var competitionRounds = context.CompetitionRounds
       .Where(cr => (string.IsNullOrWhiteSpace(competitionId) || cr.CompetitionCategory.Id == competitionId) &&
                    (string.IsNullOrWhiteSpace(roundId) || cr.Round.Id == roundId)).Include(cr => cr.CompetitionCategory)
            .ThenInclude(cc => cc.Competition)
        .Include(cr => cr.CompetitionCategory)
            .ThenInclude(cc => cc.Category)
       .Select(cr => new
       {
           cr.CompetitionCategory,
           cr.Round,
           cr.Koi
       })
       .AsEnumerable()
       .GroupBy(cr => new { cr.CompetitionCategory, cr.Round })
       .ToDictionary(
           g => (g.Key.CompetitionCategory, g.Key.Round),
           g => g.Select(cr => cr.Koi).ToList()
       );
            return competitionRounds;
        }


        public bool CheckIfAnotherRoundHasStarted(string competitionId, string id)
        {
            return context.CompetitionRounds
                .Any(cr => cr.CompetitionCategoryId == competitionId && cr.RoundId == id);
        }

        public async Task<List<CompetitionRound>> GetTopCompetitionRoundsByAverageScore(string competitionId, string roundId, int top)
        {
            var topCompetitionRounds = await context.RefereeMarks
                .Where(rm => rm.CompetitionRound.CompetitionCategoryId == competitionId && rm.CompetitionRound.RoundId == roundId)
                .GroupBy(rm => rm.CompetitionRoundId)
                .Select(group => new
                {
                    CompetitionRoundId = group.Key,
                    AverageScore = group.Average(rm => rm.Point)
                })
                .OrderByDescending(cr => cr.AverageScore)
                .Take(top)
                .ToListAsync();


            var topRounds = await context.CompetitionRounds
                .Where(cr => topCompetitionRounds.Select(t => t.CompetitionRoundId).Contains(cr.Id))
                .ToListAsync();

            return topRounds;
        }
        public List<CompetitionRoundInfoDTO> GetListIDByCompetitionCategoryIdNRoundId(string competitionCategoryId, string roundId) 
        {
            var competitionRoundInfoList = context.CompetitionRounds
             .Where(cr => cr.CompetitionCategoryId == competitionCategoryId && cr.RoundId == roundId).Include(cr => cr.Koi).ThenInclude(cr => cr.User)
             .Select(cr => new CompetitionRoundInfoDTO
             {
                 CompetitionRoundId = cr.Id,
                 KoiId = cr.KoiId,
                 KoiName = cr.Koi.Name,         
                 OwnerName = cr.Koi.User.FullName 
             })
             .ToList();

            return competitionRoundInfoList;
        }

        public async Task<bool> AddNewCompetitionRoundBasedOnTopScoresAsync(string competitionId, string roundId, int top)
        {
            bool result = false;

            var topCompetitionRounds = await GetTopCompetitionRoundsByAverageScore(competitionId, roundId, top);
            try
            {
                foreach (var topRecord in topCompetitionRounds)
                {
                  
                    var newCompetitionRound = new CompetitionRound
                    {
                        KoiId = topRecord.KoiId,                
                        CompetitionCategoryId = topRecord.CompetitionCategoryId,
                        RoundId = roundId
                    };

                    context.CompetitionRounds.Add(newCompetitionRound);
                }

                await context.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                // Log the error
               
            }
            return result;
        }


    }
}
