using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;
using static System.Reflection.Metadata.BlobBuilder;

namespace third
{
    [Route("library")]
    [ApiController]
    public class myController : ControllerBase
    {
      
        private IBook  logger;
        public myController(IBook logger)
        {
            this.logger = logger;
        }
        



        [HttpGet("getbooknames")]
        public IEnumerable<string> GetName()
        {
            List<Book> books = logger.GetBook();

            var names = from book in books select book.name;
            return names;
        }
        [HttpGet("getbookdetail/{id}")]
        
        
        public IActionResult getbookdetail(int id)
        {
            List<Book> books = logger.GetBook();
            Book bookDetail = (from book in books where book.id == id select book).FirstOrDefault();
            if (bookDetail == null)
            {
                return NotFound("Book is issued by a user");
            }
            else
            {
                return Ok(bookDetail);
            }
                
        }

 







        [HttpPost("addbook")]

        public List<Book> bookaddition([FromBody] Book newbook)
        {

            List<Book> books = logger.GetBook();
            logger.Add(newbook);
            books.Add(newbook);
         
            return books;
        }
        //[HttpPost]

        [HttpPut("updatebook/{id}")]

        public List<Book> bookupdate(int id, [FromBody] Book upbook)
        {
            List<Book> books = logger.GetBook();


            books[id - 1].name = upbook.name;
            books[id - 1].price = upbook.price;


           return books;

        }

        [HttpDelete("deletebook/{id}")]

        public IActionResult delete(int id)
        {
            List<Book> books = logger.GetBook();
            List<User> userss = logger.GetUser();
            Book bookDetail = (from book in books where book.id == id select book).FirstOrDefault();

            User check = (from user in userss where ((from book in user.userBookList select book).FirstOrDefault()).id == id select user).FirstOrDefault();



            if (bookDetail == null  && check ==null)
            {
               
                return NotFound("The book doesn't exist");
            }
            else if (check!=null)
            {
                //
                //int index = check.userBookList.IndexOf((from book in check.userBookList where book.id==id select book).FirstOrDefault() );
                Book booko = (from book in check.userBookList where book.id == id select book).FirstOrDefault();
                int index2 = userss.IndexOf(check);
                userss[index2].userBookList.Remove(booko);

                return Ok(userss);
            }
            else 
            {
                books.Remove(books[books.IndexOf(bookDetail)]);
                return Ok("removed from books");
            }
           

            

        }

        //end of books___________________________________________________

        [HttpPost("adduser")]

        public List<User> useraddition([FromBody] User newuser)

        {
            //= "hussain";
            //List<int> ids = new List<int> { 2,1 };
         
            List<Book> books = logger.GetBook();
         
            List<User> userss = logger.GetUser();
           
            if (newuser.ids != null)
            {  
                foreach (int item in newuser.ids)
            {
                newuser.userBookList.Add((from book in books where book.id == item select book).FirstOrDefault());
            }

            }
          

            User userobj = new User
            {
                userName = newuser.userName,
                userID = userss.Count() + 1,
                userBookList = newuser.userBookList

            };

           
            userss.Add(userobj);

            return userss;
        }


        [HttpPut("updateuser/{userid}")]

        public IActionResult bookupdate(int userid, [FromBody] User upuser)
        {
            List<User> userss = logger.GetUser();
            List<Book> books = logger.GetBook();

            
            //Book bookDetail = (from book in books where book.id == upuser.ids select book).FirstOrDefault();
            //if (bookDetail == null) { return NotFound("book is already issued by user"); }
            if (upuser.ids != null)
            {
                //add in library
                List<Book> userupbooks = new List<Book>();
                foreach(var item in userss[userid - 1].userBookList)
                {
                    books.Add(item);
                }
                userss[userid - 1].userBookList = null;
                int count = 0;
                foreach (int item in upuser.ids)
                {
                    // upuser.userBookList
                    Book addUserRemLibrary = (from book in books where book.id == item select book).FirstOrDefault();
                    if (addUserRemLibrary == null)
                    {
                        count++;
                    }
                    userupbooks.Add(addUserRemLibrary);
                    books.Remove(addUserRemLibrary);
                }
                if (count == upuser.ids.Count)
                {
                    return NotFound("All books are already issued by user");
                }
                userss[userid - 1].userBookList = userupbooks;


            }
            userss[userid-1].userName = upuser.userName;
            //combo im = new combo { aha = userss, oho = books };
            
           
            return Ok(books);

          



        }


    }

}
