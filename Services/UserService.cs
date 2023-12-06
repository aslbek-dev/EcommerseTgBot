using EcommerseBot.Data;
using EcommerseBot.Data.Entities;

namespace EcommerseBot.Services;

public class UserService
{
    private readonly IGenericRepository<User> _userRepository;

    public UserService(IGenericRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<(bool IsSuccess, string? ErrorMessage)> AddUserAsync(User user)
    {
        if(Exits(user.Id))
            return (false, "User exits");
        try
        {
            var result = await _userRepository.InsertAsync(user);
            return (true, null);
        }
        catch(Exception exception)
        {
            return (false, exception.Message);
        }
    }

    public async Task<User> UpdateUserAsync(User? user)
    {
        ArgumentNullException.ThrowIfNull(user);
        try
        {
            return await _userRepository.UpdateAsync(user);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public bool Exits(long? id) =>
        _userRepository.Select().Any(u => u.Id == id);
        

    public async Task<User?> GetUserByIdAsync(long? userId)
    {
        ArgumentNullException.ThrowIfNull(userId);

        return await _userRepository.SelectAsyncById(userId);
    }


}
