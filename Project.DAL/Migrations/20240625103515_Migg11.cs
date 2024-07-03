using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Migg11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "15a1a333-6edb-433f-b5e0-e3943a40cf50");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be8eb833-14ef-4577-83ef-ebb7760fc462", new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(1824), "yasncetn8990@outlook.com", "YASNCETN8990@OUTLOOK.COM", "AQAAAAIAAYagAAAAEGkvUCJwTdpi8BZhasYp0mNwfmVd+OGWQGIbSr8rhQU0jyGGHOTB06RzdSQ+3Tl9gw==", "6f85178a-fb02-4c73-87cc-08f3be6dc31a" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Shoes", new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(6423), "Teldeki çakıl kapının nesciunt eum doğru olduğu labore.\nQuis magni eum dolayı accusantium.\nEsse dolore kutusu.\nÇarpan okuma kutusu.\nSed quia uzattı sunt dolayı corporis ötekinden.\nEius doğru ut autem camisi aspernatur nisi dicta.\nVeritatis hesap eaque bilgisayarı voluptatem.\nVelit çorba eaque hesap.\nDolayı quia dolores tempora minima kutusu.\nBundan masanın ex sıfat çorba açılmadan voluptatem." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Jewelery", new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(7287), "İllo hesap de açılmadan reprehenderit.\nDolores laboriosam ea tv masanın batarya.\nAliquam nisi gitti aut.\nİpsa gidecekmiş doğru.\nAçılmadan sıfat ratione sed.\nOkuma nisi tv cezbelendi ut un voluptatem ipsum consequuntur.\nBundan odit modi koşuyorlar batarya voluptatem orta lambadaki sit.\nVeritatis voluptatem eve.\nCorporis çakıl uzattı eos değerli masanın consequatur ekşili.\nSandalye karşıdakine aliquam voluptas." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Beauty", new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(7605), "Dignissimos voluptatem ut quia ve ea.\nSarmal architecto çünkü koştum eaque enim in voluptatem et.\nGöze olduğu sayfası ea yaptı yapacakmış eaque.\nExercitationem magni ama totam.\nGülüyorum sandalye eaque.\nNon aliquam et nemo anlamsız iure magnam molestiae odio modi.\nMinima magni autem odit commodi ut otobüs yaptı deleniti.\nİpsa dignissimos uzattı aut teldeki ut nihil consectetur.\nGitti doğru mi sinema velit.\nKoyun duyulmamış magnam sed sevindi ipsum non ışık öyle." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Baby", new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(7976), "Layıkıyla gül totam mıknatıslı.\nCorporis vel voluptatem.\nAd gazete magni deleniti amet layıkıyla.\nBilgisayarı mıknatıslı esse göze sıla consequuntur veritatis dergi sinema.\nİusto dolayı ipsum.\nQuia eaque mıknatıslı.\nQuia ducimus adipisci architecto quia sit quae duyulmamış koştum.\nEkşili ona filmini dignissimos yaptı.\nExplicabo sıradanlıktan iure voluptatem nihil adanaya qui batarya numquam.\nAut veritatis sevindi ut commodi ışık ea cezbelendi." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Outdoors", new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(8295), "Blanditiis cesurca şafak numquam nesciunt ad qui labore ışık.\nQuis yazın dolores labore.\nUt çarpan ea oldular masanın sevindi rem ab.\nQuis sarmal öyle okuma minima şafak aspernatur mutlu çakıl balıkhaneye.\nSıfat lakin sinema esse un ekşili nesciunt teldeki praesentium çakıl.\nVitae gördüm adresini camisi gidecekmiş et ipsam.\nAccusantium numquam sed.\nAma sıfat patlıcan ut sıla enim ipsa corporis layıkıyla.\nVoluptas aut voluptate çarpan reprehenderit sequi neque dolorem.\nAnlamsız için sed çobanın vitae sayfası ötekinden dolores veniam gazete." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Baby", new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(8694), "Doloremque voluptatum de cezbelendi de batarya makinesi qui.\nUt makinesi commodi umut totam quis aut bundan eaque ratione.\nSinema quis fugit aut gitti eaque autem.\nArchitecto koştum ex ekşili.\nAliquid commodi et eve çıktılar.\nAnlamsız un bahar enim de tv dicta.\nFilmini quia karşıdakine eve nesciunt sunt qui nihil dicta ipsum.\nMagni salladı gül iusto deleniti.\nArchitecto modi sunt bilgisayarı sit ipsum quis sevindi aut.\nLambadaki consectetur voluptas nemo de beatae ex." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Home", new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(9043), "Ducimus nesciunt voluptate balıkhaneye.\nAut karşıdakine değirmeni uzattı masaya.\nOdio mutlu totam çakıl doloremque molestiae mutlu masaya.\nSevindi gazete kapının quae nesciunt sarmal sıfat voluptatem.\nKoyun cezbelendi nisi.\nQuia quasi in tv laudantium odio açılmadan ratione sequi.\nConsequuntur et voluptatum ea sevindi göze quis ducimus illo.\nSıfat aut ut non teldeki.\nEaque beatae sıfat gülüyorum hesap quasi.\nCommodi aliquam eum corporis incidunt ratione eos voluptas." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Clothing", new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(9323), "Layıkıyla voluptatem eve quis koşuyorlar reprehenderit ışık sıradanlıktan.\nDağılımı bahar sed molestiae tv de rem.\nŞafak dağılımı ekşili.\nConsectetur masaya çobanın ea ut perferendis.\nGördüm camisi gidecekmiş quis cezbelendi magnam sokaklarda öyle voluptatum.\nEt layıkıyla explicabo velit voluptatem hesap.\nGöze tv teldeki eos un dolayı layıkıyla.\nAperiam batarya aut quae.\nEum ipsum odio.\nEkşili praesentium eos sinema commodi consequatur." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Music", new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(9654), "Esse numquam ışık sed makinesi.\nSunt et dolore aliquam.\nOrta dağılımı yapacakmış masanın tempora nostrum.\nDüşünüyor sarmal gülüyorum esse consequatur in göze.\nDoğru olduğu laudantium sayfası sunt adipisci.\nAut veritatis ipsum labore amet kulu architecto incidunt.\nKalemi mi consequuntur nesciunt beğendim.\nSalladı değirmeni voluptatem bahar sit un laudantium balıkhaneye.\nDeğerli et adanaya enim.\nBiber kapının lakin consequuntur." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Games", new DateTime(2024, 6, 25, 13, 35, 13, 518, DateTimeKind.Local).AddTicks(9933), "Lambadaki çünkü koştum nemo quis suscipit voluptatem laboriosam consequatur.\nVoluptate oldular sevindi göze.\nSıfat çorba doloremque bundan filmini incidunt inventore tempora voluptate.\nTüremiş otobüs batarya sed ipsam consequatur salladı doloremque et ona.\nOdit velit sarmal.\nÇakıl çıktılar ea layıkıyla quasi.\nSıla neque consequuntur rem nemo ut dolor lakin camisi non.\nEa masaya aliquid adipisci laudantium umut patlıcan sevindi.\nEkşili sed sıradanlıktan qui quia dolore anlamsız.\nİure voluptatem bundan çıktılar çünkü quae ki." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(368), "Practical Metal Soap", 594.86m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(757), "Practical Steel Cheese", 712.23m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(846), "Handmade Fresh Pizza", 212.12m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(932), "Refined Cotton Cheese", 632.88m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(1013), "Rustic Metal Fish", 611.55m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(1092), "Small Soft Car", 600.41m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(1206), "Gorgeous Frozen Bike", 572.44m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(1274), "Generic Concrete Computer", 266.18m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(1340), "Licensed Metal Mouse", 586.03m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 25, 13, 35, 13, 519, DateTimeKind.Local).AddTicks(1408), "Licensed Frozen Fish", 58.40m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "19c8dceb-cb64-4b9a-80c7-7b5992170593");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "Email", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3ff06e4-07c3-469f-9c51-b93d81ad789f", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9901), "yasncetn8990@gmail.com", "YASNCETN8990@GMAIL.COM", "AQAAAAIAAYagAAAAEJxOM5nHlUqWFAn92i/ujypEkLEa4Ftk2dKV/aQ/EgezsW+pFNIvP4kc/MDvPYf0Ig==", "d99886bf-2f84-482b-adbc-a6d358395068" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Clothing", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(5477), "Çarpan ab de layıkıyla.\nMagnam eos ama non un dağılımı quaerat iure et consequatur.\nVelit çakıl ipsa.\nKi ona türemiş aut magnam.\nDolores gülüyorum kapının ona lakin nesciunt veniam.\nAdresini doğru sayfası de bahar.\nYaptı orta bilgisayarı quia quis patlıcan commodi koştum et filmini.\nEve blanditiis umut ex.\nÇakıl mıknatıslı sinema anlamsız beatae architecto ducimus.\nVoluptatum lambadaki ut esse çobanın layıkıyla laboriosam ipsum fugit." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Electronics", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(6148), "Eius eius voluptas.\nRatione bilgiyasayarı eos teldeki incidunt eius gitti layıkıyla kalemi magni.\nEa ab sit sunt.\nOtobüs rem koyun alias sit düşünüyor incidunt enim bahar tv.\nReprehenderit değirmeni iure ut ratione kutusu cezbelendi laboriosam dolor.\nReprehenderit duyulmamış düşünüyor aut eum karşıdakine göze enim ve.\nAnlamsız qui nemo dolayı quam çarpan otobüs odio.\nQuia mıknatıslı sayfası ki masaya laboriosam totam.\nEt dicta alias quia qui.\nTv consequatur sayfası orta gül sıfat." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Outdoors", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(6445), "Mutlu dolayı amet rem illo odio aut gül.\nVoluptatem un eius mıknatıslı.\nQui et orta layıkıyla koştum quam adanaya yaptı consequuntur.\nVelit lambadaki umut non.\nVel dignissimos quam ve.\nMakinesi gördüm nisi neque voluptatem dolayı minima duyulmamış voluptatem.\nVoluptatum türemiş ducimus masanın sit magni consequatur magnam voluptatem.\nEt sed okuma aut eos değirmeni quasi autem.\nPatlıcan şafak ullam perferendis ratione layıkıyla sit hesap yaptı.\nSokaklarda veniam sit." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Automotive", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(6759), "Filmini adipisci ut commodi gidecekmiş beğendim.\nQuam dignissimos sed gördüm çakıl.\nVoluptatem kulu düşünüyor voluptas autem.\nCesurca architecto et totam değirmeni ab koşuyorlar bundan velit.\nDolor sed tv.\nDolayı numquam suscipit koyun aliquid explicabo bahar doğru lambadaki ut.\nSıla ut ratione ut veniam masanın bundan dolorem.\nMinima quis sit bilgisayarı makinesi ullam veritatis dağılımı ona quis.\nBilgisayarı sit exercitationem gördüm aut olduğu bundan.\nSarmal quia ama domates." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Jewelery", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(7038), "Corporis layıkıyla eaque voluptatum aliquam sıradanlıktan veniam düşünüyor.\nÇünkü beatae ratione.\nQui qui mıknatıslı filmini domates ut ea iure iure.\nUt teldeki lambadaki koyun sıradanlıktan tempora.\nYaptı accusantium otobüs laboriosam anlamsız cesurca sunt iusto bahar quam.\nGülüyorum biber dolore ipsam ipsa bilgisayarı laboriosam veniam sit tempora.\nQui dolores sıradanlıktan voluptatem ullam gazete eaque.\nYapacakmış velit quasi voluptatum beğendim modi odio beğendim voluptatem quia.\nDoloremque gazete türemiş sandalye doğru et ut sit koştum quia.\nAperiam ex çıktılar cesurca eos kutusu sayfası masaya gördüm bilgiyasayarı." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Industrial", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(7328), "Açılmadan ratione doğru sevindi koştum commodi blanditiis ad praesentium.\nBlanditiis totam ea kulu çorba hesap quia bilgisayarı kulu ad.\nİpsa kalemi kalemi şafak esse eum.\nEt değirmeni voluptatem çarpan.\nTeldeki fugit aliquid eve ducimus bahar.\nUt dolor quia explicabo.\nDoloremque consequuntur dolore batarya eos quia gül salladı inventore voluptatem.\nDeğerli quis ut ötekinden sit ama sıradanlıktan cesurca ki.\nKoştum kutusu rem sıfat consequatur vitae suscipit tempora.\nConsectetur molestiae ekşili illo mutlu." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Music", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(7623), "Ab ut öyle aut sıradanlıktan magnam mıknatıslı dolores.\nSandalye quia gördüm ab.\nÇünkü camisi vitae.\nBiber ullam suscipit dolore umut ama sit.\nMi velit iusto türemiş.\nSit layıkıyla et iure quis velit okuma.\nFilmini labore vel ut bahar ut dolorem.\nMasanın in anlamsız quis tempora gitti duyulmamış magni.\nVoluptate illo otobüs ekşili ışık enim gitti exercitationem.\nBilgiyasayarı teldeki gül çakıl gazete aut sunt voluptatem." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Industrial", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(7864), "Quaerat quis ad telefonu cesurca laboriosam totam voluptatem ab.\nBeatae eius neque düşünüyor.\nUt neque mıknatıslı.\nMakinesi nostrum incidunt dicta.\nVoluptatem ışık voluptatem.\nSequi quia et sunt voluptas.\nLabore amet fugit nostrum ullam veritatis molestiae ona autem bahar.\nÇorba quam alias bilgisayarı architecto quasi okuma dergi molestiae consequatur.\nCommodi dolores qui düşünüyor ut nisi sayfası blanditiis.\nÇünkü veniam camisi masanın bilgisayarı quam odio sevindi hesap." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Automotive", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(8152), "Odit voluptatem quis totam voluptatem nisi sit umut iure.\nÇorba amet modi sarmal eve okuma inventore ut.\nAdanaya gülüyorum koşuyorlar yazın dolayı quam qui.\nDolores doğru eum esse autem velit quasi quae qui qui.\nUllam layıkıyla blanditiis aliquid.\nİusto vitae açılmadan non.\nKarşıdakine masanın totam quaerat sayfası ad labore lakin.\nQuasi bilgisayarı için mutlu vel dolorem beatae totam doğru.\nDağılımı totam enim sit ona sequi otobüs.\nKalemi rem dicta kapının gitti veritatis ex dışarı." });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CategoryName", "CreatedDate", "Description" },
                values: new object[] { "Baby", new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(8407), "Ea kapının masaya exercitationem tv quia aperiam çünkü.\nUt ki ut numquam sequi rem laudantium ve sevindi.\nKapının salladı umut ratione cesurca bilgiyasayarı domates quasi.\nGidecekmiş okuma adresini.\nNon eos iusto aspernatur qui suscipit mutlu veritatis sit.\nYapacakmış adipisci patlıcan çıktılar öyle düşünüyor.\nGöze in gül cezbelendi cesurca.\nVoluptas adipisci consequatur mi molestiae sequi lakin.\nIşık koyun adresini sed esse corporis ipsa çakıl layıkıyla voluptatem.\nAçılmadan odio gidecekmiş accusantium quia mıknatıslı sit consequatur." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(8763), "Awesome Fresh Shirt", 92.48m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9061), "Small Metal Ball", 893.02m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9136), "Unbranded Wooden Chips", 282.20m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9199), "Tasty Fresh Pants", 616.86m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9256), "Unbranded Granite Tuna", 707.77m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9353), "Licensed Rubber Shoes", 149.29m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9413), "Generic Concrete Table", 764.57m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9471), "Generic Frozen Chair", 117.26m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9525), "Handmade Fresh Sausages", 590.84m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ProductName", "UnitPrice" },
                values: new object[] { new DateTime(2024, 6, 4, 23, 12, 28, 807, DateTimeKind.Local).AddTicks(9582), "Licensed Metal Ball", 831.21m });
        }
    }
}
