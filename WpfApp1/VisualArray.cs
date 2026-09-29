using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public static class VisualArray
    {
        public static DataTable ToDataTable(int[] mas)
        {
            DataTable table = new DataTable();

            // Добавляем колонку с индексом
            table.Columns.Add("Индекс", typeof(int));

            // Добавляем колонку со значением
            table.Columns.Add("Значение", typeof(int));

            // Заполняем таблицу данными
            for (int i = 0; i < mas.Length; i++)
            {
                table.Rows.Add(i, mas[i]);
            }

            return table;
        } 
    }
    }
