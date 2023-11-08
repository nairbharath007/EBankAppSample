using EBankAppSample.DTOs;
using EBankAppSample.Models;
using EBankAppSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBankAppSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            List<DocumentDto> documentDtos = new List<DocumentDto>();
            var documents = _documentService.GetAll();
            if (documents.Count == 0)
            {
                return BadRequest("No documents available.");
            }
            else
            {
                foreach (var document in documents)
                {
                    documentDtos.Add(ConvertToDto(document));
                }
            }
            return Ok(documentDtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var document = _documentService.GetById(id);
            if (document != null)
            {
                var documentDto = ConvertToDto(document);
                return Ok(documentDto);
            }
            return NotFound("No such document exists.");
        }

        [HttpPost("")]
        public IActionResult Add(DocumentDto documentDto)
        {
            var document = ConvertToModel(documentDto);
            int newDocumentId = _documentService.Add(document);
            if (newDocumentId != null)
            {
                return Ok(newDocumentId);
            }
            return BadRequest("Some issue while adding the document.");
        }

        [HttpPut("")]
        public IActionResult Update(DocumentDto documentDto) 
        {
            var document = _documentService.GetById(documentDto.DocumentId);
            if (document != null)
            {
                var updatedDocument = ConvertToModel(documentDto);
                var modifiedDocument = _documentService.Update(updatedDocument);
                return Ok(modifiedDocument);
            }
            return BadRequest("Some issue while updating the document.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var document = _documentService.GetById(id);
            if (document != null)
            {
                _documentService.Delete(document);
                return Ok(id);
            }
            return BadRequest("No document found to delete.");
        }

        private Document ConvertToModel(DocumentDto documentDto) 
        {
            return new Document
            {
                DocumentId = documentDto.DocumentId,
                CustomerId = documentDto.CustomerId,
                DocumentData = documentDto.DocumentData,
                DocumentType = documentDto.DocumentType,
                UploadDate = documentDto.UploadDate,
                Status = documentDto.Status,
            };
        }

        private DocumentDto ConvertToDto(Document document)
        {
            return new DocumentDto
            {
                DocumentId = document.DocumentId,
                CustomerId = document.CustomerId,
                DocumentData = document.DocumentData,
                DocumentType = document.DocumentType,
                UploadDate = document.UploadDate,
                Status = document.Status,
            };
        }
    }
}
