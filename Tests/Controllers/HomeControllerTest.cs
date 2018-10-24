using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Web;
using Web.Controllers;
using Web.Infrastructure;

namespace Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {


        [TestMethod]
        public void Index()
        {
            var mockOrderService = MockRepository.GenerateStub<IOrderService>();
            // Arrange
            HomeController controller = new HomeController();

            //// Act
            ViewResult result = controller.Index() as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }
    }
}
