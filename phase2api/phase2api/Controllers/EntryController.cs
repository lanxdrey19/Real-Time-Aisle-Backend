using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using phase2api.Models;
using phase2api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phase2api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntriesController : ControllerBase
    {

        private ILogger _logger;
        private IEntriesService _service;


        public EntriesController(ILogger<EntriesController> logger, IEntriesService service)
        {
            _logger = logger;
            _service = service;

        }

        [HttpGet("/api/products")]
        public ActionResult<List<Entry>> GetProducts()
        {
            return _service.GetEntries();
        }

        [HttpPost("/api/products")]
        public ActionResult<Entry> AddProduct(Entry theirEntry)
        {
            _service.AddEntry(theirEntry);
            return theirEntry;
        }

        [HttpPut("/api/products/{id}")]
        public ActionResult<Entry> UpdateProduct(string id, Entry theirEntry)
        {
            _service.UpdateEntry(id, theirEntry);
            return theirEntry;
        }

        [HttpDelete("/api/products/{id}")]
        public ActionResult<string> DeleteProduct(string id)
        {
            _service.DeleteEntry(id);
            return id;
        }
    }
}
