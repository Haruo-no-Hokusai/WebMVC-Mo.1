using ImageManagement.Setting;
using ImageManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace ImageManagement.Service
{
    public class ProductService : IProductService
    {
        private readonly DataContext dataContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductService(DataContext dataContext,IWebHostEnvironment webHostEnvironment) 
        { 
            this.dataContext = dataContext;
            this.webHostEnvironment = webHostEnvironment;
        }

        public DataContext DataContext { get; }

        public async Task Add(Product product, IFormFile formFile)
        {
            string wwwPath = webHostEnvironment.WebRootPath;
            if(formFile != null)
            {
                string filename = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(formFile.FileName);

                var folder = Path.Combine(wwwPath, FilePath.Iamges);

                var externalFile = Path.Combine(folder,filename+extension);
                var fileInDb = filename + extension;

                if(!Directory.Exists(folder)) 
                {
                    Directory.CreateDirectory(folder);
                }

                using (var fileStream = new FileStream(externalFile, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }

                product.ImgUrl = fileInDb;
            }

            await dataContext.AddAsync(product);
            await dataContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Product>> GetProduct()
        {
            var Product = await dataContext.products.ToArrayAsync();

            foreach (var item in Product)
            {
                item.ImgUrl = !String.IsNullOrEmpty(item.ImgUrl) ? 
                    Path.Combine(FilePath.Iamges, item.ImgUrl) : "404.jpg";
            }

            return Product;
        }

        public async Task<Product> FindId(int Id)
        {
            var product = await dataContext.products.FindAsync(Id);
            if (!String.IsNullOrEmpty(product.ImgUrl))
            {
                product.ImgUrl = Path.Combine("\\", FilePath.Iamges, product.ImgUrl);
            }
            return product;
        }

        public async Task Delete(Product product)
        {
            if(!String.IsNullOrEmpty(product.ImgUrl))
            {
                var fileDelete = webHostEnvironment.WebRootPath + product.ImgUrl;
                if (File.Exists(fileDelete))
                {
                    File.Delete(fileDelete);
                }
            }
            
            dataContext.products.Remove(product);
            dataContext.SaveChanges();
        }

        public async Task Ubdate(Product product, IFormFile formFile)
        {
            string wwwPath = webHostEnvironment.WebRootPath;
            if (formFile != null)
            {
                string filename = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(formFile.FileName);

                var folder = Path.Combine(wwwPath, FilePath.Iamges);

                var externalFile = Path.Combine(folder, filename + extension);
                var fileInDb = filename + extension;

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                //add new
                using (var fileStream = new FileStream(externalFile, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }

                //Delete
                var fileDelete = webHostEnvironment.WebRootPath + product.ImgUrl;
                if (File.Exists(fileDelete))
                {
                    File.Delete(fileDelete);
                }

                product.ImgUrl = fileInDb;
            }

            dataContext.products.Update(product);
            await dataContext.SaveChangesAsync();
        }
    }
}
