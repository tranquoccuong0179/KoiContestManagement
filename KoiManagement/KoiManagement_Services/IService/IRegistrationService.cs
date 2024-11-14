using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Services.IService
{
    public interface IRegistrationService
    {
        public List<Registration> GetRegistrations(string id);
        public List<Registration> GetRegistrationsAll();
        public Task<Registration> GetRegistrationById(string id);
        public Task<bool> AddRegistration(Registration registration);
        public Task<bool> DeleteRegistration(Registration registration);
        public Task<bool> UpdateRegistration(Registration registration);
        public string GetUserIdByKoiId(string koiId);
    }
}
