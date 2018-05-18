using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Configuration;
using System.Windows.Shapes;

namespace AnimationExample
{
    public class EllipseInfo
    {
        public Ellipse CurEllipse { get; set; }
        public double XSpeed { get; set; }
        public double YSpeed { get; set; }
        
    }
    public sealed class BubblesForWPF
    {
        public BubblesForWPF()
        {
            this.mRandom = CreateRandom();
        }
        public BubblesForWPF(Canvas cav) : this(cav, 40, 50, 10,3) { }

        public BubblesForWPF(Canvas cav,int minR,int maxR,int countOfBubbles,int speed):this()
        {
            this.mCanv = cav;
            this.mSpeed = speed;
            this.mMinR = minR;
            this.mMaxR = maxR;
            this.mCountOfBubbles = countOfBubbles;
        }


        private Canvas mCanv;
        private int mSpeed;
        private int mMinR, mMaxR;
        private Random mRandom;
        private int mCountOfBubbles;
        private List<EllipseInfo> mListEllipse;
       private Random CreateRandom()
        {
            long tick = DateTime.Now.Ticks;
            int realTick = (int)(tick & 0xffffffffL) | (int)(tick >> 32);
            Random rd = new Random(realTick);
            return rd;
        }
       private double GetSpeed(int speed)
       {
           double speedTmp = mRandom.Next(-speed, speed);
           if (speedTmp == 0)
           {
               return GetSpeed(speed);
           }
           return speedTmp;
       }

       public void CreateBubbles(Action<Ellipse> actionSetStyle)
       {
           if(mListEllipse==null)
           {
               mListEllipse = new List<EllipseInfo>();
           }
           for(var i=0;i<this.mCountOfBubbles;i++)
           {
               Ellipse ellipse = new Ellipse();
               ellipse.Width = ellipse.Height = this.mRandom.Next(this.mMinR, this.mMaxR);
               if(actionSetStyle!=null)
               {
                   actionSetStyle(ellipse);
               }
               mListEllipse.Add(new EllipseInfo()
                   {
                       CurEllipse = ellipse,
                       XSpeed = GetSpeed(this.mSpeed),
                       YSpeed = GetSpeed(this.mSpeed)
                   });

               this.mCanv.Children.Add(ellipse);
               int width = (int)this.mCanv.Width;
               int height = (int)this.mCanv.Height;
               ellipse.SetValue(Canvas.LeftProperty, (double)this.mRandom.Next(width));
               ellipse.SetValue(Canvas.TopProperty, (double)this.mRandom.Next(height));
           }


       }

        public void Run()
       {
            foreach(var val in mListEllipse)
            {
                Move(val);
            }
       }

       private void Move(EllipseInfo eInfo)
       {
           double left = Canvas.GetLeft(eInfo.CurEllipse);
           double top = Canvas.GetTop(eInfo.CurEllipse);

           if (left >= this.mCanv.ActualWidth || left <= -100)
           {
               eInfo.XSpeed = (0 - eInfo.XSpeed);
           }
           if (top >= this.mCanv.ActualHeight || top <= -100)
           {
               eInfo.YSpeed = (0 - eInfo.YSpeed);
           }
           Canvas.SetLeft(eInfo.CurEllipse, left + eInfo.XSpeed);
           Canvas.SetTop(eInfo.CurEllipse, top + eInfo.YSpeed);
       }





    }
}
