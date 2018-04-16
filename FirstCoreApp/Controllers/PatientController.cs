using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FirstCoreApp.Model;
using System.Linq;

namespace FirstCoreApp.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly PatientContext m_context;
        
        public PatientController(PatientContext context)
        {
            m_context = context;

            if (m_context.PatientItems.Count() == 0)
            {
                m_context.PatientItems.Add(new PatientItem { Name = "UntitledName" });
                m_context.SaveChanges();
            }
            
        }


        [HttpPost]
        public IActionResult Create([FromBody] PatientItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            m_context.PatientItems.Add(item);
            m_context.SaveChanges();

            return CreatedAtRoute("GetPatient", new { id = item.Id }, item);
        }

        [HttpGet]
        public IEnumerable<PatientItem> GetAll()
        {
            return m_context.PatientItems.ToList();
        }

        [HttpGet("{id}", Name = "GetPatient")]
        public IActionResult GetById(long id)
        {
            var item = m_context.PatientItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

    }
}
