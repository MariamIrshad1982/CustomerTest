using CustomerManager;
using CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager
{
    public static class CustomerCRUD
    {
        private static BeneficialEntities db = new BeneficialEntities();
        /// <summary>
        /// Get CutomerTests
        /// </summary>
        /// <returns></returns>
        public static IQueryable<CustomerTest> GetCustomerTests()
        {
            return db.CustomerTests;
        }

        /// <summary>
        /// Insert customer test
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public static CustomerRepsonse InsertCustomerTest(CustomerTest ct)
        {
            CustomerRepsonse response = new CustomerRepsonse();

            try
            {
                //validate id
                int id = db.CustomerTests.Max(x => x.ID);
                if(id == ct.ID)
                {
                    response.message = String.Format("There is already a customer with id {0}", id);
                    return response;
                }
                db.CustomerTests.Add(ct);
                db.SaveChanges();
                response.message = "Customer added successfully";

            }
            catch (Exception ex)
            {
                response.message = String.Format("Unable to add cutomer test. Inner Exception {0}", ex.InnerException);
            }
            return response;
        }

        /// <summary>
        /// Delete customer test by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static CustomerRepsonse DeleteCustomerTestByName(string name)
        {
            CustomerRepsonse response = new CustomerRepsonse();

            try
            {
                var ct = db.CustomerTests.Where(x => x.Name == name);

                if (ct != null)
                {
                    response.message = "No customer found";
                    return response;
                }

                if (ct.Count() > 1)
                {
                    response.message = "More than one customers with same name found";
                    return response;
                }

                else
                {
                    db.CustomerTests.Remove(ct.FirstOrDefault());
                }
                db.SaveChanges();
                response.message = "Customer deleted successfully";

            }
            catch (Exception ex)
            {
                response.message = String.Format("Unable to add cutomer test. Inner Exception {0}", ex.InnerException);
            }
            return response;
        }

        /// <summary>
        /// Update customer test by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public static CustomerRepsonse UpdateCustomerById(int id, CustomerTest ct)
        {
            CustomerRepsonse response = new CustomerRepsonse();

            try
            {
                var cust = db.CustomerTests.Where(x => x.ID == id).FirstOrDefault();

                if (cust != null)
                {
                    db.CustomerTests.Remove(cust);
                    //validate id
                    int maxId = db.CustomerTests.Where(x=>x.ID != cust.ID).Max(x => x.ID);
                    if (maxId == ct.ID)
                    {
                        response.message = String.Format("There is already a customer with id {0}", id);
                        return response;
                    }
                    db.CustomerTests.Add(ct);
                }
                else
                {
                    response.message = "No customer found";
                    return response;
                }
                db.SaveChanges();
                response.message = "Customer Updated successfully";

            }
            catch (Exception ex)
            {
                response.message = String.Format("Unable to add cutomer test. Inner Exception {0}", ex.InnerException);
            }
            return response;
        }
    }
}
