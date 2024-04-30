using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace csharp.netcore.api_consuming_data_mongodb.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }

    }
}
