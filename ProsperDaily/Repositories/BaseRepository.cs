using Microsoft.EntityFrameworkCore;
using ProsperDaily.Data;
using ProsperDaily.Shared.Entities;
using System.Linq.Expressions;

namespace ProsperDaily.Repositories;

public partial class BaseRepository<T>(IDbContextFactory<ApplicationDbContext> contextFactory) where T : Entity, new()
{
    public (bool IsSuccess, int RowsAffected, string StatusMessage) LastOperationStatus { get; set; }

    public async Task AddAsync(T entity)
    {
        try
        {
            await using ApplicationDbContext context = await contextFactory.CreateDbContextAsync();
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            LastOperationStatus = (true, 1, $"{typeof(T).Name} added successfully.");
        }
        catch (Exception ex)
        {
            LastOperationStatus = (false, 0, $"Error adding {typeof(T).Name}: {ex.Message}");
        }
    }

    public async Task<List<T>> GetAllAsync()
    {
        try
        {
            await using ApplicationDbContext context = await contextFactory.CreateDbContextAsync();
            List<T> entities = await context.Set<T>().ToListAsync();
            LastOperationStatus = (true, entities.Count, $"{typeof(T).Name}s retrieved successfully.");
            return entities;
        }
        catch (Exception ex)
        {
            LastOperationStatus = (false, 0, $"Error retrieving {typeof(T).Name}s: {ex.Message}");
            return [];
        }
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
    {
        try
        {
            await using ApplicationDbContext context = await contextFactory.CreateDbContextAsync();
            List<T> entities = await context.Set<T>().Where(expression).ToListAsync();
            LastOperationStatus = (true, entities.Count, $"{typeof(T).Name}s retrieved successfully.");
            return entities;
        }
        catch (Exception ex)
        {
            LastOperationStatus = (false, 0, $"Error retrieving {typeof(T).Name}s : {ex.Message}");
            return [];
        }
    }

    public async Task<List<T>> GetAllAsync(string query)
    {
        try
        {
            await using ApplicationDbContext context = await contextFactory.CreateDbContextAsync();
            List<T> entities = await context.Set<T>().FromSqlRaw(query).ToListAsync();
            LastOperationStatus = (true, entities.Count, $"{typeof(T).Name}s retrieved successfully.");
            return entities;
        }
        catch (Exception ex)
        {
            LastOperationStatus = (false, 0, $"Error executing query for {typeof(T).Name}s: {ex.Message}");
            return [];
        }
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        try
        {
            await using ApplicationDbContext context = await contextFactory.CreateDbContextAsync();
            T? entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                LastOperationStatus = (true, 1, $"{typeof(T).Name} with ID {id} retrieved successfully.");
            }
            else
            {
                LastOperationStatus = (false, 0, $"{typeof(T).Name} with ID {id} not found.");
            }
            return entity;
        }
        catch (Exception ex)
        {
            LastOperationStatus = (false, 0, $"Error retrieving {typeof(T).Name} with ID {id}: {ex.Message}");
            return default;
        }
    }

    public async Task UpdateAsync(T entity)
    {
        try
        {
            await using ApplicationDbContext context = await contextFactory.CreateDbContextAsync();
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            LastOperationStatus = (true, 1, $"{typeof(T).Name} updated successfully.");
        }
        catch (Exception ex)
        {
            LastOperationStatus = (false, 0, $"Error updating {typeof(T).Name}: {ex.Message}");
        }
    }

    public async Task DeleteAsync(T entity)
    {
        try
        {
            await using ApplicationDbContext context = await contextFactory.CreateDbContextAsync();
            context.Remove(entity);
            await context.SaveChangesAsync();
            LastOperationStatus = (true, 1, $"{typeof(T).Name} deleted successfully.");
        }
        catch (Exception ex)
        {
            LastOperationStatus = (false, 0, $"Error deleting {typeof(T).Name}: {ex.Message}");
        }
    }

    public async Task DeleteAsync(object id)
    {
        try
        {
            T? entity = await GetByIdAsync(id);
            if (entity != null)
            {
                await DeleteAsync(entity);
            }
            else
            {
                LastOperationStatus = (false, 0, $"{typeof(T).Name} with ID {id} not found.");
            }
        }
        catch (Exception ex)
        {
            LastOperationStatus = (false, 0, $"Error deleting {typeof(T).Name} with ID {id}: {ex.Message}");
        }
    }
}
