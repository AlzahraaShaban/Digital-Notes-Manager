﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();  
        Task<Category?> GetByIdAsync(int id);
        Task<Category?> GetByNameAsync(string name);
    }
}
