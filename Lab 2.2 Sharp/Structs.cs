using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Lab_2._2_Sharp
{
    [Serializable]
    internal struct TrainTime
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public TrainTime(int hours, int minutes) 
        {
            Hours = hours;
            Minutes = minutes;
        }

    }

    [Serializable]
    internal struct Train : ISerializable
    {
        public int Number { get; set; }
        public string Way { get; set; }
        public TrainTime Departuretime { get; set; }
        public TrainTime Arrivaltime { get; set; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("num", Number, typeof(int));
            info.AddValue("way", Way, typeof(string));
            info.AddValue("departure", Departuretime, typeof(TrainTime));
            info.AddValue("arrival", Arrivaltime, typeof(TrainTime));
        }

        public Train(SerializationInfo info, StreamingContext context) 
        {
            this.Number = (int)info.GetValue("num", typeof(int));
            this.Way = (string)info.GetValue("way", typeof(string));
            this.Departuretime = (TrainTime)info.GetValue("departure", typeof(TrainTime));
            this.Arrivaltime = (TrainTime)info.GetValue("arrival", typeof(TrainTime));
        }
    }
}
