//============================================================
// Student Number : S10198102
// Student Name	: Tee Yong Teng
// Module  Group : P01 
//============================================================

using System;
namespace HospitalApp
{
    class Adult:Patient
    {
        public double medisaveBalance { get; set; }

        public Adult(string id, string n, int a, char g, string cs, string s, double bal) : base(id, n, a, g, cs, s)
        {
            medisaveBalance = bal;
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
                + "\tMedisave Balance: " + medisaveBalance;
        }


    }
}
