using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VulnerableQuestions.Models;

public class VulnerableQuestion
{
    [BsonId]
    [BsonElement("id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [AllowHtml]
    [BsonElement("question")]
    public string Question { get; set; } = null!;
}