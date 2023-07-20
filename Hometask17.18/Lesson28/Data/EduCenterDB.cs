namespace Lesson28.Data
{
    internal class EduCenterDB : DbContext
    {
        private Guid dotNetGroupId = Guid.Parse("6561e66a-29a5-47f2-a22b-ca47c8c38f24");
        private Guid nodeJSGroupId = Guid.Parse("05fedfbc-95c7-4981-a7dd-af8cfd54e95c");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost; Port=5432; User Id=postgres; Password=ing0077K; Database=EduCenterDB");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // AddGroup(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupMember> GroupMembers { get; set; }

        void AddGroup(ModelBuilder modelBuilder)
        {
            string dotNetGroupName = ".Net Group"; // default group
            string nodeJsGroupName = "NodeJS"; // default group

            modelBuilder.Entity<Group>().HasData(
                new Group
                {
                    GroupId = dotNetGroupId,
                    Name = dotNetGroupName,
                    Limit = 45,
                }
            );

            modelBuilder.Entity<Group>().HasData(
                new Group
                {
                    GroupId = nodeJSGroupId,
                    Name = nodeJsGroupName,
                    Limit = 85,
                }
            );
        }
    }
}
