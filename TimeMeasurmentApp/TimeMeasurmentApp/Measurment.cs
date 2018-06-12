using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeMeasurmentApp
{
    public class Measurment
    {
        private static int _measurmentID = 0;
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double Result { get; set; }
        public Measurment()
        {
            Id = _measurmentID;
            _measurmentID++;
        }
    }
}
