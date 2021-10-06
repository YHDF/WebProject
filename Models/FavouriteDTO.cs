using System;

namespace FavouriteDTOModel
{
    public class FavouriteDTO
    {
        // Properties
        public int FavouriteDTOId { get; set; }

        public int UserId { get; set; }

        public string ProductLink { get; set; }

        // Constructors
        public FavouriteDTO()
        {
        }

        public FavouriteDTO(int userId, string prodLink)
        {
            UserId = userId;
            ProductLink = prodLink;
        }
    }
}
