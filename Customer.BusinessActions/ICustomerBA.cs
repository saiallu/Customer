using Customer.BusinessObjects;

namespace Customer.BusinessActions
{
    public interface ICustomerBA
    {
        public List<CustomerBO> GetCustomerList();
        public CustomerBO GetCustomerById(int id);
        public int InsertCustomer(CustomerBO customer);
        public int UpdateCustomer(CustomerBO customer);
        public int DeleteCustomer(int id);
    }
}
