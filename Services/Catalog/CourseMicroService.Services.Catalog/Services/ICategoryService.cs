using CourseMicroService.Services.Catalog.Dtos;
using CourseMicroService.Services.Catalog.Models;
using CourseMicroService.Shared.Dtos;

namespace CourseMicroService.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(Category category);
        Task<Response<CategoryDto>> GetByIdAsync(string id);

    }
}
