using DevFreela.Core.Entites;
using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("Teste", "Testando",1, 2, 10000);

            //Faz algumas validações ANTES do metodo Start
            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotEmpty(project.Title);
            Assert.NotNull(project.Title);

            Assert.NotEmpty(project.Description);
            Assert.NotNull(project.Description);

            project.Start();

            //Faz algumas validações DEPOIS do metodo Start
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status); //Verifica se o primeiro status é IGUAL ao status atual do projeto
            //Assert.NotNull(project.StartedAt);

        }
    }
}
