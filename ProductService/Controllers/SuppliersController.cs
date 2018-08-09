using Microsoft.AspNet.OData;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductService.Controllers
{
    public class SuppliersController : ODataController
    {
        ProductsContext db = new ProductsContext();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}