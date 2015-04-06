using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DistantVacantGovUz
{
    public static class CVacancyUtil
    {
        /// <summary>
        /// Записать последовательность байтов в файл
        /// </summary>
        /// <param name="fileName">Полный путь к файлу</param>
        /// <param name="bytes">Массив с байтами</param>
        /// <returns>Возвратит <value>true</value> при успешном выполнении операции, в другом случае - <value>false</value></returns>
        public static bool SaveBytesToFile(string fileName, byte[] bytes)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);

                fs.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Копирование списка локальных вакансий из source в destination
        /// </summary>
        /// <param name="source">Список, который следует скопировать</param>
        /// <param name="destination">Список приемник</param>
        /// <returns>Возвратит список <value>destination</value> - результат копирования</returns>
        public static List<CVacancyItem> CopyVacancyItemList(List<CVacancyItem> source, List<CVacancyItem> destination)
        {
            if (source != null && destination != null)
            {
                destination.Clear();

                for (int i = 0; i < source.Count; i++ )
                {
                    destination.Add(CVacancyItem.Copy(source[i], new CVacancyItem()));
                }
            }

            return destination;
        }

        /// <summary>
        /// Перестановка, список X будет Y, а список Y будет X (swap)
        /// </summary>
        /// <param name="x">Первый список</param>
        /// <param name="y">Второй список</param>
        public static void Swap(ref List<CVacancyItem> x, ref List<CVacancyItem> y)
        {
            List<CVacancyItem> temp = x;
            x = y;
            y = temp;
        }
    }
}
