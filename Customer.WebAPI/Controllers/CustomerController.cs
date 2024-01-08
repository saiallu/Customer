using Customer.BusinessActions;
using Customer.BusinessObjects;
using Microsoft.AspNetCore.Mvc;

namespace Customer.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> logger;
        private readonly ICustomerBA customerBA;

        public CustomerController(ILogger<CustomerController> logger, ICustomerBA customerBA)
        {
            this.logger = logger;
            this.customerBA = customerBA;
        }

        [HttpGet]
        [Route("GetCustomers")]
        public IEnumerable<CustomerBO> GetCustomers()
        {
            return customerBA.GetCustomerList();
        }

        [HttpGet]
        [Route("GetCustomerById")]
        public CustomerBO GetCustomerById(int id)
        {
            return customerBA.GetCustomerById(id);
        }

        [HttpGet]
        [Route("DeleteCustomer")]
        public int DeleteById(int id)
        {
            return customerBA.DeleteCustomer(id);
        }

        [HttpPost]
        [Route("InsertCustomer")]
        public int InsertCustomer(CustomerBO customerBO)
        {
            return customerBA.InsertCustomer(customerBO);
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public int UpdateCustomer(CustomerBO customerBO)
        {
            return customerBA.UpdateCustomer(customerBO);
        }
    }
}
