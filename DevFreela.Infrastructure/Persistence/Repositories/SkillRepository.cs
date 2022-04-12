using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<List<SkillDTO>> ISkillRepository.GetAllAsync()
        {
            var skills = _dbContext.Skills;

            var skillsViewModel = skills
            .Select(s => new SkillDTO { Id = s.Id, Description = s.Description })
            .ToList();

            return skillsViewModel;

        }
    }
    }
