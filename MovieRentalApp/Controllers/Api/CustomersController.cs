/*
 * To build an API:
 * 1. create 'Api' folder under Controllers folder.
 * 2. in Api folder, add a controller, using 'Web Api 2 controller - empty' template
 * 3. Name the controller, by default, it should be in plural form, e.g. CustomersController
 * 4. The first time when you add an Api controller, vs automatically open readme.txt file to guide you how to config a web api
 * 5. Follow the steps in readme
 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRentalApp.Controllers.Api
{
    public class CustomersController : ApiController //notice: this class derives from ApiController
    {
    }
}
