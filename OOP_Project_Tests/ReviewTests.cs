using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Project;

namespace OOP_Project_Tests { 
    
    [TestClass] 
    public class ReviewTests { 
        [TestMethod] public void Review_ValidData_CreatesSuccessfully() { 
            var passenger = new Passenger(); 
            var review = new Review(passenger, 5, "Amazing trip!!!"); 
            Assert.AreEqual(5, review.Rating); 
            Assert.AreEqual("Amazing trip!!!", review.Comment); 
            Assert.AreEqual(passenger, review.Author); 
        } 
    } 
}


