using KoiManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;

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
            return context.CompetitionRounds.ToList();
        }
        public CompetitionRound? GetById(string id)
        {
            return context.CompetitionRounds.SingleOrDefault(c => c.Id.Equals(id));
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
                if (existComperitionRound == null)
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
        public Dictionary<(CompetitionCategory Competition, Round Round), List<Koi>> GetCompetitionRoundWithKoi(string? competitionId, string? roundId)
        {

            var competitionRounds = context.CompetitionRounds
       .Where(cr => (string.IsNullOrWhiteSpace(competitionId) || cr.CompetitionCategory.Id == competitionId) &&
                    (string.IsNullOrWhiteSpace(roundId) || cr.Round.Id == roundId))
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


        public bool CheckIfAnotherRoundHasStarted(string competitionId)
        {
            return context.CompetitionRounds
                .Any(cr => cr.CompetitionCategoryId == competitionId && cr.RoundId != "77e3e82e971f48bbb682f17a6ddcaa32");
        }

        public async Task<List<CompetitionRound>> GetTopCompetitionRoundsByAverageScoreAsync(string competitionId, string roundId, int top)
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

        public async Task AddNewCompetitionRoundBasedOnTopScoresAsync(string competitionId, string roundId, int top)
        {
           
            var topCompetitionRounds = await GetTopCompetitionRoundsByAverageScoreAsync(competitionId, roundId, top);

            string newRoundId;
            switch (top)
            {
                case 8:
                    newRoundId = "7ad10d9064fd411184bd57c1a6a94ba8";
                    break;
                case 4:
                    newRoundId = "ab6d43fba87b45f3a28a5d76e03c0fc7";
                    break;
                case 2:
                    newRoundId = "032d64ec6f8642c09e22a6f63193e76e";
                    break;
                default:
                    throw new ArgumentException("Invalid 'top' value. Only 8, 4, or 2 are allowed.");
            }

            
            foreach (var topRecord in topCompetitionRounds)
            {
                var newCompetitionRound = new CompetitionRound
                {
                    KoiId = topRecord.KoiId,                 
                    CompetitionCategoryId = topRecord.CompetitionCategoryId, 
                    RoundId = newRoundId                    
                };

         
                context.CompetitionRounds.Add(newCompetitionRound);
            }

            await context.SaveChangesAsync();
        }


    }
}
