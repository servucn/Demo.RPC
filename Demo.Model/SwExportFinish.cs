using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Model
{
    [ProtoContract]
    public class SwExportFinish
    {
        [ProtoMember(1)]
        public string Guid { get; set; }

        [ProtoMember(2)]
        public string CardId { get; set; }

        [ProtoMember(3)]
        public long GoalNumber { get; set; }

        [ProtoMember(4)]
        public long  ActNumber { get; set; }

        [ProtoMember(5)]
        public DateTime FinishTime { get; set; }
    }
}
