using Customer.BusinessObjects;
using Customer.DataAccess;

namespace Customer.BusinessActions
{
    public class CustomerBA : ICustomerBA
    {
        ICustomerDAO dao;

        public CustomerBA(ICustomerDAO dao) 
        { 
            this.dao = dao;
        }

        public int DeleteCustomer(int id)
        {
            return dao.DeleteCustomer(id);
        }

        public CustomerBO GetCustomerById(int id)
        {
            return dao.GetCustomerById(id);
        }

        public List<CustomerBO> GetCustomerList()
        {
            return dao.GetCustomerList();
        }

        public int CreateCustomer(CustomerBO customer)
        {
            return dao.CreateCustomer(customer);
        }

        public int UpdateCustomer(CustomerBO customer)
        {
            return dao.UpdateCustomer(customer);
        }
    }
}
