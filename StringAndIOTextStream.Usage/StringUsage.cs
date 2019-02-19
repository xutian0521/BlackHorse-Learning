using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringAndIOTextStream.Usage
{
    /// <summary>
    /// System.string 类的用法
    /// </summary>
    public class StringUsage
    {
        /// <summary>
        /// System.string 类的用法
        /// </summary>
        public void TestUsage()
        {
            string s = "i   爱you";
            //length ,指的是字符串的个数，不是字符串占用的字节，空格也是一个字符串
            Console.WriteLine(s.Length);
            //s1指向堆中的一个字符串，字符串为空
            string s1 = "";
            //s2 指针为空，是一个空指针，默认指向0x000000
            string s2 = null;
            Console.ReadKey();

            //ToCharArray方法是把字符串转换成char数组
            string zm = "abcdefg";
            char[] ch = zm.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                ch[i] = (char)(ch[i] + 1);
                Console.WriteLine((char)(ch[i] + 1));
            }
            Console.WriteLine(new string(ch));
            Console.ReadKey();

            //=====================用indexof方法加substring方法实现截取[]中字符串=====================================
            string msg = "我真的真的是[徐天天]哈哈哈哈。。。。！";
            int firstindex = msg.IndexOf("[");
            int lastindex = msg.IndexOf("]");
            string msg2 = msg.Substring(firstindex + 1, lastindex - firstindex - 1);
            Console.WriteLine(msg2);
            Console.ReadKey();
            //======================split分割字符串=============================================
            string teams = "公牛|小牛|快船|森林狼|开拓者|迈阿密热火|||NBANBANBA洛杉矶湖人NBA印第安纳步行者NBA尼克斯－休斯敦火箭";
            string[] teamname = teams.Split(new string[] { "|", "NBA", "-" }, StringSplitOptions.RemoveEmptyEntries);



            //========================静态方法join用指定字符连接一个字符串数组=================================================
            string fullteams = string.Join("★", teamname);
            Console.WriteLine(fullteams);
            Console.ReadKey();
            //=========================Trim方法 去掉字符串两边的空格==================================================
            string czbk = "               传智播客                 ";
            Console.WriteLine("==========" + czbk.Trim() + "==========");
            Console.ReadKey();
        }
    }
}
