namespace LinqUser.Areas.Profile.Service.ProfileService.EditeProfile
{
    public class EditeProfileUserDto
    {
        public string Bio { get; set; }
        public IFormFile? ProfileImageUrl { get; set; }
        public string? CurrentProfileImageUrl { get; set; }
    }
}
