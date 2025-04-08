using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [Required]
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("price")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("category")]
        public string Category { get; set; } = string.Empty;

        [BsonElement("stock")]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [BsonElement("imageUrl")]
        [Url]
        public string ImageUrl { get; set; } = string.Empty;
    }
}