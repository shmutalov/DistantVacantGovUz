using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DistantVacantGovUz
{
    public enum VACANCY_FILE_VERSION
    {
        VERSION_1, // xls/xlsx 1
        VERSION_2, // xls/xlsx 2
        VERSION_3, // xml 1
        UNKNOWN = -1
    }

    public static class CVacancyFileType
    {
        private static string errorMessage = "";

        public static string GetLastError()
        {
            return errorMessage;
        }

        public static List<CVacancyItem> OpenFile (string fileName)
        {
            BinaryReader reader;
            VACANCY_FILE_VERSION ver = VACANCY_FILE_VERSION.UNKNOWN;

            using (reader = new BinaryReader(new FileStream(fileName, FileMode.Open)))
            {
                try
                {
                    byte [] bytes = reader.ReadBytes(3);

                    //D0 CF 11 = xls version
                    if (bytes[0] == 0xD0 && bytes[1] == 0xCF && bytes[2] == 0x11)
                    {
                        reader.BaseStream.Seek(0, SeekOrigin.Begin);

                        NPOI.HSSF.UserModel.HSSFWorkbook xlWb = new NPOI.HSSF.UserModel.HSSFWorkbook(reader.BaseStream);
                        NPOI.HSSF.UserModel.HSSFSheet xlSheet = (NPOI.HSSF.UserModel.HSSFSheet)xlWb.GetSheetAt(0);

                        if (xlSheet.GetRow(0).GetCell(23) != null && xlSheet.GetRow(0).GetCell(23).StringCellValue == "PORTAL_VAC_ID")
                        {
                            ver = VACANCY_FILE_VERSION.VERSION_2;
                        }
                        else if (xlSheet.GetRow(0).GetCell(22) != null && xlSheet.GetRow(0).GetCell(22).StringCellValue == "EDU_ID")
                        {
                            ver = VACANCY_FILE_VERSION.VERSION_1;
                        }
                        else
                        {
                            ver = VACANCY_FILE_VERSION.UNKNOWN;
                        }
                    }
                    //EF BB BF = xml version
                    else if (bytes[0] == 0xD0 && bytes[1] == 0xCF && bytes[2] == 0x11)
                    {
                        ver = VACANCY_FILE_VERSION.VERSION_3;
                    }
                    // 50 4B 03 = xlsx version (unsupported for now by ExcelLibrary)
                    else if (bytes[0] == 0x50 && bytes[1] == 0x4B && bytes[2] == 0x03)
                    {
                        reader.BaseStream.Seek(0, SeekOrigin.Begin);

                        NPOI.XSSF.UserModel.XSSFWorkbook xlWb = new NPOI.XSSF.UserModel.XSSFWorkbook(reader.BaseStream);
                        NPOI.XSSF.UserModel.XSSFSheet xlSheet = (NPOI.XSSF.UserModel.XSSFSheet)xlWb.GetSheetAt(0);

                        if (xlSheet.GetRow(0).GetCell(23) != null && xlSheet.GetRow(0).GetCell(23).StringCellValue == "PORTAL_VAC_ID")
                        {
                            ver = VACANCY_FILE_VERSION.VERSION_2;
                        }
                        else if (xlSheet.GetRow(0).GetCell(22) != null && xlSheet.GetRow(0).GetCell(22).StringCellValue == "EDU_ID")
                        {
                            ver = VACANCY_FILE_VERSION.VERSION_1;
                        }
                        else
                        {
                            ver = VACANCY_FILE_VERSION.UNKNOWN;
                        }
                    }
                    else
                    {
                        errorMessage = "Unknown file version";
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    return null;
                }
            }

            switch (ver)
            {
                case VACANCY_FILE_VERSION.VERSION_1:
                    return OpenFileVer1(fileName);
                case VACANCY_FILE_VERSION.VERSION_2:
                    return OpenFileVer2(fileName);
                case VACANCY_FILE_VERSION.VERSION_3:
                    return OpenFileVer3(fileName);
                default:
                    errorMessage = "Unknown file version";
                    return null;
            }
        }

        public static bool SaveFile(string fileName, List<CVacancyItem> vacancies)
        {
            return false;
        }

        public static bool SaveFileAs(string fileName, List<CVacancyItem> vacancies, VACANCY_FILE_VERSION ver)
        {
            return false;
        }

        private static List<CVacancyItem> OpenFileVer1(string fileName)
        {
            NPOI.SS.UserModel.IWorkbook xlWb;
            NPOI.SS.UserModel.ISheet xlSheet;

            xlWb = NPOI.SS.UserModel.WorkbookFactory.Create(fileName);

            xlSheet = xlWb.GetSheetAt(0);
            
            List<CVacancyItem> ret = new List<CVacancyItem>();

            int i = 0;

            //while (!xlSheet.Cells[i, 0].IsEmpty)
            while (!(xlSheet.GetRow(i) == null))
            {
                if (i > 1)
                {
                    ret.Add(new CVacancyItem(
                                xlSheet.GetRow(i).GetCell(0).StringCellValue
                                , xlSheet.GetRow(i).GetCell(1).StringCellValue
                                , xlSheet.GetRow(i).GetCell(2).StringCellValue
                                , xlSheet.GetRow(i).GetCell(3).StringCellValue
                                , xlSheet.GetRow(i).GetCell(4).StringCellValue
                                , xlSheet.GetRow(i).GetCell(5).StringCellValue
                                , xlSheet.GetRow(i).GetCell(6).StringCellValue
                                , xlSheet.GetRow(i).GetCell(7).StringCellValue
                                , xlSheet.GetRow(i).GetCell(8).StringCellValue
                                , xlSheet.GetRow(i).GetCell(9).StringCellValue
                                , xlSheet.GetRow(i).GetCell(10).StringCellValue
                                , xlSheet.GetRow(i).GetCell(11).StringCellValue
                                , xlSheet.GetRow(i).GetCell(12).StringCellValue
                                , xlSheet.GetRow(i).GetCell(13).StringCellValue
                                , xlSheet.GetRow(i).GetCell(14).StringCellValue
                                , xlSheet.GetRow(i).GetCell(15).StringCellValue
                                , xlSheet.GetRow(i).GetCell(16).StringCellValue
                                , xlSheet.GetRow(i).GetCell(17).StringCellValue
                                , xlSheet.GetRow(i).GetCell(18).StringCellValue
                                , xlSheet.GetRow(i).GetCell(19).StringCellValue
                                , xlSheet.GetRow(i).GetCell(20).StringCellValue
                                , xlSheet.GetRow(i).GetCell(21).StringCellValue
                                , xlSheet.GetRow(i).GetCell(22).StringCellValue
                                , "0"
                            )
                        );
                }

                i++;
            }

            return ret;
        }

        private static List<CVacancyItem> OpenFileVer2(string fileName)
        {
            NPOI.SS.UserModel.IWorkbook xlWb;
            NPOI.SS.UserModel.ISheet xlSheet;

            xlWb = NPOI.SS.UserModel.WorkbookFactory.Create(fileName);

            xlSheet = xlWb.GetSheetAt(0);

            List<CVacancyItem> ret = new List<CVacancyItem>();

            int i = 0;

            //while (!xlSheet.Cells[i, 0].IsEmpty)
            while (!(xlSheet.GetRow(i) == null))
            {
                if (i > 1)
                {
                    ret.Add(new CVacancyItem(
                                xlSheet.GetRow(i).GetCell(0).StringCellValue
                                , xlSheet.GetRow(i).GetCell(1).StringCellValue
                                , xlSheet.GetRow(i).GetCell(2).StringCellValue
                                , xlSheet.GetRow(i).GetCell(3).StringCellValue
                                , xlSheet.GetRow(i).GetCell(4).StringCellValue
                                , xlSheet.GetRow(i).GetCell(5).StringCellValue
                                , xlSheet.GetRow(i).GetCell(6).StringCellValue
                                , xlSheet.GetRow(i).GetCell(7).StringCellValue
                                , xlSheet.GetRow(i).GetCell(8).StringCellValue
                                , xlSheet.GetRow(i).GetCell(9).StringCellValue
                                , xlSheet.GetRow(i).GetCell(10).StringCellValue
                                , xlSheet.GetRow(i).GetCell(11).StringCellValue
                                , xlSheet.GetRow(i).GetCell(12).StringCellValue
                                , xlSheet.GetRow(i).GetCell(13).StringCellValue
                                , xlSheet.GetRow(i).GetCell(14).StringCellValue
                                , xlSheet.GetRow(i).GetCell(15).StringCellValue
                                , xlSheet.GetRow(i).GetCell(16).StringCellValue
                                , xlSheet.GetRow(i).GetCell(17).StringCellValue
                                , xlSheet.GetRow(i).GetCell(18).StringCellValue
                                , xlSheet.GetRow(i).GetCell(19).StringCellValue
                                , xlSheet.GetRow(i).GetCell(20).StringCellValue
                                , xlSheet.GetRow(i).GetCell(21).StringCellValue
                                , xlSheet.GetRow(i).GetCell(22).StringCellValue
                                , xlSheet.GetRow(i).GetCell(23).StringCellValue
                            )
                        );
                }

                i++;
            }

            return ret;
        }

        private static List<CVacancyItem> OpenFileVer3(string fileName)
        {
            return null;
        }
    }
}
