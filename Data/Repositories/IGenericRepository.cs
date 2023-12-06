namespace EcommerseBot.Data;
public interface IGenericRepository<TEntity> where TEntity : class
{
    IEnumerable<TEntity> Select();

    ValueTask<TEntity> SelectAsyncById(object id);
    ValueTask<TEntity> InsertAsync(TEntity entity);
    ValueTask<TEntity> DeleteAsync(object id);
    ValueTask<TEntity> UpdateAsync(object id);
    ValueTask<TEntity> UpdateAsync(TEntity entityToUpdate);
}