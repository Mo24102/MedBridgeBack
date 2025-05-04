using MedBridge.Models;
using MedBridge.Models.ForgotPassword;
using MedBridge.Models.Messages;
using MedBridge.Models.OrderModels;
using MedBridge.Models.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace MoviesApi.models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions <ApplicationDbContext > options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // منع الحذف التتابعي بين Order و User
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()  // No navigation property for User, hence WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict); // منع الحذف التتابعي عند حذف المستخدم

            // السماح بالحذف التتابعي بين OrderItem و Order
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // السماح بالحذف التتابعي في OrderItem عند حذف Order

            // منع الحذف التتابعي بين OrderItem و Product
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // منع الحذف التتابعي للمنتج عند حذف OrderItem

            // مثال على السماح بالحذف التتابعي بين ProductModel و SubCategory
            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.SubCategory)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SubCategoryId)
                .OnDelete(DeleteBehavior.NoAction); // لا شيء يحدث عند حذف SubCategory

            // الحذف التتابعي بين Category و SubCategory
            modelBuilder.Entity<subCategory>()
                .HasOne(s => s.Category)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // السماح بالحذف التتابعي بين Category و SubCategory

            base.OnModelCreating(modelBuilder);
        }







        public DbSet<Category>Categories { get; set; }

        public DbSet<subCategory> subCategories { get; set; }

        public DbSet<ProductModel> Products { get; set; }

        public DbSet<User> users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<CartModel> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<Favourite> Favourites { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DbSet<PasswordResetOtp> PasswordResetOtp { get; set; }


        public DbSet<WorkType> WorkType { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        public DbSet<MedicalSpecialty> MedicalSpecialties { get; set; }
    }
}
