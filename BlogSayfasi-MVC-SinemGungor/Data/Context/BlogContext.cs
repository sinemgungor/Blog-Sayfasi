using BlogSayfasi_MVC_SinemGungor.Models;
using identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace BlogSayfasi_MVC_SinemGungor.Data.Context
{
    public class BlogContext : IdentityDbContext<User, Role, int>
    {
        public BlogContext()
        {

        }

        public BlogContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //uye rol ilişkisi
            IdentityUserRole<int> identityUserRole1 = new IdentityUserRole<int>()
            {
                RoleId = 2,
                UserId = 2,
            };
            IdentityUserRole<int> identityUserRole2 = new IdentityUserRole<int>()
            {
                RoleId = 2,
                UserId = 3,
            };
            IdentityUserRole<int> identityUserRole3 = new IdentityUserRole<int>()
            {
                RoleId = 2,
                UserId = 4,
            };

            builder.Entity<ArticleCategory>()
               .HasKey(ac => new { ac.ArticleId, ac.CategoryId });

            builder.Entity<ArticleCategory>()
                .HasOne(ac => ac.Article)
                .WithMany(a => a.ArticleCategories)
                .HasForeignKey(ac => ac.ArticleId);

            builder.Entity<ArticleCategory>()
                .HasOne(ac => ac.Category)
                .WithMany(c => c.ArticleCategories)
                .HasForeignKey(ac => ac.CategoryId);

            builder.Entity<UserCategory>()
                .HasKey(uc => new { uc.UserId, uc.CategoryId });

            builder.Entity<UserCategory>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCategories)
                .HasForeignKey(uc => uc.UserId);

            builder.Entity<UserCategory>()
                .HasOne(uc => uc.Category)
                .WithMany(c => c.UserCategories)
                .HasForeignKey(uc => uc.CategoryId);

            builder.Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.AuthorId);


            builder.Entity<Category>().HasData(
                 new Category { Id = 1, Name = "Teknoloji" },
                new Category { Id = 2, Name = "Bilim" },
                new Category { Id = 3, Name = "Sağlık" },
                new Category { Id = 4, Name = "Eğitim" },
                new Category { Id = 5, Name = "Seyehat" },
                new Category { Id = 6, Name = "Mühendislik" },
                new Category { Id = 7, Name = "Mimarlık" },
                new Category { Id = 8, Name = "Sosyoloji" },
                new Category { Id = 9, Name = "Felsefe" },
                new Category { Id = 10, Name = "Tarih" },
                new Category { Id = 11, Name = "Psikoloji" },
                new Category { Id = 12, Name = "Ekonomi" },
                new Category { Id = 13, Name = "Sanat" },
                new Category { Id = 14, Name = "Siyaset" }
                );

            builder.Entity<Article>().HasData(
                new Article
                {
                    Id = 1,
                    Title = "Amazon’un Teknoloji Direktöründen Yapay Zekanın Geleceğine Dair Öngörüler",
                    Content = "Amazon’un Teknoloji Direktöründen Yapay Zekanın Geleceğine Dair Öngörüler\r\n8 okunma — 26 Mayıs 2024 13:05\r\nAmazon'un Teknoloji Direktöründen Yapay Zekanın Geleceğine Dair Öngörüler\r\nAmazon’un Teknoloji Direktörü Werner Vogels, yapay zeka yani AI’nin dünyanın en büyük sorunlarını çözmede nasıl kullanılabileceğini anlattı. Vogels, VivaTech fuarında Euronews Next’e verdiği röportajda, Amazon müşterilerinin son 25 yıldır farkında olmadan yapay zekaya maruz kaldığını söyledi.Vogels, yapay zekanın meme kanserini daha iyi tespit etmeye yardımcı olma veya yoksulluğu ortadan kaldırma gibi geniş kullanım alanlarına sahip olduğunu ve dünyanın en büyük sorunlarını çözebileceğini belirtti. Yapay zeka teknolojisinin sadece sağlıklı ve iyi işler yaratma potansiyeline değil, aynı zamanda en zor sorunlarımızı sürdürülebilir bir şekilde çözme potansiyeline sahip olduğuna inandığını vurguladı.Amazon Web Services’in (AWS) tüketici odaklı bir iş olmadığını ve chatbot’lar oluşturmadığını belirten Vogels, müşterilerinin bu tür ürünleri oluşturduğunu söyledi. Yapay zekâ ve teknolojilerine erişimin demokratikleştirilmesini ve sürdürülebilir olmasını sağlamanın AWS’nin temel hedefi olduğunun altını çizdi.",
                    CreatedTime = DateTime.Now,
                    AuthorId = 2,
                    ReadCount = 10,

                },
                new Article
                {
                    Id = 2,
                    Title = "Eylemlerdeki Tekrarları Kırdığımızda Sanatsal Eylem Başlıyor",
                    Content = "“Parça Parça” sergisinde; Neriman Polat’ın küratörlüğünde Defne Parman, Doğa Çal ve Hilal Balcı, feminist pratik ile aralarında gerçekleştirdikleri iletişim üzerinden seçkiyi oluşturuyorlar. Farklı kadın oluş deneyimlerine odaklanan sergi; farkında olmadığımız yaralar, parçalarda ve eylemlerdeki tekrarlar, ilişkiler ve saplantılar gibi konuları ele alıyor.\r\n\r\nKırılganlık, yaralanabilirlik konuları odağında çalışan Defne Parman, üretim sürecinde gazete kupürleri, aydınger kâğıt, kumaş gibi hassas malzemeleri kullanıyor. Sergideki Pansuman isimli işinde “kırıldığımız yerleri nasıl iyileştirebiliriz”e odaklanan sanatçı, Örtü isimli çalışmasında ise; danteli yapı bozuma uğratıp, gazete haberlerindeki kadına ve hayvana şiddet içeren görselleri kullanarak, kâğıdı tığ ile delerek kırılgan bir örtü yaratıyor.\r\n\r\nDoğa Çal ise sergideki Kafam Başka Yerde isimli video serisinde, evin farklı odalarında parçalanmış ama her parçanın hareket ettiği ve yaşadığı kadın bedenini, trajediden uzak, absürt bir mizah duygusu ile izleyiciye sunuyor. Annem, Ben, Ananem videosu; üç jenerasyon üzerinden abartılı bir biçimde, kadınlar arasındaki ilişki ve dayanışmayı vurguluyor.\r\n\r\nKendi hareketlerine mesafe alabilmenin olanaklarını araştıran Hilal Balcı; Yutkunma, Kulaktan, Yukardan Çevirme isimli siyah-beyaz video işleri ile gündelik yaşamın sıradan hareketleri yeniden kurgulayarak alışılagelmiş ritmik hareketleri sekteye uğratmaya çalışıyor. Sanatçı, Sarı bez işi ile tekrar eden eylemlerin zaman içinde deforme olma hâlini, saplantıya dönüşen hijyen takıntısını gözler önüne seriyor.\r\n\r\n​​Defne Parman, Doğa Çal ve Hilal Balcı’nın eserlerinden oluşan, Neriman Polat’ın küratörlüğünü üstlendiği “Parça Parça” başlıklı sergiyi, 8 Haziran Cumartesi gününe kadar Merdiven Art Space’te ziyaret edebilirsiniz.\r\n\r\n",
                    AuthorId = 2,
                    CreatedTime = DateTime.Now,
                    ReadCount = 23

                }, new Article
                {
                    Id = 3,
                    Title = "Talasemi ve Demir Eksikliği Anemisi Arasındaki Farklar",
                    Content = "Marmara Üniversitesi Pendik Eğitim ve Araştırma Hastanesi Hematoloji Kliniği uzmanlarından Doç. Dr. Asu Fergün Yılmaz, toplumda sıklıkla karşılaşılan demir eksikliği anemisiyle talasemi taşıyıcılığının karıştırılmaması gerektiğini ifade etti.\r\n\r\nYılmaz, basit kan testleriyle belirlenebilen bu iki hastalık arasındaki farkın yapılmamasının talasemi taşıyıcılarının gözden kaçmasına neden olabileceği konusunda uyardı. Doç. Dr. Yılmaz, “Demir eksikliği anemisiyle talasemi taşıyıcılığı çok karışabilen iki durum. Toplumumuzda demir eksikliği anemisi de çok yaygın gözükmekte. Basit kan tahlilleriyle bunların tanısını koyabiliyoruz.” diye konuştu.Vücutta sağlıklı olarak bulunan kırmızı kan hücrelerinin üretimini etkileyen kan bozukluğu olarak tanımlanan talasemi, Akdeniz çevresindeki ülkelerde sık görülmesi nedeniyle “Akdeniz anemisi” olarak da bilinmektedir. Talasemi, anne ve babadan çocuklara kalıtsal olarak geçmekte olup, Türkiye’nin de aralarında bulunduğu Akdeniz çevresindeki ülkelerde önemli bir halk sağlığı sorunu olarak karşımıza çıkıyor.\r\n\r\n“8 Mayıs Dünya Talasemi Günü” çerçevesinde açıklamalarda bulunan Doç. Dr. Asu Fergün Yılmaz, çok ciddi kan eksikliği yaşayan talasemi hastalarının ömür boyu kan nakliyle hayatlarını geçirmek zorunda olduğunu aktardı. Yılmaz, 3 tip talasemi olduğunu belirterek, şu ifadeleri kullandı;\r\n\r\n“Birincisi bizim hasta popülasyonu dediğimiz talasemi, majör olarak tanımladığımız gruptur. Bu grup hayatları boyunca belli aralıklarda üç dört haftada bir kan nakline ihtiyaç duyarlar. Bir diğer grup talasemi taşıyıcılarıdır. Talasemi taşıyıcıları aslında hasta değildir ancak evlendikleri durumda bu kişiler hasta çocuklara sahip olabilirler ve bu yüzden talasemi taşıyıcılarının toplumda belirlenmesi gerekir. Bir diğeri de talasemi intermediate dediğimiz bu iki grubun ortasındaki hastalardır. Bu hastalar da talasemi taşıyıcılarına göre daha ciddi kansızlıkla hayatlarını geçirmek zorundalardır. Belirli dönemlerde kan nakline ihtiyaç duyarlar ama diğer majör grubuna göre çok daha düşüktür kan nakli ihtiyacı.”",
                    AuthorId = 3,
                    CreatedTime = DateTime.Now,
                    ReadCount = 56,

                },
                new Article
                {
                    Id = 4,
                    Title = "F/K oranı nedir?",
                    Content = "En basit haliyle F/K oranı, bir şirketin hisse fiyatının hisse başına net kazanca (kâr) bölünmesiyle hesaplanan bir finansal metriktir.\r\n\r\nBu metrik, hisse senedinin elde ettiği kâra göre fiyatını değerlendirilmeye yardımcı olur. Böylelikle hisse senetlerinin ucuz mu yoksa pahalı mı fiyatlandığına yönelik bir fikir elde edinilmiş olunur.\r\n\r\nBu metrik ile ayrıca yatırımcıların gelecekteki kazanç artışı beklentileri de incelenerek, mevcut kazançlara göre yatırımcıların bir şirket için ne kadar ödemek istedikleri de bulunmaya çalışılır.\r\n\r\nBir şirketin hisse fiyatının 150 dolar ve hisse başına kazancının 30 dolar olduğunu varsayarsak, burada F/K oranı 5 olurken; bu bize, hisselerin mevcut kazanç seviyelerinin beş katından işlem gördüğünü söyler. Yatırımcılar ise F/K oranı ne kadar yüksekse, hisseyi satın almanın nispeten daha yüksek maliyetli olduğunu düşünür.\r\n\r\nÖrneğin, Tesla 48,34 F/K oranıyla işlem görürken, sektör ortalaması 21,1 seviyesinde seyretmektedir. Bu ise yatırımcılara şirketin hisselerinin sektör ortalaması üzerinden fiyatlandığını göstermektedir.\r\n\r\nFacebook'un ana şirketi Meta da ise tam tersi bir durum söz konusudur. Buna göre Meta, 23,02 F/K oranıyla işlem görürken; sektör ortalaması, 27,08 düzeyinde seyretmektedir. Bu ise Meta’nın sektöründeki diğer hisselere göre daha cazip fiyattan işlem gördüğü anlamına gelebilir.\r\n\r\nAncak bu bilginin tek başına şirket hisselerini satın almak ya da satmak için yeterli olmayacağı unutulmamalıdır. Bu metrik, alım satım kararlarında yardımcı bir araç olarak görülmelidir. \r\n\r\nAyrıca yaygın olarak bilinen ve kullanılan F/K oranı dışında, ileriye dönük F/K oranı hesaplaması da hisse senedinin analizinde kritik önem taşımaktadır.\r\n\r\nBuna göre, tarihi F/K oranı, son 12 ayın (takip eden 12 aylık kazançlar olarak bilinir) veya son mali yılın gerçek hisse başına kazançlarına dayanırken; ileriye dönük F/K oranı ise şirket veya analistler tarafından sağlanan bir sonraki mali yıl için tahmini hisse başına kazançlara dayanır.\r\n\r\nÖte yandan unutulmamalıdır ki hissenin fiyatı her an değişebildiği için F/K oranı da hem hisse fiyatıyla hem de çeyreklik kâr ile değişmektedir. Bu sebeple F/K oranı hiçbir zaman sabit bir değer sunmamaktadır.",
                    AuthorId = 4,
                    CreatedTime = DateTime.Now,
                    ReadCount = 45,

                },
                 new Article
                 {
                     Id = 5,
                     Title = "BORDERLİNE KİŞİLİK BOZUKLUĞUNDA SOSYAL İLİŞKİLER",
                     Content = "Borderline kişilik bozukluğu, kişinin kendini ve başkalarını algılama biçimini etkileyen bir psikolojik durumdur. Bu bozukluğa sahip kişiler, yoğun duygular, kararsızlık ve ilişkilerde istikrarsızlık yaşayabilirler. BKB’li kişiler için sosyal ilişkilerde genellikle zorlayıcı insanlardır. Bu kişilerin, ilişkilerinde sık sık aşırıya kaçan davranışlar sergilemeleri yaygındır. Örneğin, bir BKB’li kişi, yeni biriyle tanıştıktan kısa bir süre sonra onu hayatının aşkı olarak görebilir ve o kişiye aşırı derecede bağlanabilir. Bu bağlanma, karşı taraftan reddedilme veya uzaklaşma korkusuyla birlikte olabilir. BKB’li kişiler, bir ilişkiye çok hızlı başlayıp çok hızlı da bitirebilirler. Ayrıca, bir ilişki sürecindey iken, karşı tarafa öfke, nefret ve kıskançlık gibi yoğun duygular hissedebilirler. Bu duygular, ilişkilerinde çatışmalara ve hatta şiddete yol açabilir.\r\n\r\n \r\n\r\nİlişkilerinde aşırıya kaçan davranışlar sergileyen BKB’li kişiler, ilişkilerinde de güvensizlik yaşayabilirler. Bu kişiler, karşı tarafın onları terk edeceği veya aldatacağından endişe edebilirler. Bu endişe, ilişkilerinde kıskançlık ve şüphe gibi davranışlara yol açabilir. BKB’li kişilerin sosyal ilişkilerinde yaşadıkları zorluklar, onların yaşam kalitesini olumsuz etkileyebilir. Bu kişiler, yalnızlık, izolasyon ve reddedilmişlik duyguları yaşayabilirler. Ayrıca, sosyal ilişkilerindeki zorluklar, onların iş, okul ve kişisel yaşamlarında da sorunlara yol açabilir. Borderline kişilerin sosyal ilişkilerini geliştirmelerine yardımcı olmak için, psikolojik yardım almak önemlidir. BKB tedavisi, kişinin duygularını yönetmeyi, ilişkilerinde daha sağlıklı davranışlar sergilemeyi ve kendine güveni artırmayı öğrenmesine yardımcı olabilir.\r\n\r\n \r\n\r\nBKB’li kişilerin sosyal ilişkilerini geliştirmeleri için, kendi duygularını ve ihtiyaçlarını anlamaya çalışmalı. İlişkilerinde aşırıya kaçan davranışları fark edip ve bunlara karşı kendini korumalı. Kendini ve başkalarını yargılanmaktan kaçınmalı. Başkalarına güvenmeyi öğrenmeli. Bu önemli noktalara dikkat ederek gelişim için adım atılabilir ve bir uzmandan yardım alınabilir.",
                     AuthorId = 4,
                     CreatedTime = DateTime.Now,
                     ReadCount = 45,

                 },
                  new Article
                  {
                      Id = 6,
                      Title = "Eğitim ve Geleceğimiz",
                      Content = "Eğitim doğumdan ölüme kadar süren, aileden başlayarak okul ve sonrasında kültürel, sosyal boyutlarıyla tüm yaşamımızda birlikte olduğumuz bir kavramdır. Kısaca \"Eğitim yaşamın ta kendisidir\" de diyebiliriz. Kişinin gelişmesi, tecrübe sahibi olması ya da tekamül etmesi gibi olgular eğitimin amacıdır. Daha da açarsak, düşünce ve davranış şekillerini değiştiren, geliştiren bir süreçtir. İnsanı daha iyiye, daha güzele, daha yararlıya ulaştıran bir yaşama sanatıdır eğitim.\r\n\r\nEğitimi bu genel yönüyle tanıdıktan sonra, çok iyi biliriz ki toplumların, ülkelerin hatta tüm dünyanın geleceği iyi ve doğru eğitilmiş nesillerle sıkı sıkıya bağlıdır. İyi ve doğru eğitim de, öncelikle iyi ve doğru öğrenme ve öğretme ile başarıya ulaşır. O halde, iyi öğrenmek ve öğretmek için, büyük bir hızla gelişen teknolojinin eğitim alanında, insanlığa en iyi yararlı olabilecek şekilde ve olabildiğince kullanılması kaçınılmaz bir şart olarak karşımıza çıkıyor. \r\n\r\n\"Milenyum\" denilen ve 2000 yılıyla başlayan yeni bir dönemi yaşıyoruz ve bu dönemin çocukları, gençleri de bu yeni dönemin çok açık örnekleri olarak yepyeni bir nesli temsil ediyorlar. \"İnternet Çocukları\" da dediğimiz bu çocuklar, \"Cep telefonu\"nu, \"İpod\"u ve tüm ileri teknoloji araçlarını, bireysel yaşamlarının ayrılmaz bir parçası olarak kabullenmiş şekilde büyümekteler. Bilgisayar ekranlarında MSN ile yazışıyorlar, MP dinliyorlar, cep telefonlarından SMS atıyorlar ve böylesine bir hız ve karmaşa içerisinde düşünmeye zaman ayıramıyorlar. \r\n\r\nDüşünmeye zaman ayıramamak, ister istemez tembelliği de beraberinde getirir. Bu nedenle çalışmayı da sevmez oldular. Zaten her türlü bilgi, anında cep telefonlarında ya da bilgisayar aracılığıyla avuçlarının içinde. Böylesine kolayca sahiplenmek, maalesef tatminsiz ve sadakatsiz bir insan yapısının oluşmasına da neden oluyor. \r\n\r\nGençlerimiz ve çocuklarımız bu kadar kolay yaşama şansına sahip olmalarının sonucunda da, bol tüketmek, çabuk ve çok para kazanmak, borsa ve bahis oyunlarında ustalaşmayı zorlamak gibi, bize göre \"Ter dökmeden\" kurnazca arayışlar içindeler. İşte bu gerçeklerin ışığında eğitim sistemleri yeniden planlanmalı ve programlanmalıdır. Bunu bütün dünya ülkeleri için düşünmek zorundayız. \r\n\r\nYukarıda belirttiğim şartları göz önüne aldığımızda, eğitimin artık ne kadar zorlaştığını açıkca görüyoruz. Devamlı değişen dünya değerleri, global ekonomi, çok hızla gelişen iletişim sistemleri yalnızca milli değil, global anlamda da gençlerin eğitilmesi gereğini zorluyor. Yalnız, yeni eğitimin gerçekleşebilmesi için sadece ilkeler değil, ekonomik koşulların da sisteme uygulanması çok önemli bir şart olarak önümüzde duruyor. \r\n\r\nDünyada eğitimin nerelerde olduğu ve olacağı konusunda \"TUBİTAK Bilim ve Teknoloji Staratejileri Vizyon 2023\" de yapılan tespitler, bütün dünyanın durumunu ve geleceğini pek açık ortaya koyuyor. \"Dünyada gelişmiş ülkelerde, OECD dahil, eğitimin önemini vurgulamayan tek bir ülke olmamakla birlikte, yine gelişmiş ülkeler de dahil bütün ülkeler eğitime yeterince kaynak ayıramadıklarını, mevcut eğitim sistemlerinin yarının taleplerine hazır olmadığını ve eğitimin 21.Yüzyıl'a uygun bir yapıya kavuşturulması gerektiğini tartışıp durmaktadırlar. \r\n",
                      AuthorId = 2,
                      CreatedTime = DateTime.Now,
                     
                      ReadCount = 52,

                  }


                );

            builder.Entity<ArticleCategory>().HasData(
            new ArticleCategory
            {
                ArticleId = 1,
                CategoryId = 1
            },
             new ArticleCategory
             {
                 ArticleId = 2,
                 CategoryId = 13
             },
              new ArticleCategory
              {
                  ArticleId = 3,
                  CategoryId = 3
              },
               new ArticleCategory
               {
                   ArticleId = 4,
                   CategoryId = 12
               },
                new ArticleCategory
                {
                    ArticleId = 5,
                    CategoryId = 11
                },
                new ArticleCategory
               {
                    ArticleId = 6,
                    CategoryId = 4
               }
               );
        }
    }
}
