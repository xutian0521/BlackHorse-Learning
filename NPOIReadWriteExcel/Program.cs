using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Windows.Forms;

namespace NPOIReadWriteExcel
{
    class Program
    {
        /*NPOI读取_写入Excel*/
        static void Main(string[] args)
        {
            //readExcel("ReadExcel.xls");
            writeExcel("my.xls");
            Console.ReadKey();

        }
        public static void readExcel(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                //1.读取Excel到FileStream
                using (Workbook wk = new HSSFWorkbook(fs))
                {
                    //循环获取工作表的个数
                    //wk.NumberOfSheets获取当前“工作薄”中的工作表的个数
                    for (int i = 0; i < wk.NumberOfSheets; i++)
                    {
                        //循环获取每一个工作表
                        using (Sheet sheet = wk.GetSheetAt(i))
                        {
                            //每个工作表用一条字符作为区分
                            Console.WriteLine("========================={0}======================", sheet.SheetName);
                            //循环获取当前“工作表”中的每一行。
                            //sheet.LastRowNum【获取最后一行的索引】
                            for (int r = 0; r <= sheet.LastRowNum; r++)
                            {
                                //获取每一行
                                Row row = sheet.GetRow(r);
                                //获取行中的单元格
                                //row.LastCellNum获取最后一个单元格的索引
                                for (int c = 0; c < row.LastCellNum; c++)
                                {
                                    //获取每行中的每个单元格。
                                    Cell cell = row.GetCell(c);
                                    Console.Write(cell.ToString() + "\t");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                }

            }
        }
        public static void writeExcel(string path)
        {
            //1.创建一个新的Workbook
            using(Workbook wk=new HSSFWorkbook())
            {
                //2.创建一个工作表Sheet
                using (Sheet sheet = wk.CreateSheet("工作表1"))
                {
                    //3.创建行
                    //创建第一行（索引是0，所以是第一行）
                    Row row1 = sheet.CreateRow(0);
                    //为row1中创建一些cell
                    for (int i = 0; i < 10; i++)
                    {
                        row1.CreateCell(i).SetCellValue("单元格"+i);
                    }
                    //再创建一个行，如果这里再把索引写为0，则会将上一行覆盖掉。
                    Row row2 = sheet.CreateRow(1);
                    row2.CreateCell(0).SetCellValue("单1");
                    row2.CreateCell(1).SetCellValue("单2");

                    //创建一个文件流
                    using(FileStream fs=File.OpenWrite(path))
                    {
                        wk.Write(fs);
                        MessageBox.Show("Excel已经写入成功！");
                    }

                }
            }
        }

    }
}
