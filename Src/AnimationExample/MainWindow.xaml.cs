using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimationExample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        BubblesForWPF mBubbles;
        DigitalRain rain;
        public MainWindow()
        {
            InitializeComponent();
            //mBubbles = new BubblesForWPF(this.bg_index, 80, 160, 50, 2);
            //mBubbles.CreateBubbles(ellipse =>
            //{
            //    ellipse.Fill = Brushes.White;
            //    ellipse.Opacity = 0.1;
            //});
            rain = new DigitalRain(this.bg_index);
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            //mBubbles.Run();
            rain.Run();
        }
    }
}
