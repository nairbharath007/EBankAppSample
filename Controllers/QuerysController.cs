using EBankAppSample.DTOs;
using EBankAppSample.Models;
using EBankAppSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBankAppSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuerysController : ControllerBase
    {
        private readonly IQueryService _queryService;

        public QuerysController(IQueryService queryService)
        {
            _queryService = queryService;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            List<QueryDto> queryDtos = new List<QueryDto>();
            var queries = _queryService.GetAll();
            if (queries.Count == 0)
            {
                return BadRequest("No queries are available.");
            }
            else
            {
                foreach (var query in queries)
                {
                    queryDtos.Add(ConvertToDto(query));
                }
            }
            return Ok(queryDtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var query = _queryService.GetById(id);
            if (query != null)
            {
                var queryDto = ConvertToDto(query);
                return Ok(queryDto);
            }
            return NotFound("No such query exists.");
        }

        [HttpPost("")]
        public IActionResult Add(QueryDto queryDto)
        {
            var query = ConvertToModel(queryDto);
            int newQueryId = _queryService.Add(query);
            if (newQueryId != null)
            {
                return Ok(newQueryId);
            }
            return BadRequest("Some issue while adding the query.");
        }

        [HttpPut("")]
        public IActionResult Update(QueryDto queryDto)
        {
            var query = _queryService.GetById(queryDto.QueryId);
            if (query != null)
            {
                var updatedQuery = ConvertToModel(queryDto);
                var modifiedQuery = _queryService.Update(updatedQuery);
                return Ok(modifiedQuery);
            }
            return BadRequest("Some issue while updating the query.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var query = _queryService.GetById(id);
            if (query != null)
            {
                _queryService.Delete(query);
                return Ok(id);
            }
            return BadRequest("No query found to delete.");
        }

        private Query ConvertToModel(QueryDto queryDto)
        {
            return new Query
            {
                QueryId = queryDto.QueryId,
                CustomerId = queryDto.CustomerId,
                QueryText = queryDto.QueryText,
                QueryDate = queryDto.QueryDate,
                ReplyText = queryDto.ReplyText,
                ReplyDate = queryDto.ReplyDate,
                Status = queryDto.Status,
                IsActive = queryDto.IsActive
            };
        }

        private QueryDto ConvertToDto(Query query)
        {
            return new QueryDto
            {
                QueryId = query.QueryId,
                CustomerId = query.CustomerId,
                QueryText = query.QueryText,
                QueryDate = query.QueryDate,
                ReplyText = query.ReplyText,
                ReplyDate = query.ReplyDate,
                Status = query.Status,
                IsActive = query.IsActive
            };
        }
    }
}

