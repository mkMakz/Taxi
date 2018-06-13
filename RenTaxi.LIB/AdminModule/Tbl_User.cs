using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenTaxi.LIB.AdminModule
{
    public enum Gender { male = 0, fmale }
    [Serializable]
    public class Tbl_User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Department { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public List<Tbl_Roles> Roles { get; set; }

    }
    [Serializable]
    public class Tbl_Roles
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
