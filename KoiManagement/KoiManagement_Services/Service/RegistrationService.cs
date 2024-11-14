using KoiManagement_BusinessObjects;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Services.IService;

namespace KoiManagement_Services.Service
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            this.registrationRepository = registrationRepository;
        }

        public Task<bool> AddRegistration(Registration registration)
        {
            registration.Id = Guid.NewGuid().ToString();
            registration.Active = true;
            registration.CreateAt = DateTime.Now;
            registration.UpdateAt = DateTime.Now;
            registration.IsCheckIn = false;
            registration.CheckInTime = null;
            return registrationRepository.AddRegistration(registration);
        }

        public Task<bool> DeleteRegistration(Registration registration)
        {
            return registrationRepository.DeleteRegistration(registration);
        }

        public Task<Registration> GetRegistrationById(string id)
        {
            return registrationRepository.GetRegistrationById(id);
        }

        public List<Registration> GetRegistrations(string u)
        {
            return registrationRepository.GetRegistrations(u);
        }
        public List<Registration> GetRegistrationsAll()
        {
            return registrationRepository.GetRegistrationsAll();
        }

        public Task<bool> UpdateRegistration(Registration registration)
        {
            return registrationRepository.UpdateRegistration(registration);
        }
        public string GetUserIdByKoiId(string koiId)
        {
            return registrationRepository.GetUserIdByKoiId(koiId);
        }
    }
}
