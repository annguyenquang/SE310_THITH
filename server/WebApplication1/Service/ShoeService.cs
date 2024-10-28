using Microsoft.EntityFrameworkCore;
using WebApplication1.Core.Entities;
using WebApplication1.Model;
using WebApplication1.Persistent;

namespace WebApplication1.Service
{
    public interface IShoeService
    {
        public Task<List<Shoe>> GetAllShoeAsync();
        public Task<Shoe> CreateShoe(CreateShoe shoe);
        public Task<Shoe> GetShoeById(Guid id);
        public Task<Shoe> UpdateShoe(Shoe shoe);
        public Task<Shoe> DeleteShoe(Guid id);
    }
    public class ShoeService : BaseService<Shoe>, IShoeService
    {
        public ShoeService(ApplicationContext context) : base(context)
        {
        }

        public Task<Shoe> CreateShoe(CreateShoe shoe)
        {
            var entity = new Shoe
            {
                Name = shoe.Name,
                Brand = shoe.Brand,
                Price = shoe.Price,
                Stock = shoe.Stock,
                PictureUrl = shoe.PictureUrl
            };
            return AddAsync(entity);
        }

        public async Task<Shoe> DeleteShoe(Guid id)
        {
            
            var shoe = await GetAsync(id);
            if(shoe == null) throw new Exception($"Shoe with id {id} is not found");
            var res = await DeleteAsync(shoe);
            return res;
        }

        public async Task<List<Shoe>> GetAllShoeAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Shoe> GetShoeById(Guid id)
        {
            var shoe = await GetAsync(id);
            if(shoe == null) throw new Exception($"Shoe with id {id} is not found");
            return shoe;
        }

        public async Task<Shoe> UpdateShoe(Shoe shoe)
        {
            var entity = await GetAsync(shoe.Id);
            if(entity == null)
            {
               throw new BadHttpRequestException("Shoe not found");
            }
            entity.Name = shoe.Name;
            entity.Brand = shoe.Brand;
            entity.Price = shoe.Price;
            entity.Stock = shoe.Stock;
            entity.PictureUrl = shoe.PictureUrl;
            var res = await UpdateAsync(entity);
            return res;
        }
    }
}
