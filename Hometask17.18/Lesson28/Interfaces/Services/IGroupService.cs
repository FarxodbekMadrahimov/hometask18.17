using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson28.Interfaces.Services
{
    internal interface IGroupService
    {
        void AddGroup(string groupName);

        Group GetGroup(string groupName);

        void GetGroupMembers(string groupName);
    }
}
