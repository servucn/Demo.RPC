using Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface
{
    public interface ISwExportFinish
    {
        int Insert(SwExportFinish export);

        List<SwExportFinish> GetSwExportFinishs();

        SwExportFinish GetSwExportFinish(string Id);
    }
}
