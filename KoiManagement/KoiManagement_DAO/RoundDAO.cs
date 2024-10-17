using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return context.Rounds.ToList();
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
