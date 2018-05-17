using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KeySearchExample
{
    public class TextBoxManager : DependencyObject
    {

        #region 标题附加属性
        public static string  GetTitle(DependencyObject obj)
        {
            return (string )obj.GetValue(TitleProperty);
        }

        public static void SetTitle(DependencyObject obj, string  value)
        {
            obj.SetValue(TitleProperty, value);
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.RegisterAttached("Title", typeof(string ), typeof(TextBoxManager), new FrameworkPropertyMetadata(""));



        

        



        #endregion 标题附加属性





        #region 水印附加属性
        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }

        // Using a DependencyProperty as the backing store for Watermark.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(TextBoxManager),new FrameworkPropertyMetadata(""));
        #endregion 水印附加属性
    }
}
