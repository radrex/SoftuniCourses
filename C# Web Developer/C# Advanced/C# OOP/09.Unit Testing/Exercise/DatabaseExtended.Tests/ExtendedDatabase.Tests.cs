namespace Tests
{
    using NUnit.Framework;
    using ExtendedDatabase; // comment for judge
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        //--------------- Constants ----------------
        private const int DatabaseCapacity = 16;

        //---------------- Fields ------------------
        private ExtendedDatabase extendedDatabase;
        private Person[] people;

        //------------- Initialization -------------
        [SetUp]
        public void Setup()
        {
            this.extendedDatabase = new ExtendedDatabase();
            people = new Person[]
            {
                new Person(20214141421, "qwerty"),
                new Person(21412412412, "xyz"),
                new Person(22646567658, "rng"),
                new Person(23141252366, "yeet"),
                new Person(24634634634, "l337"),
                new Person(25234234234, "memeDominator"),
                new Person(26546457777, "arrayExcavator"),
                new Person(27867999567, "Ivan_The_Destroyer"),
                new Person(28375478842, "OnModelDegrading"),
                new Person(29539859900, "BugFirstDevelopment"),
                new Person(30236534765, "asdf4"),
                new Person(31131245555, "Nero_The_Firefighter"),
                new Person(32004280552, "TransperentBoardMarker"),
                new Person(33087057979, "DelusionalMind"),
                new Person(34698759251, "Dr.Marcus"),
                new Person(35000583882, "Lazko_Lazkov"),
            };
        }

        //------------------ CONSTRUCTOR TESTS -------------------
        [Test]
        public void ConstructorShouldInitializeDatabaseWithExactly16People()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase(this.people);

            //Act

            //Assert
            Assert.AreEqual(DatabaseCapacity, this.extendedDatabase.Count);
        }

        [Test]
        public void ConstructorShouldInitializeDatabasePeopleCorrectly()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase(this.people);

            //Act

            //Assert
            for (int i = 0; i < this.extendedDatabase.Count; i++)
            {
                Person person = this.extendedDatabase.FindById(this.people[i].Id);
                long id = person.Id;
                
                Assert.AreEqual(this.people[i].Id, id);
            }
        }

        [Test]
        public void ConstructorShouldThrowArgumentExceptionWhenPassedMoreThan16People()
        {
            //Arrange
            Person[] people = new Person[17];
            this.people.CopyTo(people, 0);
            people[16] = new Person(36065884445, "JustIvan");

            //Act

            //Assert
            Assert.That(() => this.extendedDatabase = new ExtendedDatabase(people), Throws.ArgumentException
                                                                                          .With.Message
                                                                                          .EqualTo("Provided data length should be in range [0..16]!"));
        }

        //----------------- ADD OPERATION TESTS ------------------
        [Test]
        public void AddOperationExceeding16ElementsShouldThrowInvalidOperationException()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase(this.people);

            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.Add(new Person(35000583882, "Shifty")), Throws.InvalidOperationException
                                                                                                  .With.Message // should be 16 elements not 16 integers
                                                                                                  .EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddOperationShouldThrowInvalidOperationExceptionInAttemptToAddAlreadyExistingUsername()
        {
            //Arrange
            this.extendedDatabase.Add(new Person(35000583882, "Lazko_Lazkov"));

            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.Add(new Person(00141241241, "Lazko_Lazkov")), Throws.InvalidOperationException
                                                                                                        .With.Message
                                                                                                        .EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddOperationShouldThrowInvalidOperationExceptionInAttemptToAddAlreadyExistingUserWithSameId()
        {
            //Arrange
            this.extendedDatabase.Add(new Person(35000583882, "Lazko_Lazkov"));

            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.Add(new Person(35000583882, "Shifty")), Throws.InvalidOperationException
                                                                                                  .With.Message
                                                                                                  .EqualTo("There is already user with this Id!"));
        }

        //----------------- REMOVE OPERATION TESTS ---------------
        [Test]
        public void RemoveOperationShouldThrowInvalidOperationException()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase();

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Remove());
        }

        [Test]
        public void RemoveOperationShouldRemoveElementAtLastIndex()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase(new Person(35000583882, "Lazko_Lazkov"));

            //Act
            this.extendedDatabase.Remove();

            //Assert
            Assert.AreEqual(0, this.extendedDatabase.Count, "The collection is empty!");
        }

        //------------ FIND BY USERNAME OPERATION TESTS ----------
        [Test]
        public void FindByUsernameOperationShouldReturnMatchingUsername()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase(this.people);

            //Act
            Person lazko = people[15];
            Person expected = this.extendedDatabase.FindByUsername("Lazko_Lazkov");

            //Assert
            Assert.AreEqual(lazko.UserName, expected.UserName);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameOperationShouldThrowArgumentNullExceptionWhenPassingNullOrEmptyValue(string name)
        {
            //Arrange

            //Act

            //Assert
            //var ex = Assert.Throws<ArgumentNullException>(() => this.extendedDatabase.FindByUsername(name));
            //Assert.AreEqual(ex.ParamName, "Username parameter is null!");
            //Assert.That(ex.ParamName, Is.EqualTo("Username parameter is null!"));

            Assert.That(() => this.extendedDatabase.FindByUsername(name), Throws.Exception
                                                                                .TypeOf<ArgumentNullException>()
                                                                                .With.Property("ParamName")
                                                                                .EqualTo("Username parameter is null!"));
        }

        [Test]
        [TestCase("Lazko_Lazkov")]
        [TestCase("Unexisting_username")]
        public void FindByUsernameOperationShouldThrowInvalidOperationExceptionInAttemptToFindUserWithNoSuchUsername(string name)
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.FindByUsername(name), Throws.InvalidOperationException
                                                                                .With.Message
                                                                                .EqualTo("No user is present by this username!"));
        }

        //--------------- FIND BY ID OPERATION TESTS -------------
        [Test]
        public void FindByIdOperationShouldReturnMatchingUserWithGivenId()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase(this.people);

            //Act
            Person lazko = people[15];
            Person expected = this.extendedDatabase.FindById(35000583882);

            //Assert
            Assert.AreEqual(lazko.Id, expected.Id);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(long.MinValue)]
        public void FindByIdOperationShouldThrowArgumentOutOfRangeExceptionWhenPassingNegativeId(long id)
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.FindById(id), Throws.Exception
                                                                        .TypeOf<ArgumentOutOfRangeException>()
                                                                        .With.Property("ParamName")
                                                                        .EqualTo("Id should be a positive number!"));
        }

        [Test]
        [TestCase(666)]
        [TestCase(long.MaxValue)]
        public void FindByIdOperationShouldThrowInvalidOperationExceptionInAttemptToFindUserWithNoSuchId(long id)
        {
            //Arrange

            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.FindById(id), Throws.InvalidOperationException
                                                                        .With.Message
                                                                        .EqualTo("No user is present by this ID!"));
        }
    }
}