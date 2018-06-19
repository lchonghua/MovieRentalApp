using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MovieRentalApp.Models;
using MovieRentalApp.ViewModels;

namespace MovieRentalApp.Controllers
{
    public class CustomersController : Controller
    {
        //-------- set up db connections-----------
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //-------- end of set up db connections------


        // GET: Customers
        public ViewResult Index()
        {
            //no need to retrieve data here, b/c we get the data from the ajax call in datatable in index page
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer() //add this line, otherwise the new customer's id would be null, hence model validation would fail in Save action
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //data binding. ASP can extract Customer model out of CustomerFormViewModel sent from the CustomerForm view
        public ActionResult Save(Customer customer) //you can also pass in a 'UpdateCustomerDto' object - partial Customer object that contains the properties to be updated (data transfer object)
        {
            //validation:
            if (!ModelState.IsValid)
            {              
                var vm = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", vm);               
            }

            //based on if the customer has an id or not, we will decide if this is a new customer or an existing customer
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();//db context goes through all modified objects, generates sql statements at runtime, and update database

            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                /* approach 1: TryUpdateModel(customerInDb); 
                 * - this customerInDb object will be updated based on the key-val pairs in the request data.
                 * - CONS: 1). Open security holes: malicious user can modify request data and add additional k-v pairs in form data.
                 *             This method will successfully update all properties. 
                 *         2). The workaround method is to provide a list of properties for updating: TryUpdateModel(customerInDb, "", new String[]{"Name", "Email"});
                 *             The problem with this code is that it hard coded the property names, and it's easy to break if the names are changed.
                 */

                // better approach: manually set the properties to be updated
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                //or use a Mapper: Mapper.Map(customer, customerInDb); but here the cutomer should be 'UpdateCustomerDto' obj to avoid the security issue

                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}