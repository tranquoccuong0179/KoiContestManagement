using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Repositories.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        public List<Registration> GetRegistrations() => RegistrationDAO.Instance.GetRegistrations();
        public Registration GetRegistrationById(string id) => RegistrationDAO.Instance.GetRegistration(id);
        public bool AddRegistration(Registration registration) => RegistrationDAO.Instance.AddRegistration(registration);
        public bool DeleteRegistration(Registration registration) => RegistrationDAO.Instance.DeleteRegistration(registration);
        public bool UpdateRegistration(Registration registration) => RegistrationDAO.Instance.UpdateRegistration(registration);
    }
}
