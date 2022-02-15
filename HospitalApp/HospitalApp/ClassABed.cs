//============================================================
// Student Number : S10198102
// Student Name	: Tee Yong Teng
// Module  Group : P01 
//============================================================

using System;
namespace HospitalApp
{
    class ClassABed: Bed
    {
        public bool accompanyingPerson { get; set; }

        public ClassABed(int w, int b, double dr, bool a) : base(w, b, dr, a)
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
                    if (((Child)s.Patient).cdaBalance > 450.00 * noOfDays)
                    {
                        if (accompanyingPerson == true)
                        {
                            total += ((((Child)s.Patient).cdaBalance - 450.00 * noOfDays) + 100);
                        }
                        else
                        {
                            total += (((Child)s.Patient).cdaBalance - 450.00 * noOfDays);
                        }
                    }
                    else if (((Child)s.Patient).cdaBalance < 450.00)
                    {
                        total += (450.00 * noOfDays - ((Child)s.Patient).cdaBalance);
                    }

                    else
                    {
                        total += 450.00 * noOfDays;
                    }
                }

                else if(s.Patient is Adult & citzenStatus == "SC" || citzenStatus == "PR")
                {
                    if (((Adult)s.Patient).medisaveBalance > 450.00 * noOfDays)
                    {
                        if (accompanyingPerson == true)
                        {
                            total += ((((Adult)s.Patient).medisaveBalance - 450.00 * noOfDays) + 100);

                        }
                        else
                        {
                            total += (((Adult)s.Patient).medisaveBalance - 450.00 * noOfDays);
                        }
                    }
                    else if (((Adult)s.Patient).medisaveBalance < 450.00 * noOfDays)
                    {
                        if (accompanyingPerson == true)
                        {
                            total += ((450.00 * noOfDays + 100) - ((Adult)s.Patient).medisaveBalance);
                        }
                        else
                        {
                            total += (450.00 * noOfDays - ((Adult)s.Patient).medisaveBalance);
                        }
                    }

                    else
                    {
                        total += 450.00 * noOfDays;
                    }
                }

                else if (s.Patient is Senior)
                {
                    if (accompanyingPerson == true)
                    {
                        total += ((450.00 + 100) * noOfDays / 2);
                    }
                    else
                    {
                        total += (450.00 * noOfDays / 2);
                    }
                }
            }
            return total;
        }

        public override string ToString()
        {
            return base.ToString()
                + "\tAccompanying Person: " + accompanyingPerson;
        }
    }
}
