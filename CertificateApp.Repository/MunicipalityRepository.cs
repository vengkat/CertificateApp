using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificateApp.Repository
{
    public class MunicipalityRepository
    {
        string connString = ConfigurationManager.ConnectionStrings["sqlConnectionString"]?.ToString();
        public DataSet GetMunicipalityList()
        {
            var conn = new SqlConnection(connString);
            try
            {
                DataSet dsCertList = new DataSet();
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText =
                    "Select * from MunicipalityMaster";
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
