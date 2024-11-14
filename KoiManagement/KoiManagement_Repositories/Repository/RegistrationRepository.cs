using KoiManagement_BusinessObjects;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;

namespace KoiManagement_Repositories.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        public List<Registration> GetRegistrations(string id) => RegistrationDAO.Instance.GetRegistrations(id);
        public List<Registration> GetRegistrationsAll() => RegistrationDAO.Instance.GetRegistrationsAll();
        public Task<Registration> GetRegistrationByIdAsync(string id) => RegistrationDAO.Instance.GetRegistrationByIdAsync(id);
        public Task<bool> AddRegistration(Registration registration) => RegistrationDAO.Instance.AddRegistration(registration);
        public Task<bool> DeleteRegistration(Registration registration) => RegistrationDAO.Instance.DeleteRegistration(registration);
        public Task<bool> UpdateRegistrationAsync(Registration registration) => RegistrationDAO.Instance.UpdateRegistrationAsync(registration);
        public string GetUserIdByKoiId(string koiId) => RegistrationDAO.Instance.GetUserIdByKoiId(koiId);

        public Registration? GetRegistrationById(string id) => RegistrationDAO.Instance.GetRegistrationById(id);

        public bool UpdateRegistration(Registration registration) => RegistrationDAO.Instance.UpdateRegistration(registration);
    }
}
