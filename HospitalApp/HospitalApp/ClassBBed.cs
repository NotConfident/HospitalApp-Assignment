//============================================================
// Student Number : S10198102
// Student Name	: Tee Yong Teng
// Module  Group : P01 
//============================================================

using System;
namespace HospitalApp
{
    class ClassBBed : Bed
    {
        public bool airCon { get; set; }

        public ClassBBed(int w, int b, double dr, bool a) : base(w, b, dr, a)
        {
        }

        public override double CalculateCharges(string citzenStatus, int noOfDays)
        {
            double total = 0.0;

            Stay s = null;
            int week = 0;

            string date = Convert.ToString(s.admittedDate);
            DateTime now = DateTime.Now;

            double days = Convert.ToInt32((Convert.ToDateTime(date) - now).TotalDays);

            if (days < 8.0)
            {
                week += 1;
            }

            else if (days > 8.0)
            {
                week += Convert.ToInt32(Math.Ceiling(days % 7));
            }

            foreach (BedStay i in s.bedstayList)
            {
                if (s.Patient is Child && citzenStatus == "SC")
                {
                    if (((Child)s.Patient).cdaBalance > 268.00 * noOfDays)
                    {
                        if (airCon == true)
                        {
                            total += ((((Child)s.Patient).cdaBalance - 268.00 * noOfDays) + (50.00 * week));
                        }
                        else
                        {
                            total += (((Child)s.Patient).cdaBalance - 268.00 * noOfDays);
                        }
                    }
                    else if (((Child)s.Patient).cdaBalance < 268.00)
                    {
                        total += (268.00 * noOfDays - ((Child)s.Patient).cdaBalance);
                    }

                    else
                    {
                        total += 268.00 * noOfDays;
                    }
                }

                else if (s.Patient is Adult & citzenStatus == "SC" || citzenStatus == "PR")
                {
                    if (((Adult)s.Patient).medisaveBalance > 268.00 * noOfDays)
                    {
                        if (airCon == true)
                        {
                            total += ((((Adult)s.Patient).medisaveBalance - 268.00 * noOfDays) + (50.00 * week));

                        }
                        else
                        {
                            total += (((Adult)s.Patient).medisaveBalance - 268.00 * noOfDays);
                        }
                    }
                    else if (((Adult)s.Patient).medisaveBalance < 268.00 * noOfDays)
                    {
                        if (airCon == true)
                        {
                            total += ((268.00 * noOfDays + 50.00) - ((Adult)s.Patient).medisaveBalance);
                        }
                        else
                        {
                            total += (268.00 * noOfDays - ((Adult)s.Patient).medisaveBalance);
                        }
                    }

                    else
                    {
                        total += 268.00 * noOfDays;
                    }
                }

                else if (s.Patient is Senior)
                {
                    if (airCon == true)
                    {
                        total += ((268.00 + (50.00 * week)) * noOfDays / 2);
                    }
                    else
                    {
                        total += (268.00 * noOfDays / 2);
                    }
                }
            }
            return total;
        }

        public override string ToString()
        {
            return base.ToString()
                + "\tAir Con: " + airCon;
        }
    }
}
