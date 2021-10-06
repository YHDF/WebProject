using System;

namespace UserDTOModel
{
    public class UserDTO
    {
        // Properties
        public int UserDTOId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        // Constructors
        public UserDTO()
        {
        }

        public UserDTO(string username, string email, string pswd)
        {
            Username = username;
            Email = email;
            Password = pswd;
        }
    }
}
