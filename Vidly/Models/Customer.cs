using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int  Id { get; set; }
        [Required] // This dataAnnotation makes the Name field below non nullable 
        [StringLength(255)] // Sets the max char of the field below it
        public  string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }  // Added migration to add this change by itself
        public MembershipType MembershipType { get; set; }   // Navigation Type - Usefull when you want to load an object and its related objects together
        public byte MembershipTypeId { get; set; } // for optomization add this property to just load the membership id without loading the entire membership object: treated as foreign key
    }

}