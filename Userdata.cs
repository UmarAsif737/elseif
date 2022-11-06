namespace third
{
   
    public class Userdata:Iuserdata
    {
        List<User> userslist = new List<User>
    {
         new User{userID=1,userName="Ahmad"},
         new User{userID=2,userName="Hamza" },
         new User{userID=3,userName="Talha" },
         new User{userID=4,userName="Zaheer" },
         new User{userID=5,userName="Asif" },

    };
       
        public List<User> GetUser()
        {
            return userslist;
        }

    }
}
