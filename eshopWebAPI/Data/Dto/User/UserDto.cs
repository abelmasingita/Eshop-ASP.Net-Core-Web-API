namespace eshopWebAPI.Dto.User
{
    public class UserDto : UserBaseDto
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }
    }
}
