using EcommerseBot.Data;
using EcommerseBot.Data.Entities;
using EcommerseBot.Data.Enums;

namespace EcommerseBot.Services;

public class ProductService
{
    private readonly IGenericRepository<Product> _productRepository;
    public ProductService(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<(bool IsSuccess, string? ErrorMessage)> AddProductAsync(Product product)
    {
        try
        {
            var result = await _productRepository.InsertAsync(product);
            return (true, null);
        }
        catch(Exception exception)
        {
            return (false, exception.Message);
        }
    }
    public IEnumerable<Product> GetAllProduct()
    {
        var products = _productRepository.Select();

        return products;
    }

    public IQueryable<Product> GetProductByTypeAsync(ProductType productType)
    {
        var products = _productRepository
                                        .Select()
                                        .Where(p => p.productType == productType)
                                        .AsQueryable();
        
        return products;
    }
    public IList<Product> GetProducts(ProductType productType)
    {
        return _productRepository.Select().ToList();
    }

    
    public IList<Product> GetProducts()
    {
    List<Product> products = new List<Product>()
    {
        new Product{
            Name = "Baliq sabzavotlar bilan(bitta porsiya)",
            Description = @"Nafis taom boʻlib, lahm skumbriya goʻshti va barra sabzavotlar, tamatli sous ""Tam-Tam"" bilan beriladi Tarkibi:  Lahm skumbriya goʻshti, pomidor, guruch, aysberg, piyoz, limon, Tam-Tam sousi.",
            Volume = 1,
            Price = 80.000M,
            productType = ProductType.BaliqliTaom
        },
        new Product{
            Name = "Sendvich Baliqli rukkola bilan",
            Description = @"Baliqli sendvich rukkula bilan- sogʻlom ovqatlanishni yaxshi koʻradiganlar uchun ideal tanlovdir. Nafis barra baliq boʻlakchalari, oltin tusga kirgunga qadar qovurilgan boʻlib, rukkula boʻyi bilan birlashib har bir baliq boʻlakchasiga oʻzgacha taʼm beradi.

Tarkibi: Lahm skumbriya goʻshti, chiabatta non, rukkola, piyoz, pomidor, limon, Tam-Tam sousi.",
            Volume  = 1,
            Price = 45.000M,
            productType = ProductType.BaliqliTaom
        },
        new Product{
            Name = "Sendvich Baliqli",
            Description = @"Baliqli sendvich — bu taʼmdan bahramand boʻlsangiz, sizga sogʻligʻingizga gʻamxoʻrlik qilish imkonini beradigan oqsil, hayotga zarur boʻlgan omega-3 yogʻi bordir. Undan tashqari tarkibi vitaminlarga boydir.

Tarkibi: Lahm skumbriya goʻshti, chiabatta non, pomidor, piyoz, aysberg, limon sousi, Tam-Tam sousi, mayonez.",
            Volume = 1,
            Price = 40.000M,
            productType = ProductType.BaliqliTaom
        },
         new Product{
            Name = "Tovuq garnir bilan",
            Description = @"Shirali tovuq bo'laklari, xushbo'y guruch va yangi tug'ralgan sabzavotlardan iborat boy va mazali taomdir. Ushbu taom tog'ri va muvozanatli ovqatlanishni qidiradiganlar uchun ideal tanlovdir. Turk yopilgan noni ""Ekmek"" bilan beriladi.Tarkibi: aysberg, pomidor, bodring, guruch, tovuq filesi, Yekmek yassi non. Og'irligi: 350 gr.",
            Volume = 1,
            Price = 42.000M,
            productType = ProductType.Kotletlar
        },
        new Product
        {
            Name = @"Turk noni ""Ekmek"" ",
            Description = "Ekmek turk noni- Bu Turkiyaning mazali va ajoyib non bo‘lib, o‘zining betakror ta’mi va ko'rinishi bilan sizni o‘ziga rom etishi aniq.",
            Volume = 1,
            Price = 4.000M,
            productType = ProductType.Kotletlar
        }
    };
    
        return products;
    }
}