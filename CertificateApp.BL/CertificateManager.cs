using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CertificateApp.Model;
using CertificateApp.Repository;

namespace CertificateApp.BL
{
    public class CertificateManager
    {
        CertificateRepository objRepo = new CertificateRepository();
        public bool CreateNewCertificate(Certificate cert)
        {
            var result = objRepo.CreateNewCertificate(cert);
            if (result > 0)
                return true;
            else
                return false;
        }

        public IEnumerable<Certificate> GetCertificateList(string filter)
        {
            var ds = objRepo.GetCertificateList();
            try
            {
                var result = ds.Tables[0].AsEnumerable().Select(r =>
                new Certificate
                {
                    CertificateNo = Convert.ToInt32(r.Field<Int32>("Id")),
                    BrideGroom = new Person
                    {
                        name = r.Field<string>("G_Name"),
                        fatherName = r.Field<string>("G_Father_Name"),
                        motherName = r.Field<string>("G_Mother_Name"),
                        birthPlace = r.Field<string>("G_Birth_Place"),
                        DOB = Convert.ToDateTime(r.Field<string>("G_DOB")),
                        domicile= r.Field<string>("G_Domicile"),
                        profession = r.Field<string>("G_Profession"),                        
                    },
                    Bride = new Person
                    {
                        name = r.Field<string>("B_Name"),
                        fatherName = r.Field<string>("B_Father_Name"),
                        motherName = r.Field<string>("B_Mother_Name"),
                        birthPlace = r.Field<string>("B_Birth_Place"),
                        DOB = Convert.ToDateTime(r.Field<string>("B_DOB")),
                        domicile = r.Field<string>("B_Domicile"),
                        profession = r.Field<string>("B_Profession"),
                    },
                    Municipality       = new Municipality { name= r.Field<string>("Municipality_Name") },                    
                    DateOfMarriage     = r.Field<string>("Date_Marriage"),
                    DateOfRegistration = r.Field<string>("Date_Registration"),
                    DateOfIssue        = r.Field<string>("Date_Issue"),
                    PlaceOfMarriage    = r.Field<string>("Place_Marriage")
                }).ToList<Certificate>();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
