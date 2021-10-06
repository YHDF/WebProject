using System;

namespace WebApi.Entities
{
    public class Favourite
    {
        // Properties
        public int FavouriteId { get; set; }
        public int UserId { get; set; }
        public string ProductLink { get; set; }

        // Constructor
        public Favourite() {}
        
        public Favourite(int userId, string prodLink)
        {
            UserId = userId;
            ProductLink = prodLink;
        }
    }
}
