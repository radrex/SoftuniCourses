using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    //---------------- Fields ----------------
    private Hero hero;
    private HeroRepository heroRepository;

    //------------- Initialization -----------
    [SetUp]
    public void Setup()
    {
        this.hero = new Hero("Lazko_Lazkov", 5);
        this.heroRepository = new HeroRepository();
    }


    //----------- CONSTRUCTOR TESTS ----------
    //---- HERO ----
    [Test]
    public void ConstructorShouldInitializeNamePropertyCorrectly()
    {
        Assert.AreEqual("Lazko_Lazkov", this.hero.Name);
    }

    [Test]
    public void ConstructorShouldInitializeLevelPropertyCorrectly()
    {
        Assert.AreEqual(5, this.hero.Level);
    }

    //---- HERO REPOSITORY ----
    [Test]
    public void ConstructorShouldInitializeCollectionCorrectly()
    {
        IReadOnlyCollection<Hero> heroes = new List<Hero>();
        CollectionAssert.AreEqual(heroes, this.heroRepository.Heroes);
    }

    //-------------- METHOD TESTS ------------
    //---- CREATE ----
    [Test]
    public void CreateOperationShouldThrowArgumentNullExceptionInAttemptToCreateNull()
    {
        Assert.That(() => this.heroRepository.Create(null), Throws.TypeOf<ArgumentNullException>()
                                                                  .With.Property("ParamName")
                                                                  .EqualTo("hero"));
    }

    [Test]
    public void CreateOperationShouldThrowInvalidOperationExceptionInAttemptToCreateAlreadyExistingHero()
    {
        this.heroRepository.Create(this.hero);
        Assert.That(() => this.heroRepository.Create(this.hero), Throws.InvalidOperationException
                                                                       .With.Message
                                                                       .EqualTo($"Hero with name {this.hero.Name} already exists"));
    }

    [Test]
    public void CreateOperationShouldCreateHeroSuccessfully()
    {
        IReadOnlyCollection<Hero> heroes = new List<Hero>() { this.hero };
        this.heroRepository.Create(this.hero);

        CollectionAssert.AreEqual(heroes, this.heroRepository.Heroes);
    }

    [Test]
    public void CreateOperationShouldReturnCorrectMessage()
    {
        string expectedMessage = $"Successfully added hero {this.hero.Name} with level {this.hero.Level}";

        Assert.AreEqual(expectedMessage, this.heroRepository.Create(this.hero));
    }

    //---- REMOVE ----
    [Test]
    [TestCase(" ")]
    [TestCase("  ")]
    [TestCase("   ")]
    [TestCase(null)]
    public void RemoveOperationShouldThrowArgumentNullExceptionInAttemptToRemoveHeroWithNullOrWhitespaceName(string name)
    {
        Assert.That(() => this.heroRepository.Remove(name), Throws.TypeOf<ArgumentNullException>()
                                                                  .With.Property("ParamName")
                                                                  .EqualTo("name"));
    }

    [Test]
    public void RemoveOperationShouldReturnTrueOnRemove()
    {
        this.heroRepository.Create(this.hero);
        Assert.AreEqual(true, this.heroRepository.Remove(this.hero.Name));
    }

    [Test]
    public void RemoveOperationShouldReturnFalseOnRemove()
    {
        Assert.AreEqual(false, this.heroRepository.Remove("Nikoi"));
    }

    //---- GET HERO WITH HIGHEST LEVEL ----
    [Test]
    public void GetHeroWithHighestLevelOperationShouldReturnHighestLevelHero()
    {
        this.heroRepository.Create(this.hero);
        this.heroRepository.Create(new Hero("Ivan", 2));
        Assert.AreEqual(this.hero, this.heroRepository.GetHeroWithHighestLevel());
    }

    //---- GET HERO ----
    [Test]
    public void GetHeroOperationShouldReturnHero()
    {
        this.heroRepository.Create(this.hero);
        Assert.AreEqual(this.hero, this.heroRepository.GetHero(this.hero.Name));
    }

    //---- GET HERO ----
    [Test]
    public void HeroesPropertyShouldReturnCorrectCollection()
    {
        IReadOnlyCollection<Hero> heroes = new List<Hero>() { this.hero };
        this.heroRepository.Create(this.hero);

        CollectionAssert.AreEqual(heroes, this.heroRepository.Heroes);
    }
}