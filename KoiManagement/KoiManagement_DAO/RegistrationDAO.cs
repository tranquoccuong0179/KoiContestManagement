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

        public List<Registration> GetRegistrations()
        {
            return context.Registrations.Include(x => x.Koi).ToList();
        }

        public Registration GetRegistration(string id)
        {
            var entity = context.Registrations.SingleOrDefault(m => m.Id.Equals(id));
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }


        public bool AddRegistration(Registration registrationE)
        {
            bool result = false;
            Registration newRegistrationE = GetRegistration(registrationE.Id);
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
        public bool DeleteRegistration(Registration registrationE)
        {
            bool result = false;
            Registration newRegistrationE = GetRegistration(registrationE.Id);
            try
            {
                if (newRegistrationE != null)
                {
                    context.Registrations.Remove(registrationE);
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

        public bool UpdateRegistration(Registration registrationE)
        {
            bool result = false;
            Registration newregistrationE = GetRegistration(registrationE.Id);
            try
            {
                if (newregistrationE != null)
                {
                    context.Entry<Registration>(registrationE).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
