using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_5
{

    public class Calculation
    {
        public static long ProductMas(int[] mas)
        {
            long product = 1; 
            bool found = false;

        
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] < 3)
                {
                    product = product * mas[i];
                    found = true;
                }
            } 

            if (!found)
            {
                return 0;
            }

            return product;
        } 
    } 
} 