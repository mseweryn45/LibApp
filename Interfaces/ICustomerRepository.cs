using LibApp.Dtos;
using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetBooks();
        Customer GetById(int id);
        public void Delete(int id);
        public void Save();
    }
}