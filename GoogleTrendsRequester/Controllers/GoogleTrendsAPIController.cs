using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleTrendsASPCoreServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GoogleTrendsRequester.Controllers
{
    [ApiController]
    public class GoogleTrendsAPIController : ControllerBase
    {
        private readonly INodeServices _nodeServices;
        private readonly ILogger<GoogleTrendsAPIController> _logger;
        public GoogleTrendsAPIController(INodeServices nodeServices, ILogger<GoogleTrendsAPIController> logger)
        {
            _nodeServices = nodeServices;
            _logger = logger;
        }
		
		/*

        [HttpGet("api/interests/{keyword}")]
        public async Task<ActionResult<string>> InterestsOverTime(string keyword, [FromQuery]DateTime? startTime, [FromQuery]DateTime? endTime,
            [FromQuery]string geo, [FromQuery]string hl, [FromQuery]int? timeZone, [FromQuery]int? category, [FromQuery]bool? granularTimeResolution)
        {
            string result;
            try
            {
                var request = new Request(keyword, startTime, endTime, geo, hl, timeZone, category, granularTimeResolution);
                result = await _nodeServices.InvokeAsync<string>("./Node/interestOverTime", request);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
            
            return Ok(result);
        }
        
        [HttpGet("api/autocomplete/{keyword}")]
        public async Task<ActionResult<string>> AutoComplete(string keyword, [FromQuery]DateTime? startTime, [FromQuery]DateTime? endTime,
            [FromQuery]string geo, [FromQuery]string hl, [FromQuery]int? timeZone, [FromQuery]int? category, [FromQuery]bool? granularTimeResolution)
        {
            string result;
            try
            {
                var request = new Request(keyword, startTime, endTime, geo, hl, timeZone, category, granularTimeResolution);
                result = await _nodeServices.InvokeAsync<string>("./Node/autoComplete", request);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
            
            return Ok(result);
        }
		
		*/
        
        [HttpGet("api/related/{keyword}")]
        public async Task<ActionResult<string>> RelatedQueries(string keyword, [FromQuery]DateTime? startTime, [FromQuery]DateTime? endTime,
            [FromQuery]string geo, [FromQuery]string hl, [FromQuery]int? timeZone, [FromQuery]int? category, [FromQuery]bool? granularTimeResolution)
        {
            string result;
            try
            {
                var request = new Request(keyword, startTime, endTime, geo, hl, timeZone, category, granularTimeResolution);
                result = await _nodeServices.InvokeAsync<string>("./Node/relatedQueries", request);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
            
            return Ok(result);
        }
    }
}
