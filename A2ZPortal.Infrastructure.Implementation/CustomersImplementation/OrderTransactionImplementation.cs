using A2ZPortal.Core.ViewModel.OrderManagement;
using A2ZPortal.Helper.Extension;
using A2ZPortal.Infrastructure.Repository.CustomerRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ZPortal.Infrastructure.Implementation.CustomersImplementation
{
    public class OrderTransactionImplementation : IOrderTransactionRepository
    {
        private readonly string _connectionString;
        public OrderTransactionImplementation(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:dbConnection").Value;

        }
        public async  Task<List<OrderDetail>> GetCustomerOrderDetail(int customerId)
        {

            SqlParameter[] sqlParams = { new SqlParameter("@customerId", customerId) };

            var reader = await SqlHelper.ExecuteReader(_connectionString, SqlConstant.GetCustomerCartDetails,
               System.Data.CommandType.StoredProcedure, sqlParams);

            var response = new List<OrderDetail>();

            while (reader.Read())
            {
                var model = new OrderDetail();
                model.Id = reader.DefaultIfNull<int>("Id");
                model.PropertyName = reader.DefaultIfNull<string>("PropertyName");
                model.PlaceAddress = reader.DefaultIfNull<string>("PlaceAddress");
                model.CategoryName = reader.DefaultIfNull<string>("CategoryId");
                model.PropertyTypeName = reader.DefaultIfNull<string>("PropertyTypeId");
                model.Image = (reader.DefaultIfNull<string>("ImagePath"));
                model.PropertyId = reader.DefaultIfNull<int>("PropertyId");
                response.Add(model);
            }
            return response;
        }
    }
}
