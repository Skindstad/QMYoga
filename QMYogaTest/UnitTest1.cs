using QMYoga.Models;
namespace QMYogaTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Test1()
        {
            Item item = new Item();
            item.Id = 1;
            Assert.That(item.Id, Is.EqualTo(1));
        }
    }
}