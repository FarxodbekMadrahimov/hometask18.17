using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson28.Interfaces.Models;

namespace Lesson28.ViewModes
{
    internal class StudentViewModel : IPerson
    {
        public Guid? StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
    }
}
