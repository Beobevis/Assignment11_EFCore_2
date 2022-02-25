using Microsoft.EntityFrameworkCore;
using Assignment11_EFCore_2.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment11_EFCore_2.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Category
        builder.Entity<Category>(e => e.ToTable("Categories"));
        builder.Entity<Category>().HasKey(e => e.Id);
        //builder.Entity<Category>().Property(e => e.Id).Has;
        builder.Entity<Category>().Property(e => e.Name).IsRequired();
        //c standfor categories
        builder.Entity<Category>()
        .HasMany(category => category.Products)
        .WithOne(product => product.Categories)
        .HasForeignKey(product => product.CategoryId)
        .IsRequired();

        var Category = new List<Category>{
            new Category{Id=1, Name="Food"},
            new Category{Id=2, Name="Cosmetic"},
            new Category{Id=3, Name="Drinks"},
            new Category{Id=4, Name="Fashion"},
            new Category{Id=5, Name="Technologies"},
            new Category{Id=6, Name="Funiture"}

        };
        builder.Entity<Category>().HasData(Category);

        //Chỉ cần khai báo 1 trong 2
        //Product
        builder.Entity<Product>(e => e.ToTable("Products"));

        // builder.Entity<Product>().HasKey(e => e.Id);
        // //builder.Entity<Category>().Property(e => e.Id).Has;
        // builder.Entity<Product>().Property(e => e.Name).IsRequired();
        // //c standfor categories
        // builder.Entity<Product>().HasOne(product => product.Category)
        // .WithMany(category => category.Products)
        // .HasForeignKey(product => product.CategoryId)
        // .IsRequired();
        var Products = new List<Product>{
            new Product{Id=1, Name="Candy",Manufacturer="Hai Ha", CategoryId=1},
            new Product{Id=2, Name="Lipstick",Manufacturer="Yves", CategoryId=2},
            new Product{Id=3, Name="Pepsi",Manufacturer="CocaCola", CategoryId=3},
            new Product{Id=4, Name="Sting",Manufacturer="Pepsi", CategoryId=3},
            new Product{Id=5, Name="Jeans",Manufacturer="DG", CategoryId=4},
            new Product{Id=6, Name="Iphone",Manufacturer="Apple", CategoryId=5},
            new Product{Id=7, Name="Chair",Manufacturer="Hoa Phat", CategoryId=6},
            new Product{Id=8, Name="Desk",Manufacturer="Hoa Phat", CategoryId=6}

        };
        builder.Entity<Product>().HasData(Products);

    }
    //Repository
    
    public virtual DbSet<Category>? Categories { get; set; }
    public virtual DbSet<Product>? Products { get; set; }
}
