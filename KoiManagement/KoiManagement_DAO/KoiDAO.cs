using KoiManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace KoiManagement_DAO
{
    public class KoiDAO
    {
        private static KoiDAO instance;

        public static KoiDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KoiDAO();
                }
                return instance;
            }

        }

        public async Task<List<Koi>> GetAll()
        {
            using (var context = new KoiManagementContext())
            {
                return await context.Kois.Include(c => c.User).ToListAsync();
            }
        }

        public async Task<List<Koi>> GetByUserIdActive(string userId)
        {
            using (var context = new KoiManagementContext())
            {
                return await context.Kois.Include(c => c.User).Where(c => c.UserId.Equals(userId) && c.Active).ToListAsync();
            }
        }

        public async Task<List<Koi>> GetByUserId(string userId)
        {
            using (var context = new KoiManagementContext())
            {
                return await context.Kois.Include(c => c.User).Where(c => c.UserId.Equals(userId)).ToListAsync();
            }
        }

        public async Task<Koi?> GetById(string? koiId, string? userId)
        {
            using (var context = new KoiManagementContext())
            {
                IQueryable<Koi> query = context.Kois.Include(c => c.User).AsQueryable();
                if (!string.IsNullOrEmpty(koiId))
                {
                    query = query.Where(c => c.Id.Equals(koiId));
                }
                if (!string.IsNullOrEmpty(userId))
                {
                    query = query.Where(c => c.UserId.Equals(userId));

                }
                return await query.FirstOrDefaultAsync();
            }
        }


        public Koi GetKoiById(string koiId)
        {
            using (var context = new KoiManagementContext())
            {
                return context.Kois.Include(c => c.User).SingleOrDefault(c => c.Id.Equals(koiId));
            }

        }
        public async Task<bool> Create(Koi koi)
        {
            using (var context = new KoiManagementContext())
            {
                bool isSuccess = false;
                Koi? currentKoi = await GetById(koi.Id, koi.UserId);
                try
                {
                    if (currentKoi is null)
                    {
                        await context.Kois.AddAsync(koi);
                        await context.SaveChangesAsync();
                        isSuccess = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return isSuccess;
            }
        }

        public async Task<bool> Update(Koi koi)
        {
            using (var context = new KoiManagementContext())
            {
                bool isSuccess = false;
                Koi? currentKoi = await GetById(koi.Id, koi.UserId);
                try
                {
                    if (currentKoi is not null)
                    {
                        context.Entry<Koi>(koi).State = EntityState.Modified;
                        await context.SaveChangesAsync();
                        isSuccess = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return isSuccess;
            }
        }

        public async Task<bool> Delete(Koi koi)
        {
            using (var context = new KoiManagementContext())
            {
                bool isSuccess = false;
                Koi? currentKoi = await GetById(koi.Id, koi.UserId);
                try
                {
                    if (currentKoi is not null)
                    {
                        context.Entry<Koi>(koi).State = EntityState.Modified;
                        await context.SaveChangesAsync();
                        isSuccess = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return isSuccess;
            }
        }


        public async Task<KoiCompetitionVM> GetAllWithKois(string competitionRoundId)
        {
            using (var context = new KoiManagementContext())
            {
                var koiCompetition = await context.CompetitionRounds
                .Where(cr => cr.Id == competitionRoundId)
                .Select(cr => new KoiCompetitionVM()
            {
                CompetitionRoundId = cr.Id,
                KoiName = cr.Koi.Name
            })
                .SingleOrDefaultAsync();
                return koiCompetition;
            }
        }

    }
}