using System;
using System.Collections.Generic;

namespace Api_Smart_Counters.Models
{
    public partial class LeakSensor
    {
        public int IdLeakSensors { get; set; }
        public int Condition { get; set; }
        public TimeSpan TimeActivation { get; set; }
        public DateTime DateActivation { get; set; }
        public int DevicesId { get; set; }

        public virtual Device Devices { get; set; } = null!;
    }
}
