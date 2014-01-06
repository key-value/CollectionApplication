using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.Net;
using System.Collections;
using System.IO.Compression;
using System.Runtime.InteropServices;
using ThoughtWorks.QRCode.Codec;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;

/// <summary>
///公用方法
/// </summary>
public class db : System.Web.UI.Page
{
    public db()
    {
        //<appSettings>
        //<add key="ConnectionString" value="data source=localhost;initial catalog=zfwData;uid=sa;pwd=;integrated security=true"/>
        //</appSettings>
    }



    /// <summary>
    /// 创建目录
    /// </summary>
    /// <param name="dir"></param>
    public static void CreateDir(string dir)
    {
        if (dir.Length == 0) return;
        if (!Directory.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir))
            Directory.CreateDirectory(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir);
    }

    /// <summary>
    /// 删除目录
    /// </summary>
    /// <param name="dir"></param>
    public static void DeleteDir(string dir)
    {
        if (dir.Length == 0) return;
        if (Directory.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir))
            Directory.Delete(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir);
    }

    /// <summary>
    /// 删除文件
    /// </summary>
    /// <param name="file"></param>
    public static void DeleteFile(string file)
    {
        if (File.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + file))//5%1%a%s%p%x
            File.Delete(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + file);
    }

    public static void CreateFile(string dir, string pagestr)
    {
        dir = dir.Replace("/", "\\");
        if (dir.IndexOf("\\") > -1)
            CreateDir(dir.Substring(0, dir.LastIndexOf("\\")));
        System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir, false, System.Text.Encoding.GetEncoding("UTF-8"));
        sw.Write(pagestr);
        sw.Close();

    }

    public static void MoveFile(string dir1, string dir2)
    {
        dir1 = dir1.Replace("/", "\\");
        dir2 = dir2.Replace("/", "\\");
        if (File.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir1))
            File.Move(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir1, System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir2);
    }

    /// <summary>
    /// 根据时间得到目录名
    /// </summary>
    /// <returns></returns>
    public static string GetDateDir()
    {
        return DateTime.Now.ToString("yyyyMMdd");
    }

    /// <summary>
    /// 根据时间得到文件名
    /// </summary>
    /// <returns></returns>
    public static string GetDateFile()
    {
        return DateTime.Now.ToString("HHmmssff");
    }

    /// <summary>
    /// 验证字符串是否为数值
    /// </summary>
    public static bool IsNumeric(string value)
    {
        return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
    }

    public static bool IsTel(string value)
    {
        return Regex.IsMatch(value, @" ^(([0\+]\d{2,3}-)?(0\d{2,3})-)?(\d{7,8})(-(\d{3,}))?$");
    }
    /// <summary>
    /// 验证文件格式
    /// </summary>
    /// <param name="filetype"></param>
    /// <param name="currentType"></param>
    /// <returns></returns>
    public static bool CheckFileIsImage(string[] filetype, string currentType)
    {
        return Array.IndexOf(filetype, currentType) == -1;
    }

    /// <summary>
    /// 验证字符串是否为整数
    /// </summary>
    public static bool IsInt(string value)
    {
        return Regex.IsMatch(value, @"^[+-]?\d*$");
    }

    public static HttpCookie GetCookie(string name)
    {
        return HttpContext.Current.Request.Cookies[name];
    }
    /// <summary>
    /// 手机号码验证
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsPhone(string value)
    {
        return Regex.IsMatch(value, @"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|4|5|6|7|8|9])\d{8}$");
    }
    /// <summary>
    /// 移动手机号码验证
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsChinaMobileNum(string value)
    {
        return Regex.IsMatch(value, @"^(13[4|5|6|7|8|9]|14[7]|15[0|1|2|7|8|9]|18[2|3|4|7|8])\d{8}$");
    }
    /// <summary>
    /// 电信号码验证
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsChinaTelecomNum(string value)
    {
        return Regex.IsMatch(value, @"^(13[3]|15[3]|18[0|1|9])\d{8}$");
    }
    /// <summary>
    /// 联通号码验证
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsChinaUnicomNum(string value)
    {
        return Regex.IsMatch(value, @"^(13[0|1|2]|14[5]|15[5|6]|18[5|6])\d{8}$");
    }

    /// <summary>
    /// 登录名验证
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsLoginName(string value)
    {
        return Regex.IsMatch(value, @"^[a-zA-Z]{1}([a-zA-Z0-9]|[_]){5,19}$");
    }
    /// <summary>
    /// 真实名字验证
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsReadyName(string value)
    {
        return Regex.IsMatch(value, @"^[u4e00-u9fa5],{0,}$");
    }
    /// <summary>       
    /// 是否为日期型字符串
    /// </summary>
    /// <returns></returns>      
    public static bool IsDate(string StrSource)
    {
        DateTime date = new DateTime();
        bool flag = DateTime.TryParse(StrSource, out date);
        return flag;
    }

    /// <summary>
    /// 验证字符串是否为无符号数
    /// </summary>
    public static bool IsUnsign(string value)
    {
        return Regex.IsMatch(value, @"^\d*[.]?\d*$");
    }
    /// <summary>
    /// 验证字符串是否为数字
    /// </summary>
    /// <param name="length">如果对该字符串验证有长度显示，则加上该字符串的长度，否则填0</param>
    public static bool IsAmount(string value, int length)
    {
        string regex = @"^\d" + (length > 0 ? ("{" + length.ToString() + "}") : "*") + "$";
        return Regex.IsMatch(value, regex);
    }
    /// <summary>
    /// 验证字符串是否为有效的Email地址  /^\s*[.A-Za-z0-9_-]{5,30}\s*$/
    /// </summary>
    public static bool IsEmail(string value)
    {
        return Regex.IsMatch(value, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
    }

    public static bool IsCheckNickName(string value)
    {
        return Regex.IsMatch(value, @"^\s*[.A-Za-z0-9_-]{5,30}\s*$");
    }

    /// <summary>
    /// 检测链接
    /// </summary>
    /// <param name="urlobj"></param>
    /// <returns></returns>
    public static string AddHttp(string urlobj)
    {
        if (Estimate(urlobj, "http://"))
            return urlobj;
        else
            return "http://" + urlobj;
    }


    /// <summary>
    /// 截获长度
    /// </summary>
    /// <param name="sValue">值</param>
    /// <param name="sLength">长度</param>
    /// <returns>sValue</returns>
    public static string sItemLength(string sValue, int sLength)
    {
        if (sValue.Length > sLength)
        {
            return sValue.Substring(0, sLength);
        }
        else
        {
            return sValue;
        }
    }
    public static string cutLength(string sValue, int sLength)
    {
        Encoding encode = Encoding.GetEncoding("gb2312");
        byte[] byteArr = encode.GetBytes(sValue);
        if (byteArr.Length <= sLength) return sValue;

        int m = 0, n = 0;
        foreach (byte b in byteArr)
        {
            if (n >= sLength) break;
            if (b > 127) m++; //重要一步：对前p个字节中的值大于127的字符进行统计
            n++;
        }
        if (m % 2 != 0) n = sLength + 1; //如果非偶：则说明末尾为双字节字符，截取位数加1

        return encode.GetString(byteArr, 0, n);
    }

    #region 图片处理
    /// <summary>
    /// 生成等比缩略图
    /// </summary>
    /// <param name="originalImagePath">源图路径（物理路径）</param>
    /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>   
    public static void ImgBrev(string originalImagePath, string thumbnailPath, int width, int height)
    {
        #region 生成等比缩略图
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);
        int towidth = width;
        int toheight = height;
        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;
        string mode = "W";//这以后可以更换//////////重要
        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形）                
                break;
            case "W"://指定宽，高按比例                    
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）                
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //新建一个画板
        Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充
        g.Clear(Color.Transparent);

        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
            new Rectangle(x, y, ow, oh),
            GraphicsUnit.Pixel);

        try
        {
            //以jpg格式保存缩略图
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
        #endregion
    }

    /// <summary>
    /// 图片等比缩放
    /// </summary>
    /// <param name="fromFile">原图Stream对象</param>
    /// <param name="savePath">缩略图存放地址</param>
    /// <param name="targetWidth">指定的最大宽度</param>
    /// <param name="targetHeight">指定的最大高度</param>
    /// <param name="watermarkText">水印文字(为""表示不使用水印)</param>
    /// <param name="watermarkImage">水印图片路径(为""表示不使用水印)</param>
    public static void ZoomAuto(String fromFile, string savePath, System.Double targetWidth, System.Double targetHeight)
    {

        //原始图片（获取原始图片创建对象，并使用流中嵌入的颜色管理信息）
        System.Drawing.Image initImage = new System.Drawing.Bitmap(fromFile);

        //原图宽高均小于模版，不作处理，直接保存
        if (initImage.Width <= targetWidth && initImage.Height <= targetHeight)
        {
            int startWidth = 0, startHeight = 0;
            if (initImage.Width < targetWidth)
            {
                startWidth = (int)((targetWidth - initImage.Width) / 2);
            }

            if (initImage.Height < targetHeight)
            {
                startHeight = (int)((targetHeight - initImage.Height) / 2);
            }

            Bitmap bmp = new Bitmap((int)targetWidth, (int)targetHeight);
            Graphics gr = Graphics.FromImage(bmp);

            gr.FillRectangle(new SolidBrush(Color.White), 0, 0, (int)targetWidth, (int)targetHeight);

            gr.DrawImage(initImage, startWidth, startHeight, initImage.Width, initImage.Height);

            bmp.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp.Dispose();
            //释放资源
            gr.Dispose();
            initImage.Dispose();
        }
        else
        {
            //缩略图宽、高计算
            double newWidth = initImage.Width;
            double newHeight = initImage.Height;

            //宽大于高或宽等于高（横图或正方）
            if (initImage.Width > initImage.Height || initImage.Width == initImage.Height)
            {
                //如果宽大于模版
                if (initImage.Width > targetWidth)
                {
                    //宽按模版，高按比例缩放
                    newWidth = targetWidth;
                    newHeight = initImage.Height * (targetWidth / initImage.Width);
                }
            }
            //高大于宽（竖图）
            else
            {
                //如果高大于模版
                if (initImage.Height > targetHeight)
                {
                    //高按模版，宽按比例缩放
                    newHeight = targetHeight;
                    newWidth = initImage.Width * (targetHeight / initImage.Height);
                }
            }

            //生成新图
            //新建一个bmp图片
            System.Drawing.Image newImage = new System.Drawing.Bitmap((int)newWidth, (int)newHeight);
            //新建一个画板
            System.Drawing.Graphics newG = System.Drawing.Graphics.FromImage(newImage);

            //设置质量
            newG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            newG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //置背景色
            newG.Clear(Color.White);
            //画图
            int startWidth = 0, startHeight = 0;
            if (newImage.Width < targetWidth)
            {
                startWidth = (int)((targetWidth - newImage.Width) / 2);
            }

            if (newImage.Height < targetHeight)
            {
                startHeight = (int)((targetHeight - newImage.Height) / 2);
            }

            Bitmap bmp = new Bitmap((int)targetWidth, (int)targetHeight);
            Graphics gr = Graphics.FromImage(bmp);
            gr.FillRectangle(new SolidBrush(Color.White), 0, 0, (int)targetWidth, (int)targetHeight);
            newG.DrawImage(initImage, new System.Drawing.Rectangle(0, 0, newImage.Width, newImage.Height), new System.Drawing.Rectangle(0, 0, initImage.Width, initImage.Height), System.Drawing.GraphicsUnit.Pixel);

            gr.DrawImage(newImage, startWidth, startHeight);
            bmp.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);


            //释放资源
            newG.Dispose();
            newImage.Dispose();
            initImage.Dispose();
        }
    }


    /// <summary>
    /// 非等比图形
    /// </summary>
    /// <param name="originalImagePath">源图路径（物理路径）</param>
    /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>   
    public static void ImgBrev(string originalImagePath, string thumbnailPath, int width, int height, string mode)
    {
        #region 非等比图形
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;
        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;
        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形）           
                toheight = originalImage.Height * width / originalImage.Width;
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "W"://指定宽，高按比例                    
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）                
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(width, height);

        //新建一个画板
        Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充
        g.Clear(Color.White);

        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new Rectangle(0, 0, width, height),
            new Rectangle(x, y, ow, oh),
            GraphicsUnit.Pixel);

        try
        {
            //以jpg格式保存缩略图
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
        #endregion
    }

    public static void ImgLowBrev(string originalImagePath, string thumbnailPath, int width, int height, string mode)
    {
        #region 非等比图形
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;
        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;
        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形）           
                toheight = originalImage.Height * width / originalImage.Width;
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "W"://指定宽，高按比例                    
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）                
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(width, height);

        //新建一个画板
        Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;

        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

        //清空画布并以透明背景色填充
        g.Clear(Color.White);

        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new Rectangle(0, 0, width, height),
            new Rectangle(x, y, ow, oh),
            GraphicsUnit.Pixel);

        try
        {
            //以jpg格式保存缩略图
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
        #endregion
    }
    #endregion


    /// <summary>
    /// 去除Html标记
    /// </summary>
    /// <param name="Htmlstring">Html</param>
    /// <returns></returns>
    public static string ToHTML(string Htmlstring) //去除HTML标记
    {
        #region 去除Html标记
        if (!string.IsNullOrWhiteSpace(Htmlstring))
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            ////删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"(?is)</?\b(?!br|img|sup|embed|font)\b[^>]*?>", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
        }
        return Htmlstring;
        #endregion
    }

    /// <summary>
    /// 把汉字转换成拼音(全拼)
    /// </summary>
    /// <param name="hzString">汉字字符串</param>
    /// <returns>转换后的拼音(全拼)字符串</returns>
    public static string Convert(string hzString)
    {
        #region
        int[] pyValue = new int[]
				{
					-20319,-20317,-20304,-20295,-20292,-20283,-20265,-20257,-20242,-20230,-20051,-20036,
					-20032,-20026,-20002,-19990,-19986,-19982,-19976,-19805,-19784,-19775,-19774,-19763,
					-19756,-19751,-19746,-19741,-19739,-19728,-19725,-19715,-19540,-19531,-19525,-19515,
					-19500,-19484,-19479,-19467,-19289,-19288,-19281,-19275,-19270,-19263,-19261,-19249,
					-19243,-19242,-19238,-19235,-19227,-19224,-19218,-19212,-19038,-19023,-19018,-19006,
					-19003,-18996,-18977,-18961,-18952,-18783,-18774,-18773,-18763,-18756,-18741,-18735,
					-18731,-18722,-18710,-18697,-18696,-18526,-18518,-18501,-18490,-18478,-18463,-18448,
					-18447,-18446,-18239,-18237,-18231,-18220,-18211,-18201,-18184,-18183, -18181,-18012,
					-17997,-17988,-17970,-17964,-17961,-17950,-17947,-17931,-17928,-17922,-17759,-17752,
					-17733,-17730,-17721,-17703,-17701,-17697,-17692,-17683,-17676,-17496,-17487,-17482,
					-17468,-17454,-17433,-17427,-17417,-17202,-17185,-16983,-16970,-16942,-16915,-16733,
					-16708,-16706,-16689,-16664,-16657,-16647,-16474,-16470,-16465,-16459,-16452,-16448,
					-16433,-16429,-16427,-16423,-16419,-16412,-16407,-16403,-16401,-16393,-16220,-16216,
					-16212,-16205,-16202,-16187,-16180,-16171,-16169,-16158,-16155,-15959,-15958,-15944,
					-15933,-15920,-15915,-15903,-15889,-15878,-15707,-15701,-15681,-15667,-15661,-15659,
					-15652,-15640,-15631,-15625,-15454,-15448,-15436,-15435,-15419,-15416,-15408,-15394,
					-15385,-15377,-15375,-15369,-15363,-15362,-15183,-15180,-15165,-15158,-15153,-15150,
					-15149,-15144,-15143,-15141,-15140,-15139,-15128,-15121,-15119,-15117,-15110,-15109,
					-14941,-14937,-14933,-14930,-14929,-14928,-14926,-14922,-14921,-14914,-14908,-14902,
					-14894,-14889,-14882,-14873,-14871,-14857,-14678,-14674,-14670,-14668,-14663,-14654,
					-14645,-14630,-14594,-14429,-14407,-14399,-14384,-14379,-14368,-14355,-14353,-14345,
					-14170,-14159,-14151,-14149,-14145,-14140,-14137,-14135,-14125,-14123,-14122,-14112,
					-14109,-14099,-14097,-14094,-14092,-14090,-14087,-14083,-13917,-13914,-13910,-13907,
					-13906,-13905,-13896,-13894,-13878,-13870,-13859,-13847,-13831,-13658,-13611,-13601,
					-13406,-13404,-13400,-13398,-13395,-13391,-13387,-13383,-13367,-13359,-13356,-13343,
					-13340,-13329,-13326,-13318,-13147,-13138,-13120,-13107,-13096,-13095,-13091,-13076,
					-13068,-13063,-13060,-12888,-12875,-12871,-12860,-12858,-12852,-12849,-12838,-12831,
					-12829,-12812,-12802,-12607,-12597,-12594,-12585,-12556,-12359,-12346,-12320,-12300,
					-12120,-12099,-12089,-12074,-12067,-12058,-12039,-11867,-11861,-11847,-11831,-11798,
					-11781,-11604,-11589,-11536,-11358,-11340,-11339,-11324,-11303,-11097,-11077,-11067,
					-11055,-11052,-11045,-11041,-11038,-11024,-11020,-11019,-11018,-11014,-10838,-10832,
					-10815,-10800,-10790,-10780,-10764,-10587,-10544,-10533,-10519,-10331,-10329,-10328,
					-10322,-10315,-10309,-10307,-10296,-10281,-10274,-10270,-10262,-10260,-10256,-10254
				};

        string[] pyName = new string[]
				{
					"a","ai","an","ang","ao","ba","bai","ban","bang","bao","bei","ben",
					"beng","bi","bian","biao","bie","bin","bing","bo","bu","ba","cai","can",
					"cang","cao","ce","ceng","cha","chai","chan","chang","chao","che","chen","cheng",
					"chi","chong","chou","chu","chuai","chuan","chuang","chui","chun","chuo","ci","cong",
					"cou","cu","cuan","cui","cun","cuo","da","dai","dan","dang","dao","de",
					"deng","di","dian","diao","die","ding","diu","dong","dou","du","duan","dui",
					"dun","duo","e","en","er","fa","fan","fang","fei","fen","feng","fo",
					"fou","fu","ga","gai","gan","gang","gao","ge","gei","gen","geng","gong",
					"gou","gu","gua","guai","guan","guang","gui","gun","guo","ha","hai","han",
					"hang","hao","he","hei","hen","heng","hong","hou","hu","hua","huai","huan",
					"huang","hui","hun","huo","ji","jia","jian","jiang","jiao","jie","jin","jing",
					"jiong","jiu","ju","juan","jue","jun","ka","kai","kan","kang","kao","ke",
					"ken","keng","kong","kou","ku","kua","kuai","kuan","kuang","kui","kun","kuo",
					"la","lai","lan","lang","lao","le","lei","leng","li","lia","lian","liang",
					"liao","lie","lin","ling","liu","long","lou","lu","lv","luan","lue","lun",
					"luo","ma","mai","man","mang","mao","me","mei","men","meng","mi","mian",
					"miao","mie","min","ming","miu","mo","mou","mu","na","nai","nan","nang",
					"nao","ne","nei","nen","neng","ni","nian","niang","niao","nie","nin","ning",
					"niu","nong","nu","nv","nuan","nue","nuo","o","ou","pa","pai","pan",
					"pang","pao","pei","pen","peng","pi","pian","piao","pie","pin","ping","po",
					"pu","qi","qia","qian","qiang","qiao","qie","qin","qing","qiong","qiu","qu",
					"quan","que","qun","ran","rang","rao","re","ren","reng","ri","rong","rou",
					"ru","ruan","rui","run","ruo","sa","sai","san","sang","sao","se","sen",
					"seng","sha","shai","shan","shang","shao","she","shen","sheng","shi","shou","shu",
					"shua","shuai","shuan","shuang","shui","shun","shuo","si","song","sou","su","suan",
					"sui","sun","suo","ta","tai","tan","tang","tao","te","teng","ti","tian",
					"tiao","tie","ting","tong","tou","tu","tuan","tui","tun","tuo","wa","wai",
					"wan","wang","wei","wen","weng","wo","wu","xi","xia","xian","xiang","xiao",
					"xie","xin","xing","xiong","xiu","xu","xuan","xue","xun","ya","yan","yang",
					"yao","ye","yi","yin","ying","yo","yong","you","yu","yuan","yue","yun",
					"za", "zai","zan","zang","zao","ze","zei","zen","zeng","zha","zhai","zhan",
					"zhang","zhao","zhe","zhen","zheng","zhi","zhong","zhou","zhu","zhua","zhuai","zhuan",
					"zhuang","zhui","zhun","zhuo","zi","zong","zou","zu","zuan","zui","zun","zuo"

					#region
//		"A","Ai","An","Ang","Ao","Ba","Bai","Ban","Bang","Bao","Bei","Ben",
//		"Beng","Bi","Bian","Biao","Bie","Bin","Bing","Bo","Bu","Ba","Cai","Can",
//		"Cang","Cao","Ce","Ceng","Cha","Chai","Chan","Chang","Chao","Che","Chen","Cheng",
//		"Chi","Chong","Chou","Chu","Chuai","Chuan","Chuang","Chui","Chun","Chuo","Ci","Cong",
//		"Cou","Cu","Cuan","Cui","Cun","Cuo","Da","Dai","Dan","Dang","Dao","De",
//		"Deng","Di","Dian","Diao","Die","Ding","Diu","Dong","Dou","Du","Duan","Dui",
//		"Dun","Duo","E","En","Er","Fa","Fan","Fang","Fei","Fen","Feng","Fo",
//		"Fou","Fu","Ga","Gai","Gan","Gang","Gao","Ge","Gei","Gen","Geng","Gong",
//		"Gou","Gu","Gua","Guai","Guan","Guang","Gui","Gun","Guo","Ha","Hai","Han",
//		"Hang","Hao","He","Hei","Hen","Heng","Hong","Hou","Hu","Hua","Huai","Huan",
//		"Huang","Hui","Hun","Huo","Ji","Jia","Jian","Jiang","Jiao","Jie","Jin","Jing",
//		"Jiong","Jiu","Ju","Juan","Jue","Jun","Ka","Kai","Kan","Kang","Kao","Ke",
//		"Ken","Keng","Kong","Kou","Ku","Kua","Kuai","Kuan","Kuang","Kui","Kun","Kuo",
//		"La","Lai","Lan","Lang","Lao","Le","Lei","Leng","Li","Lia","Lian","Liang",
//		"Liao","Lie","Lin","Ling","Liu","Long","Lou","Lu","Lv","Luan","Lue","Lun",
//		"Luo","Ma","Mai","Man","Mang","Mao","Me","Mei","Men","Meng","Mi","Mian",
//		"Miao","Mie","Min","Ming","Miu","Mo","Mou","Mu","Na","Nai","Nan","Nang",
//		"Nao","Ne","Nei","Nen","Neng","Ni","Nian","Niang","Niao","Nie","Nin","Ning",
//		"Niu","Nong","Nu","Nv","Nuan","Nue","Nuo","O","Ou","Pa","Pai","Pan",
//		"Pang","Pao","Pei","Pen","Peng","Pi","Pian","Piao","Pie","Pin","Ping","Po",
//		"Pu","Qi","Qia","Qian","Qiang","Qiao","Qie","Qin","Qing","Qiong","Qiu","Qu",
//		"Quan","Que","Qun","Ran","Rang","Rao","Re","Ren","Reng","Ri","Rong","Rou",
//		"Ru","Ruan","Rui","Run","Ruo","Sa","Sai","San","Sang","Sao","Se","Sen",
//		"Seng","Sha","Shai","Shan","Shang","Shao","She","Shen","Sheng","Shi","Shou","Shu",
//		"Shua","Shuai","Shuan","Shuang","Shui","Shun","Shuo","Si","Song","Sou","Su","Suan",
//		"Sui","Sun","Suo","Ta","Tai","Tan","Tang","Tao","Te","Teng","Ti","Tian",
//		"Tiao","Tie","Ting","Tong","Tou","Tu","Tuan","Tui","Tun","Tuo","Wa","Wai",
//		"Wan","Wang","Wei","Wen","Weng","Wo","Wu","Xi","Xia","Xian","Xiang","Xiao",
//		"Xie","Xin","Xing","Xiong","Xiu","Xu","Xuan","Xue","Xun","Ya","Yan","Yang",
//		"Yao","Ye","Yi","Yin","Ying","Yo","Yong","You","Yu","Yuan","Yue","Yun",
//		"Za", "Zai","Zan","Zang","Zao","Ze","Zei","Zen","Zeng","Zha","Zhai","Zhan",
//		"Zhang","Zhao","Zhe","Zhen","Zheng","Zhi","Zhong","Zhou","Zhu","Zhua","Zhuai","Zhuan",
//		"Zhuang","Zhui","Zhun","Zhuo","Zi","Zong","Zou","Zu","Zuan","Zui","Zun","Zuo"
           #endregion
				};
        #endregion

        #region 匹配中文字符
        // 匹配中文字符
        Regex regex = new Regex("^[\u4e00-\u9fa5]$");
        byte[] array = new byte[2];
        string pyString = "";
        int chrAsc = 0;
        int i1 = 0;
        int i2 = 0;
        char[] noWChar = hzString.ToCharArray();

        for (int j = 0; j < noWChar.Length; j++)
        {
            // 中文字符
            if (regex.IsMatch(noWChar[j].ToString()))
            {
                array = System.Text.Encoding.Default.GetBytes(noWChar[j].ToString());
                i1 = (short)(array[0]);
                i2 = (short)(array[1]);
                chrAsc = i1 * 256 + i2 - 65536;
                if (chrAsc > 0 && chrAsc < 160)
                {
                    pyString += noWChar[j];
                }
                else
                {
                    // 修正部分文字
                    if (chrAsc == -9254)  // 修正“圳”字
                        pyString += "Zhen";
                    else
                    {
                        for (int i = (pyValue.Length - 1); i >= 0; i--)
                        {
                            if (pyValue[i] <= chrAsc)
                            {
                                pyString += pyName[i];
                                break;
                            }
                        }
                    }
                }
            }
            // 非中文字符
            else
            {
                pyString += noWChar[j].ToString();
            }
        }
        return pyString;
        #endregion
    }


    /// <summary>
    /// 获取网页HTML代码
    /// </summary>
    /// <param name="html">URL</param>
    /// <returns>返回代码</returns>
    public static string PlayResponse(string html)
    {
        #region 获取网页HTML代码
        string context = "";
        string context2 = "";
        HttpWebRequest wrq = null;
        WebResponse wrs = null;
        try
        {
            wrq = (HttpWebRequest)WebRequest.Create(html);
            wrs = wrq.GetResponse();
            wrs.GetResponseStream();
            Stream strm = wrs.GetResponseStream();
            StreamReader read = new StreamReader(strm, System.Text.Encoding.Default);
            while ((context = read.ReadLine()) != null)
            {
                context2 = context2 + context.ToString();
            }
            strm.Close();
            string b = "'";
            context2 = context2.Replace('"', char.Parse(b));
        }
        catch { }
        return context2;
        #endregion
    }


    /// <summary>
    /// 下载网络资源
    /// </summary>
    /// <param name="URL">网络资源地址</param>
    /// <param name="Filename">存放本机地址</param>
    public static void DownFile(string URL, string Filename)
    {
        //System.Net.WebClient wc = new System.Net.WebClient();

        //wc.DownloadFile(URL, Filename);
        //return;
        #region 下载网络资源
        System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
        Myrq.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-silverlight, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/QVOD, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
        Myrq.Headers.Add("Accept-Encoding", "gzip, deflate");
        Myrq.Headers.Add("Accept-Language", "zh-cn");
        Myrq.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; MS-RTC LM 8; Alexa Toolbar)";
        Myrq.Headers.Add("UA-CPU", "x86");
        Myrq.KeepAlive = true;
        System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();

        long totalBytes = myrp.ContentLength;
        System.IO.Stream st = myrp.GetResponseStream();
        System.IO.Stream so = new System.IO.FileStream(Filename, System.IO.FileMode.Create);
        long totalDownloadedByte = 0;
        byte[] by = new byte[1024];
        int osize = st.Read(by, 0, (int)by.Length);
        while (osize > 0)
        {
            totalDownloadedByte = osize + totalDownloadedByte;
            so.Write(by, 0, osize);
            osize = st.Read(by, 0, (int)by.Length);
        }
        so.Close();
        st.Close();
        #endregion
    }


    /// <summary>
    /// 判断字符串是否存在
    /// </summary>
    /// <param name="Obj">主字符串</param>
    /// <param name="myObj">要判断的字符串</param>
    /// <returns>存在:true,不存在:false</returns>
    public static bool Estimate(string Obj, string myObj)
    {
        #region 判断字符串是否存在
        if (Obj.IndexOf(myObj) != -1)
        {
            return true;
        }
        else
        {
            return false;
        }
        #endregion
    }


    /// <summary>
    /// 取得Url后缀
    /// </summary>
    /// <param name="Obj">Url</param>
    /// <returns>返回Url后缀</returns>
    public static string DordChar(string Obj)
    {
        #region 取得点后的字符串
        string[] CharString = Obj.Split('.');
        return CharString[CharString.Length - 1].ToString();
        #endregion
    }

    /// <summary>
    /// 取得Url名称
    /// </summary>
    /// <param name="Obj">Url</param>
    /// <returns>返回Url名称</returns>
    /// <returns>任意bool</returns>
    public static string DordChar(string Obj, bool obj)
    {
        #region 取得点后的名称
        string[] CharString = Obj.Split('.');
        string[] CharStringName = CharString[CharString.Length - 2].ToString().Split('\\');
        return CharStringName[CharStringName.Length - 1].ToString();
        #endregion
    }

    /// <summary>
    /// 本地和服务器路径
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string GetWebMenu(string path)
    {
        if (HttpContext.Current.Request.Url.Host.ToString().IndexOf("localhost") == -1)
        {
            return "/" + path;
        }
        else
        {
            return "/" + path;
        }
    }

    /// <summary>
    /// 取得IP地址
    /// </summary>
    /// <returns>返回IP地址</returns>
    public static string IpGet()
    {
        #region 取得IP地址
        //可以透过代理服务器
        string userIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (userIP == null || userIP == "")
        {

            //没有代理服务器,如果有代理服务器获取的是代理服务器的IP

            userIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

        }

        return userIP;
        #endregion
    }


    /// <summary>
    /// 过滤非法字符
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string Filtering(string obj)
    {
        #region 过滤字符,安全考虑
        //obj = Regex.Replace(obj, @" ", string.Empty);
        obj = Regex.Replace(obj, @"insert", string.Empty);
        obj = Regex.Replace(obj, @"update", string.Empty);
        obj = Regex.Replace(obj, @"delete", string.Empty);
        obj = Regex.Replace(obj, @"select", string.Empty);
        obj = Regex.Replace(obj, @"and", string.Empty);
        obj = Regex.Replace(obj, @"or", string.Empty);
        obj = Regex.Replace(obj, @";", string.Empty);
        obj = Regex.Replace(obj, @"'", "''");
        obj = Regex.Replace(obj, @"&", string.Empty);
        obj = Regex.Replace(obj, @"%20", string.Empty);
        obj = Regex.Replace(obj, @"--", string.Empty);
        obj = Regex.Replace(obj, @"==", string.Empty);
        obj = Regex.Replace(obj, @"<", string.Empty);
        obj = Regex.Replace(obj, @"开吃网", string.Empty);
        obj = Regex.Replace(obj, @"开吃", string.Empty);
        obj = Regex.Replace(obj, @"51k7", string.Empty);

        //obj = Regex.Replace(obj, @"/", string.Empty);
        obj = Regex.Replace(obj, @"\\", string.Empty);
        obj = Regex.Replace(obj, @"""", string.Empty);
        obj = Regex.Replace(obj, @"'", string.Empty);
        //obj = Regex.Replace(obj, @"%", string.Empty);
        return obj;
        #endregion
    }


    /// <summary>
    /// 不是框架判断Session超时间
    /// </summary>
    /// <param name="SessionName">Session名称</param>
    /// <param name="Url">要跳转得地址</param>
    public static void SessionTimeOut(string SessionName, string url)
    {
        #region Session超时
        if (HttpContext.Current.Session[SessionName] == null)
        {
            string returnUrl = "http://" + HttpContext.Current.Request.Url.Host + "/" + url;

            HttpContext.Current.Response.Write("<script>window.parent.parent.parent.location.href='" + returnUrl + "';</script>");
            return;
        }
        #endregion
    }

    /// <summary>
    /// 不会改变样式的提示框
    /// </summary>
    /// <param name="Page1">Page</param>
    /// <param name="Message">提示内容</param>
    public static void Show(System.Web.UI.Page Page1, string Message)
    {
        #region 不会改变样式的提示框
        Page1.ClientScript.RegisterStartupScript(Page1.GetType(), "gg", "alert('" + Message + "');", true);
        #endregion
    }

    /// <summary>
    /// 可以加代码的不会改变样式的提示框
    /// </summary>
    /// <param name="Page1">Page</param>
    /// <param name="Message">提示内容</param>
    ///  <param name="f">任意tree false</param>
    public static void Show(System.Web.UI.Page Page1, string Message, bool f)
    {
        #region 不会改变样式的提示框
        Page1.ClientScript.RegisterStartupScript(Page1.GetType(), "gg", "" + Message + "", true);
        #endregion
    }

    #region  Post发送方法
    /// <summary>  
    /// 创建POST方式的HTTP请求  
    /// </summary>  
    /// <param name="url">请求的URL</param>  
    /// <param name="parameters">随同请求POST的参数名称及参数值字典</param>  
    /// <returns></returns>  
    public static string CreatePostHttpResponse(string url, IDictionary<string, string> parameters)
    {
        if (string.IsNullOrEmpty(url))
        {
            throw new ArgumentNullException("url");
        }

        HttpWebRequest request = null;
        //如果是发送HTTPS请求  
        if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
        {
            //      ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
        }
        else
        {
            request = WebRequest.Create(url) as HttpWebRequest;
        }
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";

        //if (!string.IsNullOrEmpty(userAgent))
        //{
        //    request.UserAgent = userAgent;
        //}
        //else
        //{
        //    request.UserAgent = DefaultUserAgent;
        //}


        request.Timeout = 5000;


        //如果需要POST数据  
        if (!(parameters == null || parameters.Count == 0))
        {
            StringBuilder buffer = new StringBuilder();
            int i = 0;
            foreach (string key in parameters.Keys)
            {
                if (i > 0)
                {
                    buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                }
                else
                {
                    buffer.AppendFormat("{0}={1}", key, parameters[key]);
                }
                i++;
            }
            Encoding requestEncoding = Encoding.GetEncoding("gbk");
            byte[] data = requestEncoding.GetBytes(buffer.ToString());
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }
        string strResult;
        StreamReader srReader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.ASCII);
        strResult = srReader.ReadToEnd();
        return strResult;
    }


    #endregion


    /// <summary>
    /// MD5加密
    /// </summary>
    /// <param name="obj">传进参数</param>
    /// <returns>返回加密后的东西</returns>
    public static string MD5(string obj)
    {
        #region MD5加密
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(obj, "MD5");
        #endregion
    }


    /// <summary>
    /// 判断是否是浮点型
    /// </summary>
    /// <param name="obj">类型</param>
    /// <returns>返回true 与 false</returns>
    public static bool FlootIF(string obj)
    {
        #region 判断是否是浮点型
        try
        {
            float.Parse(obj);
            return true;
        }
        catch
        {
            return false;
        }
        #endregion
    }



    /// <summary>
    /// 判断是否是整型
    /// </summary>
    /// <param name="obj">类型</param>
    /// <returns>返回true 与 false</returns>
    public static bool IntIF(string obj)
    {
        #region 判断是否是整型
        try
        {
            int.Parse(obj);
            return true;
        }
        catch
        {
            return false;
        }
        #endregion
    }


    /// <summary>
    ///4位 随机数
    /// </summary>
    /// <returns>返回一个随机数</returns>
    public static string Randoms()
    {
        #region 随机数
        Random ran = new Random();
        return (ran.Next(1000, 9999) + 1).ToString();
        #endregion
    }
    /// <summary>
    /// 6位随机数
    /// </summary>
    /// <returns></returns>
    public static string Random()
    {
        #region 随机数
        Random ran = new Random();
        return ran.Next(100000, 999999).ToString();
        #endregion
    }

    /// <summary>
    /// 6位随机数
    /// </summary>
    /// <returns></returns>
    public static string Randomss()
    {
        #region 随机数
        Random ran = new Random();
        return ran.Next(10000000, 99999999).ToString();
        #endregion
    }

    /// <summary>
    /// 读取模板的内容
    /// </summary>
    /// <param name="tempDir">模板路径</param>
    /// <returns></returns>
    public static string ReadFile(string tempDir)
    {
        if (File.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + tempDir))
        {
            StreamReader sr = new StreamReader(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + tempDir, System.Text.Encoding.Default);
            string str = sr.ReadToEnd();
            sr.Close();
            return str;
        }
        return "未找到模板文件：" + tempDir;
    }


    /// <summary>
    /// 从末尾处删除一段字符串
    /// </summary>
    /// <param name="test">要传入的参数</param>
    /// <param name="obj">要替换的参数</param>
    /// <returns>返回删除后的结果</returns>
    public static string TrimEnds(string test, string obj)
    {
        #region
        char[] o = new char[obj.Length];
        for (int i = 0; i < obj.Length; i++)
        {
            o[i] = obj[i];
        }
        return test.TrimEnd(o);
        #endregion

    }

    /// <summary>
    /// 从开始处删除一段字符串
    /// </summary>
    /// <param name="test">要传入的参数</param>
    /// <param name="obj">要替换的参数</param>
    /// <returns>返回删除后的结果</returns>
    public static string TrimStarts(string test, string obj)
    {
        #region
        char[] o = new char[obj.Length];
        for (int i = 0; i < obj.Length; i++)
        {
            o[i] = obj[i];
        }
        return test.TrimStart(o);
        #endregion

    }

    /// <summary>
    /// 获取图片宽度
    /// </summary>
    /// <param name="path">图片路径</param>
    /// <returns>返回宽度</returns>
    public static string ImageWidth(string path)
    {
        #region
        if (path != "" && System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)) == true)
        {
            System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(path));
            return imgPhoto.Width.ToString();
        }
        else
        {
            return "0";
        }
        #endregion
    }


    /// <summary>
    /// 获取高度宽度
    /// </summary>
    /// <param name="path">图片路径</param>
    /// <returns>返回高度</returns>
    public static string ImageHeight(string path)
    {

        #region
        if (path != "" && System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)) == true)
        {
            System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(path));
            return imgPhoto.Height.ToString();
        }
        else
        {
            return "0";
        }
        #endregion
    }


    #region 私有成员
    /// 
    /// 获取所有文件
    /// 
    /// 
    private static Hashtable getAllFies(string filesdirectorypath, out int dirnamelength)
    {
        Hashtable FilesList = new Hashtable();
        DirectoryInfo fileDire = new DirectoryInfo(filesdirectorypath);
        if (!fileDire.Exists)
        {
            throw new System.IO.FileNotFoundException("目录:" + fileDire.FullName + "没有找到!");
        }
        dirnamelength = fileDire.Name.Length;
        getAllDirFiles(fileDire, FilesList);
        getAllDirsFiles(fileDire.GetDirectories(), FilesList);
        return FilesList;
    }
    /// 
    /// 获取一个文件夹下的所有文件夹里的文件
    /// 
    private static void getAllDirsFiles(DirectoryInfo[] dirs, Hashtable filesList)
    {
        foreach (DirectoryInfo dir in dirs)
        {
            foreach (FileInfo file in dir.GetFiles("*.*"))
            {
                filesList.Add(file.FullName, file.LastWriteTime);
            }
            getAllDirsFiles(dir.GetDirectories(), filesList);
        }
    }
    /// 
    /// 获取一个文件夹下的文件
    /// 
    private static void getAllDirFiles(DirectoryInfo dir, Hashtable filesList)
    {
        foreach (FileInfo file in dir.GetFiles("*.*"))
        {
            filesList.Add(file.FullName, file.LastWriteTime);
        }
    }
    #endregion


    #region 生成二维码图片

    /// 调用此函数后使此两种图片合并，类似相册，有个  
    /// 背景图，中间贴自己的目标图片  
    /// </summary>  
    /// <param name="sourceImg">粘贴的源图片</param>  
    /// <param name="destImg">粘贴的目标图片</param>  
    public static System.Drawing.Image CombinImage(System.Drawing.Image imgBack, string destImg)
    {

        System.Drawing.Image img = System.Drawing.Image.FromFile(destImg);        //照片图片    
        if (img.Height != 50 || img.Width != 50)
        {
            img = KiResizeImage(img, 50, 50, 0);
        }
        Graphics g = Graphics.FromImage(imgBack);

        g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);   

        g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 2, imgBack.Width / 2 - img.Width / 2 - 2, 54, 54);//相片四周刷一层黑色边框  

        //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);  

        g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
        GC.Collect();
        return imgBack;
    }
    /// <summary>  
    /// Resize图片  
    /// </summary>  
    /// <param name="bmp">原始Bitmap</param>  
    /// <param name="newW">新的宽度</param>  
    /// <param name="newH">新的高度</param>  
    /// <param name="Mode">保留着，暂时未用</param>  
    /// <returns>处理以后的图片</returns>  
    public static System.Drawing.Image KiResizeImage(System.Drawing.Image bmp, int newW, int newH, int Mode)
    {
        try
        {
            System.Drawing.Image b = new Bitmap(newW, newH);
            Graphics g = Graphics.FromImage(b);

            // 插值算法的质量  
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
            g.Dispose();

            return b;
        }
        catch
        {
            return null;
        }
    }

    #endregion


    #region ListToExcel

    /// <summary> 
    /// 将一组对象导出成EXCEL 
    /// </summary> 
    /// <typeparam name="T">要导出对象的类型</typeparam> 
    /// <param name="objList">一组对象</param> 
    /// <param name="FileName">导出后的文件名</param> 
    /// <param name="columnInfo">列名信息</param> 
    public static void ExExcel<T>(List<T> objList, string FileName, Dictionary<string, string> columnInfo)
    {
        if (columnInfo.Count == 0) { return; }
        if (objList.Count == 0) { return; }
        //生成EXCEL的HTML 
        string excelStr = "";
        Type myType = objList[0].GetType();
        //根据反射从传递进来的属性名信息得到要显示的属性 
        List<System.Reflection.PropertyInfo> myPro = new List<System.Reflection.PropertyInfo>();
        foreach (string cName in columnInfo.Keys)
        {
            System.Reflection.PropertyInfo p = myType.GetProperty(cName);
            if (p != null)
            {
                myPro.Add(p);
                excelStr += columnInfo[cName] + "\t";
            }
        }
        //如果没有找到可用的属性则结束 
        if (myPro.Count == 0) { return; }
        excelStr += "\n";
        foreach (T obj in objList)
        {
            foreach (System.Reflection.PropertyInfo p in myPro)
            {
                excelStr += p.GetValue(obj, null) + "\t";
            }
            excelStr += "\n";
        }
        //输出EXCEL 
        HttpResponse rs = System.Web.HttpContext.Current.Response;
        rs.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        rs.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
        rs.ContentType = "application/ms-excel";
        rs.Write(excelStr);
        rs.End();
    }

    #endregion

}
/// <summary>
/// 苹果AES 加密
/// </summary>
public class AppleASEClass
{
    /// <summary>
    /// 字节数组转化为十六进制字符串
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string BytesToHexString(byte[] input)
    {
        StringBuilder hexString = new StringBuilder(64);
        for (int i = 0; i < input.Length; i++)
        {
            hexString.Append(String.Format("{0:X2}", input[i]));
        }
        return hexString.ToString();
    }

    /// <summary>
    /// 十六进制字符串转化为字节数组
    /// </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    public static byte[] HexStringToBytes(string hex)
    {
        if (hex.Length == 0)
        {
            return new byte[] { 0 };
        }

        if (hex.Length % 2 == 1)
        {
            hex = "0" + hex;
        }

        byte[] result = new byte[hex.Length / 2];

        for (int i = 0; i < hex.Length / 2; i++)
        {
            result[i] = byte.Parse(hex.Substring(2 * i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
        }

        return result;
    }
    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="plainSourceStringToEncrypt">需要加密的字符串</param>
    /// <param name="passPhrase">密钥</param>
    /// <returns></returns>
    public static string EncryptString(string plainSourceStringToEncrypt, string passPhrase)
    {
        try
        {
            //Set up the encryption objects
            using (AesCryptoServiceProvider acsp = GetProvider(Encoding.UTF8.GetBytes(passPhrase)))
            {
                byte[] sourceBytes = Encoding.ASCII.GetBytes(plainSourceStringToEncrypt);
                ICryptoTransform ictE = acsp.CreateEncryptor();

                MemoryStream msS = new MemoryStream();

                CryptoStream csS = new CryptoStream(msS, ictE, CryptoStreamMode.Write);
                csS.Write(sourceBytes, 0, sourceBytes.Length);
                csS.FlushFinalBlock();

                byte[] encryptedBytes = msS.ToArray(); //.ToArray() is important, don't mess with the buffer

                return BytesToHexString(encryptedBytes);
            }
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="stringToDecrypt">接收字符串</param>
    /// <param name="pwd">密钥</param>
    /// <returns></returns>
    public static string DecryptString(string stringToDecrypt, string pwd)
    {
        try
        {
            using (AesCryptoServiceProvider acsp = GetProvider(Encoding.UTF8.GetBytes(pwd)))
            {
                byte[] RawBytes = HexStringToBytes(stringToDecrypt);
                ICryptoTransform ictD = acsp.CreateDecryptor();

                MemoryStream msD = new MemoryStream(RawBytes, 0, RawBytes.Length);
                CryptoStream csD = new CryptoStream(msD, ictD, CryptoStreamMode.Read);

                return (new StreamReader(csD)).ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    private static AesCryptoServiceProvider GetProvider(byte[] key)
    {
        AesCryptoServiceProvider result = new AesCryptoServiceProvider();
        result.BlockSize = 128;
        result.KeySize = 128;
        result.Mode = CipherMode.CBC;
        result.Padding = PaddingMode.PKCS7;

        result.GenerateIV();
        result.IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        byte[] RealKey = GetKey(key, result);
        result.Key = RealKey;
        return result;
    }

    private static byte[] GetKey(byte[] suggestedKey, SymmetricAlgorithm p)
    {
        byte[] kRaw = suggestedKey;
        List<byte> kList = new List<byte>();

        for (int i = 0; i < p.LegalKeySizes[0].MinSize; i += 8)
        {
            kList.Add(kRaw[(i / 8) % kRaw.Length]);
        }
        byte[] k = kList.ToArray();
        return k;
    }
}

/// <summary>
/// 安卓AES加密
/// </summary>
public class AndroidASEClass
{

    /// <summary>
    /// 有密码的AES加密 
    /// </summary>
    /// <param name="text">加密字符</param>
    /// <param name="password">加密的密码</param>
    /// <param name="iv">密钥</param>
    /// <returns></returns>
    public static string Encrypt(string toEncrypt, string key)
    {
        try
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    /// <summary>
    /// AES解密
    /// </summary>
    /// <param name="text"></param>
    /// <param name="password"></param>
    /// <param name="iv"></param>
    /// <returns></returns>
    public static string Decrypt(string toDecrypt, string key)
    {
        try
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        catch (Exception ex)
        {
            return "";
        }
    }
}


#region 图片，加密方法
public class Operator
{
    #region 加密解密方法

    private static readonly String strAesKey = "iwww.maoblog.comiwww.maoblog.com";//加密所需32位密匙

    /// <summary>
    /// AES加密
    /// </summary>
    /// <param name="str">要加密字符串</param>
    /// <returns>返回加密后字符串</returns>
    public static String Encrypt_AES(String str)
    {
        Byte[] keyArray = System.Text.UTF8Encoding.UTF8.GetBytes(strAesKey);
        Byte[] toEncryptArray = System.Text.UTF8Encoding.UTF8.GetBytes(str);

        System.Security.Cryptography.RijndaelManaged rDel = new System.Security.Cryptography.RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = System.Security.Cryptography.CipherMode.ECB;
        rDel.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

        System.Security.Cryptography.ICryptoTransform cTransform = rDel.CreateEncryptor();
        Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }



    /// <summary>
    /// AES解密
    /// </summary>
    /// <param name="str">要解密字符串</param>
    /// <returns>返回解密后字符串</returns>
    public static String Decrypt_AES(String str)
    {
        Byte[] keyArray = System.Text.UTF8Encoding.UTF8.GetBytes(strAesKey);
        Byte[] toEncryptArray = Convert.FromBase64String(str);

        System.Security.Cryptography.RijndaelManaged rDel = new System.Security.Cryptography.RijndaelManaged();
        rDel.Key = keyArray;
        rDel.Mode = System.Security.Cryptography.CipherMode.ECB;
        rDel.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

        System.Security.Cryptography.ICryptoTransform cTransform = rDel.CreateDecryptor();
        Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        return System.Text.UTF8Encoding.UTF8.GetString(resultArray);
    }

    #endregion

    #region 图片处理

    /// <summary>
    /// 生成等比缩略图
    /// </summary>
    /// <param name="originalImagePath">原图路径（物理路径）</param>
    /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>
    public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height)
    {

        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;
        string mode = "Auto";//这以后可以更换//////////重要
        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形）                
                break;
            case "W"://指定宽，高按比例                    
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）                
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            case "Auto":
                if ((double)originalImage.Width / (double)originalImage.Height > 1)
                {
                    toheight = originalImage.Height * width / originalImage.Width;
                }
                else
                {
                    towidth = originalImage.Width * height / originalImage.Height;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //新建一个画板
        Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充
        g.Clear(Color.Transparent);

        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
            new Rectangle(x, y, ow, oh),
            GraphicsUnit.Pixel);
        try
        {
            //以jpg格式保存缩略图
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }

    /// <summary>
    /// 处理文字水印
    /// </summary>
    /// <param name="Path">原图路径</param>
    /// <param name="NewPath">生成水印后的路径</param>
    /// <param name="WaterText">水印文字</param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="isDelOld">是否删除愿图</param>
    public static void MarkWaterText(string Path, string NewPath, string WaterText, int x, int y, bool isDelOld)
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(Path));

        try
        {
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            System.Drawing.Font f = new System.Drawing.Font("System", 12);
            System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);

            g.DrawString(WaterText, f, b, x, y);
            g.Dispose();
            image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
            image.Dispose();
        }
        catch
        {
            image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
            image.Dispose();
        }
        finally
        {
            if (isDelOld)
            {
                File.Delete(System.Web.HttpContext.Current.Server.MapPath(Path));
            }
        }
    }

    /// <summary>
    /// 处理文字水印
    /// </summary>
    /// <param name="Path">原图路径</param>
    /// <param name="NewPath">生成文字水印后的路径</param>
    /// <param name="WaterText">水印文字</param>
    /// <param name="isDelOld">是否删除愿图</param>
    public static void MarkWaterText(string Path, string NewPath, string WaterText, bool isDelOld)
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(Path));

        try
        {
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            int fsize = 12;
            if (image.Height > image.Width)
            {
                fsize = image.Height / 10;
            }
            else
            {
                fsize = image.Width / 10;
            }
            if (fsize > 16) fsize = 16;
            System.Drawing.Font f = new System.Drawing.Font("Arial", fsize);

            System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
            int leng = WaterText.Length * f.Height;

            int x, y;
            x = 15;
            y = 15;

            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.NoWrap;
            //g.DrawString(WaterText, f, b, x, y);
            g.DrawString(WaterText, f, b, image.Width - x - leng, image.Height - y - f.Height, drawFormat);
            g.Dispose();
            image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
            image.Dispose();
        }
        catch
        {
            image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
            image.Dispose();
        }
        finally
        {
            if (isDelOld)
            {
                File.Delete(System.Web.HttpContext.Current.Server.MapPath(Path));
            }
        }
    }

    /// <summary>
    /// 处理图片水印
    /// </summary>
    /// <param name="Path">原图路径</param>
    /// <param name="NewPath">生成图片水印后的路径</param>
    /// <param name="ImagePath">水印图片路径</param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="isDelOld">是否删除愿图</param>
    public static void MarkWaterImage(string Path, string NewPath, string ImagePath, int x, int y, bool isDelOld)
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(Path));
        System.Drawing.Image copyImage = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(ImagePath));
        try
        {
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);

            /*g.DrawImage(copyImage, new System.Drawing.Rectangle(x, y, copyImage.Width, copyImage.Height),
                new System.Drawing.Rectangle(0, 0, copyImage.Width, copyImage.Height),
                System.Drawing.GraphicsUnit.Pixel);*/
            g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width - x, image.Height - copyImage.Height - y, copyImage.Width, copyImage.Height),
                new System.Drawing.Rectangle(0, 0, copyImage.Width, copyImage.Height),
                System.Drawing.GraphicsUnit.Pixel);
            g.Dispose();
            image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
            image.Dispose();
        }
        catch
        {
            image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
            image.Dispose();
        }
        finally
        {
            if (isDelOld)
            {
                File.Delete(System.Web.HttpContext.Current.Server.MapPath(Path));
            }
        }
    }

    /// <summary>
    /// 处理图片水印
    /// </summary>
    /// <param name="Path">原图路径</param>
    /// <param name="NewPath">生成水印后的路径</param>
    /// <param name="ImagePath">水印图片路径</param>
    /// <param name="isDelOld">是否删除愿图</param>
    public static void MarkWaterImage(string Path, string NewPath, string ImagePath, bool isDelOld)
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(Path));
        System.Drawing.Image copyImage = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(ImagePath));
        try
        {
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            int x, y;
            x = 0;
            y = 0;
            g.DrawImage(copyImage, new System.Drawing.Rectangle((image.Width / 2) - (copyImage.Width / 2), (image.Height / 2) - (copyImage.Height / 2), copyImage.Width, copyImage.Height),
                new System.Drawing.Rectangle(0, 0, copyImage.Width, copyImage.Height),
                System.Drawing.GraphicsUnit.Pixel);
            g.Dispose();
            image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
            image.Dispose();
        }
        catch
        {
            image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
            image.Dispose();
        }
        finally
        {
            if (isDelOld)
            {
                File.Delete(System.Web.HttpContext.Current.Server.MapPath(Path));
            }
        }
    }
    /// <summary>
    /// 生成二维码
    /// </summary>
    /// <param name="content"></param>
    /// <param name="savePath"></param>
    public static void CreateQRCode(string content, string savePath)
    {
        QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
        try
        {
            int scale = Convert.ToInt16(4);
            qrCodeEncoder.QRCodeScale = scale;
        }
        catch { }
        String data = content;
        System.Drawing.Image myimg = qrCodeEncoder.Encode(data, System.Text.Encoding.UTF8); //kedee 增加utf-8编码，可支持中文汉字  
        myimg.Save(savePath, System.Drawing.Imaging.ImageFormat.Gif);
        myimg.Dispose();
    }


    /// <summary>
    /// 保存远程图片
    /// </summary>
    /// <param name="Path">存放图片的路径</param>
    /// <param name="Url">网络图片地址</param>
    /// <returns>本地图片地址</returns>
    public static string GetRemotImage(string Path, string Url)
    {
        string[] Filters = new string[] { "image/gif", "image/jpeg", "image/bmp", "image/png" };

        HttpWebRequest hwq = (HttpWebRequest)WebRequest.Create(Url.ToLower());
        HttpWebResponse hwr = (HttpWebResponse)hwq.GetResponse();
        string contenttype = hwr.ContentType.ToString();
        string typeName = "";
        bool errortype = false;
        for (int i = 0; i <= Filters.Length - 1; i++)
        {
            if (contenttype == Filters[i].ToString().ToLower())
            {
                switch (contenttype)
                {
                    case "image/gif":
                        typeName = "gif";
                        break;
                    case "image/jpeg":
                        typeName = "jpg";
                        break;
                    case "image/bmp":
                        typeName = "bmp";
                        break;
                    case "image/png":
                        typeName = "png";
                        break;
                }
                errortype = true;
                break;
            }
        }
        if (errortype)
        {
            System.Drawing.Image bmp = System.Drawing.Image.FromStream(hwr.GetResponseStream());
            string fileName = string.Empty;
            string y = DateTime.Now.Year.ToString();
            string m = DateTime.Now.Month.ToString();
            string d = DateTime.Now.Day.ToString();
            string h = DateTime.Now.Hour.ToString();
            string n = DateTime.Now.Minute.ToString();
            string s = DateTime.Now.Second.ToString();
            fileName = y + m + d + h + n + s;
            Random r = new Random();
            fileName = fileName + r.Next(1000);
            fileName = fileName + "." + typeName;
            string webFilePath = Path + fileName;
            bmp.Save(System.Web.HttpContext.Current.Server.MapPath(webFilePath));
            hwr.Close();
            return webFilePath;
        }
        else
        {
            hwr.Close();
            return "";
        }
    }

    #endregion

    #region 采集

    #region 采集相关私有成员
    private static string GetChartset(string url)
    {
        string html = getHTML(url);
        Regex reg_charset = new Regex(@"charset\b\s*=\s*(?<charset>[^""]*)");
        string enconding = null;
        if (reg_charset.IsMatch(html))
        {
            enconding = reg_charset.Match(html).Groups["charset"].Value;
        }
        else
        {
            enconding = Encoding.Default.EncodingName;
        }
        if (enconding.ToLower().Contains("gb2312"))
            enconding = "gb2312";
        if (enconding.ToLower().Contains("utf-8"))
            enconding = "utf-8";
        return enconding;
    }

    private static string getHTML(string url)
    {

        try
        {
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse webResponse = webRequest.GetResponse();
            Stream stream = webResponse.GetResponseStream();
            StreamReader sr = new StreamReader(stream, Encoding.GetEncoding(Encoding.ASCII.EncodingName));
            string html = sr.ReadToEnd();
            return html;
        }
        catch (UriFormatException ex)
        {

            Console.WriteLine(ex.Message);
            return null;
        }
        catch (WebException ex)
        {

            Console.WriteLine(ex.Message);
            return null;
        }
    }

    #endregion

    /// <summary>
    /// 采集
    /// </summary>
    /// <param name="url">要采集的地址</param>
    /// <param name="Type">采集的类型，1-全部内容，2-不带脚本的内容，3-所有文本，4-所有图片，5-所有链接</param>
    /// <returns></returns>
    public static string GetRemotUrl(string url, int Type)
    {
        string Url = url.Trim();
        string returnvalue = string.Empty;
        string result = string.Empty;
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string ce = response.ContentEncoding;
            Stream streamReceive = response.GetResponseStream();

            Encoding encoding = Encoding.GetEncoding(GetChartset(Url));
            if (ce.ToLower() == "gzip")//压缩的内容
            {
                GZipStream gzip = new GZipStream(streamReceive, CompressionMode.Decompress);
                using (StreamReader reader = new StreamReader(gzip, encoding))
                {
                    result = reader.ReadToEnd();
                }

            }
            else
            {
                using (StreamReader streamReader = new StreamReader(streamReceive, encoding))
                {
                    result = streamReader.ReadToEnd();
                }
            }

            switch (Type)
            {
                case 1:
                    returnvalue = result;
                    break;
                case 2:
                    returnvalue = wipeScript(result);
                    break;
                case 3:
                    returnvalue = ClearHTML(result);
                    break;
                case 4:
                    returnvalue = getImages(Url, result);
                    break;
                case 5:
                    returnvalue = getLink(Url, result);
                    break;
                default:
                    break;
            }
        }
        catch
        {
            returnvalue = "Error";
        }
        return returnvalue;
    }

    /// <summary>
    /// 得到所有图片
    /// </summary>
    /// <param name="Url"></param>
    /// <param name="html"></param>
    /// <returns></returns>
    public static string getImages(string Url, string html)
    {
        string resultStr = "";
        string temp = "";
        string url = "";
        string[] url2;
        Match m;
        Regex r = new Regex(@"<IMG[^>]+src=\s*(?:'(?<src>[^']+)'|""(?<src>[^""]+)""|(?<src>[^>\s]+))\s*[^>]*>", RegexOptions.IgnoreCase);
        for (m = r.Match(html); m.Success; m = m.NextMatch())
        {
            temp = m.Groups["src"].Value.ToLower();
            if (temp.IndexOf("http") == 0)
            {
                resultStr += m.Value + "<br />";
            }
            else
            {
                url2 = Url.Trim().Split('/');

                try
                {
                    if (url2.Length > 3)
                    {
                        url = Url.Trim().Replace(url2[url2.Length - 1], "");
                    }
                    else
                    {
                        url = Url.Trim();
                    }
                }
                catch
                {
                    url = Url.Trim();
                }

                if (temp.IndexOf("/") == 0)
                {

                    resultStr += m.Value.Replace(m.Groups["src"].Value, "http://" + url2[2] + m.Groups["src"].Value) + "<br/>";
                }
                else
                {
                    resultStr += m.Value.Replace(m.Groups["src"].Value, url + m.Groups["src"].Value) + "<br/>";
                }
            }
        }
        return resultStr;
    }

    /// <summary>
    /// 得到去除HTML标记的内容
    /// </summary>
    /// <param name="Htmlstring">要过滤的字符窜</param>
    /// <returns></returns>
    public static string ClearHTML(string Htmlstring)
    {
        //删除脚本
        Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        //Htmlstring = Regex.Replace(Htmlstring, @"<script[\s\S]+</script *>", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"<style[\s\S]+</style *>", "", RegexOptions.IgnoreCase);
        //删除HTML
        Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
        Htmlstring.Replace("<", "");
        Htmlstring.Replace(">", "");
        Htmlstring.Replace("\r\n", "");
        Htmlstring = System.Web.HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

        return Htmlstring;
    }

    /// <summary>
    /// 得到不带脚本的内容
    /// </summary>
    /// <param name="html"></param>
    /// <returns></returns>
    public static string wipeScript(string html)
    {
        System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        html = regex1.Replace(html, ""); //过滤<script></script>标记
        html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性
        html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件
        html = regex4.Replace(html, ""); //过滤iframe
        html = regex5.Replace(html, ""); //过滤frameset
        return html;
    }

    /// <summary>
    /// 得到所有链接地址
    /// </summary>
    /// <param name="Url"></param>
    /// <param name="html"></param>
    /// <returns></returns>
    public static string getLink(string Url, string html)
    {
        string resultStr = "";
        string temp = "";
        string url = "";
        string[] url2;
        Regex re = new Regex(@"<a[^>]+href=\s*(?:'(?<href>[^']+)'|""(?<href>[^""]+)""|(?<href>[^>\s]+))\s*[^>]*>(?<text>.*?)</a>", RegexOptions.IgnoreCase);

        MatchCollection mc = re.Matches(html);
        foreach (Match m in mc)
        {
            temp = m.Groups["href"].Value.ToLower();
            if (temp.IndexOf("http") == 0)
            {
                resultStr += m.Value + "<br/>";
            }
            else
            {
                url2 = Url.Trim().Split('/');
                try
                {
                    if (url2.Length > 1)
                    {
                        url = Url.Trim().Replace(url2[url2.Length - 1], "");
                    }
                    else
                    {
                        url = Url.Trim();
                    }
                }
                catch
                {
                    url = Url.Trim();
                }

                if (temp.IndexOf("/") == 0)
                {
                    resultStr += m.Value.Replace(m.Groups["href"].Value, "http://" + url2[2] + m.Groups["href"].Value) + "<br/>";
                }
                else if (temp.IndexOf("mailto") == 0)
                {
                    resultStr += m.Value + "<br/>";
                }
                else
                {
                    resultStr += m.Value.Replace(m.Groups["href"].Value, url + m.Groups["href"].Value) + "<br/>";
                }
            }
        }

        return resultStr;
    }

    #endregion

    #region 常用
    /// <summary>
    /// 获取指定长度的字符串(只限中文)
    /// </summary>
    /// <param name="stringToSub">要截取的字符串</param>
    /// <param name="length">截取的长度</param>
    /// <returns></returns>		
    public static string GetChinaString(string stringToSub, int length)
    {
        Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
        char[] stringChar = stringToSub.ToCharArray();
        StringBuilder sb = new StringBuilder();
        int nLength = 0;
        bool isCut = false;
        for (int i = 0; i < stringChar.Length; i++)
        {
            if (regex.IsMatch((stringChar[i]).ToString()))
            {
                sb.Append(stringChar[i]);
                nLength += 2;
            }
            else
            {
                sb.Append(stringChar[i]);
                nLength = nLength + 1;
            }

            if (nLength > length)
            {
                isCut = true;
                break;
            }
        }
        if (isCut)
            return sb.ToString() + "..";
        else
            return sb.ToString();
    }

    /// <summary>
    /// 防sql注入
    /// </summary>
    /// <param name="str">要过虑的字符串</param>
    /// <returns></returns>
    public static string FiltSQL(string str)
    {
        //str = str.Replace("&", "&amp;");
        //str = str.Replace("<", "&lt;");
        //str = str.Replace(">", "&gt");
        //str = str.Replace("'", "''");
        //str = str.Replace("*", "");
        //str = str.Replace("\n", "<br/>");
        //str = str.Replace("\r\n", "<br/>");
        //str   =   str.Replace("?","");   
        str = str.Replace("select", "");
        str = str.Replace("insert", "");
        str = str.Replace("update", "");
        str = str.Replace("delete", "");
        str = str.Replace("create", "");
        str = str.Replace("drop", "");
        str = str.Replace("delcare", "");
        str = str.Replace("   ", "&nbsp;");
        str = str.Replace("<script>", "");
        str = str.Replace("</script>", "");
        str = str.Trim();
        return str;
    }

    /// <summary>
    /// 判断是否为数字
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsNumeric(string str)
    {
        Regex r = new Regex(@"^\d+(\.)?\d*$");
        if (r.IsMatch(str))
            return true;
        else
            return false;
    }

    /// <summary>
    /// 判断是否为图片
    /// </summary>
    /// <param name="Ext">文件扩张名</param>
    /// <returns></returns>
    public static bool IsPic(string Ext)
    {
        bool flag = false;
        string[] AllowExts = new string[] { ".jpg", ".jpeg", ".gif", ".png", ".bmp" };
        foreach (string AllowExt in AllowExts)
        {
            if (AllowExt.Equals(Ext, StringComparison.InvariantCultureIgnoreCase))
            {
                flag = true;
                break;
            }
        }
        return flag;
    }

    #endregion

    #region 生成随即验证码
    /// <summary>
    /// 根据随机数生成验证码
    /// </summary>
    /// <param name="checkCode">随机数</param>
    public static void CreateImage(string checkCode)
    {
        int iwidth = (int)(checkCode.Length * 11);
        System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 19);
        Graphics g = Graphics.FromImage(image);
        g.Clear(Color.White);
        //定义颜色
        Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Chocolate, Color.Brown, Color.DarkCyan, Color.Purple };
        Random rand = new Random();

        //输出不同字体和颜色的验证码字符
        for (int i = 0; i < checkCode.Length; i++)
        {
            int cindex = rand.Next(7);
            Font f = new System.Drawing.Font("Microsoft Sans Serif", 11);
            Brush b = new System.Drawing.SolidBrush(c[cindex]);
            g.DrawString(checkCode.Substring(i, 1), f, b, (i * 10) + 1, 0, StringFormat.GenericDefault);
        }
        //画一个边框
        g.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);


        //输出到浏览器
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        System.Web.HttpContext.Current.Response.ClearContent();
        System.Web.HttpContext.Current.Response.ContentType = "image/Jpeg";
        System.Web.HttpContext.Current.Response.BinaryWrite(ms.ToArray());
        g.Dispose();
        image.Dispose();
    }

    public static void CreateImage(string text, string savePath)
    {
        if (text == "") return;
        int iwidth = (int)text.Length * 8;
        System.Drawing.Bitmap image = new Bitmap(iwidth, 19);
        Graphics g = Graphics.FromImage(image);
        g.Clear(Color.White);
        Font f = new System.Drawing.Font("宋体", 11);
        Brush b = new System.Drawing.SolidBrush(Color.Black);
        g.DrawString(text, f, b, 0.0F, 0.0F, StringFormat.GenericDefault);

        image.Save(savePath);
        image.Dispose();
        g.Dispose();
    }


    /// <summary>
    /// 获得随机数
    /// </summary>
    /// <param name="num">几位数</param>
    /// <returns>随机数</returns>
    public static string GetValidateCode(int num)
    {
        char[] chars = "023456789".ToCharArray();
        System.Random random = new Random();
        string validateCode = string.Empty;
        for (int i = 0; i < num; i++)
        {
            char rc = chars[random.Next(0, chars.Length)];
            if (validateCode.IndexOf(rc) > -1)
            {
                i--;
                continue;
            }
            validateCode += rc;
        }
        return validateCode;
    }
    #endregion

    #region 操作ini文件

    /******************************示例INI文件*************************************/
    // ;默认首页1
    // [default]
    // url1=http://www.tiantian21.com/servicemanage/netbar/default.html
    // url2=http://www.tiantian21.com/servicemanage/netbar/index.html
    // ;后面的视为注释
    // []里面的视为关键字名称
    // url1，url2视为关键字所对应的值
    /******************************************************************************/

    /******************************************************************************/
    // section：要读取的段落名
    // key: 要读取的键
    // defVal: 读取异常的情况下的缺省值
    // retVal: 此参数类型不是string，而是Byte[]用于返回byte类型的section组或键值组。
    // size: 值允许的大小
    // filePath: INI文件的完整路径和文件名 
    /******************************************************************************/

    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string defVal, System.Text.StringBuilder retVal, int size, string filePath);

    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);


    /// <summary>
    /// 写入（更新）INI文件
    /// </summary>
    /// <param name="section">要读取的段落名</param>
    /// <param name="key">要读取的关键字</param>
    /// <param name="iValue">关键字所对应的值,null则删除该关键字</param>
    /// <param name="path">路径</param>
    public static void IniWriteValue(string section, string key, string iValue, string path)
    {
        WritePrivateProfileString(section, key, iValue, path);
    }

    /// <summary>
    /// 读出INI文件的数据（返回字符串）
    /// </summary>
    /// <param name="section">要读取的段落名</param>
    /// <param name="key">要读取的关键字</param>
    /// <param name="path">路径</param>
    /// <returns></returns>
    public static string IniReadValue(string section, string key, string path)
    {
        System.Text.StringBuilder temp = new System.Text.StringBuilder(255);
        int i = GetPrivateProfileString(section, key, "", temp, 255, path);
        return temp.ToString();
    }


    /// <summary>
    /// 读出INI文件的数据（返回字节数组）
    /// </summary>
    /// <param name="section">要读取的段落名</param>
    /// <param name="key">要读取的关键字</param>
    /// <param name="path">路径</param>
    /// <returns></returns>
    public static byte[] IniReadValues(string section, string key, string path)
    {
        byte[] temp = new byte[255];
        int i = GetPrivateProfileString(section, key, "", temp, 255, path);
        return temp;
    }

    #endregion

    #region 文件操作

    /// <summary>
    /// 批量转移文件
    /// </summary>
    /// <param name="oldpath">文件夹路径</param>
    /// <param name="newpath">新文件夹路径</param>
    /// <returns></returns>
    public static bool MoveFiles(string oldpath, string newpath)
    {
        DirectoryInfo dr = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath(oldpath));
        FileInfo[] files = dr.GetFiles();
        try
        {
            foreach (FileInfo file in files)
            {
                file.MoveTo(System.Web.HttpContext.Current.Server.MapPath(newpath + file.Name));
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 更改文件名
    /// </summary>
    /// <param name="oldpath">原文件名（完整路径）</param>
    /// <param name="newpath">新文件名（完整路径）</param>
    /// <returns></returns>
    public static bool ChangeFileName(string oldpath, string newpath)
    {
        try
        {
            FileInfo file = new FileInfo(System.Web.HttpContext.Current.Server.MapPath(oldpath));
            file.MoveTo(System.Web.HttpContext.Current.Server.MapPath(newpath));
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// 获得所有文件夹下的所有文件（包含子目录）
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string GetFileNames(string path)
    {
        StringBuilder str = new StringBuilder();
        DirectoryInfo dir = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath(path));
        FileInfo[] fileinfos = dir.GetFiles();
        foreach (FileInfo file in fileinfos)
        {
            str.Append(file.Name + "|");
        }
        DirectoryInfo[] drs = dir.GetDirectories();
        foreach (DirectoryInfo dr in drs)
        {
            FileInfo[] files = dr.GetFiles();
            foreach (FileInfo file in files)
            {
                str.Append(file.Name + "|");
            }
        }
        return str.ToString();
    }

    #endregion


}
#endregion


/// <summary>
/// Request重写过滤
/// </summary>
#region Request传值重写过滤
public class QueryString
{
    public object this[string c]
    {
        get
        {
            if (System.Web.HttpContext.Current.Request.QueryString[c] == null)
            {
                return null;
            }
            else
            {
                return db.Filtering(System.Web.HttpContext.Current.Request.QueryString[c]);
            }
        }
    }
}

public class sRequest
{
    public static QueryString QueryString = new QueryString();
}
#endregion
