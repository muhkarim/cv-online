﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVOnline.Bases;
using CVOnline.Models;
using CVOnline.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperienceController : BasesController<WorkExperience, WorkExperienceRepository>
    {
        public WorkExperienceController(WorkExperienceRepository workExperienceRepository) : base(workExperienceRepository)
        {

        }
    }
}