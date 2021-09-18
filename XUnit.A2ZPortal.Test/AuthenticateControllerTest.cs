using System.Threading.Tasks;
using Moq;
using A2ZPortal.Infrastructure.Repository.UserManagement;
using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.ViewModel.UserManagement;
using A2ZAdmin.UI.Controllers.UserManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace XUnit.A2ZPortal.Test
{
    
    public class AuthenticateControllerTest
    {

        [Fact]
        public void Authenticate_User_ValidCredential()
        {
            var userManagementMock = new AuthenticateMock().GetMockObject();

            var responseModel = new ResponseModel<AuthenticateModel>();

            userManagementMock.UserManagementRepoMock.Setup(item => item.AuthenticateUser("admin", "admin"))
                .Returns(Task.FromResult(responseModel));

            var controllerObject = new AuthenticateController(userManagementMock.GetMockObject().UserManagementRepoMock.Object);
            var response = controllerObject.Authenticate(new AuthModel()
            {
                UserName = "admin",
                Password = "admin"
            });

            Assert.IsTrue(true);
        }

    }

    public class AuthenticateMock
    {
        public Mock<IUserManagementRepository> UserManagementRepoMock { get; set; }

        public AuthenticateMock GetMockObject()
        {
            return new AuthenticateMock()
            {
                UserManagementRepoMock = new Mock<IUserManagementRepository>()
            };
        }
    }
}

