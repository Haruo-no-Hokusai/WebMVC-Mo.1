


using Microsoft.EntityFrameworkCore;
using TestDataBase1to1toMany.Models;

namespace TestDataBase1to1toMany.Service
{
    public class Pservice : IPservice
    {
        private readonly FileManagementcs fm;
        List<Products> productsList;

        public Pservice(FileManagementcs Fm)
        {
            fm = Fm;
            productsList = new List<Products>();
        }

        public async Task AddProduct(Products products)
        {
            await fm.Product.AddAsync(products);
            await fm.SaveChangesAsync();
        }

        public async Task DeleteProduct(Products products)
        {
            fm.Remove(products);
            await fm.SaveChangesAsync();
        }

        public IEnumerable<Products> GetAllProduct()
        {
            return fm.Product.OrderByDescending(p => p.Id).ToList();
        }

        public async Task<Products> GetProduct(int id)
        {
            var product = await fm.Product.FindAsync(id);
            return product;
        }

        public async Task UbdateProduct(Products products)
        {
            fm.Product.Update(products);
            await fm.SaveChangesAsync();
        }
        public string GetName(int id)
        {
            var name = fm.Product.Find(id);
            return name.Name;
        }
    }
}

