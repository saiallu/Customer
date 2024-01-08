using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.BusinessObjects
{
    public class Constants
    {
        public static string SpCustomerGet = "[dbo].[Usp_Customer_Get]";
        public static string SpCustomerGetById = "[dbo].[Usp_Customer_GetById]";
        public static string SpCustomerInsert = "[dbo].[Usp_Customer_Insert]";
        public static string SpCustomerUpdate = "[dbo].[Usp_Customer_Update]";
        public static string SpCustomerDelete = "[dbo].[Usp_Customer_Delete]";
    }
}
