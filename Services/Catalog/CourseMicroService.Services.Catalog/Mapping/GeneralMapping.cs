using AutoMapper;
using CourseMicroService.Services.Catalog.Dtos;
using CourseMicroService.Services.Catalog.Models;

namespace CourseMicroService.Services.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Course,CourseDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
            CreateMap<Course, CourseCreateDto>().ReverseMap();
            CreateMap<Course, CourseUpdateDto>().ReverseMap();
        }
    }
}
