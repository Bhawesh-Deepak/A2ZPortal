using A2ZPortal.Core.Entities.VirtualTour;
using A2ZPortal.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZPortal.UI.Controllers
{
    public class VRImageDetails : Controller
    {
        public async Task<IActionResult> VirtualImage()
        {
            return View(ViewPageHelper.InstanceHelper.GetPathDetail("VRImageDetails", "VirtualImageIndex"), VRImageDetails.GetModels());
        }
        private static List<VirtualTourModel> GetModels()
        {
            return new List<VirtualTourModel>() {
                new VirtualTourModel(){
                    ImageSrc="https://my.matterport.com/show/?m=SQwUtSmRs85&play=0",
                    PropertyName="High Gardens",
                },
                 new VirtualTourModel(){
                    ImageSrc="https://my.matterport.com/show/?m=yym9FAZ1Rvm&play=0",
                    PropertyName="Bellista",
                },
                  new VirtualTourModel(){
                    ImageSrc="https://my.matterport.com/show/?m=XqY9ahaBoga&play=0",
                    PropertyName="Kiara",
                },
                   new VirtualTourModel(){
                    ImageSrc="https://my.matterport.com/show/?m=Qt87GLEQHSu&play=0",
                    PropertyName="Golf Vista",
                },
                    new VirtualTourModel(){
                    ImageSrc="https://my.matterport.com/show/?m=PCmFfvQnuYa&play=0",
                    PropertyName="Clarent Villas",
                },
                     new VirtualTourModel(){
                    ImageSrc="https://my.matterport.com/show/?m=REkoQfAkmsN&play=0",
                    PropertyName="Radisson at DAMAC Hills",
                },
                      new VirtualTourModel(){
                    ImageSrc="https://my.matterport.com/show/?m=bTM2cWkJoRp&play=0",
                    PropertyName="Trinity",
                },
                       new VirtualTourModel(){
                    ImageSrc="https://my.matterport.com/show/?m=2eKhESpVpFv&play=0",
                    PropertyName="Celestia",
                }
            };
        }
    }
}
