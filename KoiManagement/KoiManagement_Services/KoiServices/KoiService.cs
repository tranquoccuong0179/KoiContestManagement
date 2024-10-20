using AutoMapper;
using KoiManagement_BusinessObjects;
using KoiManagement_BusinessObjects.Constants;
using KoiManagement_Repositories.IRepository;
using KoiManagement_Services.IService;
using KoiManagement_Services.KoiServices.DTO;

namespace KoiManagement_Services.KoiServices
{
	internal sealed class KoiService : IKoiService
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

		public async Task<bool> Delete(KoiForDeleteDto koiForDeleteDto, string userId, string koiId)
		{
			var koi = await repositoryManager.KoiRepository.GetById(koiId, userId);
			if (koi is null) return false;
			mapper.Map(koiForDeleteDto, koi);
			koi.DeleteAt = DateTime.Now;
			return await repositoryManager.KoiRepository.Update(koi);
		}

		public async Task<List<KoiForReturnDto>> GetAll()
		{
			var koiList = await repositoryManager.KoiRepository.GetAll();
			return mapper.Map<List<KoiForReturnDto>>(koiList);
		}

		public async Task<KoiForReturnDto?> GetById(string koiId, string userId)
		{
			var koi = await repositoryManager.KoiRepository.GetById(koiId, userId);
			return mapper.Map<KoiForReturnDto>(koi);

		}

		public async Task<List<KoiForReturnDto>> GetByUserId(string userId)
		{
			var koiList = await repositoryManager.KoiRepository.GetByUserId(userId);
			return mapper.Map<List<KoiForReturnDto>>(koiList);
		}

		public async Task<bool> Update(KoiForUpdateDto koiForUpdateDto, string userId, string koiId)
		{
			var koi = await repositoryManager.KoiRepository.GetById(koiId, userId);
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
	}
}
