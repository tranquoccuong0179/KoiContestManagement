using KoiManagement_BusinessObjects;

namespace KoiManagement_DAO
{
    public class RoundDAO
    {
        private KoiManagementContext context;
        private static RoundDAO instance;
        public RoundDAO()
        {
            context = new KoiManagementContext();
        }
        public static RoundDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoundDAO();
                }
                return instance;
            }
        }
        public List<Round> GetRounds()
        {
            return context.Rounds.OrderByDescending(c => c.CreateAt).ToList();
        }

        public Round? GetRound(string id)
        {
            return context.Rounds.SingleOrDefault(m => m.Id.Equals(id));
        }

        public Round? GetRoundByName(string name)
        {
            return context.Rounds.SingleOrDefault(m => m.Name.Equals(name));
        }

        public bool AddRound(Round round)
        {
            bool result = false;
            Round? existedRound = GetRound(round.Id);
            try
            {
                if (existedRound == null)
                {
                    context.Rounds.Add(round);
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
        public bool UpdateRound(Round round)
        {
            bool result = false;
            Round? existedRound = GetRound(round.Id);
            try
            {
                if (existedRound != null)
                {
                    context.Entry<Round>(round).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
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

        public bool DeleteRound(Round round)
        {
            bool result = false;
            Round? existedRound = GetRound(round.Id);
            try
            {
                if (existedRound != null)
                {
                    context.Rounds.Remove(existedRound);
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
