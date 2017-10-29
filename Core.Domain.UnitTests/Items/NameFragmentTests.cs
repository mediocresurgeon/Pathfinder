using System;
using Core.Domain.Items;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items
{
    [TestFixture]
    public class NameFragmentTests
    {
        #region Constructor
        [Test(Description = "Ensures that a NameFragment cannot be created with a null text argument.")]
        public void Constructor_NullText_Throws()
        {
            // Arrange
            string text = null;
            string webAddress = "foo";

            // Act
            TestDelegate constructor = () => new NameFragment(text, webAddress);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Test(Description = "Ensures that a NameFragment cannot be created with a null webAddress argument.")]
        public void Constructor_NullWebAddress_Throws()
        {
            // Arrange
            string text = "foo";
            string webAddress = null;

            // Act
            TestDelegate constructor = () => new NameFragment(text, webAddress);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Test(Description = "Ensures that a NameFragment cannot be created with a non-URL webAddress argument.")]
        public void Constructor_MalformedWebAddress_Throws()
        {
            // Arrange
            string text = "foo";
            string webAddress = "This is not an HHTP or HTTPS address.";

            // Act
            TestDelegate constructor = () => new NameFragment(text, webAddress);

            // Assert
            Assert.Throws<ArgumentException>(constructor);
        }
        #endregion

        #region Properties
        [Test(Description = "Ensures that the constructor arguments can be read from the object's properties later.")]
        public void Default()
        {
            // Arrange
            string text = "myText";
            string webAddress = "http://google.com";

            // Act
            NameFragment name = new NameFragment(text, webAddress);

            // Assert
            Assert.AreEqual(text, name.Text);
            Assert.AreEqual(webAddress, name.WebAddress);
            Assert.AreEqual("myText (http://google.com)", name.ToString());
        }
        #endregion

        #region Equals()
        [Test(Description = "Ensures that null values are never equal to an instance of NameFragment.")]
        public void Equals_Null_NotEqual()
        {
            // Arrange
            string text = "myText";
            string webAddress = "http://google.com";
            var name = new NameFragment(text, webAddress);

            // Act
            bool equal = name.Equals(null);

            // Assert
            Assert.IsFalse(equal,
                          "An instance of NameFragment should never be equal to null.");
        }


        [Test(Description = "Ensures that reference values are never equal to an instance of NameFragment.")]
        public void Equals_Object_NotEqual()
        {
            // Arrange
            string text = "myText";
            string webAddress = "http://google.com";
            var name = new NameFragment(text, webAddress);
            var obj = new Object();

            // Act
            bool equal = name.Equals(obj);

            // Assert
            Assert.IsFalse(equal,
                          "An instance of NameFragment should never be equal to a plain object.");
        }


        [Test(Description = "Ensures that NameFragments with different texts are never considered equal.")]
        public void Equals_DiffQuantity_NotEqual()
        {
            // Arrange
            string webAddress = "http://google.com";
            var name1 = new NameFragment("text1", webAddress);
            var name2 = new NameFragment("text2", webAddress);

            // Act
            bool equal1 = name1.Equals(name2);
            bool equal2 = name2.Equals(name1);

            // Assert
            Assert.IsFalse(equal1,
                          "An instance of NameFragment should not be equal if they have different texts.");
            Assert.IsFalse(equal2,
                          "An instance of NameFragment should not be equal if they have different texts.");
        }


        [Test(Description = "Ensures that DiceGroups with different qualities are never considered equal.")]
        public void Equals_DiffQuality_NotEqual()
        {
            // Arrange
            string text = "myText";
            var name1 = new NameFragment(text, "http://yahoo.com");
            var name2 = new NameFragment(text, "http://google.com");

            // Act
            bool equal1 = name1.Equals(name2);
            bool equal2 = name2.Equals(name1);

            // Assert
            Assert.IsFalse(equal1,
                          "An instance of NameFragment should not be equal if they have different web addresses.");
            Assert.IsFalse(equal2,
                          "An instance of NameFragment should not be equal if they have different web addresses.");
        }


        [Test(Description = "Ensures that null values are never equal to an instance of DiceGroup.")]
        public void Equals_SameValues_Equal()
        {
            // Arrange
            var name1 = new NameFragment("myText", "http://www.example.com");
            var name2 = new NameFragment("myText", "http://www.example.com");

            // Act
            bool equal1 = name1.Equals(name2);
            bool equal2 = name2.Equals(name1);

            Assert.IsTrue(equal1,
                          "NameFragments with the same Text and WebAddress values are equal.");
            Assert.IsTrue(equal2,
                          "NameFragments with the same Text and WebAddress values are equal.");
        }
        #endregion

        #region == operator
        [Test(Description = "Ensures that null values are never equal to an instance of NameFragment.")]
        public void EqualsOp_Null_NotEqual()
        {
            // Arrange
            string text = "myText";
            string webAddress = "http://google.com";
            var name = new NameFragment(text, webAddress);

            // Act
            bool equal = name == null;

            // Assert
            Assert.IsFalse(equal,
                          "An instance of NameFragment should never be equal to null.");
        }


        [Test(Description = "Ensures that NameFragments with different texts are never considered equal.")]
        public void EqualsOp_DiffQuantity_NotEqual()
        {
            // Arrange
            string webAddress = "http://google.com";
            var name1 = new NameFragment("text1", webAddress);
            var name2 = new NameFragment("text2", webAddress);

            // Act
            bool equal1 = name1 == name2;
            bool equal2 = name2 == name1;

            // Assert
            Assert.IsFalse(equal1,
                          "An instance of NameFragment should not be equal if they have different texts.");
            Assert.IsFalse(equal2,
                          "An instance of NameFragment should not be equal if they have different texts.");
        }


        [Test(Description = "Ensures that DiceGroups with different qualities are never considered equal.")]
        public void EqualsOp_DiffQuality_NotEqual()
        {
            // Arrange
            string text = "myText";
            var name1 = new NameFragment(text, "http://yahoo.com");
            var name2 = new NameFragment(text, "http://google.com");

            // Act
            bool equal1 = name1 == name2;
            bool equal2 = name2 == name1;

            // Assert
            Assert.IsFalse(equal1,
                          "An instance of NameFragment should not be equal if they have different web addresses.");
            Assert.IsFalse(equal2,
                          "An instance of NameFragment should not be equal if they have different web addresses.");
        }


        [Test(Description = "Ensures that null values are never equal to an instance of DiceGroup.")]
        public void EqualsOp_SameValues_Equal()
        {
            // Arrange
            var name1 = new NameFragment("myText", "http://www.example.com");
            var name2 = new NameFragment("myText", "http://www.example.com");

            // Act
            bool equal1 = name1 == name2;
            bool equal2 = name2 == name1;

            Assert.IsTrue(equal1,
                          "NameFragments with the same Text and WebAddress values are equal.");
            Assert.IsTrue(equal2,
                          "NameFragments with the same Text and WebAddress values are equal.");
        }
        #endregion

        #region != operator
        [Test(Description = "Ensures that null values are never equal to an instance of NameFragment.")]
        public void NotEqualsOp_Null_NotEqual()
        {
            // Arrange
            string text = "myText";
            string webAddress = "http://google.com";
            var name = new NameFragment(text, webAddress);

            // Act
            bool equal = name != null;

            // Assert
            Assert.IsTrue(equal,
                          "An instance of NameFragment should never be equal to null.");
        }


        [Test(Description = "Ensures that NameFragments with different texts are never considered equal.")]
        public void NotEqualsOp_DiffQuantity_NotEqual()
        {
            // Arrange
            string webAddress = "http://google.com";
            var name1 = new NameFragment("text1", webAddress);
            var name2 = new NameFragment("text2", webAddress);

            // Act
            bool equal1 = name1 != name2;
            bool equal2 = name2 != name1;

            // Assert
            Assert.IsTrue(equal1,
                          "An instance of NameFragment should not be equal if they have different texts.");
            Assert.IsTrue(equal2,
                          "An instance of NameFragment should not be equal if they have different texts.");
        }


        [Test(Description = "Ensures that DiceGroups with different qualities are never considered equal.")]
        public void NotEqualsOp_DiffQuality_NotEqual()
        {
            // Arrange
            string text = "myText";
            var name1 = new NameFragment(text, "http://yahoo.com");
            var name2 = new NameFragment(text, "http://google.com");

            // Act
            bool equal1 = name1 != name2;
            bool equal2 = name2 != name1;

            // Assert
            Assert.IsTrue(equal1,
                          "An instance of NameFragment should not be equal if they have different web addresses.");
            Assert.IsTrue(equal2,
                          "An instance of NameFragment should not be equal if they have different web addresses.");
        }


        [Test(Description = "Ensures that null values are never equal to an instance of DiceGroup.")]
        public void NotEqualsOp_SameValues_Equal()
        {
            // Arrange
            var name1 = new NameFragment("myText", "http://www.example.com");
            var name2 = new NameFragment("myText", "http://www.example.com");

            // Act
            bool equal1 = name1 != name2;
            bool equal2 = name2 != name1;

            Assert.IsFalse(equal1,
                          "NameFragments with the same Text and WebAddress values are equal.");
            Assert.IsFalse(equal2,
                          "NameFragments with the same Text and WebAddress values are equal.");
        }
        #endregion
    }
}