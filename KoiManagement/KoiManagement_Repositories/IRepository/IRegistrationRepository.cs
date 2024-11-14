using KoiManagement_BusinessObjects;

namespace KoiManagement_Repositories.IRepository
{
    public interface IRegistrationRepository
    {
        public List<Registration> GetRegistrations(string id);
        public List<Registration> GetRegistrationsAll();
        public Task<Registration> GetRegistrationByIdAsync(string id);
        public Task<bool> AddRegistration(Registration registration);
        public Task<bool> DeleteRegistration(Registration registration);
        public Task<bool> UpdateRegistrationAsync(Registration registration);
        public string GetUserIdByKoiId(string koiId);
        public Registration? GetRegistrationById(string id);
        bool UpdateRegistration(Registration registration);

    }
}
