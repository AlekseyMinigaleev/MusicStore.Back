using Bogus;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Query;
using MusicStore.DB.Enums;
using MusicStore.DB.Models;

#nullable disable

namespace MusicStore.DB.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var musicNamesAuthorsGenres = new[]
            {
                new { Name = "Буремные высоты", Author = "Петр Чайковский", Genre = "Симфония" },
                new { Name = "Соул серфинг", Author = "Майкл Джексон", Genre = "Поп, соул" },
                new { Name = "Летящий в небесах", Author = "Эрик Клэптон", Genre = "Рок, блюз" },
                new { Name = "Ода к радости", Author = "Людвиг ван Бетховен", Genre = "Симфония" },
                new { Name = "Боем, гроза замолкла", Author = "Владимир Высоцкий", Genre = "Авторская песня" },
                new { Name = "Шедевр в синем", Author = "Джордж Гершвин", Genre = "Джаз" },
                new { Name = "Пятая симфония", Author = "Людвиг ван Бетховен", Genre = "Симфония" },
                new { Name = "Странный день в городе", Author = "The Cure", Genre = "Пост-панк, новая волна" },
                new { Name = "Город в огне", Author = "Брюс Спрингстин", Genre = "Рок" },
                new { Name = "Поющие в дождь", Author = "Нино Рота", Genre = "Саундтрек" },
            };

            var musicEnsemblesGenres = new[]
            {
                new { Ensemble = "Барокко Стринг Квартет", Genre = "Классика" },
                new { Ensemble = "Гроза Блюз Бенд", Genre = "Блюз" },
                new { Ensemble = "Экспериментальные Звуки Лаборатории", Genre = "Экспериментальная музыка" },
                new { Ensemble = "Фолк Хармонии Коллектив", Genre = "Фолк" },
                new { Ensemble = "Джазовый Оркестр Нового Века", Genre = "Джаз" },
                new { Ensemble = "Поп Рок Аккорд", Genre = "Поп, Рок" },
                new { Ensemble = "Трансцендентальные Клавишные Моменты", Genre = "Классика, Новая волна" },
                new { Ensemble = "Свинговая Ритм-Машина", Genre = "Свинг" },
                new { Ensemble = "Синтезатор Сферических Звуков", Genre = "Электроника, Амбиент" },
                new { Ensemble = "Регги Ритмическая Секция", Genre = "Регги" },
                new { Ensemble = "Металлический Шторм Гитары", Genre = "Металл" },
                new { Ensemble = "Латино-Танцевальный Оркестр", Genre = "Латино, Танцевальная музыка" },
                new { Ensemble = "Аккордеонисты Италии", Genre = "Верди, Аккордеон" },
                new { Ensemble = "Барбершоп Квартет Гармонии", Genre = "Акапелла" },
                new { Ensemble = "Фьюжн Фантазия Группа", Genre = "Фьюжн" },
                new { Ensemble = "Индийская Рага Симфония", Genre = "Индийская классическая музыка" },
                new { Ensemble = "Рок-н-Ролльные Рифмы Кометы", Genre = "Рок-н-ролл" },
                new { Ensemble = "Сингапурский Шансон Квартет", Genre = "Шансон" },
                new { Ensemble = "Африканская Перкуссионная Энергия", Genre = "Африканская музыка, Перкуссия" },
                new { Ensemble = "Токийский Электронный Эксперимент", Genre = "Электроника, Техно" },
            };

            var random = new Random();
            var durations = Enumerable.Range(1, 6)
                .Select(_ => TimeSpan.FromMinutes(random.Next(1, 10)).Add(TimeSpan.FromSeconds(random.Next(1, 60))));

            var manufactoringCompanyFaker = new Faker<ManufacturingCompany>()
                .CustomInstantiator(f =>
                    new ManufacturingCompany(
                        name: f.Company.CompanyName(),
                        shortName: "",
                        address: f.Address.FullAddress(),
                        manufacturedDisks: new List<CompactDisk>().ToHashSet()
                        ));

            var musicFaker = new Faker<Music>()
                .CustomInstantiator(f =>
                {
                    var selectedMusic = f.PickRandom(musicNamesAuthorsGenres);
                    var selectedEnsembleNames = f.PickRandom(musicEnsemblesGenres);

                    return new Music(
                        name: selectedMusic.Name,
                        genre: selectedMusic.Genre,
                        author: new Songwriter(
                            firstName: selectedMusic.Author.Split(' ')[0],
                            lastName: selectedMusic.Author.Split(' ')[1],
                            patronomyc: "",
                            musics: new List<Music>().ToHashSet()
                        ),
                        performances: new HashSet<Performance>()
                        {
                            new Performance(
                                    place: f.Address.FullAddress(),
                                    name: selectedMusic.Name + " " + selectedEnsembleNames.Genre,
                                    ensambel: new Ensemble(
                                            name: selectedEnsembleNames.Ensemble,
                                            musicants:  new HashSet<Musicant>(),
                                            ensumbleTypeRuleDto: new List<TDOs.EnsembleTypeRuleDto>().ToArray(),
                                            performance: new HashSet<Performance>()
                                        ),
                                    musicalMetadata: new MusicalMetadata(
                                        duration: f.PickRandom(durations),
                                        tempo: f.Random.Enum<MusicTempo>(),
                                        interpretation: selectedEnsembleNames.Genre),
                                    music: null
                                ),
                        },
                        compactDisks: new List<CompactDisk>().ToHashSet()
                    );
                });

            var musics = musicFaker.Generate(10);
            var manufactoringCompanies = manufactoringCompanyFaker.Generate(2);

            var compactDiscFaker = new Faker<CompactDisk>()
               .CustomInstantiator(f =>
                   new CompactDisk(
                           music: f.PickRandom(musics),
                           manufacturingCompany: f.Random.ListItem(manufactoringCompanies),
                           retailPrice: f.Random.Decimal(100, 1000),
                           whosalerPrice: f.Random.Decimal(50, 500),
                           countInStock: 100
                       ));

            var musicantFaker = new Faker<Musicant>()
                 .CustomInstantiator(f =>
                    new Musicant(
                        firstName: f.Name.FirstName(),
                        lastName: f.Name.LastName(),
                        patronomyc: null,
                        musicalInstrument: f.Random.ListItem(new[] { "Скрипка", "Виолончель", "Флейта", "Кларнет", "Фагот", "Труба", "Тромбон", "Туба", "Контрабас", "Альт", "Гобой", "Валторна", "Ударные инструменты (барабаны, ксилофон и др.)", "Саксофон (альт, тенор, баритон)", "Электрогитара", "Бас-гитара", "Пианино", "Гитара", "Клавесин", "Орган", "Барабаны с малой плотностью", "Акустическая гитара", "Перкуссия (тамбурин, маракасы)", "Гармоника", "Мандолина", "Банджо", "Аккордеон", "Концертина", "Баритон" }),
                        ensembles: new List<Ensemble>().ToHashSet()
                        ));

            var musicants = musicantFaker.Generate(10);

            var compactDiscs = compactDiscFaker.Generate(10);

            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            var connectionString = $"Data Source = {dbHost}; Initial Catalog={dbName};Integrated security=False; User ID=sa; Password={dbPassword};Trust Server Certificate=Yes;";
            
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();
            try
            {
                foreach (var company in manufactoringCompanies)
                {
                    var insertQuery = "INSERT INTO ManufactoringCompany (Id, Name, ShortName, Address) " +
                                         "VALUES (@Id, @Name, @ShortName, @Address)";

                    using var cmd = new SqlCommand(insertQuery, connection, transaction);
                    cmd.Parameters.AddWithValue("@Id", company.Id);
                    cmd.Parameters.AddWithValue("@Name", company.Name);
                    cmd.Parameters.AddWithValue("@ShortName", company.ShortName);
                    cmd.Parameters.AddWithValue("@Address", company.Address);
                    cmd.ExecuteNonQuery();
                }

                foreach (var musicant in musicants)
                {
                    var insertQuery = "INSERT INTO Musicant (Id, FirstName, LastName, Patronomyc, MusicalInstrument) " +
                                        "VALUES (@Id, @FirstName, @LastName, @Patronomyc, @MusicalInstrument)";

                    using var cmd = new SqlCommand(insertQuery, connection, transaction);
                    cmd.Parameters.AddWithValue("@Id", musicant.Id);
                    cmd.Parameters.AddWithValue("@FirstName", musicant.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", musicant.LastName);
                    cmd.Parameters.AddWithValue("@Patronomyc", DBNull.Value);
                    cmd.Parameters.AddWithValue("@MusicalInstrument", musicant.MusicalInstrument);

                    cmd.ExecuteNonQuery();
                }

                foreach (var songwriter in musics.Select(x => x.Author))
                {
                    var insertQuery = "INSERT INTO Songwriter (Id, FirstName, LastName, Patronomyc) " +
                                         "VALUES (@Id, @FirstName, @LastName, @Patronomyc)";

                    using var cmd = new SqlCommand(insertQuery, connection, transaction);
                    cmd.Parameters.AddWithValue("@Id", songwriter.Id);
                    cmd.Parameters.AddWithValue("@FirstName", songwriter.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", songwriter.LastName);
                    cmd.Parameters.AddWithValue("@Patronomyc", songwriter.Patronomyc);

                    cmd.ExecuteNonQuery();
                }

                foreach (var music in musics)
                {
                    var insertQuery = "INSERT INTO Music (Id, Name, Genre, AuthorId)" +
                                        "VALUES (@Id, @Name, @Genre,@AuthorId)";

                    using var cmd = new SqlCommand(insertQuery, connection, transaction);
                    cmd.Parameters.AddWithValue("@Id", music.Id);
                    cmd.Parameters.AddWithValue("@Name", music.Name);
                    cmd.Parameters.AddWithValue("@Genre", music.Genre);
                    cmd.Parameters.AddWithValue("@AuthorId", music.Author.Id);

                    cmd.ExecuteNonQuery();
                }

                foreach (var compactDisc in compactDiscs)
                {
                    var insertQuery = "INSERT INTO CompactDisk (Id, Name, CreationDate, RetailPrice, WhosalerPrice, CountInStock, CountSoldPreviousYear, CountSoldCurrentYear, MusicId, ManufacturingCompanyId)" +
                                      "VALUES (@Id, @Name, @CreationDate, @RetailPrice, @WhosalerPrice, @CountInStock, @CountSoldPreviousYear, @CountSoldCurrentYear, @MusicId, @ManufacturingCompanyId)";

                    using var cmd = new SqlCommand(insertQuery, connection, transaction);
                    cmd.Parameters.AddWithValue("@Id", compactDisc.Id);
                    cmd.Parameters.AddWithValue("@Name", compactDisc.Name);
                    cmd.Parameters.AddWithValue("@CreationDate", compactDisc.CreationDate);
                    cmd.Parameters.AddWithValue("@RetailPrice", compactDisc.RetailPrice);
                    cmd.Parameters.AddWithValue("@WhosalerPrice", compactDisc.WhosalerPrice);
                    cmd.Parameters.AddWithValue("@CountInStock", compactDisc.CountInStock);
                    cmd.Parameters.AddWithValue("@CountSoldPreviousYear", DBNull.Value);
                    cmd.Parameters.AddWithValue("@CountSoldCurrentYear", compactDisc.CountSoldCurrentYear);
                    cmd.Parameters.AddWithValue("@MusicId", compactDisc.MusicId);
                    cmd.Parameters.AddWithValue("@ManufacturingCompanyId", compactDisc.ManufacturingCompanyId);

                    cmd.ExecuteNonQuery();
                }

                foreach (var ensemble in musics.SelectMany(x => x.Performances).Select(x => x.Ensemble))
                {
                    var insertQuery = "INSERT INTO Ensemble (Id, Type, Name)" +
                                      "VALUES (@Id, @Type, @Name)";

                    using var cmd = new SqlCommand(insertQuery, connection, transaction);
                    cmd.Parameters.AddWithValue("@Id", ensemble.Id);
                    cmd.Parameters.AddWithValue("@Type", ensemble.Type);
                    cmd.Parameters.AddWithValue("@Name", ensemble.Name);

                    cmd.ExecuteNonQuery();
                }

                foreach (var musicalMetadata in musics.SelectMany(x => x.Performances).Select(x => x.MusicalMetadata))
                {
                    var insertQuery = "INSERT INTO MusicalMetadata (Id, Duration, Tempo, Interpretation)" +
                                      "VALUES (@Id, @Duration, @Tempo, @Interpretation)";

                    using var cmd = new SqlCommand(insertQuery, connection, transaction);
                    cmd.Parameters.AddWithValue("@Id", musicalMetadata.Id);
                    cmd.Parameters.AddWithValue("@Duration", musicalMetadata.Duration);
                    cmd.Parameters.AddWithValue("@Tempo", musicalMetadata.Tempo);
                    cmd.Parameters.AddWithValue("@Interpretation", musicalMetadata.Interpretation);

                    cmd.ExecuteNonQuery();
                }

                foreach (var music in musics)
                {
                    foreach (var performance in music.Performances)
                    {
                        var insertQuery = "INSERT INTO Performance (Id, Place, Name, EnsembleId, MusicId, MusicalMetadataId)" +
                                     "VALUES (@Id, @Place, @Name, @EnsembleId, @MusicId, @MusicalMetadataId)";

                        using var cmd = new SqlCommand(insertQuery, connection, transaction);
                        cmd.Parameters.AddWithValue("@Id", performance.Id);
                        cmd.Parameters.AddWithValue("@Place", performance.Place);
                        cmd.Parameters.AddWithValue("@Name", performance.Name);
                        cmd.Parameters.AddWithValue("@EnsembleId", performance.EnsembleId);
                        cmd.Parameters.AddWithValue("@MusicId", music.Id);
                        cmd.Parameters.AddWithValue("@MusicalMetadataId", performance.MusicalMetadataId);

                        cmd.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine("===========================================================================================================================================================================================================================================================================================================================================================================");
                Console.WriteLine("===========================================================================================================================================================================================================================================================================================================================================================================");
                Console.WriteLine("===========================================================================================================================================================================================================================================================================================================================================================================");
                Console.WriteLine("===========================================================================================================================================================================================================================================================================================================================================================================");
                Console.WriteLine(e.Message);
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}