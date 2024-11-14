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
        public List<Registration> GetRegistrations(string id) => RegistrationDAO.Instance.GetRegistrations(id);
        public List<Registration> GetRegistrationsAll() => RegistrationDAO.Instance.GetRegistrationsAll();
        public Task<Registration> GetRegistrationById(string id) => RegistrationDAO.Instance.GetRegistration(id);
        public Task<bool> AddRegistration(Registration registration) => RegistrationDAO.Instance.AddRegistration(registration);
        public Task<bool> DeleteRegistration(Registration registration) => RegistrationDAO.Instance.DeleteRegistration(registration);
        public Task<bool> UpdateRegistration(Registration registration) => RegistrationDAO.Instance.UpdateRegistration(registration);
        public string GetUserIdByKoiId(string koiId) => RegistrationDAO.Instance.GetUserIdByKoiId(koiId);
    }
}
