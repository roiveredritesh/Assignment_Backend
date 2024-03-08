using Assignment.Model;
using Assignment.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Assignment.Controllers
{
    //[Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class DocumentCenterController : ControllerBase
    {
        private readonly IDocumentCenterSL _documentCenterSL;

        public DocumentCenterController(IDocumentCenterSL documentCenterSL)
        {
            _documentCenterSL = documentCenterSL;
        }

        [HttpGet("GetAllDocumentCenters")]
        public async Task<IActionResult> GetAllDocumentCenters()
        {
            var documentCenters = await _documentCenterSL.GetDocumentCenters();
            return Ok(documentCenters);
        }

        [HttpGet("DocumentCenter/{id}")]
        public async Task<IActionResult> GetAllDocumentCenter(int id)
        {
            var documentCenters = await _documentCenterSL.GetDocumentCenter(id);
            if (documentCenters is null)
                return NotFound("No Record Found");
            return Ok(documentCenters);
        }

        [HttpPost("AddDocumentCenter")]
        public async Task<IActionResult> AddDocumentCenter([FromForm] Create_DocumentCenter create_DocumentCenter)
        {
            if (create_DocumentCenter.File.Length == 0)
            {
                return BadRequest("File not found. Please upload file.");
            }

            var documentCenter = await _documentCenterSL.AddDocumentCenter(create_DocumentCenter);
            if (documentCenter is null)
                return BadRequest("Something went wrong");
            return Ok(documentCenter);
        }


        [HttpPut("UpdateDocumentCenter/{id}")]
        public async Task<IActionResult> UpdateDocumentCenter(int id, [FromForm] Update_DocumentCenter update_DocumentCenter)
        {
            var documentCenter = await _documentCenterSL.UpdateDocumentCenter(id, update_DocumentCenter);
            if (documentCenter is null)
                return BadRequest("Something went wrong");
            return Ok(documentCenter);
        }


        [HttpDelete("DeleteDocumentCenter/{id}")]
        public async Task<IActionResult> DeleteDocumentCenter(int id)
        {
            bool result = await _documentCenterSL.DeleteDocumentCenter(id);
            if (!result)
                return BadRequest("Something went wrong");
            return Ok("Deleted successfully.");
        }




        [HttpGet("GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _documentCenterSL.GetDepartments();
            return Ok(departments);
        }


        [HttpGet("GetAllOffices")]
        public async Task<IActionResult> GetAllOffices()
        {
            var offices = await _documentCenterSL.GetOffices();
            return Ok(offices);
        }

        [HttpGet("GetAllDivisions")]
        public async Task<IActionResult> GetAllDivisions()
        {
            var divisions = await _documentCenterSL.GetDivisions();
            return Ok(divisions);
        }

        [HttpGet("DownloadFile/{fileName}")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            try
            {
                string foldername = Path.Combine("Resource", "DocumentCenter");
                string directorypath = Path.Combine(Directory.GetCurrentDirectory(), foldername);
                string filename = fileName;
                string fullpath = Path.Combine(directorypath, filename);
                if (!System.IO.File.Exists(fullpath))
                {
                    return BadRequest("No file exists.");
                }
                var fileContent = await System.IO.File.ReadAllBytesAsync(fullpath);
                var filecontentresult = new FileContentResult(fileContent, "application/octet-stream")
                {
                    FileDownloadName = filename
                };
                return filecontentresult;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
