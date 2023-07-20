using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson28.Models
{
    internal class GroupMember
    {
        [Key]
        public Guid GroupMemberId { get; set; }

        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }

        [ForeignKey(nameof(Group))]
        public Guid GroupId { get; set; }

        #region Relations

        public Group Group { get; set; }

        public Student Student { get; set; }

        #endregion Relations
    }
}
