using AutoMapper;
using LibApp.Dtos;
using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetById(int id);
        public void Add(Book book);
        public void Update(BookDto book);
        public void Delete(int id);
        public void Save();
    }
}