using Lesson28.Interfaces.Models;

namespace Lesson28.Models
{
    internal class Group : IName
    {
        public Group()
        {

        }

        public Group(string name)
        {
            this.Name = name;
        }

        [Key]
        public Guid GroupId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Limit { get; set; }
    }
}
