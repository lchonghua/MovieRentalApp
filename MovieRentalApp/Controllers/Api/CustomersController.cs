﻿/*
 * To build an API:
 * 1. create 'Api' folder under Controllers folder.
 * 2. in Api folder, add a controller, using 'Web Api 2 controller - empty' template
 * 3. Name the controller, by default, it should be in plural form, e.g. CustomersController
 * 4. The first time when you add an Api controller, vs automatically open readme.txt file to guide you how to config a web api
 * 5. Follow the steps in readme
 
 */
using AutoMapper;
using MovieRentalApp.Dtos;
using MovieRentalApp.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRentalApp.Controllers.Api
{
    public class CustomersController : ApiController //notice: this class derives from ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        
        //GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customerDto = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);//use delegate
            return Ok(customerDto);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }
        
        // POST /api/customers
        [HttpPost] //if you name the action 'PostCustomer', then this attribute is not required
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) // by convention, post returns the newly created item
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges(); //at this point, the id property will be set based on the id generated by the database

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri+"/"+customer.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto) //you can also return the updated item
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();

            return Ok();
        }

        // Delete /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
