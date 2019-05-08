using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EcommerShop.Models.ModelBusiness
{
    public partial class ECommerceStoreContext : DbContext
    {
        public ECommerceStoreContext()
        {
           
        }

        public ECommerceStoreContext(DbContextOptions<ECommerceStoreContext> options)
            : base(options)
        {
           
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Attribute> Attribute { get; set; }
        public virtual DbSet<AttributeSet> AttributeSet { get; set; }
        public virtual DbSet<AttributeValue> AttributeValue { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<JointAttributeSet> JointAttributeSet { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderLine> OrderLine { get; set; }
        public virtual DbSet<Pricing> Pricing { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<ShopTrading> ShopTrading { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-PUC5QPE;Initial Catalog=ECommerceStore;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FullName).HasColumnType("text");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(10);

                entity.Property(e => e.DataType)
                    .HasColumnName("data_type")
                    .HasMaxLength(20);

                entity.Property(e => e.DefaultValue)
                    .HasColumnName("default_value")
                    .HasColumnType("text");

                entity.Property(e => e.IsHighlighted).HasColumnName("is_highlighted");

                entity.Property(e => e.IsRequired).HasColumnName("is_required");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<AttributeSet>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<AttributeValue>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttributeCode)
                    .HasColumnName("attribute_code")
                    .HasMaxLength(10);

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("text");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("text");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.AttributeValue)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Attribute__produ__5FB337D6");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment1)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasColumnType("text");

                entity.Property(e => e.CommentDate)
                    .HasColumnName("comment_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EditedDate)
                    .HasColumnName("edited_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.OnwerId)
                    .IsRequired()
                    .HasColumnName("onwer_id")
                    .HasMaxLength(450);

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.TimeChanged).HasColumnName("time_changed");

                entity.HasOne(d => d.Onwer)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.OnwerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_AspNetUsers");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Product");
            });

            modelBuilder.Entity<JointAttributeSet>(entity =>
            {
                entity.HasKey(e => new { e.AttributeSetId, e.AttributeId });

                entity.Property(e => e.AttributeSetId).HasColumnName("attribute_set_id");

                entity.Property(e => e.AttributeId).HasColumnName("attribute_id");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.JointAttributeSet)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JointAttributeSet_Attribute");

                entity.HasOne(d => d.AttributeSet)
                    .WithMany(p => p.JointAttributeSet)
                    .HasForeignKey(d => d.AttributeSetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JointAttributeSet_AttributeSet");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AreSuppliersVerify).HasColumnName("are_suppliers_verify");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasMaxLength(450);

                entity.Property(e => e.ItemsShipDate)
                    .HasColumnName("items_ship_date")
                    .HasColumnType("date");

                entity.Property(e => e.ItemsSupplied).HasColumnName("items_supplied");

                entity.Property(e => e.PromotionId).HasColumnName("promotion_id");

                entity.Property(e => e.ToAddress)
                    .IsRequired()
                    .HasColumnName("to_address")
                    .HasColumnType("text");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_AspNetUsers");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId, e.TimeChanged });

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.TimeChanged)
                    .HasColumnName("time_changed")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EditedDate)
                    .HasColumnName("edited_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.IsShipWh).HasColumnName("is_ship_wh");

                entity.Property(e => e.IsSupplierConfirm).HasColumnName("is_supplier_confirm");

                entity.Property(e => e.NumberProduct).HasColumnName("number_product");

                entity.Property(e => e.ShipDate)
                    .HasColumnName("ship_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLine)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderLine_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderLine)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderLine_Product");
            });

            modelBuilder.Entity<Pricing>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.TimeChanged });

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.TimeChanged)
                    .HasColumnName("time_changed")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ApplyDate)
                    .HasColumnName("apply_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.PromotionId).HasColumnName("promotion_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Pricing)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pricing_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttributeSetId).HasColumnName("attribute_set_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.OwnerId)
                    .IsRequired()
                    .HasColumnName("owner_id")
                    .HasMaxLength(450);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("text");

                entity.Property(e => e.Vote)
                    .HasColumnName("vote")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.AttributeSet)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.AttributeSetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_AttributeSet");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_AspNetUsers");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                     .ValueGeneratedOnAdd();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("text");

                entity.Property(e => e.TradingCode)
                    .IsRequired()
                    .HasColumnName("trading_code")
                    .HasColumnType("text");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Shop)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Shop__user_id__6B24EA82");
            });

            modelBuilder.Entity<ShopTrading>(entity =>
            {
                entity.HasKey(e => new { e.ShopId, e.ProductId, e.TimeChange });

                entity.Property(e => e.ShopId).HasColumnName("shop_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.TimeChange)
                    .HasColumnName("time_change")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ShopTrading)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopTrading_Product");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ShopTrading)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopTrading_Shop");
            });
        }
    }
}
