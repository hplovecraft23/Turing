using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TuringApi.mySQL
{
    public partial class TuringContext : DbContext
    {
        public TuringContext()
        {
        }

        public TuringContext(DbContextOptions<TuringContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Cashflow> Cashflow { get; set; }
        public virtual DbSet<CashflowCloses> CashflowCloses { get; set; }
        public virtual DbSet<CashflowTypes> CashflowTypes { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CategoriesSub> CategoriesSub { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<StockMovTypes> StockMovTypes { get; set; }
        public virtual DbSet<StockMovs> StockMovs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=mysql;port=3306;user=root;password=Example;database=Turing");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.IdBrands);

                entity.ToTable("brands", "turing");

                entity.HasIndex(e => e.IdBrands)
                    .HasName("idBrands_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdBrands)
                    .HasColumnName("idBrands")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrandName)
                    .HasColumnName("Brand_Name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cashflow>(entity =>
            {
                entity.HasKey(e => e.IdCashFlow);

                entity.ToTable("cashflow", "turing");

                entity.HasIndex(e => e.CashFlowClosesIdCashFlowCloses)
                    .HasName("fk_CashFlow_CashFlow_Closes1_idx");

                entity.HasIndex(e => e.CashFlowTypesIdCashFlowTypes)
                    .HasName("fk_CashFlow_CashFlow_Types1_idx");

                entity.HasIndex(e => e.IdCashFlow)
                    .HasName("idCashFlow_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.StockMovsIdStockMovs)
                    .HasName("fk_CashFlow_Stock_Movs1_idx");

                entity.Property(e => e.IdCashFlow)
                    .HasColumnName("idCashFlow")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CashFlowAmmount).HasColumnName("CashFlow_Ammount");

                entity.Property(e => e.CashFlowClosesIdCashFlowCloses)
                    .HasColumnName("CashFlow_Closes_idCashFlow_Closes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CashFlowIsClosed)
                    .HasColumnName("CashFlow_IsCLosed")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.CashFlowTime).HasColumnName("CashFlow_Time");

                entity.Property(e => e.CashFlowTypesIdCashFlowTypes)
                    .HasColumnName("CashFlow_Types_idCashFlow_Types")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CashFlowcol)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CashflowUser)
                    .HasColumnName("Cashflow_User")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.StockMovsIdStockMovs)
                    .HasColumnName("Stock_Movs_idStock_Movs")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CashFlowClosesIdCashFlowClosesNavigation)
                    .WithMany(p => p.Cashflow)
                    .HasForeignKey(d => d.CashFlowClosesIdCashFlowCloses)
                    .HasConstraintName("fk_CashFlow_CashFlow_Closes1");

                entity.HasOne(d => d.CashFlowTypesIdCashFlowTypesNavigation)
                    .WithMany(p => p.Cashflow)
                    .HasForeignKey(d => d.CashFlowTypesIdCashFlowTypes)
                    .HasConstraintName("fk_CashFlow_CashFlow_Types1");

                entity.HasOne(d => d.StockMovsIdStockMovsNavigation)
                    .WithMany(p => p.Cashflow)
                    .HasForeignKey(d => d.StockMovsIdStockMovs)
                    .HasConstraintName("fk_CashFlow_Stock_Movs1");
            });

            modelBuilder.Entity<CashflowCloses>(entity =>
            {
                entity.HasKey(e => e.IdCashFlowCloses);

                entity.ToTable("cashflow_closes", "turing");

                entity.HasIndex(e => e.IdCashFlowCloses)
                    .HasName("idCashFlow_Closes_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdCashFlowCloses)
                    .HasColumnName("idCashFlow_Closes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CashFlowClosesDate).HasColumnName("CashFlow_Closes_Date");

                entity.Property(e => e.CashFlowClosesUsr)
                    .HasColumnName("CashFlow_Closes_Usr")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.CashFlowClosescol)
                    .HasColumnName("CashFlow_Closescol")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CashflowTypes>(entity =>
            {
                entity.HasKey(e => e.IdCashFlowTypes);

                entity.ToTable("cashflow_types", "turing");

                entity.HasIndex(e => e.IdCashFlowTypes)
                    .HasName("idCashFlow_Types_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdCashFlowTypes)
                    .HasColumnName("idCashFlow_Types")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CashFlowTypesName)
                    .HasColumnName("CashFlow_Types_Name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.IdCategories);

                entity.ToTable("categories", "turing");

                entity.HasIndex(e => e.IdCategories)
                    .HasName("idCategories_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdCategories)
                    .HasColumnName("idCategories")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoriesName)
                    .HasColumnName("Categories_Name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoriesSub>(entity =>
            {
                entity.HasKey(e => e.IdCategoriesSub);

                entity.ToTable("categories_sub", "turing");

                entity.HasIndex(e => e.CategoriesIdCategories)
                    .HasName("fk_Categories_sub_Categories1_idx");

                entity.HasIndex(e => e.IdCategoriesSub)
                    .HasName("idCategories_sub_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdCategoriesSub)
                    .HasColumnName("idCategories_sub")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoriesIdCategories)
                    .HasColumnName("Categories_idCategories")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoriesSubName)
                    .HasColumnName("Categories_sub_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoriesIdCategoriesNavigation)
                    .WithMany(p => p.CategoriesSub)
                    .HasForeignKey(d => d.CategoriesIdCategories)
                    .HasConstraintName("fk_Categories_sub_Categories1");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.IdCustomers);

                entity.ToTable("customers", "turing");

                entity.HasIndex(e => e.IdCustomers)
                    .HasName("idCustomers_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdCustomers)
                    .HasColumnName("idCustomers")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomersAddressDetails)
                    .HasColumnName("Customers_Address_Details")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersAddressNumber)
                    .HasColumnName("Customers_Address_Number")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersAddressStreet)
                    .HasColumnName("Customers_Address_Street")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersCuit)
                    .HasColumnName("Customers_Cuit")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersEmail)
                    .HasColumnName("Customers_Email")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CustomersName)
                    .HasColumnName("Customers_Name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.IdStock);

                entity.ToTable("stock", "turing");

                entity.HasIndex(e => e.BrandsIdBrands)
                    .HasName("fk_Stock_Brands1_idx");

                entity.HasIndex(e => e.CategoriesIdCategories)
                    .HasName("fk_Stock_Categories1_idx");

                entity.HasIndex(e => e.CategoriesSubIdCategoriesSub)
                    .HasName("fk_Stock_Categories_sub1_idx");

                entity.HasIndex(e => e.IdStock)
                    .HasName("idStock_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdStock)
                    .HasColumnName("idStock")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrandsIdBrands)
                    .HasColumnName("Brands_idBrands")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoriesIdCategories)
                    .HasColumnName("Categories_idCategories")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoriesSubIdCategoriesSub)
                    .HasColumnName("Categories_sub_idCategories_sub")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StockBuyPrice).HasColumnName("Stock_BuyPrice");

                entity.Property(e => e.StockName)
                    .HasColumnName("Stock_Name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.StockSellRatio).HasColumnName("Stock_Sell_Ratio");

                entity.HasOne(d => d.BrandsIdBrandsNavigation)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.BrandsIdBrands)
                    .HasConstraintName("fk_Stock_Brands1");

                entity.HasOne(d => d.CategoriesIdCategoriesNavigation)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.CategoriesIdCategories)
                    .HasConstraintName("fk_Stock_Categories1");

                entity.HasOne(d => d.CategoriesSubIdCategoriesSubNavigation)
                    .WithMany(p => p.Stock)
                    .HasForeignKey(d => d.CategoriesSubIdCategoriesSub)
                    .HasConstraintName("fk_Stock_Categories_sub1");
            });

            modelBuilder.Entity<StockMovTypes>(entity =>
            {
                entity.HasKey(e => e.IdStockMovTypes);

                entity.ToTable("stock_mov_types", "turing");

                entity.HasIndex(e => e.IdStockMovTypes)
                    .HasName("idStock_Mov_Types_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdStockMovTypes)
                    .HasColumnName("idStock_Mov_Types")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StockMovTypeName)
                    .HasColumnName("Stock_Mov_Type_Name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StockMovs>(entity =>
            {
                entity.HasKey(e => e.IdStockMovs);

                entity.ToTable("stock_movs", "turing");

                entity.HasIndex(e => e.CustomersIdCustomers)
                    .HasName("fk_Stock_Movs_Customers1_idx");

                entity.HasIndex(e => e.IdStockMovs)
                    .HasName("idStock_Movs_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.StockIdStock)
                    .HasName("fk_Stock_Movs_Stock1_idx");

                entity.HasIndex(e => e.StockMovTypesIdStockMovTypes)
                    .HasName("fk_Stock_Movs_Stock_Mov_Types1_idx");

                entity.HasIndex(e => e.StockSellId)
                    .HasName("Stock_Sell_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdStockMovs)
                    .HasColumnName("idStock_Movs")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CustomersIdCustomers)
                    .HasColumnName("Customers_idCustomers")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StockIdStock)
                    .HasColumnName("Stock_idStock")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StockMovAmount)
                    .HasColumnName("Stock_Mov_Amount")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StockMovPrice).HasColumnName("Stock_Mov_Price");

                entity.Property(e => e.StockMovTime).HasColumnName("Stock_Mov_Time");

                entity.Property(e => e.StockMovTypesIdStockMovTypes)
                    .HasColumnName("Stock_Mov_Types_idStock_Mov_Types")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StockMovUsr)
                    .HasColumnName("Stock_Mov_Usr")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.StockMovsSellDiscount).HasColumnName("Stock_Movs_Sell_Discount");

                entity.Property(e => e.StockMovscol)
                    .HasColumnName("Stock_Movscol")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.StockSellId)
                    .HasColumnName("Stock_Sell_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CustomersIdCustomersNavigation)
                    .WithMany(p => p.StockMovs)
                    .HasForeignKey(d => d.CustomersIdCustomers)
                    .HasConstraintName("fk_Stock_Movs_Customers1");

                entity.HasOne(d => d.StockIdStockNavigation)
                    .WithMany(p => p.StockMovs)
                    .HasForeignKey(d => d.StockIdStock)
                    .HasConstraintName("fk_Stock_Movs_Stock1");

                entity.HasOne(d => d.StockMovTypesIdStockMovTypesNavigation)
                    .WithMany(p => p.StockMovs)
                    .HasForeignKey(d => d.StockMovTypesIdStockMovTypes)
                    .HasConstraintName("fk_Stock_Movs_Stock_Mov_Types1");
            });
        }
    }
}
