using CourseMicroService.Services.Catalog.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CourseMicroService.Services.Catalog.Dtos
{
    public class CourseCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public string UserId { get; set; }
        public FeatureDto Feature { get; set; }
        public string CategoryId { get; set; }

    }
}
