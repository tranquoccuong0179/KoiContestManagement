using KoiManagement_BusinessObjects;

namespace KoiManagement_Services.IService
{
    public interface IRegistrationService
    {
        public List<Registration> GetRegistrations(string id);
        public List<Registration> GetRegistrationsAll();
        public Task<Registration> GetRegistrationByIdAsync(string id);
        public Task<bool> AddRegistration(Registration registration);
        public Task<bool> DeleteRegistration(Registration registration);
        public Task<bool> UpdateRegistrationAsync(Registration registration);
        public string GetUserIdByKoiId(string koiId);
        public Registration? GetRegistrationById(string id);
        public bool UpdateRegistration(Registration registration);

    }
}
