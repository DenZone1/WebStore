

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


using WebStore.DAL.Context;
using WebStore.Domain.Entites.Identity;

namespace WebStore.Data;

public class DbInitializer
{
    private readonly WebStoreDB _db;
    private readonly UserManager<User> _UserManager;
    private readonly RoleManager<Role> _RoleManager;
    private readonly ILogger<DbInitializer> _logger;

    public DbInitializer(WebStoreDB db,
        UserManager<User> UserManager,
        RoleManager<Role> RoleManager,
        ILogger<DbInitializer> Logger)
    {
        _db = db;
        _UserManager = UserManager;
        _RoleManager = RoleManager;
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

        if (AddTestData)
        {
             await InitializeProductsAsync(Cancel);
            await InitializeEmployeesAsync(Cancel);
        }

        await InitializeIdentityAsync(Cancel);

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
            child_section.Parent = sections_pool[(int)child_section.ParentId!];//была ошибка!

        foreach (var product in TestData.Products)
        {
            product.Section = sections_pool[product.SectionId];
            if (product.BrandId is { } brand_id)
                product.Brand = brands_pool[brand_id];

            product.Id = 0;
            product.SectionId = 0;
            product.BrandId = null;
        }

        foreach (var brand in TestData.Brands)
        brand.Id = 0;

        foreach (var section in TestData.Sections)
        {
            section.Id = 0;
            section.ParentId = null;
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

    private async Task InitializeEmployeesAsync(CancellationToken Cancel)
    {
        if (await _db.Employees.AnyAsync(Cancel).ConfigureAwait(false))
        {
            _logger.LogInformation("DB Initilialization tables emmployees no need");
        return;
        }
        _logger.LogInformation("DB Initilialization tables emmployees...");

        foreach (var employee in TestData.Employees)
            employee.Id = 0;

        await _db.AddRangeAsync(TestData.Employees, Cancel);
        await _db.SaveChangesAsync(Cancel);

        _logger.LogInformation("DB Initilialization tables emmployees sucess");



        foreach (var child_section in TestData.Sections.Where(s => s.ParentId is not null))
            child_section.Parent = sections_pool[child_section.Id];

        foreach (var product in TestData.Products)
        {
            product.Section = sections_pool[product.SectionId];
            if(product.BrandId is { } brand_id)
                product.Brand = brands_pool[brand_id];

            product.Id = 0;
            product.SectionId = 0;
            product.BrandId = null;
        }
        foreach(var brand in TestData.Brands)
            brand.Id = 0;

        foreach (var section in TestData.Sections)
        {
            section.Id = 0;
            section.ParentId = 0;
        }


        await using var transaction = await _db.Database.BeginTransactionAsync(Cancel);

        _logger.LogInformation("Add DATA in DataBase...");
        await _db.Sections.AddRangeAsync(TestData.Sections, Cancel);
        await _db.Brands.AddRangeAsync(TestData.Brands, Cancel);
        await _db.Products.AddRangeAsync(TestData.Products, Cancel);

        await _db.SaveChangesAsync(Cancel);
        _logger.LogInformation("Add DATA in DataBase sucess");

        await transaction.CommitAsync(Cancel);
        _logger.LogInformation("Tranzaction in DataBase sucess");

    }
    private async Task InitializeIdentityAsync(CancellationToken Cancel) 
    {


        _logger.LogInformation("DB Initilialization system of Identity...");

        async Task CheckRoleAsync(string RoleName)
        {
             if (await _RoleManager.RoleExistsAsync(RoleName))
                _logger.LogInformation("Role {0} exeest in DB", RoleName);
            else
             {
                    _logger.LogInformation("Role {0} don`t exeest is DB. Creating... ", RoleName);
                    await _RoleManager.CreateAsync(new Role {Name= RoleName });
                    _logger.LogInformation("Role {0}  Creating sucess ", RoleName);
             }
        }

        await CheckRoleAsync(Role.Administrator);
        await CheckRoleAsync(Role.User);

        if (await _UserManager.FindByNameAsync(User.Administrator) is null)
        {
            _logger.LogInformation("User {0} don`t exeest is DB. Creating... ", User.Administrator);

            var admin = new User
            {
                UserName = User.Administrator,
            };

            var creation_result = await _UserManager.CreateAsync(admin, User.AdminPassword);
            if (creation_result.Succeeded)
            {
                _logger.LogInformation("User {0}  Created ", User.Administrator);
                await _UserManager.AddToRoleAsync(admin, Role.Administrator);
                _logger.LogInformation("User {0}  Created, Role - Administrator ", User.Administrator);
            }
            else
            {
                var errors = creation_result.Errors.Select(e => e.Description);
                var error_message = String.Join(", ", errors);
                _logger.LogError("{0} don`t creating. Error {1}", User.Administrator, error_message);

                throw new InvalidOperationException($"Can`t creatr {User.Administrator}, Error {error_message}");
            }


        }
        else
        {  
            _logger.LogInformation("User {0} Exeest ", User.Administrator);
        }
           


        _logger.LogInformation("DB Initilialization system of Identity sucess");
    }


}
