using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithms_Final_V.Models
{
    public class RoleAssignment
    {

        public int OfficerID { get; set; }
        public int RoleID { get; set; }
        public Officer Officer { get; set; }
        public Role Role { get; set; }
    }
}
