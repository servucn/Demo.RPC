using Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface
{
    public interface ISwExport
    {

        int Insert(SwExport export);

        List<SwExport> GetSwExports();

        SwExport GetExport(string Id);
    }
}
