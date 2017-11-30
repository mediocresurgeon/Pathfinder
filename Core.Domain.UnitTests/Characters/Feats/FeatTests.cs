﻿using Core.Domain.Characters.Feats;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Feats
{
    [TestFixture]
    [Parallelizable]
    public class FeatTests
    {
        [Test(Description = "Ensures that arguments passed into the constructor can be retrieved by properties later.")]
        public void Constructor_Properties_RoundTrip()
        {
            // Arrange
            string name = "my feat name";
            string webAddress = "http://google.com/";
            var feat = new Mock<Feat>(MockBehavior.Loose, name, webAddress) { CallBase = true }.Object;

            // Assert
            Assert.AreEqual(name, feat.Name);
            Assert.AreEqual(webAddress, feat.Source.ToString());
        }
    }
}