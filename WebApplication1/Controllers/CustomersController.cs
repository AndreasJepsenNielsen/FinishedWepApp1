using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList(); // koden her er til at lave et nyt medlem den tager brug af Customerform
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if(customer.Id == 0) // dette styk kode er hvis customer ikke eksisterer så laver den hurtigt en ny og gemmer ham/hende
            _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id); // dette styk kode er hvis der eksistere en kunde, så setter man værdierne manuelt.

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers"); // returnerer til Index og Customerscontrolleren
        }
        public ViewResult Index()
        {
           // var customers = _context.Customers.Include(c => c.MembershipType).ToList();
           
            return View(); // viser alle customers med navn og deres MembershipType
        } 

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer); // viser den givne customers details deres navn fødselsdato og membershiptype
        }

        public ActionResult Edit(int id) // Tager brug af CUstomerform til at ændre i en customer
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) // hvis customer ikke findes
            return HttpNotFound();

            var viewModel = new CustomerFormViewModel // hvis customer findes
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}