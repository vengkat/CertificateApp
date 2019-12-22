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
    public class MunicipalityManager
    {
        MunicipalityRepository objRepo = new MunicipalityRepository();
        public IEnumerable<Municipality> GetMunicipalityList()
        {
            var ds = objRepo.GetMunicipalityList();
            try
            {
                var result = ds.Tables[0].AsEnumerable().Select(r =>
                new Municipality
                {
                    id = Convert.ToInt32(r.Field<Int32>("Id")),
                    name = r.Field<string>("name")
                }).ToList<Municipality>();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
