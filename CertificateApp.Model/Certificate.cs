using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CertificateApp.Model
{
    public class CertificateWrapper
    {
        public Certificate Certificate { get; set; }
        public List<SelectListItem> MunicipalityList { get; set; }
    }
    public class Certificate
    {
        public int CertificateNo { get; set; }
        public string OMI { get; set; }
        public Person BrideGroom { get; set; }
        public Person Bride { get; set; }
        [Required(ErrorMessage = "DOB is required")]        
        public string PlaceOfMarriage { get; set; }
        [Required(ErrorMessage = "Date of marriage is required")]        
        public string DateOfMarriage { get; set; }
        [Required(ErrorMessage = "Date of Registration is required")]        
        public string DateOfRegistration { get; set; }        
        public string DateOfIssue { get; set; }
        [Required(ErrorMessage = "Municipality is required")]        
        public Municipality Municipality { get; set; }
    }

    public class Person
    {
        public string name { get; set; }

        [Required(ErrorMessage = "DOB is required")]
        [DataType(DataType.Date)]
        public System.DateTime DOB { get; set; }        
        public int age { get; set; }
        [Required(ErrorMessage = " Birth Place is required")]        
        public string birthPlace { get; set; }
        [Required(ErrorMessage = "Domicile is required")]
        public string domicile { get; set; }
        [Required(ErrorMessage = "Father name is required")]
        public string fatherName { get; set; }
        [Required(ErrorMessage = "Mother name is required")]
        public string motherName { get; set; }        
        public string profession { get; set; }
    }
}
