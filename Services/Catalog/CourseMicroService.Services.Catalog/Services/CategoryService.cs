using AutoMapper;
using CourseMicroService.Services.Catalog.Dtos;
using CourseMicroService.Services.Catalog.Models;
using CourseMicroService.Services.Catalog.Settings;
using CourseMicroService.Shared.Dtos;
using MongoDB.Driver;

namespace CourseMicroService.Services.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();

            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories),200);
        }

        public async Task<Response<CategoryDto>> CreateAsync(Category category)
        {
            await _categoryCollection.InsertOneAsync(category);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category),200);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x=> x.Id == id).FirstOrDefaultAsync();
            if(category == null)
            {
                return Response<CategoryDto>.Fail("Category Not Found", 404);
            }
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

    }
}
