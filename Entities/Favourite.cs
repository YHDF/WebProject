using System;

namespace WebApi.Entities
{
    public class Favourite
    {
        // Properties
        public int FavouriteId { get; set; }
        public string UserId { get; set; }
        public string UserMail { get; set; }
        public string ProductLink { get; set; }

        // Constructor
        public Favourite() {}
        
        public Favourite(string userId, string userMail, string prodLink)
        {
            UserId = userId;
            UserMail = userMail;
            ProductLink = prodLink;
        }
    }
}
