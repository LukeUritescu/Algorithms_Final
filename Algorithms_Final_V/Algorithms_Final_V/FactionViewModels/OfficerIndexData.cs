using Algorithms_Final_V.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithms_Final_V.FactionViewModels
{
    public class OfficerIndexData
    {
        public IEnumerable<Officer> Officer { get; set; }
        public IEnumerable<Role> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
