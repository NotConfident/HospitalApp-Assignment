//============================================================
// Student Number : S10198102
// Student Name	: Tee Yong Teng
// Module  Group : P01 
//============================================================

using System;
namespace HospitalApp
{
    class BedStay
    {
        public DateTime startBedstay { get; set; }
        public DateTime? endBedstay { get; set; }
        public Bed bed { get; set; }

        public BedStay(DateTime start, Bed b)
        {
            startBedstay = start;
            bed = b;
        }

        public override string ToString()
        {
            return base.ToString()
                + "Start Bed Stay: " + startBedstay
                + "Bed: " + bed;
        }
    }
}
