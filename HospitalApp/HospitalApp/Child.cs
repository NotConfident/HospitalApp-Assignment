//============================================================
// Student Number : S10198102
// Student Name	: Tee Yong Teng
// Module  Group : P01 
//============================================================

using System;
namespace HospitalApp
{
    class Child:Patient
    {
        public double cdaBalance { get; set; }

        public Child(string id, string n, int a, char g, string cs, string s, double cda) : base (id, n, a, g, cs, s)
        {
            cdaBalance = cda;
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
            return base.ToString()
                + "\tCDA Balance: " + cdaBalance;
        }



    }
}
