using Lesson28.Interfaces.Services;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace Lesson28.Services
{
    internal class GroupService : IGroupService
    {
        public void AddGroup(string groupName)
        {
            var db = new EduCenterDB();
            var group = new Group(groupName);
            db.Add(group);
            db.SaveChanges();
        }

        public Group GetGroup(string groupName)
        {
            var db = new EduCenterDB();
            var group = db.Groups.FirstOrDefault(student => student.Name.Equals(groupName));
            return group;
        }

        public void GetGroups()
        {
            var db = new EduCenterDB();
            var groupsQuery = db.Groups;
            var groups = groupsQuery.ToList();

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Name}");
            }
        }

        public void GetGroupMembers(string groupName)
        {
            var db = new EduCenterDB();
            var groupMembers = db.GroupMembers.Where(student => student.Group.Name.Equals(groupName))
                .Select(member => new StudentViewModel()
                {
                    FirstName = member.Student.FirstName,
                    LastName = member.Student.LastName,
                    StudentId = member.Student.StudentId,
                }).ToList();

            var groupMembersSQLWithSelect = db.GroupMembers.Where(student => student.Group.Name.Equals(groupName))
                .Select(member => new StudentViewModel()
                {
                    FirstName = member.Student.FirstName,
                    LastName = member.Student.LastName,
                    StudentId = member.Student.StudentId,
                }).ToQueryString();
            
            var groupMembersSQLWithInclude = db.GroupMembers.Include(groupMember => groupMember.Student).Where(student => student.Group.Name.Equals(groupName)).ToQueryString();

            foreach (var groupMember in groupMembers)
            {
                Console.WriteLine($"{groupMember.FirstName}-{groupMember.LastName}");
            }
        }

        public void GetGroupWithJoin()
        {
            var db = new EduCenterDB();
            var groups= db.Groups;
            var groupMembers = db.GroupMembers.Join(groups, groupMember => groupMember.GroupId, group => group.GroupId, (groupMember, group) => new GroupMemberViewModel
            {
                GroupMemberId = groupMember.GroupMemberId,
                GroupName = group.Name,
            }).ToList();
            foreach (var groupMember in groupMembers)
            {
                Console.WriteLine($"{groupMember.GroupMemberId} {groupMember.GroupName}");
            }
        }

        public void GetGroupWithGroupJoin()
        {
            var db = new EduCenterDB();

            var query = from b in db.GroupMembers
                        join p in db.Groups
                            on b.GroupId equals p.GroupId into grouping
                        select new { b, grouping };

            var asdasd = query.ToList();
            var groups = db.Groups;
            var groupMembers = db.GroupMembers.GroupJoin(groups, groupMember => groupMember.GroupId, group => group.GroupId, (groupMember, group) => new
            {
                GroupMemberId = groupMember.GroupMemberId,
                Groups = group,
            }).ToList();

            foreach (var groupMember in groupMembers)
            {
                Console.WriteLine($"---------");
                foreach (var item in groupMember.Groups)
                {
                    Console.WriteLine($"{item.Name} {item.Limit}");
                }
            }
        }

        public void GetGroupWithGroupJoin_1111()
        {
            var db = new EduCenterDB();
            var groups = db.Groups.ToList();
            var groupMembers = db.GroupMembers.GroupJoin(groups, groupMember => groupMember.GroupId, group => group.GroupId, (groupMember, group) => new GroupMemberViewModel
            {
                GroupMemberId = groupMember.GroupMemberId,
                //GroupName = group.ToList(),
            }).ToList();
            foreach (var groupMember in groupMembers)
            {
                Console.WriteLine($"{groupMember.GroupMemberId} {groupMember.GroupName}");
            }
        }
    }
}
