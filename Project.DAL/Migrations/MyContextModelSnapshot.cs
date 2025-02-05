﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.DAL.ContextClasses;

#nullable disable

namespace Project.DAL.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            ConcurrencyStamp = "15a1a333-6edb-433f-b5e0-e3943a40cf50",
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
                            ConcurrencyStamp = "be8eb833-14ef-4577-83ef-ebb7760fc462",
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(1824),
                            Email = "yasncetn8990@outlook.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "YASNCETN8990@OUTLOOK.COM",
                            NormalizedUserName = "YASN33",
                            PasswordHash = "AQAAAAIAAYagAAAAEGkvUCJwTdpi8BZhasYp0mNwfmVd+OGWQGIbSr8rhQU0jyGGHOTB06RzdSQ+3Tl9gw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6f85178a-fb02-4c73-87cc-08f3be6dc31a",
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
                            CategoryName = "Shoes",
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(6423),
                            Description = "Teldeki çakıl kapının nesciunt eum doğru olduğu labore.\nQuis magni eum dolayı accusantium.\nEsse dolore kutusu.\nÇarpan okuma kutusu.\nSed quia uzattı sunt dolayı corporis ötekinden.\nEius doğru ut autem camisi aspernatur nisi dicta.\nVeritatis hesap eaque bilgisayarı voluptatem.\nVelit çorba eaque hesap.\nDolayı quia dolores tempora minima kutusu.\nBundan masanın ex sıfat çorba açılmadan voluptatem.",
                            Status = 1
                        },
                        new
                        {
                            ID = 2,
                            CategoryName = "Jewelery",
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(7287),
                            Description = "İllo hesap de açılmadan reprehenderit.\nDolores laboriosam ea tv masanın batarya.\nAliquam nisi gitti aut.\nİpsa gidecekmiş doğru.\nAçılmadan sıfat ratione sed.\nOkuma nisi tv cezbelendi ut un voluptatem ipsum consequuntur.\nBundan odit modi koşuyorlar batarya voluptatem orta lambadaki sit.\nVeritatis voluptatem eve.\nCorporis çakıl uzattı eos değerli masanın consequatur ekşili.\nSandalye karşıdakine aliquam voluptas.",
                            Status = 1
                        },
                        new
                        {
                            ID = 3,
                            CategoryName = "Beauty",
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(7605),
                            Description = "Dignissimos voluptatem ut quia ve ea.\nSarmal architecto çünkü koştum eaque enim in voluptatem et.\nGöze olduğu sayfası ea yaptı yapacakmış eaque.\nExercitationem magni ama totam.\nGülüyorum sandalye eaque.\nNon aliquam et nemo anlamsız iure magnam molestiae odio modi.\nMinima magni autem odit commodi ut otobüs yaptı deleniti.\nİpsa dignissimos uzattı aut teldeki ut nihil consectetur.\nGitti doğru mi sinema velit.\nKoyun duyulmamış magnam sed sevindi ipsum non ışık öyle.",
                            Status = 1
                        },
                        new
                        {
                            ID = 4,
                            CategoryName = "Baby",
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(7976),
                            Description = "Layıkıyla gül totam mıknatıslı.\nCorporis vel voluptatem.\nAd gazete magni deleniti amet layıkıyla.\nBilgisayarı mıknatıslı esse göze sıla consequuntur veritatis dergi sinema.\nİusto dolayı ipsum.\nQuia eaque mıknatıslı.\nQuia ducimus adipisci architecto quia sit quae duyulmamış koştum.\nEkşili ona filmini dignissimos yaptı.\nExplicabo sıradanlıktan iure voluptatem nihil adanaya qui batarya numquam.\nAut veritatis sevindi ut commodi ışık ea cezbelendi.",
                            Status = 1
                        },
                        new
                        {
                            ID = 5,
                            CategoryName = "Outdoors",
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(8295),
                            Description = "Blanditiis cesurca şafak numquam nesciunt ad qui labore ışık.\nQuis yazın dolores labore.\nUt çarpan ea oldular masanın sevindi rem ab.\nQuis sarmal öyle okuma minima şafak aspernatur mutlu çakıl balıkhaneye.\nSıfat lakin sinema esse un ekşili nesciunt teldeki praesentium çakıl.\nVitae gördüm adresini camisi gidecekmiş et ipsam.\nAccusantium numquam sed.\nAma sıfat patlıcan ut sıla enim ipsa corporis layıkıyla.\nVoluptas aut voluptate çarpan reprehenderit sequi neque dolorem.\nAnlamsız için sed çobanın vitae sayfası ötekinden dolores veniam gazete.",
                            Status = 1
                        },
                        new
                        {
                            ID = 6,
                            CategoryName = "Baby",
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(8694),
                            Description = "Doloremque voluptatum de cezbelendi de batarya makinesi qui.\nUt makinesi commodi umut totam quis aut bundan eaque ratione.\nSinema quis fugit aut gitti eaque autem.\nArchitecto koştum ex ekşili.\nAliquid commodi et eve çıktılar.\nAnlamsız un bahar enim de tv dicta.\nFilmini quia karşıdakine eve nesciunt sunt qui nihil dicta ipsum.\nMagni salladı gül iusto deleniti.\nArchitecto modi sunt bilgisayarı sit ipsum quis sevindi aut.\nLambadaki consectetur voluptas nemo de beatae ex.",
                            Status = 1
                        },
                        new
                        {
                            ID = 7,
                            CategoryName = "Home",
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(9043),
                            Description = "Ducimus nesciunt voluptate balıkhaneye.\nAut karşıdakine değirmeni uzattı masaya.\nOdio mutlu totam çakıl doloremque molestiae mutlu masaya.\nSevindi gazete kapının quae nesciunt sarmal sıfat voluptatem.\nKoyun cezbelendi nisi.\nQuia quasi in tv laudantium odio açılmadan ratione sequi.\nConsequuntur et voluptatum ea sevindi göze quis ducimus illo.\nSıfat aut ut non teldeki.\nEaque beatae sıfat gülüyorum hesap quasi.\nCommodi aliquam eum corporis incidunt ratione eos voluptas.",
                            Status = 1
                        },
                        new
                        {
                            ID = 8,
                            CategoryName = "Clothing",
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(9323),
                            Description = "Layıkıyla voluptatem eve quis koşuyorlar reprehenderit ışık sıradanlıktan.\nDağılımı bahar sed molestiae tv de rem.\nŞafak dağılımı ekşili.\nConsectetur masaya çobanın ea ut perferendis.\nGördüm camisi gidecekmiş quis cezbelendi magnam sokaklarda öyle voluptatum.\nEt layıkıyla explicabo velit voluptatem hesap.\nGöze tv teldeki eos un dolayı layıkıyla.\nAperiam batarya aut quae.\nEum ipsum odio.\nEkşili praesentium eos sinema commodi consequatur.",
                            Status = 1
                        },
                        new
                        {
                            ID = 9,
                            CategoryName = "Music",
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(9654),
                            Description = "Esse numquam ışık sed makinesi.\nSunt et dolore aliquam.\nOrta dağılımı yapacakmış masanın tempora nostrum.\nDüşünüyor sarmal gülüyorum esse consequatur in göze.\nDoğru olduğu laudantium sayfası sunt adipisci.\nAut veritatis ipsum labore amet kulu architecto incidunt.\nKalemi mi consequuntur nesciunt beğendim.\nSalladı değirmeni voluptatem bahar sit un laudantium balıkhaneye.\nDeğerli et adanaya enim.\nBiber kapının lakin consequuntur.",
                            Status = 1
                        },
                        new
                        {
                            ID = 10,
                            CategoryName = "Games",
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(9933),
                            Description = "Lambadaki çünkü koştum nemo quis suscipit voluptatem laboriosam consequatur.\nVoluptate oldular sevindi göze.\nSıfat çorba doloremque bundan filmini incidunt inventore tempora voluptate.\nTüremiş otobüs batarya sed ipsam consequatur salladı doloremque et ona.\nOdit velit sarmal.\nÇakıl çıktılar ea layıkıyla quasi.\nSıla neque consequuntur rem nemo ut dolor lakin camisi non.\nEa masaya aliquid adipisci laudantium umut patlıcan sevindi.\nEkşili sed sıradanlıktan qui quia dolore anlamsız.\nİure voluptatem bundan çıktılar çünkü quae ki.",
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
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(368),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Practical Metal Soap",
                            Status = 1,
                            UnitPrice = 594.86m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 2,
                            CategoryID = 2,
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(757),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Practical Steel Cheese",
                            Status = 1,
                            UnitPrice = 712.23m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 3,
                            CategoryID = 3,
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(846),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Handmade Fresh Pizza",
                            Status = 1,
                            UnitPrice = 212.12m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 4,
                            CategoryID = 4,
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(932),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Refined Cotton Cheese",
                            Status = 1,
                            UnitPrice = 632.88m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 5,
                            CategoryID = 5,
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(1013),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Rustic Metal Fish",
                            Status = 1,
                            UnitPrice = 611.55m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 6,
                            CategoryID = 6,
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(1092),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Small Soft Car",
                            Status = 1,
                            UnitPrice = 600.41m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 7,
                            CategoryID = 7,
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(1206),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Gorgeous Frozen Bike",
                            Status = 1,
                            UnitPrice = 572.44m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 8,
                            CategoryID = 8,
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(1274),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Generic Concrete Computer",
                            Status = 1,
                            UnitPrice = 266.18m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 9,
                            CategoryID = 9,
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(1340),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Licensed Metal Mouse",
                            Status = 1,
                            UnitPrice = 586.03m,
                            UnitsInStock = 100
                        },
                        new
                        {
                            ID = 10,
                            CategoryID = 10,
                            CreatedDate = new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(1408),
                            ImagePath = "http://lorempixel.com/640/480/nightlife",
                            ProductName = "Licensed Frozen Fish",
                            Status = 1,
                            UnitPrice = 58.40m,
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
