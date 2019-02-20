using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace AspNetGeneralHandler
{
    /// <summary>
    /// UpImgTest 的摘要说明
    /// </summary>
    public class UpImgTest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpFileCollection files = context.Request.Files;
            int count= context.Request.Files.Count;
            //判断上传能让是否为空
            if(count>0)
            {
                //循环file中的每个元素
                for (int i = 0; i < count; i++)
                {
                    //判断上传的文件 是否 为 图片
                    //通过 判断文件的 类型
                    if (files[i].ContentType.Contains("image/"))
                    {
                        
                        //2.1获取图片文件流，并封装到 C# 的 Image对象中 方便操作
                        using (Image img = Image.FromStream(files[i].InputStream))
                        {
                            #region 2.为图片加水印
                            //2.2生成缩略图 对象
                            using (Image imgThumb = new Bitmap(200, 150))
                            {
                                //2.2.1生成 画家对象 在它在 缩略图上作画(imgThumb相当于纸)
                                Graphics g = Graphics.FromImage(imgThumb);
                                {
                                    //          原图，     要把原图缩略成多大  默认取全部 省略就取全部
                                    g.DrawImage(img, new Rectangle(0, 0, imgThumb.Height, imgThumb.Width));
                                    ////         原图 ， 要把原图缩略成多大                                   ，  取原图的哪个部分 来缩略                      ，单位（像素）
                                    //g.DrawImage(img, new Rectangle(0, 0, imgThumb.Width, imgThumb.Height), new RectangleF(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                                }
                                //获取上传原图的文件名 
                                string filename = System.IO.Path.GetFileName(files[i].FileName);
                                //加上缩略图标识
                                filename = "Thumb" + filename;
                                //获取物理路径
                                string phyPath = context.Request.MapPath("/updown/" + filename);
                                //保存
                                imgThumb.Save(phyPath);
                            }
                            #endregion
                            #region 3.为图片画水印
                            //3.为图片画水印
                            //3.1读取水印图片
                            using (Image imgWater = Image.FromFile(context.Server.MapPath("/images/applelogo.jpg")))
                            {
                                //创建画家对象 把用户传来的图片当纸 
                                using (Graphics g = Graphics.FromImage(img))
                                {
                                    //g.DrawString("广州.Net训练营", new Font("微软雅黑", 14), Brushes.Red, 0, 0);
                                    //将 水印图片 画到 上传的图上
                                    g.DrawImage(imgWater, 0, 0);
                                }
                                //获取上传原图的文件名 
                                string filename = System.IO.Path.GetFileName(files[i].FileName);
                                //加上缩略图标识
                                filename = "Water" + filename;
                                //获取物理路径
                                string phyPath = context.Request.MapPath("/updown/" + filename);
                                img.Save(phyPath);
                            } 
                            #endregion
                        }
                        #region 保存原图
                        //获取上传原图的文件名 
                        string name = System.IO.Path.GetFileName(files[i].FileName);
                        //获取物理路径
                        string path = context.Request.MapPath("/updown/" + name);
                        //保存
                        files[i].SaveAs(path);
                        
                        #endregion
                    }
                }
            }

                
            
        }

        void GetRandomName()
        { }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

}