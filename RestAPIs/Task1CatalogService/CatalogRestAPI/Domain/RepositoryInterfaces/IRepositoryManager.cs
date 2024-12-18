﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IRepositoryManager
    {
        public ICategoryRepository CategoryRepository  { get; }
        public IProductRepository ProductRepository { get; }
    }
}
