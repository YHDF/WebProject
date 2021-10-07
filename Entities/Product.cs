using System;

namespace WebApi.Entities
{
    public class Product
    {
        // Properties
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImageURL { get; set; }
        public string ProductURL { get; set; }

        // Constructor
        public Product() {}
        
        public Product(string name, int price, string imgUrl, string prodUrl)
        {
            Name = name;
            Price = price;
            ImageURL = imgUrl;
            ProductURL = prodUrl;
        }
    }
}
