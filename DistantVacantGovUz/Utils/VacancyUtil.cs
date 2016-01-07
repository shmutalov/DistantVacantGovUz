using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DistantVacantGovUz.Models;

namespace DistantVacantGovUz.Utils
{
    public static class VacancyUtil
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
                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                return true;
            }
            catch (Exception)
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
        public static void CopyVacancyItemList(List<VacancyItem> source, List<VacancyItem> destination)
        {
            if (source == null || destination == null)
                return;

            destination.Clear();

            destination.AddRange(source.Select(vacancy => VacancyItem.Copy(vacancy, new VacancyItem())));
        }

        /// <summary>
        /// Перестановка, список X будет Y, а список Y будет X (swap)
        /// </summary>
        /// <param name="x">Первый список</param>
        /// <param name="y">Второй список</param>
        public static void Swap(ref List<VacancyItem> x, ref List<VacancyItem> y)
        {
            var temp = x;
            x = y;
            y = temp;
        }

        private class VacancyItemComparer : IComparer<VacancyItem>
        {
            public int Compare(VacancyItem x, VacancyItem y)
            {
                int xSeqNum;
                int ySeqNum;

                int.TryParse(x.SequenceNumber, out xSeqNum);
                int.TryParse(y.SequenceNumber, out ySeqNum);

                return xSeqNum.CompareTo(ySeqNum);
            }
        }

        public static void SortBySeqNum(List<VacancyItem> vacancyList)
        {
            vacancyList.Sort(new VacancyItemComparer());
        }
    }
}
