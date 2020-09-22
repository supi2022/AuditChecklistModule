using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditChecklistModule.Models;
using AuditChecklistModule.Providers;
using AuditChecklistModule.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditChecklistModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditChecklistController : ControllerBase
    {

         readonly log4net.ILog _log4net;
        public AuditChecklistController()
        {
            _log4net = log4net.LogManager.GetLogger(typeof(AuditChecklistController));
        }

        // GET: api/AuditChecklist
        [HttpGet("{auditType}")]
        public IActionResult Get(string auditType)
        {
            _log4net.Info(" AuditChecklistController Http GET request called");
            try
            {
                ChecklistProvider obj = new ChecklistProvider();

                var list = obj.QuestionsProvider(auditType);

                if (list != null)
                    return Ok(list);
            }
            catch(Exception)
            {
                _log4net.Info("Exception from AuditChecklist");
                return Ok("EXception from AuditChecklist");
            }
            return BadRequest("No input or Wrong Input");
            

            
        }        
    }
}
