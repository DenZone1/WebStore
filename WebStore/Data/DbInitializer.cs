using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using WebStore.DAL.Context;

namespace WebStore.Data;

public class DbInitializer
{
    private readonly WebStoreDB _db;
    private readonly ILogger<DbInitializer> _logger;

    public DbInitializer(WebStoreDB db, ILogger<DbInitializer> Logger)
    {
        _db = db;
        _logger = Logger;
    }


    public async Task<bool> RemoveAsync(CancellationToken Cancel = default)
    {
        _logger.LogInformation("DB Deleted...");
        var result = await _db.Database.EnsureDeletedAsync(Cancel).ConfigureAwait(false);
        if (result)
        _logger.LogInformation("DB Deleted sucess");
        else
            _logger.LogInformation("DB Deleted unsucess - DB not found in Server");

        return result;
    }

    public async Task InitialyzeAsync(bool RemoveBefore,  CancellationToken Cancel = default)
    {
        _logger.LogInformation("DB Initilialization...");

        if (RemoveBefore)
            await RemoveAsync(Cancel).ConfigureAwait(false);


        // await _db.Database.EnsureCreatedAsync(Cancel).ConfigureAwait(false);


        _logger.LogInformation("The use of DB migrations...");
        await _db.Database.MigrateAsync(Cancel).ConfigureAwait(false);
        _logger.LogInformation("DB migrations sucess");

        await InitializeProductsAsync(Cancel);
        _logger.LogInformation("DB Initilialization sucess");
    }

    private async Task InitializeProductsAsync(CancellationToken Cancel)
    {
        _logger.LogInformation("DB Initilialization with Test Data...");
        if (await _db.Products.AnyAsync(Cancel).ConfigureAwait(false))
{
            _logger.LogInformation("Initialization of the DB with test data is not required");
            return;
        }

       
        await using var transaction = await _db.Database.BeginTransactionAsync(Cancel);

        _logger.LogInformation("Add Sections in DB...");
        await _db.Sections.AddRangeAsync(TestData.Sections, Cancel);
        await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Section] ON", Cancel);
        _db.SaveChangesAsync(Cancel);
        await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Section] OFF", Cancel);
        _logger.LogInformation("Add Sections in DB sucess");


        _logger.LogInformation("Add Brands in DB...");
        await _db.Brands.AddRangeAsync(TestData.Brands, Cancel);
        await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Brands] ON", Cancel);
        _db.SaveChangesAsync(Cancel);
        await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Brands] OFF", Cancel);
        _logger.LogInformation("Add Brands in DB sucess");

        _logger.LogInformation("Add Products in DB...");
        await _db.Products.AddRangeAsync(TestData.Products, Cancel);
        await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Products] ON", Cancel);
        _db.SaveChangesAsync(Cancel);
        await _db.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Products] OFF", Cancel);
        _logger.LogInformation("Add Products in DB sucess");


        await transaction.CommitAsync(Cancel);
    }
}
