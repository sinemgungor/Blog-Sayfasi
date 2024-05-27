using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogSayfasi_MVC_SinemGungor.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
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
                    OlusturmaZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
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
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    ReadCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
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
                name: "UserCategories",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategories", x => new { x.UserId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_UserCategories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => new { x.ArticleId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ArticleCategories_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "OlusturmaZamani" },
                values: new object[,]
                {
                    { 1, "4c7d2424-e00e-496d-9ad8-c003cbf5eb00", "Admin", "ADMIN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "0723f34c-87a4-4267-87f0-d64197fd99ef", "Uye", "UYE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "Url", "UserName" },
                values: new object[,]
                {
                    { 2, null, 0, "08ccc9c5-41b9-4540-ab94-7faf5eca6251", "sinem@sinem.com", false, null, null, false, null, "SINEM@SINEM.COM", "SINEM", "AQAAAAIAAYagAAAAEGfJbbC5VP8FiSHCzCxpZxVMA2f1J5On4kS3bFzMgTgzltoNUyKcdXWRsOZ3sqWIYQ==", null, false, null, null, false, null, "sinem" },
                    { 3, null, 0, "edfb00c7-6500-40bd-a316-de7bf178c395", "sena.malkoc@gmail.com", false, null, null, false, null, "SENA.MALKOC@GMAIL.COM", "SENA", "AQAAAAIAAYagAAAAEG0xNhAK0cGb5l7yvDtxDdb1AIUwiLs1MISUUsmOCamAErrL4wkjVjNhrKTEL5tTmw==", null, false, null, null, false, null, "sena" },
                    { 4, null, 0, "33260d88-f81b-4c32-ae99-0031847045ec", "sema@gmail.com", false, null, null, false, null, "SEMA@GMAIL.COM", "SEMA", null, null, false, null, null, false, null, "sema" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Teknoloji" },
                    { 2, "Bilim" },
                    { 3, "Sağlık" },
                    { 4, "Eğitim" },
                    { 5, "Seyehat" },
                    { 6, "Mühendislik" },
                    { 7, "Mimarlık" },
                    { 8, "Sosyoloji" },
                    { 9, "Felsefe" },
                    { 10, "Tarih" },
                    { 11, "Psikoloji" },
                    { 12, "Ekonomi" },
                    { 13, "Sanat" },
                    { 14, "Siyaset" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedTime", "ReadCount", "Title" },
                values: new object[,]
                {
                    { 1, 2, "Amazon’un Teknoloji Direktöründen Yapay Zekanın Geleceğine Dair Öngörüler\r\n8 okunma — 26 Mayıs 2024 13:05\r\nAmazon'un Teknoloji Direktöründen Yapay Zekanın Geleceğine Dair Öngörüler\r\nAmazon’un Teknoloji Direktörü Werner Vogels, yapay zeka yani AI’nin dünyanın en büyük sorunlarını çözmede nasıl kullanılabileceğini anlattı. Vogels, VivaTech fuarında Euronews Next’e verdiği röportajda, Amazon müşterilerinin son 25 yıldır farkında olmadan yapay zekaya maruz kaldığını söyledi.Vogels, yapay zekanın meme kanserini daha iyi tespit etmeye yardımcı olma veya yoksulluğu ortadan kaldırma gibi geniş kullanım alanlarına sahip olduğunu ve dünyanın en büyük sorunlarını çözebileceğini belirtti. Yapay zeka teknolojisinin sadece sağlıklı ve iyi işler yaratma potansiyeline değil, aynı zamanda en zor sorunlarımızı sürdürülebilir bir şekilde çözme potansiyeline sahip olduğuna inandığını vurguladı.Amazon Web Services’in (AWS) tüketici odaklı bir iş olmadığını ve chatbot’lar oluşturmadığını belirten Vogels, müşterilerinin bu tür ürünleri oluşturduğunu söyledi. Yapay zekâ ve teknolojilerine erişimin demokratikleştirilmesini ve sürdürülebilir olmasını sağlamanın AWS’nin temel hedefi olduğunun altını çizdi.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Amazon’un Teknoloji Direktöründen Yapay Zekanın Geleceğine Dair Öngörüler" },
                    { 2, 2, "“Parça Parça” sergisinde; Neriman Polat’ın küratörlüğünde Defne Parman, Doğa Çal ve Hilal Balcı, feminist pratik ile aralarında gerçekleştirdikleri iletişim üzerinden seçkiyi oluşturuyorlar. Farklı kadın oluş deneyimlerine odaklanan sergi; farkında olmadığımız yaralar, parçalarda ve eylemlerdeki tekrarlar, ilişkiler ve saplantılar gibi konuları ele alıyor.\r\n\r\nKırılganlık, yaralanabilirlik konuları odağında çalışan Defne Parman, üretim sürecinde gazete kupürleri, aydınger kâğıt, kumaş gibi hassas malzemeleri kullanıyor. Sergideki Pansuman isimli işinde “kırıldığımız yerleri nasıl iyileştirebiliriz”e odaklanan sanatçı, Örtü isimli çalışmasında ise; danteli yapı bozuma uğratıp, gazete haberlerindeki kadına ve hayvana şiddet içeren görselleri kullanarak, kâğıdı tığ ile delerek kırılgan bir örtü yaratıyor.\r\n\r\nDoğa Çal ise sergideki Kafam Başka Yerde isimli video serisinde, evin farklı odalarında parçalanmış ama her parçanın hareket ettiği ve yaşadığı kadın bedenini, trajediden uzak, absürt bir mizah duygusu ile izleyiciye sunuyor. Annem, Ben, Ananem videosu; üç jenerasyon üzerinden abartılı bir biçimde, kadınlar arasındaki ilişki ve dayanışmayı vurguluyor.\r\n\r\nKendi hareketlerine mesafe alabilmenin olanaklarını araştıran Hilal Balcı; Yutkunma, Kulaktan, Yukardan Çevirme isimli siyah-beyaz video işleri ile gündelik yaşamın sıradan hareketleri yeniden kurgulayarak alışılagelmiş ritmik hareketleri sekteye uğratmaya çalışıyor. Sanatçı, Sarı bez işi ile tekrar eden eylemlerin zaman içinde deforme olma hâlini, saplantıya dönüşen hijyen takıntısını gözler önüne seriyor.\r\n\r\n​​Defne Parman, Doğa Çal ve Hilal Balcı’nın eserlerinden oluşan, Neriman Polat’ın küratörlüğünü üstlendiği “Parça Parça” başlıklı sergiyi, 8 Haziran Cumartesi gününe kadar Merdiven Art Space’te ziyaret edebilirsiniz.\r\n\r\n", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, "Eylemlerdeki Tekrarları Kırdığımızda Sanatsal Eylem Başlıyor" },
                    { 3, 3, "Marmara Üniversitesi Pendik Eğitim ve Araştırma Hastanesi Hematoloji Kliniği uzmanlarından Doç. Dr. Asu Fergün Yılmaz, toplumda sıklıkla karşılaşılan demir eksikliği anemisiyle talasemi taşıyıcılığının karıştırılmaması gerektiğini ifade etti.\r\n\r\nYılmaz, basit kan testleriyle belirlenebilen bu iki hastalık arasındaki farkın yapılmamasının talasemi taşıyıcılarının gözden kaçmasına neden olabileceği konusunda uyardı. Doç. Dr. Yılmaz, “Demir eksikliği anemisiyle talasemi taşıyıcılığı çok karışabilen iki durum. Toplumumuzda demir eksikliği anemisi de çok yaygın gözükmekte. Basit kan tahlilleriyle bunların tanısını koyabiliyoruz.” diye konuştu.Vücutta sağlıklı olarak bulunan kırmızı kan hücrelerinin üretimini etkileyen kan bozukluğu olarak tanımlanan talasemi, Akdeniz çevresindeki ülkelerde sık görülmesi nedeniyle “Akdeniz anemisi” olarak da bilinmektedir. Talasemi, anne ve babadan çocuklara kalıtsal olarak geçmekte olup, Türkiye’nin de aralarında bulunduğu Akdeniz çevresindeki ülkelerde önemli bir halk sağlığı sorunu olarak karşımıza çıkıyor.\r\n\r\n“8 Mayıs Dünya Talasemi Günü” çerçevesinde açıklamalarda bulunan Doç. Dr. Asu Fergün Yılmaz, çok ciddi kan eksikliği yaşayan talasemi hastalarının ömür boyu kan nakliyle hayatlarını geçirmek zorunda olduğunu aktardı. Yılmaz, 3 tip talasemi olduğunu belirterek, şu ifadeleri kullandı;\r\n\r\n“Birincisi bizim hasta popülasyonu dediğimiz talasemi, majör olarak tanımladığımız gruptur. Bu grup hayatları boyunca belli aralıklarda üç dört haftada bir kan nakline ihtiyaç duyarlar. Bir diğer grup talasemi taşıyıcılarıdır. Talasemi taşıyıcıları aslında hasta değildir ancak evlendikleri durumda bu kişiler hasta çocuklara sahip olabilirler ve bu yüzden talasemi taşıyıcılarının toplumda belirlenmesi gerekir. Bir diğeri de talasemi intermediate dediğimiz bu iki grubun ortasındaki hastalardır. Bu hastalar da talasemi taşıyıcılarına göre daha ciddi kansızlıkla hayatlarını geçirmek zorundalardır. Belirli dönemlerde kan nakline ihtiyaç duyarlar ama diğer majör grubuna göre çok daha düşüktür kan nakli ihtiyacı.”", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 56, "Talasemi ve Demir Eksikliği Anemisi Arasındaki Farklar" },
                    { 4, 4, "En basit haliyle F/K oranı, bir şirketin hisse fiyatının hisse başına net kazanca (kâr) bölünmesiyle hesaplanan bir finansal metriktir.\r\n\r\nBu metrik, hisse senedinin elde ettiği kâra göre fiyatını değerlendirilmeye yardımcı olur. Böylelikle hisse senetlerinin ucuz mu yoksa pahalı mı fiyatlandığına yönelik bir fikir elde edinilmiş olunur.\r\n\r\nBu metrik ile ayrıca yatırımcıların gelecekteki kazanç artışı beklentileri de incelenerek, mevcut kazançlara göre yatırımcıların bir şirket için ne kadar ödemek istedikleri de bulunmaya çalışılır.\r\n\r\nBir şirketin hisse fiyatının 150 dolar ve hisse başına kazancının 30 dolar olduğunu varsayarsak, burada F/K oranı 5 olurken; bu bize, hisselerin mevcut kazanç seviyelerinin beş katından işlem gördüğünü söyler. Yatırımcılar ise F/K oranı ne kadar yüksekse, hisseyi satın almanın nispeten daha yüksek maliyetli olduğunu düşünür.\r\n\r\nÖrneğin, Tesla 48,34 F/K oranıyla işlem görürken, sektör ortalaması 21,1 seviyesinde seyretmektedir. Bu ise yatırımcılara şirketin hisselerinin sektör ortalaması üzerinden fiyatlandığını göstermektedir.\r\n\r\nFacebook'un ana şirketi Meta da ise tam tersi bir durum söz konusudur. Buna göre Meta, 23,02 F/K oranıyla işlem görürken; sektör ortalaması, 27,08 düzeyinde seyretmektedir. Bu ise Meta’nın sektöründeki diğer hisselere göre daha cazip fiyattan işlem gördüğü anlamına gelebilir.\r\n\r\nAncak bu bilginin tek başına şirket hisselerini satın almak ya da satmak için yeterli olmayacağı unutulmamalıdır. Bu metrik, alım satım kararlarında yardımcı bir araç olarak görülmelidir. \r\n\r\nAyrıca yaygın olarak bilinen ve kullanılan F/K oranı dışında, ileriye dönük F/K oranı hesaplaması da hisse senedinin analizinde kritik önem taşımaktadır.\r\n\r\nBuna göre, tarihi F/K oranı, son 12 ayın (takip eden 12 aylık kazançlar olarak bilinir) veya son mali yılın gerçek hisse başına kazançlarına dayanırken; ileriye dönük F/K oranı ise şirket veya analistler tarafından sağlanan bir sonraki mali yıl için tahmini hisse başına kazançlara dayanır.\r\n\r\nÖte yandan unutulmamalıdır ki hissenin fiyatı her an değişebildiği için F/K oranı da hem hisse fiyatıyla hem de çeyreklik kâr ile değişmektedir. Bu sebeple F/K oranı hiçbir zaman sabit bir değer sunmamaktadır.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, "F/K oranı nedir?" },
                    { 5, 4, "Borderline kişilik bozukluğu, kişinin kendini ve başkalarını algılama biçimini etkileyen bir psikolojik durumdur. Bu bozukluğa sahip kişiler, yoğun duygular, kararsızlık ve ilişkilerde istikrarsızlık yaşayabilirler. BKB’li kişiler için sosyal ilişkilerde genellikle zorlayıcı insanlardır. Bu kişilerin, ilişkilerinde sık sık aşırıya kaçan davranışlar sergilemeleri yaygındır. Örneğin, bir BKB’li kişi, yeni biriyle tanıştıktan kısa bir süre sonra onu hayatının aşkı olarak görebilir ve o kişiye aşırı derecede bağlanabilir. Bu bağlanma, karşı taraftan reddedilme veya uzaklaşma korkusuyla birlikte olabilir. BKB’li kişiler, bir ilişkiye çok hızlı başlayıp çok hızlı da bitirebilirler. Ayrıca, bir ilişki sürecindey iken, karşı tarafa öfke, nefret ve kıskançlık gibi yoğun duygular hissedebilirler. Bu duygular, ilişkilerinde çatışmalara ve hatta şiddete yol açabilir.\r\n\r\n \r\n\r\nİlişkilerinde aşırıya kaçan davranışlar sergileyen BKB’li kişiler, ilişkilerinde de güvensizlik yaşayabilirler. Bu kişiler, karşı tarafın onları terk edeceği veya aldatacağından endişe edebilirler. Bu endişe, ilişkilerinde kıskançlık ve şüphe gibi davranışlara yol açabilir. BKB’li kişilerin sosyal ilişkilerinde yaşadıkları zorluklar, onların yaşam kalitesini olumsuz etkileyebilir. Bu kişiler, yalnızlık, izolasyon ve reddedilmişlik duyguları yaşayabilirler. Ayrıca, sosyal ilişkilerindeki zorluklar, onların iş, okul ve kişisel yaşamlarında da sorunlara yol açabilir. Borderline kişilerin sosyal ilişkilerini geliştirmelerine yardımcı olmak için, psikolojik yardım almak önemlidir. BKB tedavisi, kişinin duygularını yönetmeyi, ilişkilerinde daha sağlıklı davranışlar sergilemeyi ve kendine güveni artırmayı öğrenmesine yardımcı olabilir.\r\n\r\n \r\n\r\nBKB’li kişilerin sosyal ilişkilerini geliştirmeleri için, kendi duygularını ve ihtiyaçlarını anlamaya çalışmalı. İlişkilerinde aşırıya kaçan davranışları fark edip ve bunlara karşı kendini korumalı. Kendini ve başkalarını yargılanmaktan kaçınmalı. Başkalarına güvenmeyi öğrenmeli. Bu önemli noktalara dikkat ederek gelişim için adım atılabilir ve bir uzmandan yardım alınabilir.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, "BORDERLİNE KİŞİLİK BOZUKLUĞUNDA SOSYAL İLİŞKİLER" },
                    { 6, 2, "Eğitim doğumdan ölüme kadar süren, aileden başlayarak okul ve sonrasında kültürel, sosyal boyutlarıyla tüm yaşamımızda birlikte olduğumuz bir kavramdır. Kısaca \"Eğitim yaşamın ta kendisidir\" de diyebiliriz. Kişinin gelişmesi, tecrübe sahibi olması ya da tekamül etmesi gibi olgular eğitimin amacıdır. Daha da açarsak, düşünce ve davranış şekillerini değiştiren, geliştiren bir süreçtir. İnsanı daha iyiye, daha güzele, daha yararlıya ulaştıran bir yaşama sanatıdır eğitim.\r\n\r\nEğitimi bu genel yönüyle tanıdıktan sonra, çok iyi biliriz ki toplumların, ülkelerin hatta tüm dünyanın geleceği iyi ve doğru eğitilmiş nesillerle sıkı sıkıya bağlıdır. İyi ve doğru eğitim de, öncelikle iyi ve doğru öğrenme ve öğretme ile başarıya ulaşır. O halde, iyi öğrenmek ve öğretmek için, büyük bir hızla gelişen teknolojinin eğitim alanında, insanlığa en iyi yararlı olabilecek şekilde ve olabildiğince kullanılması kaçınılmaz bir şart olarak karşımıza çıkıyor. \r\n\r\n\"Milenyum\" denilen ve 2000 yılıyla başlayan yeni bir dönemi yaşıyoruz ve bu dönemin çocukları, gençleri de bu yeni dönemin çok açık örnekleri olarak yepyeni bir nesli temsil ediyorlar. \"İnternet Çocukları\" da dediğimiz bu çocuklar, \"Cep telefonu\"nu, \"İpod\"u ve tüm ileri teknoloji araçlarını, bireysel yaşamlarının ayrılmaz bir parçası olarak kabullenmiş şekilde büyümekteler. Bilgisayar ekranlarında MSN ile yazışıyorlar, MP dinliyorlar, cep telefonlarından SMS atıyorlar ve böylesine bir hız ve karmaşa içerisinde düşünmeye zaman ayıramıyorlar. \r\n\r\nDüşünmeye zaman ayıramamak, ister istemez tembelliği de beraberinde getirir. Bu nedenle çalışmayı da sevmez oldular. Zaten her türlü bilgi, anında cep telefonlarında ya da bilgisayar aracılığıyla avuçlarının içinde. Böylesine kolayca sahiplenmek, maalesef tatminsiz ve sadakatsiz bir insan yapısının oluşmasına da neden oluyor. \r\n\r\nGençlerimiz ve çocuklarımız bu kadar kolay yaşama şansına sahip olmalarının sonucunda da, bol tüketmek, çabuk ve çok para kazanmak, borsa ve bahis oyunlarında ustalaşmayı zorlamak gibi, bize göre \"Ter dökmeden\" kurnazca arayışlar içindeler. İşte bu gerçeklerin ışığında eğitim sistemleri yeniden planlanmalı ve programlanmalıdır. Bunu bütün dünya ülkeleri için düşünmek zorundayız. \r\n\r\nYukarıda belirttiğim şartları göz önüne aldığımızda, eğitimin artık ne kadar zorlaştığını açıkca görüyoruz. Devamlı değişen dünya değerleri, global ekonomi, çok hızla gelişen iletişim sistemleri yalnızca milli değil, global anlamda da gençlerin eğitilmesi gereğini zorluyor. Yalnız, yeni eğitimin gerçekleşebilmesi için sadece ilkeler değil, ekonomik koşulların da sisteme uygulanması çok önemli bir şart olarak önümüzde duruyor. \r\n\r\nDünyada eğitimin nerelerde olduğu ve olacağı konusunda \"TUBİTAK Bilim ve Teknoloji Staratejileri Vizyon 2023\" de yapılan tespitler, bütün dünyanın durumunu ve geleceğini pek açık ortaya koyuyor. \"Dünyada gelişmiş ülkelerde, OECD dahil, eğitimin önemini vurgulamayan tek bir ülke olmamakla birlikte, yine gelişmiş ülkeler de dahil bütün ülkeler eğitime yeterince kaynak ayıramadıklarını, mevcut eğitim sistemlerinin yarının taleplerine hazır olmadığını ve eğitimin 21.Yüzyıl'a uygun bir yapıya kavuşturulması gerektiğini tartışıp durmaktadırlar. \r\n", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, "Eğitim ve Geleceğimiz" }
                });

            migrationBuilder.InsertData(
                table: "ArticleCategories",
                columns: new[] { "ArticleId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 13 },
                    { 3, 3 },
                    { 4, 12 },
                    { 5, 11 },
                    { 6, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_CategoryId",
                table: "ArticleCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

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
                name: "IX_UserCategories_CategoryId",
                table: "UserCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategories");

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
                name: "UserCategories");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
