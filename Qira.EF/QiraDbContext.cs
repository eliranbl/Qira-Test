using Microsoft.EntityFrameworkCore;
using Qira.Domain.Invoices;
using System.Reflection;

namespace Qira.EF;

/// <summary>
/// Qira DB Context.
/// </summary>
public class QiraDbContext : DbContext
{
    /// <summary>
    /// Invoices.
    /// </summary>
    public DbSet<Invoice> Invoices { get; set; }

    /// <summary>
    /// Creates context.
    /// </summary>
    /// <param name="options">Context options.</param>
    public QiraDbContext(DbContextOptions<QiraDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetAssembly(typeof(QiraDbContext))!);
    }
}