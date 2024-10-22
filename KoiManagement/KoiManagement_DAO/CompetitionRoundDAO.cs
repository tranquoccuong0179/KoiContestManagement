using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if(instance == null)
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
            return context.CompetitionRounds.SingleOrDefault(c =>c.Id.Equals(id));
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
    }
}
