using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDataTransfer;

namespace TradingCompany.BusinessLogic.Interfaces
{
    public interface ITraderManager
    {
        TransactionDTO AddTansaction(TransactionDTO transaction);
        List<TransactionDTO> GetAllTransaction();
        List<ProductDTO> GetAllProduct();
        List<CategoryDTO> GetAllCategories();
        TransactionDTO UpdateTransaction(int id,TransactionDTO transaction);
        void DeleteTransaction(int transactionID);
        void BuyProduct(ProductDTO product);
        void BuyManyProducts(ProductDTO product,int count);
        void DeleteProduct(int id);
        UserDTO GetUserById(int id);
        StatusDTO GetStatusTransaction(int id);







    }
}
