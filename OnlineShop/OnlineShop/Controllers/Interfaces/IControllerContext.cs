using OnlineShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers.Interfaces
{
    interface IControllerContext
    {
        ApplicationDbContext GetContext();
    }
}
