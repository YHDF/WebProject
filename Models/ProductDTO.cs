using System;

namespace ProductDTOModel
{
    public class ProductDTO
    {
        // Properties
        public int ProductDTOId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string ImageURL { get; set; }

        public string ProductURL { get; set; }

        // Constructors
        public ProductDTO()
        {
        }

        public ProductDTO(string name, int price, string imgUrl, string prodUrl)
        {
            Name = name;
            Price = price;
            ImageURL = imgUrl;
            ProductURL = prodUrl;
        }
    }
}
