using MVCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLibrary.Abstract.IServices
{
    public interface ICartService
    {
        bool AddBookToCart(Cart cart,int id);

        bool ClearCart(Cart cart);

        bool LendBooks(Cart cart);

        bool RemoveBook(Cart cart, int id);

    }
}
