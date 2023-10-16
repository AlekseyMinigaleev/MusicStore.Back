using Bogus;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations;
using MusicStore.DB.Models;

#nullable disable

namespace MusicStore.DB.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        public seeding()
        {

        }
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var songwriterFaker = new Faker<Songwriter>()
                .CustomInstantiator(f =>
                    new Songwriter(
                        firstName: f.Name.FirstName(),
                        secondName: f.Name.LastName(),
                        patronomyc: "",
                        musics: new List<Music>().ToHashSet()));

           

            var manufactoringCompanyFaker = new Faker<ManufacturingCompany>()
                .CustomInstantiator(f =>
                    new ManufacturingCompany(
                        name: f.Company.CompanyName(),
                        shortName: "",
                        address: f.Address.FullAddress(),
                        manufacturedDisks: new List<CompactDisk>().ToHashSet()
                        ));

            var musicantFaker = new Faker<Musicant>()
                 .CustomInstantiator(f =>
                    new Musicant(
                        firstName: f.Name.FirstName(),
                        secondName: f.Name.LastName(),
                        patronomyc: "",
                        musicalInstrument: f.Random.ListItem(new[] { "Скрипка", "Виолончель", "Флейта", "Кларнет", "Фагот", "Труба", "Тромбон", "Туба", "Контрабас", "Альт", "Гобой", "Валторна", "Ударные инструменты (барабаны, ксилофон и др.)", "Саксофон (альт, тенор, баритон)", "Электрогитара", "Бас-гитара", "Пианино", "Гитара", "Клавесин", "Орган", "Барабаны с малой плотностью", "Акустическая гитара", "Перкуссия (тамбурин, маракасы)", "Гармоника", "Мандолина", "Банджо", "Аккордеон", "Концертина", "Баритон" }),
                        ensembles:new List<Ensemble>().ToHashSet()
                        ));

            var manufactoringCompanies = manufactoringCompanyFaker.Generate(2);
            var musicants = musicantFaker.Generate(10);
            var songwriters = songwriterFaker.Generate(10);

            var musicFaker = new Faker<Music>()
              .CustomInstantiator(f =>
                  new Music(
                      name: f.Commerce.ProductName(),
                      genre: f.Music.Genre(),
                      author: f.Random.ListItem(songwriters),
                      performances: new List<Performance>().ToHashSet(),
                        compactDisks: new List<CompactDisk>().ToHashSet()
                        ));

            var musics = musicFaker.Generate(10);

            var connectionString = "Server=.;Database=MusicStore;Trusted_Connection=True;Trust Server Certificate=Yes;";

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();
            try
            {
                foreach (var company in manufactoringCompanies)
                {
                    var insertQuery = "INSERT INTO ManufactoringCompany (Id, Name, ShortName, Address, WhosalerPrice) " +
                                         "VALUES (@Id, @Name, @ShortName, @Address, @WhosalerPrice)";

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
                    cmd.Parameters.AddWithValue("@LastName", musicant.SecondName);
                    cmd.Parameters.AddWithValue("@Patronomyc", musicant.Patronomyc);
                    cmd.Parameters.AddWithValue("@MusicalInstrument", musicant.MusicalInstrument);

                    cmd.ExecuteNonQuery();
                }

                foreach (var songwriter in songwriters)
                {
                    var insertQuery = "INSERT INTO Songwriter (Id, FirstName, LastName, Patronomyc) " +
                                         "VALUES (@Id, @FirstName, @LastName, @Patronomyc)";

                    using var cmd = new SqlCommand(insertQuery, connection, transaction);
                    cmd.Parameters.AddWithValue("@Id", songwriter.Id);
                    cmd.Parameters.AddWithValue("@FirstName", songwriter.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", songwriter.SecondName);
                    cmd.Parameters.AddWithValue("@Patronomyc", songwriter.Patronomyc);

                    cmd.ExecuteNonQuery();
                }

                

                foreach (var music in musics)
                {
                    var insertQuery = "INSERT INTO Music (Id, Name, Genre, AutorId)" +
                                        "VALUES (@Id, @Name, @Genre, @Autor)";

                    using var cmd = new SqlCommand(insertQuery, connection, transaction);
                    cmd.Parameters.AddWithValue("@Id", music.Id);
                    cmd.Parameters.AddWithValue("@Name", music.Name);
                    cmd.Parameters.AddWithValue("@Genre", music.Genre);
                    cmd.Parameters.AddWithValue("@AutorId", music.Autor.Id);

                    cmd.ExecuteNonQuery();
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
