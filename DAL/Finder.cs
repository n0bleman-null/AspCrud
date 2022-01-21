﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Finder<T> : IFinder<T> where T : class
    {
        private DbSet<T> _dbset;
        public Finder(DbSet<T> dbset)
        {
            _dbset = dbset;
        }
        public IQueryable<T> AsQueryable()
        {
            return _dbset.AsQueryable();
        }
    }
}