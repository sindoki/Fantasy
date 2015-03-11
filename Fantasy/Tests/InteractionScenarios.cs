using System;
using System.Collections;
using System.Collections.Generic;
using Fantasy.Battleware;
using Fantasy.Enums;
using Fantasy.Interaction;
using Fantasy.Races;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class InteractionScenarios
    {

        private IBattleActions BattleActions = new BattleActionsHonest();

        private ICommonActions CommonActions = new CommonActionsSimple() {
            ActionsChecker = new ActionsChecker(),
            BattleActions = new BattleActionsHonest()
        };

        // Гоблин съел овцу.
        [TestMethod]
        public void TestScenario1()
        {
            Goblin goblin = new Goblin();
            Sheep sheep = new Sheep();
            
            EatAttemptResult result = CommonActions.TryToEat(goblin, sheep);

            Assert.AreEqual(EatAttemptResult.Success, result);
        }

        // Два гоблина подрались из-за овцы. Победитель съел овцу.
        [TestMethod]
        public void TestScenario2()
        {
            Goblin goblin1 = new Goblin(),
                   goblin2 = new Goblin();
            Sheep sheep = new Sheep();

            Goblin victor = BattleActions.Battle(goblin1, goblin2) as Goblin;
            EatAttemptResult result = CommonActions.TryToEat(victor, sheep);

            Assert.AreEqual(EatAttemptResult.Success, result);
        }

        // Огр попытался съесть группу гоблинов, но не смог.
        [TestMethod]
        public void TestScenario3()
        {
            List<Ogre> ogres = new List<Ogre>() { new Ogre() };
            List<Goblin> goblins = new List<Goblin>();
            for (int i = 0; i < 6; i++)
                goblins.Add(new Goblin());

            EatAttemptResult result = CommonActions.TryToEat(ogres, goblins);

            Assert.AreEqual(EatAttemptResult.Fail, result);
        }

        // Группа огров успешно съела группу гоблинов.
        [TestMethod]
        public void TestScenario4()
        {
            List<Ogre> ogres = new List<Ogre>();
            List<Goblin> goblins = new List<Goblin>();
            for (int i = 0; i < 3; i++)
                ogres.Add(new Ogre());
            for (int i = 0; i < 8; i++)
                goblins.Add(new Goblin());

            EatAttemptResult result = CommonActions.TryToEat(ogres, goblins);

            Assert.AreEqual(EatAttemptResult.Success, result);
        }

        // Два огра попытались съесть гоблина с волшебным мечом, но не смогли.
        [TestMethod]
        public void TestScenario5()
        {
            List<Ogre> ogres = new List<Ogre>();
            List<Goblin> goblins = new List<Goblin> { 
                new Goblin() { Weapon = new MagicSword() }
            };
            for (int i = 0; i < 2; i++)
                ogres.Add(new Ogre());

            EatAttemptResult result = CommonActions.TryToEat(ogres, goblins);

            Assert.AreEqual(EatAttemptResult.Fail, result);
        }

        // Стадо овец и группа гоблинов дерётся с двумя ограми и побеждает.
        [TestMethod]
        public void TestScenario6()
        {
            List<Creature> sheepsAndGoblins = new List<Creature>();
            List<Ogre> ogres = new List<Ogre>();
            for (int i = 0; i < 30; i++)
                sheepsAndGoblins.Add(new Sheep());
            for (int i = 0; i < 4; i++)
                sheepsAndGoblins.Add(new Goblin());
            for (int i = 0; i < 2; i++)
                ogres.Add(new Ogre());

            var victors = BattleActions.BattleGroups(sheepsAndGoblins, ogres);

            Assert.AreEqual(sheepsAndGoblins.GetHashCode(), victors.GetHashCode());
        }

    }
}
