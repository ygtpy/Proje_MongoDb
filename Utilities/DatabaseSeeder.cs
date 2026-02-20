using AkademiQMongoDb.DTOs.BannerDtos;
using AkademiQMongoDb.DTOs.CategoryDtos;
using AkademiQMongoDb.DTOs.FeatureDtos;
using AkademiQMongoDb.DTOs.ProductDtos;
using AkademiQMongoDb.DTOs.TeamDtos;
using AkademiQMongoDb.DTOs.TestimonialDtos;
using AkademiQMongoDb.DTOs.GalleryDtos;
using AkademiQMongoDb.Services.BannerServices;
using AkademiQMongoDb.Services.CategoryServices;
using AkademiQMongoDb.Services.FeatureServices;
using AkademiQMongoDb.Services.ProductServices;
using AkademiQMongoDb.Services.TeamServices;
using AkademiQMongoDb.Services.TestimonialServices;
using AkademiQMongoDb.Services.GalleryServices;

namespace AkademiQMongoDb.Utilities
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            var productService = serviceProvider.GetRequiredService<IProductService>();
            var bannerService = serviceProvider.GetRequiredService<IBannerService>();
            var featureService = serviceProvider.GetRequiredService<IFeatureService>();
            var teamService = serviceProvider.GetRequiredService<ITeamService>();
            var testimonialService = serviceProvider.GetRequiredService<ITestimonialService>();
            var galleryService = serviceProvider.GetRequiredService<IGalleryService>();

            // Seed Categories
            var categories = await categoryService.GetAllAsync();
            if (categories.Count == 0)
            {
                await categoryService.CreateAsync(new CreateCategoryDto { Name = "Burgerler" });
                await categoryService.CreateAsync(new CreateCategoryDto { Name = "Pizzalar" });
                await categoryService.CreateAsync(new CreateCategoryDto { Name = "İçecekler" });
                await categoryService.CreateAsync(new CreateCategoryDto { Name = "Tatlılar" });
                categories = await categoryService.GetAllAsync(); // Refresh list associated with Ids
            }

            // Seed Products
            var products = await productService.GetAllAsync();
            if (products.Count == 0 && categories.Count > 0)
            {
                var burgerCat = categories.FirstOrDefault(x => x.Name == "Burgerler");
                var pizzaCat = categories.FirstOrDefault(x => x.Name == "Pizzalar");
                var drinkCat = categories.FirstOrDefault(x => x.Name == "İçecekler");
                var desertCat = categories.FirstOrDefault(x => x.Name == "Tatlılar");

                if (burgerCat != null)
                {
                    await productService.CreateAsync(new CreateProductDto
                    {
                        Name = "Cheeseburger",
                        Description = "Özel soslu, taze yeşillikli nefis cheeseburger.",
                        Price = 120,
                        ImageUrl = "/source/assets/img/food/1.jpg",
                        CategoryId = burgerCat.Id,
                        CategoryName = burgerCat.Name
                    });
                    await productService.CreateAsync(new CreateProductDto
                    {
                        Name = "Barbekü Burger",
                        Description = "Barbekü soslu, füme etli burger.",
                        Price = 140,
                        ImageUrl = "/source/assets/img/food/2.jpg",
                        CategoryId = burgerCat.Id,
                        CategoryName = burgerCat.Name
                    });
                }
                
                if (pizzaCat != null)
                {
                    await productService.CreateAsync(new CreateProductDto
                    {
                        Name = "Karışık Pizza",
                        Description = "Bol malzemeli, ince hamurlu karışık pizza.",
                        Price = 180,
                        ImageUrl = "/source/assets/img/food/3.jpg",
                        CategoryId = pizzaCat.Id,
                        CategoryName = pizzaCat.Name
                    });
                     await productService.CreateAsync(new CreateProductDto
                    {
                        Name = "Sucuklu Pizza",
                        Description = "Özel baharatlı sucuklarla hazırlanan pizza.",
                        Price = 190,
                        ImageUrl = "/source/assets/img/food/5.jpg",
                        CategoryId = pizzaCat.Id,
                        CategoryName = pizzaCat.Name
                    });
                }

                if (drinkCat != null)
                {
                    await productService.CreateAsync(new CreateProductDto
                    {
                        Name = "Kola",
                        Description = "Soğuk buz gibi kola.",
                        Price = 40,
                        ImageUrl = "/source/assets/img/food/4.jpg",
                        CategoryId = drinkCat.Id,
                        CategoryName = drinkCat.Name
                    });
                    await productService.CreateAsync(new CreateProductDto
                    {
                        Name = "Ayran",
                        Description = "Yayık ayranı.",
                        Price = 30,
                        ImageUrl = "/source/assets/img/food/2.jpg",
                        CategoryId = drinkCat.Id,
                        CategoryName = drinkCat.Name
                    });
                }
                
                if (desertCat != null)
                {
                    await productService.CreateAsync(new CreateProductDto
                    {
                        Name = "Sufle",
                        Description = "Akışkan çikolatalı sufle.",
                        Price = 90,
                        ImageUrl = "/source/assets/img/food/6.jpg",
                        CategoryId = desertCat.Id,
                        CategoryName = desertCat.Name
                    });
                }
            }

            // Seed Banners
            var banners = await bannerService.GetAllAsync();
            if (banners.Count == 0)
            {
                 await bannerService.CreateAsync(new CreateBannerDto
                 {
                     Title = "Lezzet Dünyası",
                     SubTitle = "%50 İndirim",
                     Description = "Haftanın en sevilen menülerinde geçerli büyük indirim fırsatını kaçırmayın.",
                     ImageUrl = "/source/assets/img/illustration/3.png"
                 });
                 await bannerService.CreateAsync(new CreateBannerDto
                 {
                     Title = "Taze ve Doğal",
                     SubTitle = "Organik Tatlar",
                     Description = "Tamamen doğal malzemelerle hazırlanan eşsiz lezzetler sizi bekliyor.",
                     ImageUrl = "/source/assets/img/illustration/pizza.png"
                 });
            }

            // Seed Features
            var features = await featureService.GetAllAsync();
            if (features.Count == 0)
            {
                await featureService.CreateAsync(new CreateFeatureDto
                {
                    Title = "Çıtır Tavuk Menü",
                    Description = "Dışı çıtır içi yumuşacık tavuklar.",
                    ImageUrl = "/source/assets/img/icon/1.png"
                });
                 await featureService.CreateAsync(new CreateFeatureDto
                {
                    Title = "Hızlı Teslimat",
                    Description = "Siparişiniz 30 dakikada kapınızda.",
                    ImageUrl = "/source/assets/img/icon/2.png" 
                });
                  await featureService.CreateAsync(new CreateFeatureDto
                {
                    Title = "Özel Tatlar",
                    Description = "Şefimizin spesiyalleri.",
                    ImageUrl = "/source/assets/img/icon/3.png" 
                });
            }

            // Seed Teams
            var teams = await teamService.GetAllAsync();
            if (teams.Count == 0)
            {
                await teamService.CreateAsync(new CreateTeamDto { FullName = "Ahmet Yılmaz", Title = "Baş Aşçı", ImageUrl = "/source/assets/img/team/1.jpg" });
                await teamService.CreateAsync(new CreateTeamDto { FullName = "Ayşe Demir", Title = "Pasta Şefi", ImageUrl = "/source/assets/img/team/2.jpg" });
                await teamService.CreateAsync(new CreateTeamDto { FullName = "Mehmet Kaya", Title = "Sous Chef", ImageUrl = "/source/assets/img/team/3.jpg" });
            }

            // Seed Testimonials
            var testimonials = await testimonialService.GetAllAsync();
            if (testimonials.Count == 0)
            {
                await testimonialService.CreateAsync(new CreateTestimonialDto { FullName = "Ali Veli", Title = "Müşteri", Comment = "Harika yemekler, kesinlikle tavsiye ederim!", ImageUrl = "/source/assets/img/team/1.jpg" });
                await testimonialService.CreateAsync(new CreateTestimonialDto { FullName = "Zeynep Gül", Title = "Gurme", Comment = "Hizmet kalitesi ve lezzet on numara.", ImageUrl = "/source/assets/img/team/2.jpg" });
            }

             // Seed Gallery
            var gallery = await galleryService.GetAllAsync();
            if (gallery.Count == 0)
            {
                await galleryService.CreateAsync(new CreateGalleryDto { ImageUrl = "/source/assets/img/food/1.jpg" });
                await galleryService.CreateAsync(new CreateGalleryDto { ImageUrl = "/source/assets/img/food/2.jpg" });
                await galleryService.CreateAsync(new CreateGalleryDto { ImageUrl = "/source/assets/img/food/3.jpg" });
                await galleryService.CreateAsync(new CreateGalleryDto { ImageUrl = "/source/assets/img/food/4.jpg" });
                await galleryService.CreateAsync(new CreateGalleryDto { ImageUrl = "/source/assets/img/food/5.jpg" });
                await galleryService.CreateAsync(new CreateGalleryDto { ImageUrl = "/source/assets/img/food/6.jpg" });
            }
        }
    }
}
