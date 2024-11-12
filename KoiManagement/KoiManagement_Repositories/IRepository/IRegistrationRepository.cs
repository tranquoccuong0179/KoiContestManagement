using KoiManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Repositories.IRepository
{
    public interface IRegistrationRepository
    {
        public List<Registration> GetRegistrations();
        public Registration GetRegistrationById(string id);
        public bool AddRegistration(Registration registration);
        public bool DeleteRegistration(Registration registration);
        public bool UpdateRegistration(Registration registration);
    }
}
