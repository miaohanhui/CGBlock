using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGBlcok.MongoDAL.Model
{
    public class Article
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { set; get; }

        [BsonElement("title")]
        public string title { set; get; }

        [BsonElement("ltitle")]
        public string ltitle { set; get; }

        [BsonElement("imgUrl")]
        public string imgUrl { set; get; }

        [BsonElement("orderId")]
        public int orderId { set; get; }
    }

    public class Photo
    {
        public int OrderId { set; get; }
        public string Path { set; get; }       
    }

    public class Comment
    {
        public string Username { set; get; }
        public string Content { set; get; }
        public DateTime CommentDate { set; get; }
    }
}