using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial.Services.SkillService
{
    public interface ISkillService
    {
        Task<ServiceResponse<List<Skill>>> GetAllSkill();
    }
}