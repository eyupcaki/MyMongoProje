using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMongoProje.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }    
        public string ProductName { get; set; }    
        public int ProductStock { get; set; }  
        public decimal ProductPrice { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set;}

        [BsonIgnore]  // Veritabanına yansımayacak 
        public Category Category { get; set; }
    }
}
