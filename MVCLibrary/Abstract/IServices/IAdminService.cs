﻿using MVCLibrary.Models;
using MVCLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLibrary.IServices
{
    public interface IAdminService 
    {
        AddBookViewModel GetAddBookVM();

        bool AddNewBook(AddBookViewModel addBookVM);

        bool AddNewCategory(AddCategoryViewModel addCategoryVM);

        AddCategoryViewModel GetAddCategoryVM();

        IEnumerable<User> GetAllClients();
    }
}
