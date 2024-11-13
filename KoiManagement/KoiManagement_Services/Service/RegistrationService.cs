using KoiManagement_BusinessObjects;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiManagement_Services.Service
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            this.registrationRepository = registrationRepository;
        }

        public bool AddRegistration(Registration registration)
        {
            registration.Id = Guid.NewGuid().ToString();
            registration.Active = true;
            registration.CreateAt = DateTime.Now;
            registration.UpdateAt = DateTime.Now;
            registration.IsCheckIn = false;
            registration.CheckInTime = null;
            return registrationRepository.AddRegistration(registration);
        }

        public bool DeleteRegistration(Registration registration)
        {
            return registrationRepository.DeleteRegistration(registration);
        }

        public Registration GetRegistrationById(string id)
        {
            return registrationRepository.GetRegistrationById(id);
        }

        public List<Registration> GetRegistrations()
        {
            return registrationRepository.GetRegistrations();
        }

        public bool UpdateRegistration(Registration registration)
        {
            return registrationRepository.UpdateRegistration(registration);
        }
    }
}
