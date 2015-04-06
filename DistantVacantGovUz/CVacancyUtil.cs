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
    }
}
