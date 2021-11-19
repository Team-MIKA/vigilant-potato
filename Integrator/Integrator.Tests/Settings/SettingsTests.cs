using NUnit.Framework;

namespace Integrator.Tests.Settings
{
    public class SettingsTests
    {
        [SetUp]
        public void Setup()
        {
        }
    
        [Test]
        public void TestFail()
        {
            // Arrange
            
            // Act
            
            // Assert
            Assert.AreEqual(11,11);
        }
        
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}