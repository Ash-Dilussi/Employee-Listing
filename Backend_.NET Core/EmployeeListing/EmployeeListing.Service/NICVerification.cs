using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeListing.Service
{
    public class NICVerification
    {
        public async Task<bool> validNic(String nicNumber)
        {
            if (nicNumber != null)
            {
                if (nicNumber.Length == 10)
                {
                    try
                    {

                        int dayDigits = int.Parse(nicNumber.Substring(2, 3));

                        if (dayDigits > 500 + 366)
                        {
                            return false;
                        }
                        else if (dayDigits > 366 && dayDigits < 500)
                        {
                            return false;
                        }
                        return true;


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error NIC", ex);

                    }
                }
                else if (nicNumber.Length == 12)
                {
                    try
                    {
                        string currentYear = DateTime.Now.Year.ToString();
                        int currY = int.Parse(currentYear);

                        int dayDigits = int.Parse(nicNumber.Substring(4, 3));
                        int years = int.Parse(nicNumber.Substring(0, 4));

                        if (dayDigits > 500 + 366 || 18  > (currY - years))
                        {
                            return false;
                        }
                        else if(dayDigits > 366 && dayDigits <500)
                        {
                            return false;
                        }
                        return true;


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error NIC", ex);

                    }
                }
                throw new ArgumentException("Invalid NIC lenght");

            }
            throw new ArgumentException("Null NIC number");
        }

    }
}
