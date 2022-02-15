//============================================================
// Student Number : S10198102
// Student Name	: Tee Yong Teng
// Module  Group : P01 
//============================================================

using System;
namespace HospitalApp
{
    abstract class Bed
    {
        public int WardNo { get; set; }
        public int BedNo { get; set; }
        public double DailyRate  { get; set; }
        public bool Available { get; set; }

        protected Bed(int w, int b, double dr, bool a)
        {
            WardNo = w;
            BedNo = b;
            DailyRate = dr;
            Available = a;
        }

        public abstract double CalculateCharges(string citzenStatus, int noOfDays);
        //{
        //    BedStay s = null;

        //    if (s.bed  is ClassABed)
        //    {
        //        ClassABed a = null;
        //        a.CalculateCharges(citzenStatus, noOfDays);
        //    }

        //    else if (s.bed is ClassBBed)
        //    {
        //        ClassBBed b = null;
        //        b.CalculateCharges(citzenStatus, noOfDays);
        //    }

        //    else if (s.bed is ClassCBed)
        //    {
        //        ClassCBed c = null;
        //        c.CalculateCharges(citzenStatus, noOfDays);
        //    }

        //    return s.bed.CalculateCharges(citzenStatus, noOfDays);
        //}

        public override string ToString()
        {
            return "Ward No: " + WardNo
                + "\tBed No: " + BedNo
                + "\tDaily Rate" + DailyRate
                + "Availability: " + Available;
        }
    }
}
