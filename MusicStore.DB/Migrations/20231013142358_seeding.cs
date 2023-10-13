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
            var musicFaker = new Faker<Music>()
                .CustomInstantiator(f =>
                    new Music(
                        name: f.Commerce.ProductName(),
                        genre: f.Music.Genre(),
                        autorFIO: f.Person.FullName,
                        performances: new List<Performance>().ToHashSet(),
                        compactDisks: new List<CompactDisk>().ToHashSet()
                        ));

            var manufactoringCompanyFaker = new Faker<ManufacturingCompany>()
                .CustomInstantiator(f =>
                    new ManufacturingCompany(
                        name: f.Company.CompanyName(),
                        shortName: "",
                        address: f.Address.FullAddress(),
                        whosalerPrice: f.Random.Int(100 - 10000),
                        manufacturedDisks: new List<CompactDisk>().ToHashSet()
                        ));

            var musicantFaker = new Faker<Musicant>()
                 .CustomInstantiator(f =>
                    new Musicant(
                        firstName: f.Name.FirstName(),
                        lastName: f.Name.LastName(),
                        patronomyc: "",
                        profileLink: f.Person.Website,
                        leaderEnsembles: new List<Ensemble>().ToHashSet(),
                        orchestraConductorEnsembles: new List<Ensemble>().ToHashSet(),
                        composerEnsembles: new List<Ensemble>().ToHashSet(),
                        musicalInstrument: f.Random.ListItem(new[] { "Скрипка", "Виолончель", "Флейта", "Кларнет", "Фагот", "Труба", "Тромбон", "Туба", "Контрабас", "Альт", "Гобой", "Валторна", "Ударные инструменты (барабаны, ксилофон и др.)", "Саксофон (альт, тенор, баритон)", "Электрогитара", "Бас-гитара", "Пианино", "Гитара", "Клавесин", "Орган", "Барабаны с малой плотностью", "Акустическая гитара", "Перкуссия (тамбурин, маракасы)", "Гармоника", "Мандолина", "Банджо", "Аккордеон", "Концертина", "Баритон" })
                        ));

            var ensembleMemberFaker = new Faker<EnsembleMember>()
                 .CustomInstantiator(f =>
                    new EnsembleMember(
                        firstName: f.Name.FirstName(),
                        lastName: f.Name.LastName(),
                        patronomyc: "",
                        profileLink: f.Person.Website,
                        leaderEnsembles: new List<Ensemble>().ToHashSet(),
                        orchestraConductorEnsembles: new List<Ensemble>().ToHashSet(),
                        composerEnsembles: new List<Ensemble>().ToHashSet()
                        ));

            var ensembleMembers = ensembleMemberFaker.Generate(3);
            var manufactoringCompanies = manufactoringCompanyFaker.Generate(2);
            var musicants = musicantFaker.Generate(10);
            var musics = musicFaker.Generate(10);

            var connectionString = "Server=.;Database=MusicStore;Trusted_Connection=True;Trust Server Certificate=Yes;";

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();
            try
            {
                foreach (var ensembleMember in ensembleMembers)
                {
                    var insertQuery = "INSERT INTO EnsembleMembers (Id, FirstName, LastName, Patronomyc, ProfileLink, Discriminator, MusicalInstrument) " +
                                         "VALUES (@Id, @FirstName, @LastName, @Patronomyc, @ProfileLink, @Discriminator, @MusicalInstrument)";

                    using var cmd = new SqlCommand(insertQuery, connection, transaction);
                    cmd.Parameters.AddWithValue("@Id", ensembleMember.Id);
                    cmd.Parameters.AddWithValue("@FirstName", ensembleMember.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", ensembleMember.LastName);
                    cmd.Parameters.AddWithValue("@Patronomyc", ensembleMember.Patronomyc);
                    cmd.Parameters.AddWithValue("@ProfileLink", ensembleMember.ProfileLink);
                    cmd.Parameters.AddWithValue("@Discriminator", "EnsembleMember");
                    cmd.Parameters.AddWithValue("@MusicalInstrument", "");

                    cmd.ExecuteNonQuery();
                }

                foreach (var musicant in musicants)
                {
                    var insertQuery = "INSERT INTO EnsembleMembers (Id, FirstName, LastName, Patronomyc, ProfileLink, Discriminator, MusicalInstrument) " +
                                        "VALUES (@Id, @FirstName, @LastName, @Patronomyc, @ProfileLink, @Discriminator, @MusicalInstrument)";

                    using var cmd = new SqlCommand(insertQuery, connection, transaction);
                    cmd.Parameters.AddWithValue("@Id", musicant.Id);
                    cmd.Parameters.AddWithValue("@FirstName", musicant.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", musicant.LastName);
                    cmd.Parameters.AddWithValue("@Patronomyc", musicant.Patronomyc);
                    cmd.Parameters.AddWithValue("@ProfileLink", musicant.ProfileLink);
                    cmd.Parameters.AddWithValue("@Discriminator", "Musicant");
                    cmd.Parameters.AddWithValue("@MusicalInstrument", musicant.MusicalInstrument);

                    cmd.ExecuteNonQuery();
                }

                foreach (var music in musics)
                {
                    var insertQuery = "INSERT INTO Music (Id, Name, Genre, Autor)" +
                                        "VALUES (@Id, @Name, @Genre, @Autor)";

                    using var cmd = new SqlCommand(insertQuery, connection, transaction);
                    cmd.Parameters.AddWithValue("@Id", music.Id);
                    cmd.Parameters.AddWithValue("@Name", music.Name);
                    cmd.Parameters.AddWithValue("@Genre", music.Genre);
                    cmd.Parameters.AddWithValue("@Autor", music.Autor);

                    cmd.ExecuteNonQuery();
                }

                foreach (var company in manufactoringCompanies)
                {
                    var insertQuery = "INSERT INTO ManufactoringCompany (Id, Name, ShortName, Address, WhosalerPrice) " +
                                         "VALUES (@Id, @Name, @ShortName, @Address, @WhosalerPrice)";

                    using var cmd = new SqlCommand(insertQuery, connection, transaction);
                    cmd.Parameters.AddWithValue("@Id", company.Id);
                    cmd.Parameters.AddWithValue("@Name", company.Name);
                    cmd.Parameters.AddWithValue("@ShortName", company.ShortName);
                    cmd.Parameters.AddWithValue("@Address", company.Address);
                    cmd.Parameters.AddWithValue("@WhosalerPrice", company.WhosalerPrice);

                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
            }
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
