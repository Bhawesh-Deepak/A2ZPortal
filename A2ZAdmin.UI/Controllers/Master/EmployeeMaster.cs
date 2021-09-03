using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Core.ViewModel.UserManagement;
using A2ZPortal.Helper;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A2ZAdmin.UI.Controllers.Master
{
    public class EmployeeMaster : Controller
    {
        private readonly IGenericRepository<Employee, int> _IEmployeeRepository;
        private readonly IGenericRepository<RoleMaster, int> _IRoleMasterRepository;
        public EmployeeMaster(IGenericRepository<Employee, int> _employeeRepository,
            IGenericRepository<RoleMaster, int> _roleMasterRepository)
        {
            _IEmployeeRepository = _employeeRepository;
            _IRoleMasterRepository = _roleMasterRepository;
        }

        public IActionResult Index()
        {
            ViewData["Header"] = "Employee  Master";
            return View(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(EmployeeMaster), "EmployeeMasterIndex"));
        }

        public async Task<IActionResult> GetDetail()
        {
            var employeeDetails = await _IEmployeeRepository.GetList(x => x.IsActive == true 
            && x.IsDeleted == false);

            var roleDetails = await _IRoleMasterRepository.GetList(x => x.IsActive == true 
            && x.IsDeleted == false);

            if (employeeDetails.ResponseStatus != ResponseStatus.Error
                && roleDetails.ResponseStatus != ResponseStatus.Error)
            {
                List<EmployeeModel> response = GetEmployeeDetails(employeeDetails, roleDetails);

                return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(EmployeeMaster), "EmployeeMasterDetails"), response);

            }
            else {
                Log.Error($"{employeeDetails.Message} / {roleDetails.Message}");
                return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail("Shared", "Error"));
            }
           
        }

        private static List<EmployeeModel> GetEmployeeDetails(ResponseModel<Employee> employeeDetails, ResponseModel<RoleMaster> roleDetails)
        {
            return (from emp in employeeDetails.Entities
                    join role in roleDetails.Entities
                    on emp.RoleId equals role.Id
                    select new EmployeeModel()
                    {
                        EmployeeId = emp.Id,
                        EmployeeName = emp.EmployeeName,
                        Email = emp.Email,
                        Phone = emp.Phone,
                        Role = role.RoleName,
                        UserName= emp.UserName,
                        EmpCode= emp.EmpCode
                    }).ToList();
        }

        public async Task<IActionResult> Create(int id)
        {
            await PopulateViewBag();

            var response = await _IEmployeeRepository.GetSingle(x => x.Id == id);

            return PartialView(ViewPageHelper.InstanceHelper.GetPathDetail(nameof(EmployeeMaster), "EmployeeMasterCreate"), response.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreate(Employee model)
        {
            //model.Password = PasswordEncrypter.GetEncryptedPassword(model.Password).ToString();
            if (model.Id > 0)
            {
                var updateModel = CommonCrudHelper.CommonUpdateCode(model, 1);
                var updateResponse = await _IEmployeeRepository.Update(updateModel);
                if (updateResponse.ResponseStatus != ResponseStatus.Error)
                {
                    return Json("Employee Master Updated Successfully !!!");
                }
                Log.Error(updateResponse.Message);
                return Json("Something went wrong Please contact Admin Team !!!");
            }

            var createModel = CommonCrudHelper.CommonCreateCode(model, 1);
            var createResponse = await _IEmployeeRepository.CreateEntity(createModel);
            if (createResponse.ResponseStatus != ResponseStatus.Error)
            {
                return Json("Employee Master created Successfully !!!");
            }
            Log.Error(createResponse.Message);
            return Json("Something went wrong Please contact Admin Team !!!");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _IEmployeeRepository.GetSingle(x => x.Id == id);
            var deleteModel = CommonCrudHelper.CommonDeleteCode(response.Entity, 1);
            var deleteResponse = await _IEmployeeRepository.Delete(deleteModel);
            return Json(deleteResponse.ResponseStatus != ResponseStatus.Error ?
                "Employee Master  deleted successfully !!!" : "Something went wrong Please contact Admin !!");
        }

        private async Task PopulateViewBag()
        {
            ViewBag.RoleDetails = (await _IRoleMasterRepository.GetList(x => x.IsActive == true && x.IsDeleted == false)).Entities;
        }

    }
}
