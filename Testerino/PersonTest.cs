using NUnit.Framework;
using Obblig_1;


namespace Testerino
{
    public class PersonTest
    {
        [Test]
        public void TestAllFields()
        {
            var p = new Person
            {
                Id = 17,
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = 2000,
                DeathYear = 3000,
                Father = new Person() { Id = 23, FirstName = "Per" },
                Mother = new Person() { Id = 29, FirstName = "Lise" },
            };

            var actualDescription = p.getDescription();
            var expectedDescription = "Ola Nordmann (Id=17) Født: 2000 Død: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
        
        [Test]
        public void TestNoFields()
        {
            var p = new Person
            {
                Id = 1,
            };

            var actualDescription = p.getDescription();
            var expectedDescription = "(Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
        [Test]
        public void Knoobs()
        {
            var p = new Person
            {
                Id = 1,
                FirstName = "Johnny",
                LastName = "343",
                BirthYear = 1,
                DeathYear = 2021,
                Mother = new Person() { Id = 33333 },
            };
            var actualDescription = p.getDescription();
            var expectedDescription = "Johnny 343 (Id=1) Født: 1 Død: 2021 Mor: (Id=33333)";
            Assert.AreEqual(expectedDescription, actualDescription);
        }
        [Test]
        public void Test2()
        {
            var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
            var ingridAlexandra = new Person { Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
            var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
            var harald = new Person { Id = 6, FirstName = "Harald", BirthYear = 1937 };
            sverreMagnus.Father = haakon;
            ingridAlexandra.Father = haakon;
            haakon.Father = harald;

            var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon);
            var actualResponse = app.HandleCommand("vis 3");
            var expectedResponse = "Haakon Magnus (Id=3) Født: 1973 Far: Harald (Id=6)\n"
                                   + "  Barn:\n"
                                   + "    Sverre Magnus (Id=1) Født: 2005\n"
                                   + "    Ingrid Alexandra (Id=2) Født: 2004\n";
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [Test]
        public void Test5()
        {
            var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
            var ingridAlexandra = new Person { Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
            var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
            var harald = new Person { Id = 6, FirstName = "Harald", BirthYear = 1937 };
            sverreMagnus.Father = haakon;
            ingridAlexandra.Father = haakon;
            haakon.Father = harald;

            var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon);
            var actualResponse = app.HandleCommand("vis 1");
            var expectedResponse = "Sverre Magnus (Id=1) Født: 2005 Far: Haakon Magnus (Id=3)\n";
            Assert.AreEqual(expectedResponse, actualResponse);
        }
    }
}