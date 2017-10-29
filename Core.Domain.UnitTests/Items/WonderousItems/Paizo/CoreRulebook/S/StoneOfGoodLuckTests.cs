using System;
using Core.Domain.Characters;
using Core.Domain.Characters.Initiatives;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.SavingThrows;
using Core.Domain.Characters.Skills;
using Core.Domain.Items.WonderousItems.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.WonderousItems.Paizo.CoreRulebook.S
{
    [TestFixture]
    public class StoneOfGoodLuckTests
    {
        [Test(Description = "Ensures sensible defaults for a fresh instance of Stone of Good Luck.")]
        public void Default()
        {
            // Arrange
            StoneOfGoodLuck luckstone = new StoneOfGoodLuck();

            // Assert
            Assert.AreEqual(0, luckstone.Weight);
            Assert.AreEqual(5, luckstone.CasterLevel.Value);
            Assert.AreEqual(8, luckstone.GetHardness());
            Assert.AreEqual(15, luckstone.GetHitPoints());
            Assert.AreEqual(20000, luckstone.GetMarketPrice());
            Assert.AreEqual("Stone of Good Luck", luckstone.GetName()[0].Text);
            Assert.Contains(School.Evocation, luckstone.GetSchools());
        }

        #region Stow()
        [Test(Description = "Ensures that Stone of Good Luck cannot be stowed on a null character.")]
        public void ApplyTo_NullICharacter_Throws()
        {
            // Arrange
            ICharacter character = null;
            StoneOfGoodLuck luckstone = new StoneOfGoodLuck();

            // Act
            TestDelegate stow = () => luckstone.ApplyTo(character);

            // Assert
            Assert.Throws<ArgumentNullException>(stow);
        }


        [Test(Description = "Ensures that Stone of Good Luck is applied to a character correctly when stowed.")]
        public void ApplyTo()
        {
            // Arrange
            int luckBonusAppliedToSkillCount = 0; // we'll read from this later to make sure that all of the skills were updated correctly

            var mockLuckBonus = new Mock<IModifierTracker>();
            mockLuckBonus.Setup(lb => lb.Add(It.Is<byte>(input => 1 == input)))
                         .Callback(() => luckBonusAppliedToSkillCount++);
            IModifierTracker luckBonusTracker = mockLuckBonus.Object;
            #region Craft skill section
            var mockCraftAlchemy = new Mock<ISkill>();
            mockCraftAlchemy.Setup(s => s.LuckBonuses)
                            .Returns(luckBonusTracker);
            var mockCraftArmor = new Mock<ISkill>();
            mockCraftArmor.Setup(s => s.LuckBonuses)
                          .Returns(luckBonusTracker);
            var mockCraftBaskets = new Mock<ISkill>();
            mockCraftBaskets.Setup(s => s.LuckBonuses)
                            .Returns(luckBonusTracker);
            var mockCraftBooks = new Mock<ISkill>();
            mockCraftBooks.Setup(s => s.LuckBonuses)
                          .Returns(luckBonusTracker);
            var mockCraftBows = new Mock<ISkill>();
            mockCraftBows.Setup(s => s.LuckBonuses)
                         .Returns(luckBonusTracker);
            var mockCraftCalligraphy = new Mock<ISkill>();
            mockCraftCalligraphy.Setup(s => s.LuckBonuses)
                                .Returns(luckBonusTracker);
            var mockCraftCarpentry = new Mock<ISkill>();
            mockCraftCarpentry.Setup(s => s.LuckBonuses)
                              .Returns(luckBonusTracker);
            var mockCraftCloth = new Mock<ISkill>();
            mockCraftCloth.Setup(s => s.LuckBonuses)
                          .Returns(luckBonusTracker);
            var mockCraftClothing = new Mock<ISkill>();
            mockCraftClothing.Setup(s => s.LuckBonuses)
                             .Returns(luckBonusTracker);
            var mockCraftGlass = new Mock<ISkill>();
            mockCraftGlass.Setup(s => s.LuckBonuses)
                          .Returns(luckBonusTracker);
            var mockCraftJewelry = new Mock<ISkill>();
            mockCraftJewelry.Setup(s => s.LuckBonuses)
                            .Returns(luckBonusTracker);
            var mockCraftLeather = new Mock<ISkill>();
            mockCraftLeather.Setup(s => s.LuckBonuses)
                            .Returns(luckBonusTracker);
            var mockCraftLocks = new Mock<ISkill>();
            mockCraftLocks.Setup(s => s.LuckBonuses)
                          .Returns(luckBonusTracker);
            var mockCraftPaintings = new Mock<ISkill>();
            mockCraftPaintings.Setup(s => s.LuckBonuses)
                              .Returns(luckBonusTracker);
            var mockCraftPottery = new Mock<ISkill>();
            mockCraftPottery.Setup(s => s.LuckBonuses)
                            .Returns(luckBonusTracker);
            var mockCraftSculptures = new Mock<ISkill>();
            mockCraftSculptures.Setup(s => s.LuckBonuses)
                               .Returns(luckBonusTracker);
            var mockCraftShips = new Mock<ISkill>();
            mockCraftShips.Setup(s => s.LuckBonuses)
                          .Returns(luckBonusTracker);
            var mockCraftShoes = new Mock<ISkill>();
            mockCraftShoes.Setup(s => s.LuckBonuses)
                          .Returns(luckBonusTracker);
            var mockCraftStonemasonry = new Mock<ISkill>();
            mockCraftStonemasonry.Setup(s => s.LuckBonuses)
                                 .Returns(luckBonusTracker);
            var mockCraftTraps = new Mock<ISkill>();
            mockCraftTraps.Setup(s => s.LuckBonuses)
                          .Returns(luckBonusTracker);
            var mockCraftWeapons = new Mock<ISkill>();
            mockCraftWeapons.Setup(s => s.LuckBonuses)
                            .Returns(luckBonusTracker);

            var mockCraftSkillSection = new Mock<ICraftSkillSection>();
            mockCraftSkillSection.Setup(css => css.Alchemy)
                                 .Returns(mockCraftAlchemy.Object);
            mockCraftSkillSection.Setup(css => css.Armor)
                                 .Returns(mockCraftArmor.Object);
            mockCraftSkillSection.Setup(css => css.Armor)
                                 .Returns(mockCraftArmor.Object);
            mockCraftSkillSection.Setup(css => css.Baskets)
                                 .Returns(mockCraftBaskets.Object);
            mockCraftSkillSection.Setup(css => css.Books)
                                 .Returns(mockCraftBooks.Object);
            mockCraftSkillSection.Setup(css => css.Bows)
                                 .Returns(mockCraftBows.Object);
            mockCraftSkillSection.Setup(css => css.Calligraphy)
                                 .Returns(mockCraftCalligraphy.Object);
            mockCraftSkillSection.Setup(css => css.Carpentry)
                                 .Returns(mockCraftCarpentry.Object);
            mockCraftSkillSection.Setup(css => css.Cloth)
                                 .Returns(mockCraftCloth.Object);
            mockCraftSkillSection.Setup(css => css.Clothing)
                                 .Returns(mockCraftClothing.Object);
            mockCraftSkillSection.Setup(css => css.Glass)
                                 .Returns(mockCraftGlass.Object);
            mockCraftSkillSection.Setup(css => css.Jewelry)
                                 .Returns(mockCraftJewelry.Object);
            mockCraftSkillSection.Setup(css => css.Leather)
                                 .Returns(mockCraftLeather.Object);
            mockCraftSkillSection.Setup(css => css.Locks)
                                 .Returns(mockCraftLocks.Object);
            mockCraftSkillSection.Setup(css => css.Paintings)
                                 .Returns(mockCraftPaintings.Object);
            mockCraftSkillSection.Setup(css => css.Pottery)
                                 .Returns(mockCraftPottery.Object);
            mockCraftSkillSection.Setup(css => css.Sculptures)
                                 .Returns(mockCraftSculptures.Object);
            mockCraftSkillSection.Setup(css => css.Ships)
                                 .Returns(mockCraftShips.Object);
            mockCraftSkillSection.Setup(css => css.Shoes)
                                 .Returns(mockCraftShoes.Object);
            mockCraftSkillSection.Setup(css => css.Stonemasonry)
                                 .Returns(mockCraftStonemasonry.Object);
            mockCraftSkillSection.Setup(css => css.Traps)
                                 .Returns(mockCraftTraps.Object);
            mockCraftSkillSection.Setup(css => css.Weapons)
                                 .Returns(mockCraftWeapons.Object);
            #endregion
            #region Knowledge skill section
            var mockKnowledgeArcana = new Mock<ISkill>();
            mockKnowledgeArcana.Setup(s => s.LuckBonuses)
                               .Returns(luckBonusTracker);
            var mockKnowledgeDungeoneering = new Mock<ISkill>();
            mockKnowledgeDungeoneering.Setup(s => s.LuckBonuses)
                                      .Returns(luckBonusTracker);
            var mockKnowledgeEngineering= new Mock<ISkill>();
            mockKnowledgeEngineering.Setup(s => s.LuckBonuses)
                                    .Returns(luckBonusTracker);
            var mockKnowledgeGeography = new Mock<ISkill>();
            mockKnowledgeGeography.Setup(s => s.LuckBonuses)
                                  .Returns(luckBonusTracker);
            var mockKnowledgeHistory = new Mock<ISkill>();
            mockKnowledgeHistory.Setup(s => s.LuckBonuses)
                                .Returns(luckBonusTracker);
            var mockKnowledgeLocal = new Mock<ISkill>();
            mockKnowledgeLocal.Setup(s => s.LuckBonuses)
                              .Returns(luckBonusTracker);
            var mockKnowledgeNature = new Mock<ISkill>();
            mockKnowledgeNature.Setup(s => s.LuckBonuses)
                               .Returns(luckBonusTracker);
            var mockKnowledgeNobility = new Mock<ISkill>();
            mockKnowledgeNobility.Setup(s => s.LuckBonuses)
                                 .Returns(luckBonusTracker);
            var mockKnowledgePlanes = new Mock<ISkill>();
            mockKnowledgePlanes.Setup(s => s.LuckBonuses)
                               .Returns(luckBonusTracker);
            var mockKnowledgeReligion = new Mock<ISkill>();
            mockKnowledgeReligion.Setup(s => s.LuckBonuses)
                                 .Returns(luckBonusTracker);
            
            var mockKnowledgeSkillSection = new Mock<IKnowledgeSkillSection>();
            mockKnowledgeSkillSection.Setup(kss => kss.Arcana)
                                     .Returns(mockKnowledgeArcana.Object);
            mockKnowledgeSkillSection.Setup(kss => kss.Dungeoneering)
                                     .Returns(mockKnowledgeDungeoneering.Object);
            mockKnowledgeSkillSection.Setup(kss => kss.Engineering)
                                     .Returns(mockKnowledgeEngineering.Object);
            mockKnowledgeSkillSection.Setup(kss => kss.Geography)
                                     .Returns(mockKnowledgeGeography.Object);
            mockKnowledgeSkillSection.Setup(kss => kss.History)
                                     .Returns(mockKnowledgeHistory.Object);
            mockKnowledgeSkillSection.Setup(kss => kss.Local)
                                     .Returns(mockKnowledgeLocal.Object);
            mockKnowledgeSkillSection.Setup(kss => kss.Nature)
                                     .Returns(mockKnowledgeNature.Object);
            mockKnowledgeSkillSection.Setup(kss => kss.Nobility)
                                     .Returns(mockKnowledgeNobility.Object);
            mockKnowledgeSkillSection.Setup(kss => kss.Planes)
                                     .Returns(mockKnowledgePlanes.Object);
            mockKnowledgeSkillSection.Setup(kss => kss.Religion)
                                     .Returns(mockKnowledgeReligion.Object);
            #endregion
            #region Perform skill section
            var mockPerformAct = new Mock<ISkill>();
            mockPerformAct.Setup(s => s.LuckBonuses)
                          .Returns(luckBonusTracker);
            var mockPerformComedy = new Mock<ISkill>();
            mockPerformComedy.Setup(s => s.LuckBonuses)
                             .Returns(luckBonusTracker);
            var mockPerformDance = new Mock<ISkill>();
            mockPerformDance.Setup(s => s.LuckBonuses)
                            .Returns(luckBonusTracker);
            var mockPerformKeyboardInstruments = new Mock<ISkill>();
            mockPerformKeyboardInstruments.Setup(s => s.LuckBonuses)
                                          .Returns(luckBonusTracker);
            var mockPerformOratory = new Mock<ISkill>();
            mockPerformOratory.Setup(s => s.LuckBonuses)
                              .Returns(luckBonusTracker);
            var mockPerformPercussionInstruments = new Mock<ISkill>();
            mockPerformPercussionInstruments.Setup(s => s.LuckBonuses)
                                            .Returns(luckBonusTracker);
            var mockPerformStringInstruments = new Mock<ISkill>();
            mockPerformStringInstruments.Setup(s => s.LuckBonuses)
                                        .Returns(luckBonusTracker);
            var mockPerformWindInstruments = new Mock<ISkill>();
            mockPerformWindInstruments.Setup(s => s.LuckBonuses)
                                      .Returns(luckBonusTracker);
            var mockPerformSing = new Mock<ISkill>();
            mockPerformSing.Setup(s => s.LuckBonuses)
                           .Returns(luckBonusTracker);
            
            var mockPerformSkillSection = new Mock<IPerformSkillSection>();
            mockPerformSkillSection.Setup(pss => pss.Act)
                                   .Returns(mockPerformAct.Object);
            mockPerformSkillSection.Setup(pss => pss.Comedy)
                                   .Returns(mockPerformComedy.Object);
            mockPerformSkillSection.Setup(pss => pss.Dance)
                                   .Returns(mockPerformDance.Object);
            mockPerformSkillSection.Setup(pss => pss.KeyboardInstruments)
                                   .Returns(mockPerformKeyboardInstruments.Object);
            mockPerformSkillSection.Setup(pss => pss.Oratory)
                                   .Returns(mockPerformOratory.Object);
            mockPerformSkillSection.Setup(pss => pss.PercussionInstruments)
                                   .Returns(mockPerformPercussionInstruments.Object);
            mockPerformSkillSection.Setup(pss => pss.Sing)
                                   .Returns(mockPerformSing.Object);
            mockPerformSkillSection.Setup(pss => pss.StringInstruments)
                                   .Returns(mockPerformStringInstruments.Object);
            mockPerformSkillSection.Setup(pss => pss.WindInstruments)
                                   .Returns(mockPerformWindInstruments.Object);
            #endregion
            #region Profession skill section
            var mockProfessionArchitect = new Mock<ISkill>();
            mockProfessionArchitect.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionBaker = new Mock<ISkill>();
            mockProfessionBaker.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionBarrister = new Mock<ISkill>();
            mockProfessionBarrister.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionBrewer = new Mock<ISkill>();
            mockProfessionBrewer.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionButcher = new Mock<ISkill>();
            mockProfessionButcher.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionClerk = new Mock<ISkill>();
            mockProfessionClerk.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionCook = new Mock<ISkill>();
            mockProfessionCook.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionCourtesan = new Mock<ISkill>();
            mockProfessionCourtesan.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionDriver = new Mock<ISkill>();
            mockProfessionDriver.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionEngineer = new Mock<ISkill>();
            mockProfessionEngineer.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionFarmer = new Mock<ISkill>();
            mockProfessionFarmer.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionFisherman = new Mock<ISkill>();
            mockProfessionFisherman.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionGambler = new Mock<ISkill>();
            mockProfessionGambler.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionGardener = new Mock<ISkill>();
            mockProfessionGardener.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionHerbalist = new Mock<ISkill>();
            mockProfessionHerbalist.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionInnkeeper = new Mock<ISkill>();
            mockProfessionInnkeeper.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionLibrarian = new Mock<ISkill>();
            mockProfessionLibrarian.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionMerchant = new Mock<ISkill>();
            mockProfessionMerchant.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionMidwife = new Mock<ISkill>();
            mockProfessionMidwife.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionMiller = new Mock<ISkill>();
            mockProfessionMiller.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionMiner = new Mock<ISkill>();
            mockProfessionMiner.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionPorter = new Mock<ISkill>();
            mockProfessionPorter.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionSailor = new Mock<ISkill>();
            mockProfessionSailor.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionScribe = new Mock<ISkill>();
            mockProfessionScribe.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionShepherd = new Mock<ISkill>();
            mockProfessionShepherd.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionStableMaster = new Mock<ISkill>();
            mockProfessionStableMaster.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionSoldier = new Mock<ISkill>();
            mockProfessionSoldier.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionTanner = new Mock<ISkill>();
            mockProfessionTanner.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionTrapper = new Mock<ISkill>();
            mockProfessionTrapper.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);
            var mockProfessionWoodcutter = new Mock<ISkill>();
            mockProfessionWoodcutter.Setup(s => s.LuckBonuses)
                                   .Returns(luckBonusTracker);

            var mockProfessionSkillSection = new Mock<IProfessionSkillSection>();
            mockProfessionSkillSection.Setup(pss => pss.Architect)
                                      .Returns(mockProfessionArchitect.Object);
            mockProfessionSkillSection.Setup(pss => pss.Baker)
                                      .Returns(mockProfessionBaker.Object);
            mockProfessionSkillSection.Setup(pss => pss.Barrister)
                                      .Returns(mockProfessionBarrister.Object);
            mockProfessionSkillSection.Setup(pss => pss.Brewer)
                                      .Returns(mockProfessionBrewer.Object);
            mockProfessionSkillSection.Setup(pss => pss.Butcher)
                                      .Returns(mockProfessionButcher.Object);
            mockProfessionSkillSection.Setup(pss => pss.Clerk)
                                      .Returns(mockProfessionClerk.Object);
            mockProfessionSkillSection.Setup(pss => pss.Cook)
                                      .Returns(mockProfessionCook.Object);
            mockProfessionSkillSection.Setup(pss => pss.Courtesan)
                                      .Returns(mockProfessionCourtesan.Object);
            mockProfessionSkillSection.Setup(pss => pss.Driver)
                                      .Returns(mockProfessionDriver.Object);
            mockProfessionSkillSection.Setup(pss => pss.Engineer)
                                      .Returns(mockProfessionEngineer.Object);
            mockProfessionSkillSection.Setup(pss => pss.Farmer)
                                      .Returns(mockProfessionFarmer.Object);
            mockProfessionSkillSection.Setup(pss => pss.Fisherman)
                                      .Returns(mockProfessionFisherman.Object);
            mockProfessionSkillSection.Setup(pss => pss.Gambler)
                                      .Returns(mockProfessionGambler.Object);
            mockProfessionSkillSection.Setup(pss => pss.Gardener)
                                      .Returns(mockProfessionGardener.Object);
            mockProfessionSkillSection.Setup(pss => pss.Herbalist)
                                      .Returns(mockProfessionHerbalist.Object);
            mockProfessionSkillSection.Setup(pss => pss.Innkeeper)
                                      .Returns(mockProfessionInnkeeper.Object);
            mockProfessionSkillSection.Setup(pss => pss.Librarian)
                                      .Returns(mockProfessionLibrarian.Object);
            mockProfessionSkillSection.Setup(pss => pss.Merchant)
                                      .Returns(mockProfessionMerchant.Object);
            mockProfessionSkillSection.Setup(pss => pss.Midwife)
                                      .Returns(mockProfessionMidwife.Object);
            mockProfessionSkillSection.Setup(pss => pss.Miller)
                                      .Returns(mockProfessionMiller.Object);
            mockProfessionSkillSection.Setup(pss => pss.Miner)
                                      .Returns(mockProfessionMiner.Object);
            mockProfessionSkillSection.Setup(pss => pss.Porter)
                                      .Returns(mockProfessionPorter.Object);
            mockProfessionSkillSection.Setup(pss => pss.Sailor)
                                      .Returns(mockProfessionSailor.Object);
            mockProfessionSkillSection.Setup(pss => pss.Scribe)
                                      .Returns(mockProfessionScribe.Object);
            mockProfessionSkillSection.Setup(pss => pss.Shepherd)
                                      .Returns(mockProfessionShepherd.Object);
            mockProfessionSkillSection.Setup(pss => pss.Soldier)
                                      .Returns(mockProfessionSoldier.Object);
            mockProfessionSkillSection.Setup(pss => pss.StableMaster)
                                      .Returns(mockProfessionStableMaster.Object);
            mockProfessionSkillSection.Setup(pss => pss.Tanner)
                                      .Returns(mockProfessionTanner.Object);
            mockProfessionSkillSection.Setup(pss => pss.Trapper)
                                      .Returns(mockProfessionTrapper.Object);
            mockProfessionSkillSection.Setup(pss => pss.Woodcutter)
                                      .Returns(mockProfessionWoodcutter.Object);
            #endregion
            #region Skill section
            var mockAcrobatics = new Mock<ISkill>();
            mockAcrobatics.Setup(s => s.LuckBonuses)
                          .Returns(luckBonusTracker);
            var mockAppraise = new Mock<ISkill>();
            mockAppraise.Setup(s => s.LuckBonuses)
                        .Returns(luckBonusTracker);
            var mockBluff = new Mock<ISkill>();
            mockBluff.Setup(s => s.LuckBonuses)
                     .Returns(luckBonusTracker);
            var mockClimb = new Mock<ISkill>();
            mockClimb.Setup(s => s.LuckBonuses)
                     .Returns(luckBonusTracker);
            var mockDiplomacy = new Mock<ISkill>();
            mockDiplomacy.Setup(s => s.LuckBonuses)
                         .Returns(luckBonusTracker);
            var mockDisableDevice = new Mock<ISkill>();
            mockDisableDevice.Setup(s => s.LuckBonuses)
                             .Returns(luckBonusTracker);
            var mockDisguise = new Mock<ISkill>();
            mockDisguise.Setup(s => s.LuckBonuses)
                        .Returns(luckBonusTracker);
            var mockEscapeArtist = new Mock<ISkill>();
            mockEscapeArtist.Setup(s => s.LuckBonuses)
                            .Returns(luckBonusTracker);
            var mockFly = new Mock<ISkill>();
            mockFly.Setup(s => s.LuckBonuses)
                   .Returns(luckBonusTracker);
            var mockHandleAnimal = new Mock<ISkill>();
            mockHandleAnimal.Setup(s => s.LuckBonuses)
                            .Returns(luckBonusTracker);
            var mockHeal = new Mock<ISkill>();
            mockHeal.Setup(s => s.LuckBonuses)
                    .Returns(luckBonusTracker);
            var mockIntimidate = new Mock<ISkill>();
            mockIntimidate.Setup(s => s.LuckBonuses)
                          .Returns(luckBonusTracker);
            var mockLinguistics = new Mock<ISkill>();
            mockLinguistics.Setup(s => s.LuckBonuses)
                           .Returns(luckBonusTracker);
            var mockPerception = new Mock<ISkill>();
            mockPerception.Setup(s => s.LuckBonuses)
                          .Returns(luckBonusTracker);
            var mockRide = new Mock<ISkill>();
            mockRide.Setup(s => s.LuckBonuses)
                    .Returns(luckBonusTracker);
            var mockSenseMotive = new Mock<ISkill>();
            mockSenseMotive.Setup(s => s.LuckBonuses)
                           .Returns(luckBonusTracker);
            var mockSleightOfHand = new Mock<ISkill>();
            mockSleightOfHand.Setup(s => s.LuckBonuses)
                             .Returns(luckBonusTracker);
            var mockSpellcraft = new Mock<ISkill>();
            mockSpellcraft.Setup(s => s.LuckBonuses)
                          .Returns(luckBonusTracker);
            var mockStealth = new Mock<ISkill>();
            mockStealth.Setup(s => s.LuckBonuses)
                       .Returns(luckBonusTracker);
            var mockSurvival = new Mock<ISkill>();
            mockSurvival.Setup(s => s.LuckBonuses)
                        .Returns(luckBonusTracker);
            var mockSwim = new Mock<ISkill>();
            mockSwim.Setup(s => s.LuckBonuses)
                    .Returns(luckBonusTracker);
            var mockUseMagicDevice = new Mock<ISkill>();
            mockUseMagicDevice.Setup(s => s.LuckBonuses)
                              .Returns(luckBonusTracker);
            
            var mockSkillSection = new Mock<ISkillSection>();
            mockSkillSection.Setup(mss => mss.Acrobatics)
                            .Returns(mockAcrobatics.Object);
            mockSkillSection.Setup(mss => mss.Appraise)
                            .Returns(mockAppraise.Object);
            mockSkillSection.Setup(mss => mss.Bluff)
                            .Returns(mockBluff.Object);
            mockSkillSection.Setup(mss => mss.Climb)
                            .Returns(mockClimb.Object);
            mockSkillSection.Setup(mss => mss.Diplomacy)
                            .Returns(mockDiplomacy.Object);
            mockSkillSection.Setup(mss => mss.DisableDevice)
                            .Returns(mockDisableDevice.Object);
            mockSkillSection.Setup(mss => mss.Disguise)
                            .Returns(mockDisguise.Object);
            mockSkillSection.Setup(mss => mss.EscapeArtist)
                            .Returns(mockEscapeArtist.Object);
            mockSkillSection.Setup(mss => mss.Fly)
                            .Returns(mockFly.Object);
            mockSkillSection.Setup(mss => mss.HandleAnimal)
                            .Returns(mockHandleAnimal.Object);
            mockSkillSection.Setup(mss => mss.Heal)
                            .Returns(mockHeal.Object);
            mockSkillSection.Setup(mss => mss.Intimidate)
                            .Returns(mockIntimidate.Object);
            mockSkillSection.Setup(mss => mss.Linguistics)
                            .Returns(mockLinguistics.Object);
            mockSkillSection.Setup(mss => mss.Perception)
                            .Returns(mockPerception.Object);
            mockSkillSection.Setup(mss => mss.Ride)
                            .Returns(mockRide.Object);
            mockSkillSection.Setup(mss => mss.SenseMotive)
                            .Returns(mockSenseMotive.Object);
            mockSkillSection.Setup(mss => mss.SleightOfHand)
                            .Returns(mockSleightOfHand.Object);
            mockSkillSection.Setup(mss => mss.Spellcraft)
                            .Returns(mockSpellcraft.Object);
            mockSkillSection.Setup(mss => mss.Stealth)
                            .Returns(mockStealth.Object);
            mockSkillSection.Setup(mss => mss.Survival)
                            .Returns(mockSurvival.Object);
            mockSkillSection.Setup(mss => mss.Swim)
                            .Returns(mockSwim.Object);
            mockSkillSection.Setup(mss => mss.UseMagicDevice)
                            .Returns(mockUseMagicDevice.Object);

            mockSkillSection.Setup(ss => ss.Craft)
                            .Returns(mockCraftSkillSection.Object);
            mockSkillSection.Setup(ss => ss.Knowledge)
                            .Returns(mockKnowledgeSkillSection.Object);
            mockSkillSection.Setup(ss => ss.Perform)
                            .Returns(mockPerformSkillSection.Object);
            mockSkillSection.Setup(ss => ss.Profession)
                            .Returns(mockProfessionSkillSection.Object);
            #endregion
            #region Initative
            bool appliedToInitiative = false;
            var mockInitLuckBonusTracker = new Mock<IModifierTracker>();
            mockInitLuckBonusTracker.Setup(ilbt => ilbt.Add(It.Is<byte>(input => 1 == input)))
                                    .Callback(() => appliedToInitiative = true);
            var mockInitative = new Mock<IInitiative>();
            mockInitative.Setup(init => init.LuckBonuses)
                         .Returns(mockInitLuckBonusTracker.Object);
            #endregion
            #region Fortitude
            bool appliedToFortitude = false;
            var mockFortLuckBonusTracker = new Mock<IModifierTracker>();
            mockFortLuckBonusTracker.Setup(flbt => flbt.Add(It.Is<byte>(input => 1 == input)))
                                    .Callback(() => appliedToFortitude = true);
            var mockFortitude = new Mock<ISavingThrow>();
            mockFortitude.Setup(flbt => flbt.LuckBonuses)
                         .Returns(mockFortLuckBonusTracker.Object);
            #endregion
            #region Reflex
            bool appliedToReflex = false;
            var mockRefLuckBonusTracker = new Mock<IModifierTracker>();
            mockRefLuckBonusTracker.Setup(rlbt => rlbt.Add(It.Is<byte>(input => 1 == input)))
                                   .Callback(() => appliedToReflex = true);
            var mockReflex = new Mock<ISavingThrow>();
            mockReflex.Setup(rlbt => rlbt.LuckBonuses)
                      .Returns(mockRefLuckBonusTracker.Object);
            #endregion
            #region Will
            bool appliedToWill = false;
            var mockWillLuckBonusTracker = new Mock<IModifierTracker>();
            mockWillLuckBonusTracker.Setup(wlbt => wlbt.Add(It.Is<byte>(input => 1 == input)))
                                    .Callback(() => appliedToWill = true);
            var mockWill = new Mock<ISavingThrow>();
            mockWill.Setup(wlbt => wlbt.LuckBonuses)
                    .Returns(mockWillLuckBonusTracker.Object);
            #endregion

            var mockSavingThrowSection = new Mock<ISavingThrowSection>();
            mockSavingThrowSection.Setup(sts => sts.Fortitude)
                                  .Returns(mockFortitude.Object);
            mockSavingThrowSection.Setup(sts => sts.Reflex)
                                  .Returns(mockReflex.Object);
            mockSavingThrowSection.Setup(sts => sts.Will)
                                  .Returns(mockWill.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Initiative)
                         .Returns(mockInitative.Object);
            mockCharacter.Setup(c => c.SavingThrows)
                         .Returns(mockSavingThrowSection.Object);
            mockCharacter.Setup(c => c.Skills)
                         .Returns(mockSkillSection.Object);
            StoneOfGoodLuck luckstone = new StoneOfGoodLuck();

            // Act
            luckstone.ApplyTo(mockCharacter.Object);

            // Assert
            Assert.IsTrue(appliedToInitiative,
                          "Stone of Good Luck gives a +1 luck bonus to ability checks; Initiative is an ability check.");
            Assert.IsTrue(appliedToFortitude,
                          "Stone of Good Luck gives a +1 luck bonus to saving throws, including Fortitude.");
            Assert.IsTrue(appliedToReflex,
                          "Stone of Good Luck gives a +1 luck bonus to saving throws, including Reflex.");
            Assert.IsTrue(appliedToWill,
                          "Stone of Good Luck gives a +1 luck bonus to saving throws, including Will.");
            Assert.AreEqual(92, luckBonusAppliedToSkillCount,
                            "92 = 22 base skills + 21 craft skills + 10 knowledge skills + 9 perform skills + 30 profession skills");
        }
        #endregion
    }
}