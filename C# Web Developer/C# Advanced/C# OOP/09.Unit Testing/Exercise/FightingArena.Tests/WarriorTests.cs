namespace Tests
{
    using FightingArena; // comment for judge
    using NUnit.Framework;

    public class WarriorTests
    {
        //--------------- Constants ----------------
        private const int MIN_ATTACK_HP = 30;

        //---------------- Fields ------------------
        private Warrior warrior;

        //------------- Initialization -------------
        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Lazko_Lazkov", 25, 120);
        }

        //------------------ CONSTRUCTOR TESTS -------------------
        //--------- NAME ----------
        [Test]
        [TestCase("Lazko_Lazkov", 25, 120)]
        public void ConstructorShouldInitializeNameCorrectly(string name, int damage, int hp)
        {
            warrior = new Warrior(name, damage, hp);
            Assert.AreEqual(name, this.warrior.Name);
        }

        [Test]
        [TestCase("", 25, 120)]
        [TestCase(" ", 25, 120)]
        [TestCase("  ", 25, 120)]
        [TestCase("   ", 25, 120)]
        [TestCase(null, 25, 120)]
        public void ConstructorShouldThrowArgumentExceptionInAttemptToSetNameValueToNullOrWhitespace(string name, int damage, int hp)
        {
            Assert.That(() => this.warrior = new Warrior(name, damage, hp), Throws.ArgumentException
                                                                                  .With.Message
                                                                                  .EqualTo("Name should not be empty or whitespace!"));
        }

        //-------- DAMAGE ---------
        [Test]
        [TestCase("Lazko_Lazkov", 25, 120)]
        public void ConstructorShouldInitializeDamageCorrectly(string name, int damage, int hp)
        {
            warrior = new Warrior(name, damage, hp);
            Assert.AreEqual(damage, this.warrior.Damage);
        }

        [Test]
        [TestCase("Lazko_Lazkov", 0, 120)]
        [TestCase("Lazko_Lazkov", -100, 120)]
        public void ConstructorShouldThrowArgumentExceptionInAttemptToSetDamageValueToZeroOrLess(string name, int damage, int hp)
        {
            Assert.That(() => this.warrior = new Warrior(name, damage, hp), Throws.ArgumentException
                                                                                  .With.Message
                                                                                  .EqualTo("Damage value should be positive!"));
        }

        //---------- HP -----------
        [Test]
        [TestCase("Lazko_Lazkov", 25, 120)]
        public void ConstructorShouldInitializeHPCorrectly(string name, int damage, int hp)
        {
            warrior = new Warrior(name, damage, hp);
            Assert.AreEqual(hp, this.warrior.HP);
        }

        [Test]
        [TestCase("Lazko_Lazkov", 25, -1)]
        [TestCase("Lazko_Lazkov", 25, -100)]
        public void ConstructorShouldThrowArgumentExceptionInAttemptToSetHPValueToLessThanZero(string name, int damage, int hp)
        {
            Assert.That(() => this.warrior = new Warrior(name, damage, hp), Throws.ArgumentException
                                                                                  .With.Message
                                                                                  .EqualTo("HP should not be negative!"));
        }

        //-------------------- METHOD TESTS ----------------------
        //---------- ATTACK OPERATION TESTS ----------
        [Test]
        public void AttackOperationShouldDecrementWarriorHP()
        {
            Warrior otherWarrior = new Warrior("durvo", 5, 120);
            int expectedHP = 115;

            this.warrior.Attack(otherWarrior);

            Assert.AreEqual(expectedHP, this.warrior.HP);
        }

        [Test]
        [TestCase(120)]
        [TestCase(130)]
        public void AttackOperationShouldSetOtherWarriorHealthToZero(int attackDmg)
        {
            this.warrior = new Warrior("Lazko_Lazkov", attackDmg, 50);
            Warrior otherWarrior = new Warrior("durvo", 5, 120);

            this.warrior.Attack(otherWarrior);

            Assert.AreEqual(0, otherWarrior.HP);
        }

        [Test]
        public void AttackOperationShouldDecrementOtherWarriorHP()
        {
            this.warrior = new Warrior("Lazko_Lazkov", 100, 50);
            Warrior otherWarrior = new Warrior("durvo", 5, 120);
            int expectedHP = 20;

            this.warrior.Attack(otherWarrior);

            Assert.AreEqual(expectedHP, otherWarrior.HP);
        }

        [Test]
        [TestCase(1)]
        [TestCase(29)]
        [TestCase(30)]
        public void AttackOperationShouldThrowInvalidOperationExceptionInAttemptToAttackOtherWarriorWhileOnLowHP(int hp)
        {
            this.warrior = new Warrior("Lazko_Lazkov", 25, hp);
            Warrior otherWarrior = new Warrior("durvo", 30, 120);

            Assert.That(() => this.warrior.Attack(otherWarrior), Throws.InvalidOperationException
                                                                       .With.Message
                                                                       .EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        [TestCase(1)]
        [TestCase(29)]
        [TestCase(30)]
        public void AttackOperationShouldThrowInvalidOperationExceptionInAttemptToAttackOtherWarriorWithLowHP(int hp)
        {
            Warrior otherWarrior = new Warrior("durvo", 30, hp);

            Assert.That(() => this.warrior.Attack(otherWarrior), Throws.InvalidOperationException
                                                                       .With.Message
                                                                       .EqualTo($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!"));

        }

        [Test]
        [TestCase(50, 60)]
        public void AttackOperationShouldThrowInvalidOperationExceptionInAttemptToAttackAStrongerWarrior(int hp, int otherWarriorDmg)
        {
            this.warrior = new Warrior("Lazko_Lazkov", 25, hp);
            Warrior otherWarrior = new Warrior("durvo", otherWarriorDmg, hp);

            Assert.That(() => this.warrior.Attack(otherWarrior), Throws.InvalidOperationException
                                                                       .With.Message
                                                                       .EqualTo("You are trying to attack too strong enemy"));
        }
    }
}