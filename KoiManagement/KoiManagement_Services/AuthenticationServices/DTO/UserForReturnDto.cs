namespace KoiManagement_Services.AuthenticationServices.DTO
{
	public record UserForReturnDto
	{
		public string Id { get; init; }
		public string FullName { get; init; }
		public string UserName { get; init; }
		public bool Active { get; init; }
		public DateTime CreateAt { get; init; }
		public DateTime? UpdateAt { get; set; }
		public DateTime? DeleteAt { get; set; }
		public List<string> Roles { get; set; }
	}
}
