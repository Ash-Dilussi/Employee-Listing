using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeListing.Service
{
    public class DatafromId
    {
        private readonly int[] monthadd = {0,31,60,91,121,152,182,231,244,274,305,335,366};
        
        public DateOnly DOB(String nicNumber)
        {
            if (nicNumber.Length == 12)
            {

                    int yearDigits = int.Parse(nicNumber.Substring(0, 4));
                    int dayDigits = int.Parse(nicNumber.Substring(4, 3));   

                    if (dayDigits > 500) { dayDigits -= 500;  }

                    int i ;
                    for( i=0 ; i< monthadd.Length; i++)
                    {
                        if (dayDigits <= monthadd[i])
                        {
                            break;
                        }
                    }

                    int month = i;

                    int date = dayDigits - monthadd[i-1];

                    DateOnly birthday = new DateOnly(yearDigits, month,date);
                    return birthday;
                    
                               
                

            }

            else if (nicNumber.Length == 10)
            {
                

                    int yearDigits = 1900 + int.Parse(nicNumber.Substring(0, 2));
                    int dayDigits = int.Parse(nicNumber.Substring(2, 3));

                    if (dayDigits > 500) { dayDigits -= 500; }

                    int i;
                    for (i = 0; i < monthadd.Length; i++)
                    {
                        if (dayDigits <= monthadd[i])
                        {
                            break;
                        }
                    }

                    int month = i ;
                    

                    int date = dayDigits - monthadd[i - 1];

                    DateOnly birthday = new DateOnly(yearDigits, month, date);
                    return birthday;


            }

            throw new ArgumentException("Invalid NIC number Length");
        }


        public char genderType(String nicNumber)
        {
            char gender;
            if(nicNumber.Length == 10 )
            {
               
                    int dayDigits = int.Parse(nicNumber.Substring(2, 3));
                    
                    if (dayDigits > 500)
                    {
                        gender = 'F';
                    }
                else { gender = 'M'; }
                    


                    return gender;


              
                
            }
            if (nicNumber.Length == 12)
            {
                
                    int dayDigits = int.Parse(nicNumber.Substring(4, 3));

                if (dayDigits > 500)
                {
                    gender = 'F';
                }
                else
                {
                    gender = 'M';
                }

                    return gender;
              

            }

            throw new Exception("UnIdentified Gender");


        }

    }
}
