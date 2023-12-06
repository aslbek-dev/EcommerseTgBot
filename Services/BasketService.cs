using EcommerseBot.Data;
using EcommerseBot.Data.Entities;

namespace EcommerseBot.Services;

public class BasketService
{
    private readonly IGenericRepository<Basket> _basketRepository;
    public BasketService(IGenericRepository<Basket> basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task AddBasket(Basket basket)
    {
        try
        {
            await _basketRepository.InsertAsync(basket);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
        
    }
    public async Task DeleteProductOnBasket(int basketId, Product product)
    {
        var basket = await _basketRepository.SelectAsyncById(basketId);

        var products = basket.Products.Remove(product);
    }
}
