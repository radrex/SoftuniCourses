namespace Tests
{
    using FightingArena; // comment for judge
    using NUnit.Framework;
    using System.Collections.Generic;

    public class ArenaTests
    {
        //---------------- Fields ------------------
        private Arena arena;

        //------------- Initialization -------------
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        //------------------ CONSTRUCTOR TESTS -------------------
        [Test]
        public void ConstructorShouldInitializeCollection()
        {
            this.arena = new Arena();
            List<Warrior> warriors = new List<Warrior>();

            CollectionAssert.AreEqual(warriors, arena.Warriors);
        }

        //-------------------- METHOD TESTS ----------------------
        //---------- ENROLL OPERATION TESTS ----------
        [Test]
        public void EnrollOperationShouldEnrollWarriorsCorrectly()
        {
            this.arena = new Arena();
            Warrior gosho = new Warrior("Gosho", 5, 100);
            Warrior pesho = new Warrior("Pesho", 5, 120);

            arena.Enroll(gosho);
            arena.Enroll(pesho);

            List<Warrior> expected = new List<Warrior> { gosho, pesho };

            CollectionAssert.AreEqual(expected, arena.Warriors);
        }

        [Test]
        public void EnrollOperationShouldEnrollWarriorToCollection()
        {
            Warrior warrior = new Warrior("Lazko_Lazkov", 25, 120);
            this.arena.Enroll(warrior);

            Assert.AreEqual(1, this.arena.Count);
        }

        [Test]
        public void EnrollOperationShouldThrowInvalidOperationExceptionInAttemptToEnrollAlreadyEnrolledWarrior()
        {
            Warrior warrior = new Warrior("Lazko_Lazkov", 25, 120);
            this.arena.Enroll(warrior);

            Assert.That(() => this.arena.Enroll(warrior), Throws.InvalidOperationException
                                                                .With.Message
                                                                .EqualTo("Warrior is already enrolled for the fights!"));
        }

        //---------- FIGHT OPERATION TESTS -----------
        [Test]
        public void FightOperationShouldExecuteSuccessfully()
        {
            this.arena = new Arena();
            Warrior gosho = new Warrior("Gosho", 5, 100);
            Warrior pesho = new Warrior("Pesho", 5, 120);
            arena.Enroll(gosho);
            arena.Enroll(pesho);

            arena.Fight("Gosho", "Pesho");

            var expectedPeshoHp = 115;
            var actual = pesho.HP;
            Assert.AreEqual(expectedPeshoHp, actual);
        }

        [Test]
        public void FightOperationShouldThrowInvalidOperationExceptionInAttemptToFightWithMissingAttackerName()
        {
            this.arena.Enroll(new Warrior("Stoyan", 5, 120));
            string attacker = "Ivan";

            Assert.That(() => this.arena.Fight(attacker, "Stoyan"), Throws.InvalidOperationException
                                                                        .With.Message
                                                                        .EqualTo($"There is no fighter with name {attacker} enrolled for the fights!"));
        }

        [Test]
        public void FightOperationShouldThrowInvalidOperationExceptionInAttemptToFightWithMissingDefenderName()
        {
            this.arena.Enroll(new Warrior("Stoyan", 5, 120));
            string defender = "Ivan";

            Assert.That(() => this.arena.Fight("Stoyan", defender), Throws.InvalidOperationException
                                                                          .With.Message
                                                                          .EqualTo($"There is no fighter with name {defender} enrolled for the fights!"));
        }
    }
}
