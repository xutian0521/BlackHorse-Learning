using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Xml.Usage
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlUsageDemo xmlUsage = new XmlUsageDemo();

            //递归输出每个节点的值
            xmlUsage.Demo1();

            //xml 写入
            xmlUsage.Demo2();

            //获取某个指定标签的元素
            xmlUsage.Demo3();

            //解析订单xml_练习
            xmlUsage.Demo4();


        }

    }
}
