using Dapper;
using Demo.Interface;
using Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UcAsp.RPC;

namespace Demo.Bll
{
    [Restful("Weight")]
    public class SwPackageWeightBll : ISwPackageWeight
    {
        public SwPackageWeight GetSwPackageWeight(string Guid)
        {
            using (var conn = new DataBase().CreateDataBase())
            {
                return conn.Query<SwPackageWeight>("select * from SW_PACKAGE_WEIGHT where GUID=:Guid", new { Guid = Guid }).FirstOrDefault();
            }
        }
        [Restful("POST", "GetWeights")]
        public List<SwPackageWeight> GetSwPackageWeights()
        {
            using (var conn = new DataBase().CreateDataBase())
            {
                return conn.Query<SwPackageWeight>("select * from SW_PACKAGE_WEIGHT ").ToList();
            }
        }

        public int Insert(SwPackageWeight export)
        {
            using (var conn = new DataBase().CreateDataBase())
            {
                int number = conn.Execute(string.Format("insert into SW_PACKAGE_WEIGHT(guid, device_id, card_id, total_weight, create_date)  values('{0}', '{1}','{2}', '{3}', sysdate)", export.Guid, export.DeviceId, export.CardId, export.TotalWeight));
                return number;
            }
        }
    }
}
