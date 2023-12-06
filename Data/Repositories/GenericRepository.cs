using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EcommerseBot.Data;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly  BotDbContext dbContext;
    private readonly DbSet<TEntity> dbSet;
    public GenericRepository(BotDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }
    public IEnumerable<TEntity> Select() => dbSet;
    public async ValueTask<TEntity> SelectAsyncById(object id)
    {
        var entity = await dbSet.FindAsync(id);
        
        ArgumentNullException.ThrowIfNull(entity);

        return entity; 
    } 
            
    public async ValueTask<TEntity> InsertAsync(TEntity entity)
    {
        EntityEntry<TEntity> entityEntry = await dbSet.AddAsync(entity);

        await dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<TEntity> DeleteAsync(object id)
    {
        TEntity? entityToDelete = await dbSet.FindAsync(id);

        ArgumentNullException.ThrowIfNull(entityToDelete);

        EntityEntry<TEntity> deletedEntity = dbSet.Remove(entityToDelete);

        await dbContext.SaveChangesAsync();

        return deletedEntity.Entity;
    }
    public async ValueTask<TEntity> DeleteAsync(TEntity entityToDelete)
    {
        EntityEntry<TEntity> deletedEntity = dbSet.Remove(entityToDelete);
           
        await dbContext.SaveChangesAsync();

        return deletedEntity.Entity;
    }
    public async ValueTask<TEntity> UpdateAsync(object id)
    {
        TEntity? entityToUpdate = await dbSet.FindAsync(id);

        ArgumentNullException.ThrowIfNull(entityToUpdate);

        EntityEntry<TEntity> updatedEntityEntry = dbSet.Update(entityToUpdate);

        return updatedEntityEntry.Entity;
    }
    public async ValueTask<TEntity> UpdateAsync(TEntity entityToUpdate)
    {
        EntityEntry<TEntity> updatedEntity = dbSet.Update(entityToUpdate);
        await dbContext.SaveChangesAsync();

        return updatedEntity.Entity;
    }    
}

