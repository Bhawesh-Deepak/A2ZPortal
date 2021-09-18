using A2ZAdmin.UI.Controllers.UserManagement;
using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.ViewModel.UserManagement;
using A2ZPortal.Infrastructure.Repository.UserManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace A2ZTest
{
    [TestClass]
    public class AunthenticateTests
    {
        [TestMethod]
        public async Task Authenticate_Valid_Credential_Error_Response_Test()
        {
            var responseModel = new ResponseModel<AuthenticateModel>() 
            { 
                ResponseStatus= ResponseStatus.Error,
               
            };
            var container = new AuthenticateMockContainer().GetContainerObject();
            container.AuthenticateMock.Setup(item => item.AuthenticateUser("admin", "admin"))
                .Returns(Task.FromResult(responseModel));

            var controllerObject = new AuthenticateController(container.AuthenticateMock.Object);

            var authModel=new AuthModel() { UserName = "admin", Password = "admin" };

            var response = await controllerObject.Authenticate(authModel);

            Assert.IsInstanceOfType(response, typeof(IActionResult));

            Assert.AreEqual( "User name or password is not valid !", authModel.Message);
        }

    }
    /// <summary>
    /// Authenticate Test Case for implementing Test case for verify 
    /// all the code is working fine and expected
    /// </summary>
    public class AuthenticateMockContainer
    {
        public Mock<IUserManagementRepository> AuthenticateMock { get; set; }

        public AuthenticateMockContainer GetContainerObject()
        {
            return new AuthenticateMockContainer()
            {
                AuthenticateMock = new Mock<IUserManagementRepository>()
            };
        }
    }
}
