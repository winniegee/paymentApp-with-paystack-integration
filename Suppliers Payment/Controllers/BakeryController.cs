using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Infrastructuree.Data.Managers;
using Infrastructuree.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Suppliers_Payment_web.Controllers
{
    public class BakeryController : Controller
    {
        private IRepository<Suppliers> repo;
        public BakeryController(IRepository<Suppliers> repo)
        {
            this.repo = repo;
        }
        [HttpPost]
        [Route("api/bakery/createSupplier")]
        public ActionResult CreateSupplier([FromBody] SuppliersVM vM)
        {
            var exists = repo.GetAll().Where(x => x.RecipientCode == vM.RecipientCode).ToList();
            if (exists == null)
            {
                var manager = new SupplierManager(repo);
                manager.CreateSupplier(vM);
                return Ok();
            }
            return Ok();
        }
        [HttpGet]
        [Route("api/bakery/listSuppliers")]
        public IEnumerable<Suppliers> ListSupplier()
        {
            var result=repo.GetAll().ToList();
            return result;
        }
    }
}
