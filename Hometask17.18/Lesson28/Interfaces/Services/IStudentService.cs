using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson28.Interfaces.Services
{
    internal interface IStudentService
    {
        void AddStudent(StudentViewModel studentViewModel);
        void EnrollMember(Guid studentId, Guid groupId);
        Student GetStudentByUserName(string username);
        void GetSudents();
    }
}
