using KoiManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_DAO
{
    public class RegistrationDAO
    {
        private KoiManagementContext context;
        private static RegistrationDAO instance;

        public static RegistrationDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RegistrationDAO();
                }
                return instance;
            }
        }

        public RegistrationDAO()
        {
            context = new KoiManagementContext();
        }

        public List<Registration> GetRegistrations(string userId)
        {
            return context.Registrations.Include(x => x.Koi).Include(x => x.CompetitionCategory).ThenInclude(x => x.Category).Where(x=>x.Active==true && x.Koi.UserId == userId).ToList();
        }

        public List<Registration> GetRegistrationsAll()
        {
            return context.Registrations.Include(x => x.Koi).Include(x => x.CompetitionCategory).ThenInclude(x => x.Category).ToList();
        }

        public async Task<Registration> GetRegistration(string id)
        {
            var entity = await context.Registrations.SingleOrDefaultAsync(m => m.Id.Equals(id));
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public string GetUserIdByKoiId(string koiId)
        {
            var koi = context.Kois.SingleOrDefault(m => m.Id.Equals(koiId));
            return koi.UserId;
        }

        public async Task<bool> AddRegistration(Registration registrationE)
        {
            bool result = false;
            Registration newRegistrationE = await GetRegistration(registrationE.Id);
            try
            {
                if (newRegistrationE == null)
                {
                    context.Registrations.Add(registrationE);
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
        public async Task<bool> DeleteRegistration(Registration registrationE)
        {
            bool result = false;
            Registration newRegistrationE = await GetRegistration(registrationE.Id);
            try
            {
                if (newRegistrationE != null)
                {
                    if (newRegistrationE.Active) {
                        registrationE.Active = false;
                        registrationE.DeleteAt = DateTime.Now;
                        context.Registrations.Update(registrationE);
                        context.SaveChanges();
                        result = true;
                    }
                    result = true;
                }
            }
            catch (Exception ex)
            {
                //Log
            }
            return result;
        }

        public async Task<bool> UpdateRegistration(Registration registrationE)
        {
            bool result = false;
            Registration newregistrationE = await GetRegistration(registrationE.Id);
            try
            {
                if (newregistrationE != null)
                {
                    context.Entry<Registration>(registrationE).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    registrationE.UpdateAt = DateTime.Now;
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
