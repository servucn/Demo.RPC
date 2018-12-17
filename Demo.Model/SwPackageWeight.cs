using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Model
{
    [ProtoContract]
    public class SwPackageWeight
    {
        [ProtoMember(1)]
        public string Guid { get; set; }

        [ProtoMember(2)]
        public string DeviceId { get; set; }

        [ProtoMember(3)]
        public string CardId { get; set; }

        [ProtoMember(4)]
        public long TotalWeight { get; set; }

        [ProtoMember(5)]
        public DateTime CreateDate { get; set; }
    }
}
