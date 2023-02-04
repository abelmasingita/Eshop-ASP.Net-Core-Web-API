﻿namespace eshopWebAPI.Dto
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }
    }
}
