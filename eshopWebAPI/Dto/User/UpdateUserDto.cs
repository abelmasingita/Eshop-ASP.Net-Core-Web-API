namespace eshopWebAPI.Dto.User
{
    public class UpdateUserDto : UserBaseDto
    {
        public int Id { get; set; }
        public string Password { get; set; }
    }
}
