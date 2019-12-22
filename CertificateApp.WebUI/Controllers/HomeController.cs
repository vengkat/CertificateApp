using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CertificateApp.Model;
using CertificateApp.BL;
namespace CertificateApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        CertificateManager objCert = new CertificateManager();
        MunicipalityManager objMpt = new MunicipalityManager();
        // GET: Home
        public ActionResult Index()
        {
            var model = objCert.GetCertificateList("");
            return View(model);
        }
        public ActionResult NewCertificate()
        {
            CertificateWrapper model = new CertificateWrapper {
                Certificate = new Certificate { DateOfIssue=DateTime.Now.ToString("dd/MM/yyyy")},
                MunicipalityList = GetMunicipalityList()
            };
            return View(model);
        }
        
        //[HttpGet]
        //public ActionResult NewCertificate(string filter)
        //{
        //    CertificateWrapper model = new CertificateWrapper();
        //    model.Certificate = objCert.GetCertificateList(filter).FirstOrDefault();
        //    return View(model);
        //}

        [HttpPost]
        public ActionResult NewCertificate(CertificateWrapper value)
        {
            if (ModelState.IsValid)
            {
                var certificate = value.Certificate;
                certificate.DateOfIssue = DateTime.Now.ToString("dd/MM/yyyy");
                var result = objCert.CreateNewCertificate(certificate);
                if (result)
                {
                    CertificateWrapper model = new CertificateWrapper
                    {
                        Certificate = new Certificate { DateOfIssue = DateTime.Now.ToString("dd/MM/yyyy") },
                        MunicipalityList = GetMunicipalityList()
                    };
                    return View(model);
                }
            }
            value.Certificate.DateOfIssue = DateTime.Now.ToString("dd/MM/yyyy");
            value.MunicipalityList = GetMunicipalityList();
            return View(value);
        }
        public ActionResult SearchCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchCertificate(string filter)
        {
            var model = objCert.GetCertificateList(filter);
            return View(model);
        }
        
        //public ActionResult ViewCertificate()
        //{
        //    return View();
        //}

        
        public ActionResult ViewCertificate(string filter)
        {
            var model = objCert.GetCertificateList(filter).Where(c=>c.CertificateNo==Convert.ToInt32(filter)).FirstOrDefault();
            return View(model);
        }
        public ActionResult Test()
        {
            return View();
        }

        private List<SelectListItem> GetMunicipalityList()
        {
            var municipalityList = objMpt.GetMunicipalityList();
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (Municipality item in municipalityList)
            {
                selectList.Add(new SelectListItem { Text = item.name, Value = item.id.ToString() });
            }
            return selectList;
        }
    }
}