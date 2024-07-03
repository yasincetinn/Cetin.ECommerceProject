using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivationCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceOfOrder = table.Column<decimal>(type: "money", nullable: false),
                    AppUserID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_ID",
                        column: x => x.ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "19c8dceb-cb64-4b9a-80c7-7b5992170593", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationCode", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, new Guid("00000000-0000-0000-0000-000000000000"), "d3ff06e4-07c3-469f-9c51-b93d81ad789f", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9901), null, "yasncetn8990@gmail.com", true, false, null, null, "YASNCETN8990@GMAIL.COM", "YASN33", "AQAAAAIAAYagAAAAEJxOM5nHlUqWFAn92i/ujypEkLEa4Ftk2dKV/aQ/EgezsW+pFNIvP4kc/MDvPYf0Ig==", null, false, "d99886bf-2f84-482b-adbc-a6d358395068", 1, false, "yasn33" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CategoryName", "CreatedDate", "DeletedDate", "Description", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, "Clothing", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(5477), null, "Çarpan ab de layıkıyla.\nMagnam eos ama non un dağılımı quaerat iure et consequatur.\nVelit çakıl ipsa.\nKi ona türemiş aut magnam.\nDolores gülüyorum kapının ona lakin nesciunt veniam.\nAdresini doğru sayfası de bahar.\nYaptı orta bilgisayarı quia quis patlıcan commodi koştum et filmini.\nEve blanditiis umut ex.\nÇakıl mıknatıslı sinema anlamsız beatae architecto ducimus.\nVoluptatum lambadaki ut esse çobanın layıkıyla laboriosam ipsum fugit.", null, 1 },
                    { 2, "Electronics", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(6148), null, "Eius eius voluptas.\nRatione bilgiyasayarı eos teldeki incidunt eius gitti layıkıyla kalemi magni.\nEa ab sit sunt.\nOtobüs rem koyun alias sit düşünüyor incidunt enim bahar tv.\nReprehenderit değirmeni iure ut ratione kutusu cezbelendi laboriosam dolor.\nReprehenderit duyulmamış düşünüyor aut eum karşıdakine göze enim ve.\nAnlamsız qui nemo dolayı quam çarpan otobüs odio.\nQuia mıknatıslı sayfası ki masaya laboriosam totam.\nEt dicta alias quia qui.\nTv consequatur sayfası orta gül sıfat.", null, 1 },
                    { 3, "Outdoors", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(6445), null, "Mutlu dolayı amet rem illo odio aut gül.\nVoluptatem un eius mıknatıslı.\nQui et orta layıkıyla koştum quam adanaya yaptı consequuntur.\nVelit lambadaki umut non.\nVel dignissimos quam ve.\nMakinesi gördüm nisi neque voluptatem dolayı minima duyulmamış voluptatem.\nVoluptatum türemiş ducimus masanın sit magni consequatur magnam voluptatem.\nEt sed okuma aut eos değirmeni quasi autem.\nPatlıcan şafak ullam perferendis ratione layıkıyla sit hesap yaptı.\nSokaklarda veniam sit.", null, 1 },
                    { 4, "Automotive", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(6759), null, "Filmini adipisci ut commodi gidecekmiş beğendim.\nQuam dignissimos sed gördüm çakıl.\nVoluptatem kulu düşünüyor voluptas autem.\nCesurca architecto et totam değirmeni ab koşuyorlar bundan velit.\nDolor sed tv.\nDolayı numquam suscipit koyun aliquid explicabo bahar doğru lambadaki ut.\nSıla ut ratione ut veniam masanın bundan dolorem.\nMinima quis sit bilgisayarı makinesi ullam veritatis dağılımı ona quis.\nBilgisayarı sit exercitationem gördüm aut olduğu bundan.\nSarmal quia ama domates.", null, 1 },
                    { 5, "Jewelery", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(7038), null, "Corporis layıkıyla eaque voluptatum aliquam sıradanlıktan veniam düşünüyor.\nÇünkü beatae ratione.\nQui qui mıknatıslı filmini domates ut ea iure iure.\nUt teldeki lambadaki koyun sıradanlıktan tempora.\nYaptı accusantium otobüs laboriosam anlamsız cesurca sunt iusto bahar quam.\nGülüyorum biber dolore ipsam ipsa bilgisayarı laboriosam veniam sit tempora.\nQui dolores sıradanlıktan voluptatem ullam gazete eaque.\nYapacakmış velit quasi voluptatum beğendim modi odio beğendim voluptatem quia.\nDoloremque gazete türemiş sandalye doğru et ut sit koştum quia.\nAperiam ex çıktılar cesurca eos kutusu sayfası masaya gördüm bilgiyasayarı.", null, 1 },
                    { 6, "Industrial", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(7328), null, "Açılmadan ratione doğru sevindi koştum commodi blanditiis ad praesentium.\nBlanditiis totam ea kulu çorba hesap quia bilgisayarı kulu ad.\nİpsa kalemi kalemi şafak esse eum.\nEt değirmeni voluptatem çarpan.\nTeldeki fugit aliquid eve ducimus bahar.\nUt dolor quia explicabo.\nDoloremque consequuntur dolore batarya eos quia gül salladı inventore voluptatem.\nDeğerli quis ut ötekinden sit ama sıradanlıktan cesurca ki.\nKoştum kutusu rem sıfat consequatur vitae suscipit tempora.\nConsectetur molestiae ekşili illo mutlu.", null, 1 },
                    { 7, "Music", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(7623), null, "Ab ut öyle aut sıradanlıktan magnam mıknatıslı dolores.\nSandalye quia gördüm ab.\nÇünkü camisi vitae.\nBiber ullam suscipit dolore umut ama sit.\nMi velit iusto türemiş.\nSit layıkıyla et iure quis velit okuma.\nFilmini labore vel ut bahar ut dolorem.\nMasanın in anlamsız quis tempora gitti duyulmamış magni.\nVoluptate illo otobüs ekşili ışık enim gitti exercitationem.\nBilgiyasayarı teldeki gül çakıl gazete aut sunt voluptatem.", null, 1 },
                    { 8, "Industrial", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(7864), null, "Quaerat quis ad telefonu cesurca laboriosam totam voluptatem ab.\nBeatae eius neque düşünüyor.\nUt neque mıknatıslı.\nMakinesi nostrum incidunt dicta.\nVoluptatem ışık voluptatem.\nSequi quia et sunt voluptas.\nLabore amet fugit nostrum ullam veritatis molestiae ona autem bahar.\nÇorba quam alias bilgisayarı architecto quasi okuma dergi molestiae consequatur.\nCommodi dolores qui düşünüyor ut nisi sayfası blanditiis.\nÇünkü veniam camisi masanın bilgisayarı quam odio sevindi hesap.", null, 1 },
                    { 9, "Automotive", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(8152), null, "Odit voluptatem quis totam voluptatem nisi sit umut iure.\nÇorba amet modi sarmal eve okuma inventore ut.\nAdanaya gülüyorum koşuyorlar yazın dolayı quam qui.\nDolores doğru eum esse autem velit quasi quae qui qui.\nUllam layıkıyla blanditiis aliquid.\nİusto vitae açılmadan non.\nKarşıdakine masanın totam quaerat sayfası ad labore lakin.\nQuasi bilgisayarı için mutlu vel dolorem beatae totam doğru.\nDağılımı totam enim sit ona sequi otobüs.\nKalemi rem dicta kapının gitti veritatis ex dışarı.", null, 1 },
                    { 10, "Baby", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(8407), null, "Ea kapının masaya exercitationem tv quia aperiam çünkü.\nUt ki ut numquam sequi rem laudantium ve sevindi.\nKapının salladı umut ratione cesurca bilgiyasayarı domates quasi.\nGidecekmiş okuma adresini.\nNon eos iusto aspernatur qui suscipit mutlu veritatis sit.\nYapacakmış adipisci patlıcan çıktılar öyle düşünüyor.\nGöze in gül cezbelendi cesurca.\nVoluptas adipisci consequatur mi molestiae sequi lakin.\nIşık koyun adresini sed esse corporis ipsa çakıl layıkıyla voluptatem.\nAçılmadan odio gidecekmiş accusantium quia mıknatıslı sit consequatur.", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "CreatedDate", "DeletedDate", "ImagePath", "ModifiedDate", "ProductName", "Status", "UnitPrice", "UnitsInStock" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(8763), null, "http://lorempixel.com/640/480/nightlife", null, "Awesome Fresh Shirt", 1, 92.48m, 100 },
                    { 2, 2, new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9061), null, "http://lorempixel.com/640/480/nightlife", null, "Small Metal Ball", 1, 893.02m, 100 },
                    { 3, 3, new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9136), null, "http://lorempixel.com/640/480/nightlife", null, "Unbranded Wooden Chips", 1, 282.20m, 100 },
                    { 4, 4, new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9199), null, "http://lorempixel.com/640/480/nightlife", null, "Tasty Fresh Pants", 1, 616.86m, 100 },
                    { 5, 5, new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9256), null, "http://lorempixel.com/640/480/nightlife", null, "Unbranded Granite Tuna", 1, 707.77m, 100 },
                    { 6, 6, new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9353), null, "http://lorempixel.com/640/480/nightlife", null, "Licensed Rubber Shoes", 1, 149.29m, 100 },
                    { 7, 7, new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9413), null, "http://lorempixel.com/640/480/nightlife", null, "Generic Concrete Table", 1, 764.57m, 100 },
                    { 8, 8, new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9471), null, "http://lorempixel.com/640/480/nightlife", null, "Generic Frozen Chair", 1, 117.26m, 100 },
                    { 9, 9, new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9525), null, "http://lorempixel.com/640/480/nightlife", null, "Handmade Fresh Sausages", 1, 590.84m, 100 },
                    { 10, 10, new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9582), null, "http://lorempixel.com/640/480/nightlife", null, "Licensed Metal Ball", 1, 831.21m, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserID",
                table: "Orders",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
