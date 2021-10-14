using App.Template.Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Template.Infra.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options){}
        public DbSet<UserModel> Users { get; private set;}
    }
}