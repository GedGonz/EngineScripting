using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesEngine.utils
{
    public class User
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string Adress { get; set; }


        public static List<string> GetUsersText()
        {
            return new List<string>() { "ggonzalez", "caburto", "gmasaya", "hmorales", "clopez", "pgaitan" };
        }

        public static List<User> GetUsers()
        {
            return new List<User>()
            { 
                new User(){ Id=1, name="Gerld", lastname="Gonzalez", Adress="masaya"},
                new User(){ Id=1, name="Helen", lastname="Morales", Adress="managua"},
                new User(){ Id=1, name="carlos", lastname="Lopez", Adress="managua"}
            };
        }
    }
}
