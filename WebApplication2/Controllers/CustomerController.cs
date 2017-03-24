using CustomerManager;
using System.Linq;
using System.Web.Mvc;
using System.Web.Http;
using CustomerModel;
using System.Collections.Generic;

namespace WebApplication2.Controllers
{

    public class CustomerController : ApiController
    {
        // GET: Customer
        [System.Web.Http.HttpGet]
        public List<CustomerTest> GetCustomers()
        {
            var ct =  CustomerCRUD.GetCustomerTests();
            return ct.ToList();
        }

        [System.Web.Http.HttpPost]
        public CustomerRepsonse PostCustomer(CustomerTest ct)
        {
            return CustomerCRUD.InsertCustomerTest(ct);
        }

        [System.Web.Http.HttpDelete]
        public CustomerRepsonse DeleteCustomerTestByname(string name)
        {
            return CustomerCRUD.DeleteCustomerTestByName(name);
        }

        [System.Web.Http.HttpPut]
        public CustomerRepsonse UpdateCutomer(int id, CustomerTest ct)
        {
            return CustomerCRUD.UpdateCustomerById(id, ct);
        }
    }
}

