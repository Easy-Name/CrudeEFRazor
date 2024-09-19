using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data;

public class ApplicationDbContextBkp : IdentityDbContext
{
    public ApplicationDbContextBkp(DbContextOptions<ApplicationDbContextBkp> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; } = default!;
    public DbSet<Premium> Premium { get; set; } = default!;
}
