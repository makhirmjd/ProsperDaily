using Microsoft.EntityFrameworkCore;
using ProsperDaily.Data;
using ProsperDaily.Data.Design;

DbContextOptionsBuilder<ApplicationDbContext> optionBuilder = new();
optionBuilder.UseSqlite($"Filename={DatabaseName}");

ApplicationDbContext context = new(optionBuilder.Options, new CurrentDesignUserService { });
context.Database.Migrate();