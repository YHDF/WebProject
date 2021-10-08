using System;

namespace WebApi.Entities
{
    public class Favourite
    {
        // Properties
        public int FavouriteId { get; set; }
        public string UserMail { get; set; }
        public string ProductLink { get; set; }
        public string ProductImg { get; set; }
        public string ProductPrice { get; set; }

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
