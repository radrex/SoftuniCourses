namespace Skeleton.Tests
{
    using Moq;
    using NUnit.Framework;
    using Skeleton.Contracts; // comment this using for judge otherwise won't pass

    public class HeroTests
    {
        //---------------- Fields ------------------
        private IWeapon weapon;
        private const int Attack = 10;
        private const int Durability = 10;

        private ITarget target;
        private const int Health = 10;
        private const int Experience = 5;

        private Hero hero;
        private const string HeroName = "Ivan the Destroyer";

        //-------------- Initializer ---------------
        [SetUp]
        public void TestInit()
        {
            this.weapon = new Axe(Attack, Durability);
            this.target = new Dummy(Health, Experience);
            this.hero = new Hero(HeroName, this.weapon);
        }

        //---------------- Tests -------------------
        [Test]
        public void HeroGainsExperienceWhenTargetIsDestroyed()
        {
            //Arrange

            //Act
            this.hero.Attack(this.target);

            //Assert
            Assert.AreEqual(this.target.GiveExperience(), hero.Experience, "Hero doesn't gain the correct amount of experience.");
        }

        [Test]
        public void HeroGainsExperienceWhenTargetIsDestroyedMoqVersion()
        {
            // Arrange
            Mock<ITarget> target = new Mock<ITarget>();
            target.Setup(t => t.Health).Returns(0);
            target.Setup(t => t.GiveExperience()).Returns(10);
            target.Setup(t => t.IsDead()).Returns(true);

            Mock<IWeapon> weapon = new Mock<IWeapon>();
            Hero hero = new Hero(HeroName, weapon.Object);

            // Act
            hero.Attack(target.Object);

            // Assert
            Assert.AreEqual(10, hero.Experience);
        }
    }
}
