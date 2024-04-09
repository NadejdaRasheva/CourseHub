using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseHub.Core.Contracts
{
    public interface ICourseModel
    {
        public string Name { get; set; }
        public string City { get; set; }
    }
}
