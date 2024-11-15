using KoiManagement_BusinessObjects;
using KoiManagement_DAO.DTO;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_DAO
{
    public class RefereeMarkDAO
    {
        private KoiManagementContext context;
        private static RefereeMarkDAO instance;

        public RefereeMarkDAO()
        {
            context = new KoiManagementContext();
        }

        public static RefereeMarkDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RefereeMarkDAO();
                }
                return instance;
            }
        }

        public List<RefereeMark> GetRefereeMarks()
        {
            return context.RefereeMarks.Include(r => r.CompetitionRound).ThenInclude(r => r.Koi).Include(k => k.User).Where(r => r.Active == true).ToList();
        }

        public RefereeMark? GetExistRefereeMark(string competitionId, string userId)
        {
            var refereeMark = context.RefereeMarks.SingleOrDefault(r => r.CompetitionRoundId.Equals(competitionId) && r.UserId.Equals(userId));
            return refereeMark;
        }

        public RefereeMark GetRefereeMark(string id)
        {

            var entity = context.RefereeMarks.Include(r => r.CompetitionRound).ThenInclude(r => r.Koi).Include(k => k.User).SingleOrDefault(m => m.Id.Equals(id) && m.Active == true);
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public bool AddRefereeMark(RefereeMark refereeMarkNew)
        {
            bool result = false;
            refereeMarkNew.Id = Guid.NewGuid().ToString();
            refereeMarkNew.Active = true;
            try
            {

                context.RefereeMarks.Add(refereeMarkNew);
                context.SaveChanges();
                result = true;

            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }
        public bool UpdateRefereeMark(RefereeMark refereeMarkUpdate)
        {
            bool result = false;
            RefereeMark refereeMark = GetRefereeMark(refereeMarkUpdate.Id);
            try
            {
                if (refereeMark != null)
                {
                    context.Entry<RefereeMark>(refereeMarkUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public bool DeleteRefereeMark(RefereeMark refereeMarkDelete)
        {
            bool result = false;
            RefereeMark? existedRefereeMark = GetRefereeMark(refereeMarkDelete.Id);
            try
            {
                if (existedRefereeMark != null)
                {
                    existedRefereeMark.Active = false;
                    context.Entry<RefereeMark>(existedRefereeMark).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public List<CompetitionRoundScore> GetTopCompetitionRoundsByAverageScore(
    List<CompetitionRoundInfoDTO> competitionRoundInfoList, int top)
        {
  
            var competitionRoundIds = competitionRoundInfoList.Select(dto => dto.CompetitionRoundId).ToList();

            var topCompetitionRounds = context.RefereeMarks
                .Where(rm => competitionRoundIds.Contains(rm.CompetitionRoundId))
                .GroupBy(rm => rm.CompetitionRoundId)
                .Select(group => new
                {
                    CompetitionRoundId = group.Key,
                    AveragePoint = group.Average(rm => rm.Point)
                })
                .OrderByDescending(cr => cr.AveragePoint)
                .Take(top)
                .ToList(); 

            var topCompetitionRoundDTOs = topCompetitionRounds
                .Join(competitionRoundInfoList,
                      top => top.CompetitionRoundId,
                      info => info.CompetitionRoundId,
                      (top, info) => new CompetitionRoundScore
                      {
                          CompetitionRoundId = info.CompetitionRoundId,
                          KoiId = info.KoiId,
                          KoiName = info.KoiName,
                          OwnerName = info.OwnerName,
                          AveragePoint = top.AveragePoint
                      })
                .ToList();

            return topCompetitionRoundDTOs;
        }

        //    public async Task<List<CompetitionRoundScore>> GetTopCompetitionRoundsByAverageScore(
        //List<CompetitionRoundInfoDTO> competitionRoundInfoList, int top)
        //    {

        //        var competitionRoundIds = competitionRoundInfoList.Select(dto => dto.CompetitionRoundId).ToList();


        //        var topCompetitionRounds = await context.RefereeMarks
        //            .Where(rm => competitionRoundIds.Contains(rm.CompetitionRoundId))
        //            .GroupBy(rm => rm.CompetitionRoundId)
        //            .Select(group => new
        //            {
        //                CompetitionRoundId = group.Key,
        //                AveragePoint = group.Average(rm => rm.Point)
        //            })
        //            .OrderByDescending(cr => cr.AveragePoint)
        //            .Take(top)
        //            .ToListAsync();


        //        var topCompetitionRoundDTOs = topCompetitionRounds
        //            .Join(competitionRoundInfoList,
        //                  top => top.CompetitionRoundId,
        //                  info => info.CompetitionRoundId,
        //                  (top, info) => new CompetitionRoundScore
        //                  {
        //                      CompetitionRoundId = info.CompetitionRoundId,
        //                      KoiId = info.KoiId,
        //                      KoiName = info.KoiName,
        //                      OwnerName = info.OwnerName,
        //                      AveragePoint = top.AveragePoint
        //                  })
        //            .ToList();

        //        return topCompetitionRoundDTOs;
        //    }


    }
}

