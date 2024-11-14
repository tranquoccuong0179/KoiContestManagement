using AutoMapper;
using KoiManagement_BusinessObjects;
using KoiManagement_BusinessObjects.Constants;
using KoiManagement_DAO;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Services.IService;
using KoiManagement_Services.KoiServices.DTO;
using System.Reflection.Metadata.Ecma335;

namespace KoiManagement_Services.Service
{
    public class KoiService : IKoiService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;
        private readonly IBlobService blobService;

        public KoiService(IRepositoryManager repositoryManager, IMapper mapper, IBlobService blobService)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
            this.blobService = blobService;
        }

        public async Task<bool> Create(KoiForCreationDto koiForCreationDto)
        {
            string imageFileName = $"{Guid.NewGuid()}{Path.GetExtension(koiForCreationDto.File.FileName)}";

            var koi = mapper.Map<Koi>(koiForCreationDto);
            koi.Id = Guid.NewGuid().ToString();
            koi.Active = true;
            koi.Image = await blobService.UploadBlob(imageFileName, BlobStorage.Storage_Container, koiForCreationDto.File);
            koi.CreateAt = DateTime.Now;

            return await repositoryManager.KoiRepository.Create(koi);
        }

        public async Task<bool> Delete(string userId, string koiId)
        {
            var koi = await repositoryManager.KoiRepository.GetById(koiId, userId);
            if (koi is null) return false;
            koi.Active = false;
            koi.DeleteAt = DateTime.Now;
            return await repositoryManager.KoiRepository.Delete(koi);
        }

        public async Task<List<Koi>> GetAll()
        {
            return await repositoryManager.KoiRepository.GetAll();
        }
        public async Task<List<Koi>> GetByUserIdActive(string userId)
        {
            return await repositoryManager.KoiRepository.GetByUserIdActive(userId);
        }

        public async Task<Koi?> GetById(string? koiId, string? userId)
        {
            return await repositoryManager.KoiRepository.GetById(koiId, userId);

        }

        public async Task<List<Koi>> GetByUserId(string userId)
        {
            return await repositoryManager.KoiRepository.GetByUserId(userId);
        }

        public async Task<bool> Update(KoiForUpdateDto koiForUpdateDto)
        {
            var koi = await repositoryManager.KoiRepository.GetById(koiForUpdateDto.Id, koiForUpdateDto.UserId);
            if (koi is null) return false;
            mapper.Map(koiForUpdateDto, koi);
            if (koiForUpdateDto.File is not null && koiForUpdateDto.File.Length > 0)
            {
                await blobService.DeleteBlob(koi.Image.Split('/').Last(), BlobStorage.Storage_Container);
                string imageFileName = $"{Guid.NewGuid()}{Path.GetExtension(koiForUpdateDto.File.FileName)}";
                koi.Image = await blobService.UploadBlob(imageFileName, BlobStorage.Storage_Container, koiForUpdateDto.File);
            }
            koi.UpdateAt = DateTime.Now;
            return await repositoryManager.KoiRepository.Update(koi);
        }

        public async Task<KoiCompetitionVM> GetAllWithKois(string competitionRoundId) => await repositoryManager.KoiRepository.GetAllWithKois(competitionRoundId);

        public Koi GetKoiById(string? koiId) => repositoryManager.KoiRepository.GetKoiById(koiId);
    }
}
