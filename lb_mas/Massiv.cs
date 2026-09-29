using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb_mas
{
    public class Massiv
    {

        public static void InitMas(out int[] mas, int column, int randMax)
        {
            Random rnd = new Random();
            mas = new int[column];
            for (int i = 0; i < column; i++)
            {
                mas[i] = rnd.Next(randMax);
            }
        } 


        public static int SumMas(int[] mas)
        {
            int sum = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                sum = sum + mas[i];
            }
            return sum;
        } 


        public static void SaveMas(int[] mas, string fileName)
        {
            StreamWriter file = new StreamWriter(fileName);
            file.WriteLine(mas.Length);
            for (int i = 0; i < mas.Length; i++)
            {
                file.WriteLine(mas[i]);
            }
            file.Close();
        } 


        public static void OpenMas(out int[] mas, string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            int len = Convert.ToInt32(file.ReadLine());
            mas = new int[len];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = Convert.ToInt32(file.ReadLine());
            }
            file.Close();
        } 


        public static void ClearMas(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = 0;
            }
        } 
    } 
} 