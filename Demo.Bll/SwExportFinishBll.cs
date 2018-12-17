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
    [Restful("Finish")]
    public class SwExportFinishBll : ISwExportFinish
    {
        public SwExportFinish GetSwExportFinish(string Id)
        {
            using (var conn = new DataBase().CreateDataBase())
            {
                return conn.Query<SwExportFinish>("select * from SW_EXPORT_FINISH where card_id=:CardId", new { CardId = Id }).FirstOrDefault();
            }
        }

        public List<SwExportFinish> GetSwExportFinishs()
        {
            using (var conn = new DataBase().CreateDataBase())
            {
                return conn.Query<SwExportFinish>("select * from SW_EXPORT_FINISH").ToList();
            }
        }

        public int Insert(SwExportFinish export)
        {
            using (var conn = new DataBase().CreateDataBase())
            {
                string sql = string.Format(@"insert into sw_export_finish(guid,card_id,goal_number,act_number,finish_time) values('{0}', '{1}', {2}, {3}, sysdate)", export.Guid, export.CardId, export.GoalNumber, export.ActNumber);
                int number = conn.Execute(sql);
                return number;
            }
        }
    }
}
