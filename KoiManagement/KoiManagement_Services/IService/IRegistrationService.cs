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
        public Registration GetRegistrationById(string id);
        public bool AddRegistration(Registration registration);
        public bool DeleteRegistration(Registration registration);
        public bool UpdateRegistration(Registration registration);
    }
}
