using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CertificateApp.Model;

namespace CertificateApp.Repository
{
    public class CertificateRepository
    {
        string connString = ConfigurationManager.ConnectionStrings["sqlConnectionString"]?.ToString();
        public int CreateNewCertificate(Certificate cert)
        {
            var conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                    "INSERT into CertificateMaster(G_Name,  G_Father_Name,  G_Mother_Name,  G_DOB,  G_age,  G_Profession,   G_Domicile," +
                    "B_Name,    B_Father_Name,  B_Mother_Name,  B_DOB,  B_Age,  B_Profession,   B_Domicile," +
                    "Date_Marriage, Date_Registration,  Date_Issue, Municipality) " +
                    "values('"+cert.BrideGroom.name+ "', '" + 
                    cert.BrideGroom.fatherName + "', '" + 
                    cert.BrideGroom.motherName + "', '" +
                    cert.BrideGroom.DOB + "', '" +
                    cert.BrideGroom.age + "', '" +
                    cert.BrideGroom.profession + "', '" +
                    cert.BrideGroom.domicile + "', '" +
                    cert.Bride.name + "', '" +
                    cert.Bride.fatherName + "', '" +
                    cert.Bride.motherName + "', '" +
                    cert.Bride.DOB + "', '" +
                    cert.Bride.age + "', '" +
                    cert.Bride.profession + "', '" +
                    cert.Bride.domicile + "', '" +
                    cert.DateOfMarriage + "', '" +
                    cert.DateOfRegistration + "', '" +
                    cert.DateOfIssue + "', '" +
                    cert.Municipality.id + "')";
                return command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }            
        }

        public DataSet GetCertificateList()
        {
            var conn = new SqlConnection(connString);
            try
            {
                DataSet dsCertList = new DataSet();
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                    "SELECT c.*,m.Name AS 'Municipality_Name' FROM CERTIFICATEMASTER c " +
                        "INNER JOIN MUNICIPALITYMASTER m ON c.Municipality = m.Id " +
                        "ORDER BY C.ID DESC";
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dsCertList);
                return dsCertList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
