using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project;

namespace OOP_Project_Tests
{
    [TestClass]
    public class ReviewTests
    {
        [TestMethod]
        public void Review_ValidData_CreatesSuccessfully()
        {
            var review = new Review
            {
                Author = new Passenger(),
                Rating = 5,
                Comment = "Amazing trip!!!"
            };
            Assert.AreEqual(5, review.Rating);
            Assert.AreEqual("Amazing trip!!!", review.Comment);
        }
    }
}
