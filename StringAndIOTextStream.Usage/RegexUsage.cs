using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;

namespace StringAndIOTextStream.Usage
{
    public class RegexUsage
    {
        /// <summary>
        /// 正则表达式 用法测试
        /// </summary>
        public void TestUsage()
        {
            ////====================================验证身份证号码==================================================
            //Regex rege = new Regex(@"(^[0-9]{18}$)|(^[0-9]{17}[xX]$)");
            //Console.WriteLine( rege.IsMatch("342423199106214033"));
            ////=======================================判断邮箱地址===================================================
            //Regex rege2 = new Regex(@"^[0-9a-zA-Z]+@[0-9a-zA-Z]+(\.[a-zA-Z]+)+$");
            //Console.WriteLine(rege2.IsMatch("xutian0521@qq.cn.net"));

            //Regex rege3 = new Regex(@"[0-9a-zA-Z]+@[0-9a-zA-Z]+(\.[a-zA-Z]+)+");
            //Console.WriteLine("请输入一个带邮箱的字符串");
            //string input = File.ReadAllText(@"求种的邮箱字符串.txt", Encoding.Default);
            //MatchCollection matchcoll= rege3.Matches(input);
            //Console.WriteLine(matchcoll[1].Value+matchcoll[6].Value);
            //foreach(Match match in matchcoll )
            //{
            //    Console.WriteLine(match.Value);
            //}

            //Console.ReadKey();
            ////正则表达式 匹配规律过程，从指定字符串中第一个开始匹配，依次1-n进行匹配
            ////在从2和2-n匹配，一直匹配到(n-1)-n和n-n。
            //string s = "111xutian.。3131321。xut。11kkk。";
            //Regex regex4 = new Regex(@"[a-z]+。");
            //Console.WriteLine( regex4.Match(s));
            //Console.ReadKey();
            ////===============================贪婪模式，正则表达式会尽量找最多的那个能匹配的字符串。====================
            //string s2 = "1111。111。1 1111。1113。";
            //Regex reggex5 = new Regex(@".+。");
            //Console.WriteLine(reggex5.Match(s2));
            //Console.ReadKey();
            ////===================================终止贪婪模式，在限定符后加个“?”符号=================================
            //string s3 = "aaa1111。aa111。1a 1111。1113。";
            //Regex reggex6 = new Regex(@"[0-9]+?。");
            //Console.WriteLine(reggex6.Match(s3));
            //Console.ReadKey();

            ////================================判断邮箱地址并计算qq，网易163，126 出现的次数============================
            //Regex rege7 = new Regex(@"([0-9a-zA-Z]+)(@[0-9a-zA-Z]+)(\.[a-zA-Z]+)+");
            //string input2 = File.ReadAllText(@"求种的邮箱字符串.txt", Encoding.Default);
            //MatchCollection matchcoll2 = rege7.Matches(input);
            //Console.WriteLine(matchcoll[1].Value + matchcoll2[6].Value);
            //int const_qq = 0;
            //int const_163 = 0;
            //int const_126 = 0;
            //foreach (Match match in matchcoll2)
            //{
            //    if (match.Groups[2].Value == "@qq")
            //    {
            //        const_qq++;
            //    }
            //    else if (match.Groups[2].Value == "@163")
            //    {
            //        const_163++;
            //    }
            //    else if (match.Groups[2].Value == "@126")
            //    {
            //        const_126++;
            //    }
            //    Console.WriteLine(match.Value);
            //}
            //Console.WriteLine("qq:{0}次163:{1}次126:{2}次",const_qq,const_163,const_126);
            //Console.ReadKey();
            //================================从网上下载字符串然后提取邮箱==============================================
            WebClient wc = new WebClient();
            string url = @"http://tieba.baidu.com/p/1331855164";
            string ss = wc.DownloadString(url);
            Regex regex8 = new Regex(@"([0-9a-zA-Z]+)(@[0-9a-zA-Z]+)(\.[a-zA-Z]+)+");
            MatchCollection matchcollection = regex8.Matches(ss);
            Match[] array = new Match[matchcollection.Count];
            matchcollection.CopyTo(array, 0);//把集合复制给指定数组，这里只能用Match数组。
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadKey();


            ////=========================================Regex.Replace方法==================================================
            //string msg = "   我   爱 北京     天安门  ";
            //string str= Regex.Replace(msg, @"\s+", " ");
            //Console.WriteLine(str);
            //Console.ReadKey();
            //==============================从魅族官网下载下载官网首页 的所有图片============================================
            //<img src='http://storeimg.meizu.com/product/1372034751-53757.jpg ' alt='魅族MX2'/>
            Regex regex9 = new Regex("[iI][mM][gG] src=.+?(http://.+?\\.jpg)");
            WebClient wc2 = new WebClient();
            wc2.Encoding = Encoding.UTF8;
            string strurl = wc2.DownloadString("http://www.meizu.com/");
            MatchCollection matchcollection2 = regex9.Matches(strurl);
            foreach (Match item in matchcollection2)
            {
                string imgurl = item.Groups[1].Value;
                Console.WriteLine(imgurl);

                wc2.DownloadFile(item.Groups[1].Value, @"c:\meizu\" + Path.GetFileName(imgurl));
            }
            Console.ReadKey();



            //=======================提取字符串中的电话号码然后以133****8888的形式输出=====================
            //string input = " hahh浪费 18788891130 地方 13185904990 15434567890方法 ";
            //string pattern = "([0-9]{3})([0-9]{4})([0-9]{4})";
            //MatchCollection matches = Regex.Matches(input, pattern);
            //foreach(Match match in matches)
            //{
            //    Console.WriteLine(Regex.Replace(match.Value, pattern, "$1****$3"));
            //}

            //Console.ReadKey();
            //======================邮箱掩码（11@qq.com-**@qq.com,2222@qq.com-****@qq.com）================
            string input = "2285781142@126.com zhangfan@qq.com xutian@163.com xutian0521@qq.com 770297519@sina.com";
            string pattern = @"([0-9a-zA-Z]+)(@[0-9a-zA-Z]+)(\.[a-zA-Z]+)+";
            MatchCollection matches = Regex.Matches(input, pattern);

            string ch;
            foreach (Match match in matches)
            {
                ch = "*";
                for (int i = 1; i < match.Groups[1].Length; i++)
                {
                    ch = ch + "*";
                }

                Console.WriteLine(Regex.Replace(match.Value, pattern, ch + "$2$3"));
            }

            Console.ReadKey();
        }
    }
}
