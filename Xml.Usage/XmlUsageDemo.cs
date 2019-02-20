using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Xml.Usage
{
    /// <summary>
    /// xml用法演示类
    /// </summary>
    public class XmlUsageDemo
    {
        public void Demo1()
        {
            #region 读取xml文件  通过XDocument
            Console.WriteLine("--------------------递归输出每个节点的值-----------------------------");
            //1.加载Xml文件
            XDocument xDoc = XDocument.Load("readtest.xml");
            //循环遍历每个节点
            //1.获取根节点
            XElement xeRoot = xDoc.Root;
            //输出根节点的名称
            Console.WriteLine(xeRoot.Name + xeRoot.Value);
            Console.ReadKey();


            //递归遍历Xml中的每个节点
            DiGuiGetXml(xeRoot);

            Console.WriteLine("--------------------把xml文件中节点作为一个字符串输出-----------------------------");
            //把xml文件中节点作为一个字符串输出
            string xml = xDoc.ToString();
            Console.WriteLine(xml);
            Console.ReadKey();
            #endregion
        }
        public void Demo2()
        {

            #region  xml 写入
            Console.WriteLine("--------------------xml 写入-----------------------------");
            //1.创建一个xml对象
            XDocument xdoc2 = new XDocument();

            //2.为xdoc增加一个根节点
            XElement xeRoot2 = new XElement("Websites");

            //3.将根节点加到xdoc中
            xdoc2.Add(xeRoot2);

            //==========================创建第一个元素=================================
            //4.为根节点增加内容
            XElement xeBaidu = new XElement("Website");

            //5.为baidu，增加一个属性
            XAttribute attrUrl = new XAttribute("url", "http://www.baidu.com");

            //6.将百度元素下增加一个属性
            xeBaidu.Add(attrUrl);

            //7.将baidu加到根元素下
            xeRoot2.Add(xeBaidu);

            //===========================================================================
            //增加元素的快捷方法
            xeRoot2.SetElementValue("WebsiteCount", 100);
            //========================================================
            //增加属性的快捷方法
            XElement xeGoole = new XElement("Website");
            xeGoole.SetAttributeValue("url", "http://www.google.com");

            xeRoot2.Add(xeGoole);

            //继续为xeGoogle增加子标签
            xeGoole.SetElementValue("name", "谷歌");
            xeGoole.SetElementValue("age", "14");
            xeGoole.SetElementValue("boss", "写盖尔");

            //最后一步：
            //将xdoc写入到硬盘文件
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            xdoc2.Save(currentDir + @"\website.xml");
            Console.WriteLine("添加完毕");
            Console.ReadKey();

            #endregion
        }
        public void Demo3()
        {
            #region  获取某个指定标签的元素
            Console.WriteLine("--------------------获取某个指定标签的元素-----------------------------");
            XDocument xdoc3 = XDocument.Load(@"readtest.xml");
            XElement xeRoot3 = xdoc3.Root;
            //在根节点的直接子元素下搜索itcastJava
            Console.WriteLine(xeRoot3.Element("itcastJava").Value);

            //在根节点下后代元素（所有后代元素）中搜索
            foreach (XElement item in xeRoot3.Descendants("itcastJava"))
            {
                Console.WriteLine(item.Value);
            }
            Console.ReadKey();
            #endregion
        }
        public void Demo4()
        {
            #region 解析订单xml_练习

            Console.WriteLine("--------------------解析订单xml_练习-----------------------------");
            string exepath = Assembly.GetExecutingAssembly().Location;
            exepath = Path.Combine(Path.GetDirectoryName(exepath), "orders.xml");
            XDocument xmlDoc = XDocument.Load(exepath);
            XElement Rootelement = xmlDoc.Element("Order");
            XElement CustomeName = Rootelement.Element("CustomeName");
            XElement OrderNumber = Rootelement.Element("OrderNumber");
            IEnumerable<XElement> Items = Rootelement.Element("Items").Elements("OrderItem");
            //XElement OrderItem = Items.Element("OrderItem");
            //XAttribute xa1= OrderItem.Attribute("Name");
            //XAttribute xatt= OrderItem.FirstAttribute;
            Console.WriteLine("订单号：{0}\n姓名：{1}\n订单信息：", OrderNumber.Value, CustomeName.Value);

            foreach (XElement item in Items)
            {
                Console.WriteLine("          {0} {1}个", item.FirstAttribute.Value, item.LastAttribute.Value);

            }
            Console.ReadKey();
            #endregion
        }


        /// <summary>
        /// 递归遍历xml中的每个节点
        /// </summary>
        /// <param name="xeRoot"></param>
        private static void DiGuiGetXml(XElement xeRoot)
        {
            //1.遍历xeRoot下面的所有的子元素
            // xeRoot.Elements();
            //获取xeRoot元素下的所有直接子元素
            foreach (XElement ele in xeRoot.Elements())
            {
                Console.WriteLine(ele.Name);
                DiGuiGetXml(ele);
            }
        }
    }
}
