using Domain.Entities;
using Domain.Interface;
using Infrastructuree.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructuree.Data.Managers
{
    public class SupplierManager
    {
        private IRepository<Suppliers> repo;
        public SupplierManager(IRepository<Suppliers> repo)
        {
            this.repo = repo;
        }
        public void CreateSupplier(SuppliersVM model)
        {
            var entity = model.Create();
            repo.Add(entity);
        }
    }
}