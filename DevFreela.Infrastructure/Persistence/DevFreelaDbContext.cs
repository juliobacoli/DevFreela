using DevFreela.Core.Entites;
using System;
using System.Collections.Generic;


namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
            new Project("Meu projet ASPNET Core 1", "Descrição de projeto 1", 1,1,10000),
            new Project("Meu projet ASPNET Core 2", "Descrição de projeto 2", 1,1,20000),
            new Project("Meu projet ASPNET Core 3", "Descrição de projeto 3", 1,1,13000)
        };

            Users = new List<User>
            {
                new User("Julio Bacoli", "juliobacoli@gmail.com", new DateTime(1997,08,03)),
                new User("José Bacoli", "josebacoli@gmail.com", new DateTime(1997,08,02)),
                new User("Joaquina Bacoli", "joaquinabacoli@gmail.com", new DateTime(1997,08,01))
            };

            Skills = new List<Skill>
            {
                new Skill(".NETCORE"),
                new Skill("SQL"),
                new Skill("ANGULAR")
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }

    }
}