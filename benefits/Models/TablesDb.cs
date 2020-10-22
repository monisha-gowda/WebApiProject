using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;

namespace benefits.Models
{

    public class Groups
    {[Key]
    public int groupId { get; set; }
    public string groupName { get; set; }
    public string groupDesc { get; set; }
    public virtual List<Policies> policies { get; set; }
     public Groups()
        {
            
        }
}

    public class Policies
    {
    [Key]
    public int policyId { get; set; }
    public string policyName { get; set; }
    public string policyDesc{ get; set; }
    
    [ForeignKey("groupId")]
    public int groupId{get; set;}
    public Groups Group{ get; set; }
    public virtual List<Benefits> benefits { get; set; }
        public Policies()
        {
            
        }
    }
    public class Benefits
    {
        [Key]
        public int benefitId { get; set; }
        public string benefitName { get; set; }
        [ForeignKey("policyId")]
        public int policyId{ get; set;}
        public Policies Policy { get; set; }
        public Benefits()
        {
            
        }
        
    }
}