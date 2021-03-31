using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aerolog.Engines;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aerolog.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileEngine _fileEngine;
        public FileController(IFileEngine fileEngine)
        {
            _fileEngine = fileEngine;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContent(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                var file = await _fileEngine.GetById(id);
                return File(file.FileContent, file.ContentType);
            }
            return null;
        }
    }
}
