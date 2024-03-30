using System;
using System.Collections.Generic;

namespace Api_Smart_Counters.Models
{
    public partial class Device
    {
        public Device()
        {
            Counters = new HashSet<Counter>();
            LeakSensors = new HashSet<LeakSensor>();
        }

        public int IdDevices { get; set; }
        public string? DeviceName { get; set; }
        public int TransmitRate { get; set; }
        public int? UsersId { get; set; }
        public TimeSpan TimeLastConnect { get; set; }
        public DateTime DateLastConnect { get; set; }

        public virtual User? Users { get; set; }
        public virtual ICollection<Counter> Counters { get; set; }
        public virtual ICollection<LeakSensor> LeakSensors { get; set; }
    }
}
