using System.Data;
using third;
using static System.Reflection.Metadata.BlobBuilder;

namespace third
{
    public class Bookdata : IBook
    {

        List<Book> mybooks = new List<Book>
        {
          
            new Book{id=3,name="book3",price=300},
            new Book{id=4,name="book4",price=400},
            new Book{id=5,name="book5",price=500},
            new Book{id=6,name="book6",price=600},
            new Book{id=7,name="book7",price=700},
            new Book{id=8,name="book8",price=800},
            new Book{id=9,name="book9",price=900},
            new Book{id=10,name="book10",price=1000},
            new Book{id=11,name="book11",price=1100},
            new Book{id=12,name="book12",price=1200},
            new Book{id=13,name="book13",price=1300},
            new Book{id=14,name="book14",price=1400},
            new Book{id=15,name="book15",price=1500},
            new Book{id=16,name="book16",price=1600},
            new Book{id=17,name="book17",price=1700},
            new Book{id=18,name="book18",price=1800},
            new Book{id=19,name="book19",price=1900},
            new Book{id=20,name="book20",price=2000}
        };
       public List<Book> takenbooks = new List<Book>
        { 
            new Book{id=1,name="book1",price=100},
            new Book{id=2,name="book2",price=200}
        };

    
        

        public List<Book> GetBook()

        {
          
            return mybooks;
     
        }
        public void Add(Book addedbook)
        {
            mybooks.Add(addedbook);


        }

        List<User> userslist = new List<User>

        {
         new User{userID=1,userName="Ahmad"},
         new User{userID=2,userName="Hamza" },
         new User { userID = 3, userName = "Talha" },
         new User { userID = 4, userName = "Zaheer" },
         new User { userID = 5, userName = "Asif" },

        };
        
public List<User> GetUser()
{
            userslist[0].userBookList = takenbooks;

    return userslist;
    }

    }

}
   