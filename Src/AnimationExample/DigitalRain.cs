using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AnimationExample {
    public class DigitalRain {
        public DigitalRain(Canvas cav) {
            m_CavMain = cav;
            m_Rnd = CreateRandom();
            m_LstStpnl = new List<StackPanel>();
            
            for (int i = 0; i <80; i++) {
                StackPanel pnl = GetDigital();
                
                cav.Children.Add(pnl);
                m_LstStpnl.Add(pnl);
                
            }
            
        }

        private Canvas m_CavMain;
        private Random m_Rnd;

        List<StackPanel> m_LstStpnl;
        
        public void Run() {
           foreach(StackPanel val in m_LstStpnl) {
                Move(val);
            }
        }
        private Random CreateRandom() {
            long tick = DateTime.Now.Ticks;
            int realTick = (int)(tick & 0xffffffffL) | (int)(tick >> 32);
            Random rd = new Random(realTick);
            return rd;
        }

        private StackPanel GetDigital() {
            StackPanel stackPanel = new StackPanel();
            
            stackPanel.Orientation = Orientation.Vertical;
            double opacity = m_Rnd.NextDouble();
            double fontSize = m_Rnd.Next(10,32);
            double count = m_Rnd.Next(4,14);
            
            for (int i = 0; i < count; i++) {
                TextBlock txt = new TextBlock();
                txt.Text = m_Rnd.Next(0, 2).ToString();
                txt.Background = Brushes.Transparent;

                txt.Foreground = String2Brush("#4F83B6");
                txt.FontSize =fontSize;
                txt.Opacity = opacity;
                
                txt.FontFamily = new FontFamily("微软雅黑");
                stackPanel.Children.Add(txt);
            }
            
            TranslateTransform tr = new TranslateTransform();
            tr.X = m_Rnd.Next(0, (int)m_CavMain.Width - 100);
            tr.Y= m_Rnd.Next(-64,(int)m_CavMain.Height);
            stackPanel.RenderTransform = tr;
            return stackPanel;
        }

        private void Move(StackPanel pnl) {
           
            TranslateTransform tr = pnl.RenderTransform as TranslateTransform;
            
            if (tr.Y <= 0 || tr.Y >= m_CavMain.Height) {
                tr.X = m_Rnd.Next(0, (int)m_CavMain.Width);
                tr.Y= tr.Y = m_Rnd.Next(0, 120);
                return;
            }
            
            tr.Y += 15;
        }
        internal static Brush String2Brush(string StrColor) {
            BrushConverter BrcInstance = new BrushConverter();
            return (Brush)BrcInstance.ConvertFromString(StrColor);
        }

    }
}
