//============================================================
// Student Number : S10198102
// Student Name	: Tee Yong Teng
// Module  Group : P01 
//============================================================

using System;
namespace HospitalApp
{
    class Senior:Patient
    {
        public Senior(string id, string n, int a, char g, string cs, string s) : base(id, n, a, g, cs, s)
        {
        }

        public double CalculateCharges()
        {
            string date = Convert.ToString(Stay.admittedDate);
            Bed bed = null;
            DateTime now = DateTime.Now;
            int days = Convert.ToInt32((Convert.ToDateTime(date) - now).TotalDays);
            return bed.CalculateCharges(citizenStatus, days);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
