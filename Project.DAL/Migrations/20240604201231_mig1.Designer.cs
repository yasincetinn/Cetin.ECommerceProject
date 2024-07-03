﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.DAL.ContextClasses;

#nullable disable

namespace Project.DAL.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240604201231_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "19c8dceb-cb64-4b9a-80c7-7b5992170593",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Project.ENTITIES.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid>("ActivationCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ActivationCode = new Guid("00000000-0000-0000-0000-000000000000"),
                            ConcurrencyStamp = "d3ff06e4-07c3-469f-9c51-b93d81ad789f",
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9901),
                            Email = "yasncetn8990@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "YASNCETN8990@GMAIL.COM",
                            NormalizedUserName = "YASN33",
                            PasswordHash = "AQAAAAIAAYagAAAAEJxOM5nHlUqWFAn92i/ujypEkLEa4Ftk2dKV/aQ/EgezsW+pFNIvP4kc/MDvPYf0Ig==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d99886bf-2f84-482b-adbc-a6d358395068",
                            Status = 1,
                            TwoFactorEnabled = false,
                            UserName = "yasn33"
                        });
                });

            modelBuilder.Entity("Project.ENTITIES.Models.AppUserProfile", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CategoryName = "Clothing",
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(5477),
                            Description = "Çarpan ab de layıkıyla.\nMagnam eos ama non un dağılımı quaerat iure et consequatur.\nVelit çakıl ipsa.\nKi ona türemiş aut magnam.\nDolores gülüyorum kapının ona lakin nesciunt veniam.\nAdresini doğru sayfası de bahar.\nYaptı orta bilgisayarı quia quis patlıcan commodi koştum et filmini.\nEve blanditiis umut ex.\nÇakıl mıknatıslı sinema anlamsız beatae architecto ducimus.\nVoluptatum lambadaki ut esse çobanın layıkıyla laboriosam ipsum fugit.",
                            Status = 1
                        },
                        new
                        {
                            ID = 2,
                            CategoryName = "Electronics",
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(6148),
                            Description = "Eius eius voluptas.\nRatione bilgiyasayarı eos teldeki incidunt eius gitti layıkıyla kalemi magni.\nEa ab sit sunt.\nOtobüs rem koyun alias sit düşünüyor incidunt enim bahar tv.\nReprehenderit değirmeni iure ut ratione kutusu cezbelendi laboriosam dolor.\nReprehenderit duyulmamış düşünüyor aut eum karşıdakine göze enim ve.\nAnlamsız qui nemo dolayı quam çarpan otobüs odio.\nQuia mıknatıslı sayfası ki masaya laboriosam totam.\nEt dicta alias quia qui.\nTv consequatur sayfası orta gül sıfat.",
                            Status = 1
                        },
                        new
                        {
                            ID = 3,
                            CategoryName = "Outdoors",
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(6445),
                            Description = "Mutlu dolayı amet rem illo odio aut gül.\nVoluptatem un eius mıknatıslı.\nQui et orta layıkıyla koştum quam adanaya yaptı consequuntur.\nVelit lambadaki umut non.\nVel dignissimos quam ve.\nMakinesi gördüm nisi neque voluptatem dolayı minima duyulmamış voluptatem.\nVoluptatum türemiş ducimus masanın sit magni consequatur magnam voluptatem.\nEt sed okuma aut eos değirmeni quasi autem.\nPatlıcan şafak ullam perferendis ratione layıkıyla sit hesap yaptı.\nSokaklarda veniam sit.",
                            Status = 1
                        },
                        new
                        {
                            ID = 4,
                            CategoryName = "Automotive",
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(6759),
                            Description = "Filmini adipisci ut commodi gidecekmiş beğendim.\nQuam dignissimos sed gördüm çakıl.\nVoluptatem kulu düşünüyor voluptas autem.\nCesurca architecto et totam değirmeni ab koşuyorlar bundan velit.\nDolor sed tv.\nDolayı numquam suscipit koyun aliquid explicabo bahar doğru lambadaki ut.\nSıla ut ratione ut veniam masanın bundan dolorem.\nMinima quis sit bilgisayarı makinesi ullam veritatis dağılımı ona quis.\nBilgisayarı sit exercitationem gördüm aut olduğu bundan.\nSarmal quia ama domates.",
                            Status = 1
                        },
                        new
                        {
                            ID = 5,
                            CategoryName = "Jewelery",
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(7038),
                            Description = "Corporis layıkıyla eaque voluptatum aliquam sıradanlıktan veniam düşünüyor.\nÇünkü beatae ratione.\nQui qui mıknatıslı filmini domates ut ea iure iure.\nUt teldeki lambadaki koyun sıradanlıktan tempora.\nYaptı accusantium otobüs laboriosam anlamsız cesurca sunt iusto bahar quam.\nGülüyorum biber dolore ipsam ipsa bilgisayarı laboriosam veniam sit tempora.\nQui dolores sıradanlıktan voluptatem ullam gazete eaque.\nYapacakmış velit quasi voluptatum beğendim modi odio beğendim voluptatem quia.\nDoloremque gazete türemiş sandalye doğru et ut sit koştum quia.\nAperiam ex çıktılar cesurca eos kutusu sayfası masaya gördüm bilgiyasayarı.",
                            Status = 1
                        },
                        new
                        {
                            ID = 6,
                            CategoryName = "Industrial",
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(7328),
                            Description = "Açılmadan ratione doğru sevindi koştum commodi blanditiis ad praesentium.\nBlanditiis totam ea kulu çorba hesap quia bilgisayarı kulu ad.\nİpsa kalemi kalemi şafak esse eum.\nEt değirmeni voluptatem çarpan.\nTeldeki fugit aliquid eve ducimus bahar.\nUt dolor quia explicabo.\nDoloremque consequuntur dolore batarya eos quia gül salladı inventore voluptatem.\nDeğerli quis ut ötekinden sit ama sıradanlıktan cesurca ki.\nKoştum kutusu rem sıfat consequatur vitae suscipit tempora.\nConsectetur molestiae ekşili illo mutlu.",
                            Status = 1
                        },
                        new
                        {
                            ID = 7,
                            CategoryName = "Music",
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(7623),
                            Description = "Ab ut öyle aut sıradanlıktan magnam mıknatıslı dolores.\nSandalye quia gördüm ab.\nÇünkü camisi vitae.\nBiber ullam suscipit dolore umut ama sit.\nMi velit iusto türemiş.\nSit layıkıyla et iure quis velit okuma.\nFilmini labore vel ut bahar ut dolorem.\nMasanın in anlamsız quis tempora gitti duyulmamış magni.\nVoluptate illo otobüs ekşili ışık enim gitti exercitationem.\nBilgiyasayarı teldeki gül çakıl gazete aut sunt voluptatem.",
                            Status = 1
                        },
                        new
                        {
                            ID = 8,
                            CategoryName = "Industrial",
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(7864),
                            Description = "Quaerat quis ad telefonu cesurca laboriosam totam voluptatem ab.\nBeatae eius neque düşünüyor.\nUt neque mıknatıslı.\nMakinesi nostrum incidunt dicta.\nVoluptatem ışık voluptatem.\nSequi quia et sunt voluptas.\nLabore amet fugit nostrum ullam veritatis molestiae ona autem bahar.\nÇorba quam alias bilgisayarı architecto quasi okuma dergi molestiae consequatur.\nCommodi dolores qui düşünüyor ut nisi sayfası blanditiis.\nÇünkü veniam camisi masanın bilgisayarı quam odio sevindi hesap.",
                            Status = 1
                        },
                        new
                        {
                            ID = 9,
                            CategoryName = "Automotive",
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(8152),
                            Description = "Odit voluptatem quis totam voluptatem nisi sit umut iure.\nÇorba amet modi sarmal eve okuma inventore ut.\nAdanaya gülüyorum koşuyorlar yazın dolayı quam qui.\nDolores doğru eum esse autem velit quasi quae qui qui.\nUllam layıkıyla blanditiis aliquid.\nİusto vitae açılmadan non.\nKarşıdakine masanın totam quaerat sayfası ad labore lakin.\nQuasi bilgisayarı için mutlu vel dolorem beatae totam doğru.\nDağılımı totam enim sit ona sequi otobüs.\nKalemi rem dicta kapının gitti veritatis ex dışarı.",
                            Status = 1
                        },
                        new
                        {
                            ID = 10,
                            CategoryName = "Baby",
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(8407),
                            Description = "Ea kapının masaya exercitationem tv quia aperiam çünkü.\nUt ki ut numquam sequi rem laudantium ve sevindi.\nKapının salladı umut ratione cesurca bilgiyasayarı domates quasi.\nGidecekmiş okuma adresini.\nNon eos iusto aspernatur qui suscipit mutlu veritatis sit.\nYapacakmış adipisci patlıcan çıktılar öyle düşünüyor.\nGöze in gül cezbelendi cesurca.\nVoluptas adipisci consequatur mi molestiae sequi lakin.\nIşık koyun adresini sed esse corporis ipsa çakıl layıkıyla voluptatem.\nAçılmadan odio gidecekmiş accusantium quia mıknatıslı sit consequatur.",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("AppUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceOfOrder")
                        .HasColumnType("money");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AppUserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CategoryID = 1,
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(8763),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Awesome Fresh Shirt",
                            Status = 1,
                            UnitPrice = 92.48m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 2,
                            CategoryID = 2,
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9061),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Small Metal Ball",
                            Status = 1,
                            UnitPrice = 893.02m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 3,
                            CategoryID = 3,
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9136),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Unbranded Wooden Chips",
                            Status = 1,
                            UnitPrice = 282.20m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 4,
                            CategoryID = 4,
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9199),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Tasty Fresh Pants",
                            Status = 1,
                            UnitPrice = 616.86m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 5,
                            CategoryID = 5,
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9256),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Unbranded Granite Tuna",
                            Status = 1,
                            UnitPrice = 707.77m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 6,
                            CategoryID = 6,
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9353),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Licensed Rubber Shoes",
                            Status = 1,
                            UnitPrice = 149.29m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 7,
                            CategoryID = 7,
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9413),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Generic Concrete Table",
                            Status = 1,
                            UnitPrice = 764.57m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 8,
                            CategoryID = 8,
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9471),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Generic Frozen Chair",
                            Status = 1,
                            UnitPrice = 117.26m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 9,
                            CategoryID = 9,
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9525),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Handmade Fresh Sausages",
                            Status = 1,
                            UnitPrice = 590.84m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 10,
                            CategoryID = 10,
                            CreatedDate = new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9582),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Licensed Metal Ball",
                            Status = 1,
                            UnitPrice = 831.21m,
                            UnitsInStock = 100
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Project.ENTITIES.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Project.ENTITIES.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.ENTITIES.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Project.ENTITIES.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Project.ENTITIES.Models.AppUserProfile", b =>
                {
                    b.HasOne("Project.ENTITIES.Models.AppUser", "AppUser")
                        .WithOne("Profile")
                        .HasForeignKey("Project.ENTITIES.Models.AppUserProfile", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Order", b =>
                {
                    b.HasOne("Project.ENTITIES.Models.AppUser", "AppUser")
                        .WithMany("Orders")
                        .HasForeignKey("AppUserID");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.OrderDetail", b =>
                {
                    b.HasOne("Project.ENTITIES.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.ENTITIES.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Product", b =>
                {
                    b.HasOne("Project.ENTITIES.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.AppUser", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Profile")
                        .IsRequired();
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Project.ENTITIES.Models.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
