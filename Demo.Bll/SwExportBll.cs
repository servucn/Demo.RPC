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

    [Restful("SwExport")]
    public class SwExportBll : ISwExport
    {
        [Restful("POST", "GetExport")]
        public SwExport GetExport(string Id)
        {
            using (var conn = new DataBase().CreateDataBase())
            {
                return conn.Query<SwExport>("select * from SW_EXPORT where card_id=:CardId", new { CardId = Id }).FirstOrDefault();
            }
        }

        [Restful("POST", "GetAllExports")]
        public List<SwExport> GetSwExports()
        {
            using (var conn = new DataBase().CreateDataBase())
            {
                return conn.Query<SwExport>("select * from SW_EXPORT").ToList();
            }
        }
        [Restful("POST", "AddExport")]
        public int Insert(SwExport export)
        {
            using (var conn = new DataBase().CreateDataBase())
            {
                int number = conn.Execute(string.Format("insert into SW_EXPORT(guid,  card_id, EXIT_NUMBER, CREATE_TIME)  values('{0}', '{1}','{2}', sysdate)", export.Guid, export.CardId, export.ExitNumber));
                return number;
            }
        }
    }
}
