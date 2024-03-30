using System;
using System.Collections.Generic;

namespace Api_Smart_Counters.Models
{
    public partial class Counter
    {
        public int IdCounters { get; set; }
        public bool TypeCounter { get; set; }
        public int Indication { get; set; }
        public TimeSpan TimePush { get; set; }
        public DateTime DatePush { get; set; }
        public int DevicesId { get; set; }


    }
}
