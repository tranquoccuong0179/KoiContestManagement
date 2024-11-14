using KoiManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;

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

        public bool AddRound(Round round)
        {
            bool result = false;
            Round? existedRound = GetRound(round.Id);
            try
            {
                if (existedRound == null)
                {
                    if (context.Rounds.Any(r => r.Name.Equals(round.Name) || r.OrderNumber == round.OrderNumber)) 
                    {
                        return false;
                    }
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
            Round? existingRound = GetRound(round.Id);
            try
            {
                if (existingRound != null)
                {
                    bool nameExists = context.Rounds.Any(r => r.Name == round.Name && r.Id != round.Id);
                    bool orderNumberExists = context.Rounds.Any(r => r.OrderNumber == round.OrderNumber && r.Id != round.Id);

                    if (nameExists || orderNumberExists)
                    {
                        return false;
                    }
                    context.Entry(existingRound).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    context.Entry(round).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                // Log the exception (implement logging as needed)
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
        public Round? GetFirstRound()
        {
            return context.Rounds.OrderBy(r => r.OrderNumber).FirstOrDefault();
        }

        public Round? GetNextRound(int currentRoundNumber)
        {
            return  context.Rounds.Where(r => r.OrderNumber > currentRoundNumber).OrderBy(r => r.OrderNumber).FirstOrDefault();
        }
    }
}
