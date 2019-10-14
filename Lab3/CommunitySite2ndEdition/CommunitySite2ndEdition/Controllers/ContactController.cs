using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCServeciesApp.Controllers
{
    public class ContactController : Controller
    {
        public String Index()

        {

            /* Return a literal string instead of calling view() */

            return "Never call me jackass!";

        }
    }
}