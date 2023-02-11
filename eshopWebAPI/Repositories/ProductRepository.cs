using eshopWebAPI.Data;
using eshopWebAPI.Interfaces;
using eshopWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace eshopWebAPI.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
