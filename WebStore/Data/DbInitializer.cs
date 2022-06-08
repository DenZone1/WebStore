

using Microsoft.EntityFrameworkCore;


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

    public async Task InitializeAsync(
        bool RemoveBefore,
          bool AddTestData,
        CancellationToken Cancel = default)
    {
        _logger.LogInformation("DB Initilialization...");

        if (RemoveBefore)
            await RemoveAsync(Cancel).ConfigureAwait(false);


        // await _db.Database.EnsureCreatedAsync(Cancel).ConfigureAwait(false);


        _logger.LogInformation("The use of DB migrations...");
        await _db.Database.MigrateAsync(Cancel).ConfigureAwait(false);
        _logger.LogInformation("DB migrations sucess");

        if(AddTestData)
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



        var sections_pool = TestData.Sections.ToDictionary(s => s.Id);
        var brands_pool = TestData.Brands.ToDictionary(b => b.Id);


        foreach (var child_section in TestData.Sections.Where(s => s.ParentId is not null))
            child_section.Parent = sections_pool[child_section.Id];

        foreach (var product in TestData.Products)
        {
            product.Section = sections_pool[product.SectionId];
            if (product.BrandId is { } brand_id)
                product.Brand = brands_pool[brand_id];

            product.Id = 0;
            product.SectionId = 0;
            product.BrandId = 0;
        }

        foreach (var brand in TestData.Brands)
        brand.Id = 0;

        foreach (var section in TestData.Sections)
        {
            section.Id = 0;
            section.ParentId = 0;
        }    

        await using var transaction = await _db.Database.BeginTransactionAsync(Cancel);
        _logger.LogInformation("Add DATA in DB...");
        await _db.Sections.AddRangeAsync(TestData.Sections, Cancel);
        await _db.Brands.AddRangeAsync(TestData.Brands, Cancel);
        await _db.Products.AddRangeAsync(TestData.Products, Cancel);

        await _db.SaveChangesAsync(Cancel);
        _logger.LogInformation("Add DATA in DB sucess");

        await transaction.CommitAsync(Cancel);
    }
}
