
using Lesson28.Services;
string dotNetGroupName = ".Net Group";

Console.WriteLine("Hello Kamoliddin");


var studentService = new StudentService();
var student = new StudentViewModel()
{
    LastName = "TEST",
    FirstName = "TEST",
    UserName = "TEST",
};
studentService.AddStudent(student);
var groupId = Guid.Parse("05fedfbc-95c7-4981-a7dd-af8cfd54e95c");
var studentId = Guid.Parse("60bbe040-5a4a-4af6-9e28-482b675ed47a");
studentService.EnrollMember(studentId, groupId);

var groupService = new GroupService();
groupService.GetGroupWithGroupJoin();

//addgroup(groupname);
//addstudent(student);
//console.writeline("done");
//getsudents();
//string username = console.readline();
//var student = getstudentbyusername(username);
//var group = getgroup(groupname);
//if (student != null && group != null)
//{
//    enrollmember(groupid: group.groupid, studentid: student.studentid);
//}
//getsudents();
//getgroupmembers(groupname);
