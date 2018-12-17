using Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface
{
    public interface ISwPackageWeight
    {
        int Insert(SwPackageWeight export);

        List<SwPackageWeight> GetSwPackageWeights();

        SwPackageWeight GetSwPackageWeight(string Id);
    }
}
