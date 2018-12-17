using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Model
{
    [ProtoContract]
    public class SwExport
    {

        [ProtoMember(1)]
        public string Guid { get; set; }
        [ProtoMember(2)]
        public string CardId { get; set; }

        [ProtoMember(3)]
        public string ExitNumber { get; set; }

        [ProtoMember(4)]
        public DateTime CreateTime { get; set; }

    }
}
