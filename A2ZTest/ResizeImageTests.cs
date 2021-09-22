using A2ZPortal.Helper.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZTest
{
    [TestClass]
    public class ResizeImageTests
    {
        [TestMethod]
        public void ResizeImageTest()
        {
            var image =ResizeImage.ResizeImageData("D:\\PublishFolder\\SERPHosting\\wwwroot\\Images", new System.Drawing.Size(25, 25));
        }
    }
}
