//============================================================
// Student Number : S10198102
// Student Name	: Tee Yong Teng
// Module  Group : P01 
//============================================================

using System;
namespace HospitalApp
{
    class ClassCBed:Bed
    {
        public bool portableTv { get; set; }

        public ClassCBed(int w, int b, double dr, bool a) : base(w, b, dr, a)
        {
        }

        public override double CalculateCharges(string citzenStatus, int noOfDays)
        {
            double total = 0.0;

            Stay s = null;

            foreach (BedStay i in s.bedstayList)
            {
                if (s.Patient is Child && citzenStatus == "SC")
                {
                    if (((Child)s.Patient).cdaBalance > 205.00 * noOfDays)
                    {
                        if (portableTv == true)
                        {
                            total += ((((Child)s.Patient).cdaBalance - 205.00 * noOfDays) + 30.00);
                        }
                        else
                        {
                            total += (((Child)s.Patient).cdaBalance - 205.00 * noOfDays);
                        }
                    }
                    else if (((Child)s.Patient).cdaBalance < 205.00)
                    {
                        total += (205.00 * noOfDays - ((Child)s.Patient).cdaBalance);
                    }

                    else
                    {
                        total += 205.00 * noOfDays;
                    }
                }

                else if (s.Patient is Adult & citzenStatus == "SC" || citzenStatus == "PR")
                {
                    if (((Adult)s.Patient).medisaveBalance > 205.00 * noOfDays)
                    {
                        if (portableTv == true)
                        {
                            total += ((((Adult)s.Patient).medisaveBalance - 205.00 * noOfDays) + 30.00);

                        }
                        else
                        {
                            total += (((Adult)s.Patient).medisaveBalance - 205.00 * noOfDays);
                        }
                    }
                    else if (((Adult)s.Patient).medisaveBalance < 205.00 * noOfDays)
                    {
                        if (portableTv == true)
                        {
                            total += ((205.00 * noOfDays + 50.00) - ((Adult)s.Patient).medisaveBalance);
                        }
                        else
                        {
                            total += (205.00 * noOfDays - ((Adult)s.Patient).medisaveBalance);
                        }
                    }

                    else
                    {
                        total += 205.00 * noOfDays;
                    }
                }

                else if (s.Patient is Senior)
                {
                    if (portableTv == true)
                    {
                        total += ((205.00 + 30.00) * noOfDays / 2);
                    }
                    else
                    {
                        total += (205.00 * noOfDays / 2);
                    }
                }
            }
            return total;
        }

        public override string ToString()
        {
            return base.ToString()
                + "\tPortable TV: " + portableTv;
        }
    }
}
