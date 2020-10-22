using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using benefits.Models;

namespace benefits.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TablesDbController : ControllerBase
    {   
         private TablesDbContext Context;

         public TablesDbController(TablesDbContext context)
        {
            this.Context = context;
        }

        [HttpGet] // Get Groups available
        public ActionResult<IEnumerable<Groups>> Get()
        {
            return Context.groups.ToList();
        }

        [HttpGet("grp/{id}")]//Get Policies By its GroupID
        public ActionResult<IEnumerable<Policies>> GetPolicies(int? id)
        {
          
            return Context.policy.Where(x=>x.groupId==id).ToList(); 
            
        } 


        [HttpGet("grp/policy/{id}")]//Get Policy By its ID
        public ActionResult<Policies> GetPolicy(int? id)
        {
            Policies g = Context.policy.FirstOrDefault(x=>x.policyId==id);
            return g;
        } 

        [HttpGet("grp/policy/benefits/{id}")]//Get Benefits By its ID
        public ActionResult<IEnumerable<Benefits>> GetBenefits(int? id)
        {
          
            return Context.benefit.Where(x=>x.policyId==id).ToList(); 
            
        } 


        [HttpPost("createpolicy")] // Create New Policy
        public ActionResult<Policies> Post([FromBody]Policies newpolicy)
        {
            if(newpolicy==null)
            {return BadRequest();}
            Context.policy.Add(newpolicy);
            Context.SaveChanges();
            return Ok(newpolicy);
        }
        
        [HttpPost("addbenefit")] // Create New Benefit
        public ActionResult<Benefits> Post([FromBody]Benefits newbenefit)
        {
            if(newbenefit==null)
            {return BadRequest();}
            Context.benefit.Add(newbenefit);
            Context.SaveChanges();
            return Ok(newbenefit);
        }

        [HttpDelete("deletepolicy/{policyId}")] //Delete Policy
        public ActionResult<Policies> DeletePolicy(int? policyId)
        {
            if(policyId==null) return BadRequest();
            Policies policy=Context.policy.FirstOrDefault(x=>x.policyId==policyId);	
            Context.policy.Remove(policy);
            Context.SaveChanges();
            return new NoContentResult();
        }

         [HttpDelete("deletebenefit/{benefitId}")] //Delete Benefit
        public ActionResult<Benefits> DeleteBenefit(int? benefitId)
        {
            if(benefitId==null) return BadRequest();
            Benefits exist_benefit=Context.benefit.FirstOrDefault(x=>x.benefitId==benefitId);	
            Context.benefit.Remove(exist_benefit);
            Context.SaveChanges();
            return new NoContentResult();
        }

        
         [HttpDelete("deletegroup/{groupId}")] //Delete Group
        public ActionResult<Groups> DeleteGroups(int? groupId)
        {
            if(groupId==null) return BadRequest();
            Groups exist_group=Context.groups.FirstOrDefault(x=>x.groupId==groupId);	
            Context.groups.Remove(exist_group);
            Context.SaveChanges();
            return new NoContentResult();
        }

       
        [HttpPut("updatepolicy/{id}")]

        public ActionResult<Policies> UpdatePolicy(int? id,[FromBody] Policies p)
        {
            Policies m = Context.policy.FirstOrDefault(x=>x.policyId==id);
            if(p==null) return BadRequest();
            m.policyName=p.policyName;
            m.policyDesc=p.policyDesc;
            m.groupId=p.groupId;
            Context.policy.Update(m);
            Context.SaveChanges();
            return new NoContentResult();
            
        }
        
        





        // private static readonly string[] Summaries = new[]
        // {
        //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        // };

        // private readonly ILogger<WeatherForecastController> _logger;

        // public WeatherForecastController(ILogger<WeatherForecastController> logger)
        // {
        //     _logger = logger;
        // }

        // [HttpGet]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     var rng = new Random();
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateTime.Now.AddDays(index),
        //         TemperatureC = rng.Next(-20, 55),
        //         Summary = Summaries[rng.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }
    }
}
