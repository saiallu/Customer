using Customer.BusinessObjects;

namespace Customer.DataAccess
{
    public interface ICustomerDAO
    {
        public List<CustomerBO> GetCustomerList();        
        public CustomerBO GetCustomerById(int id);
        public int CreateCustomer(CustomerBO customer);
        public int UpdateCustomer(CustomerBO customer);
        public int DeleteCustomer(int id);
    }
}
