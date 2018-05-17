using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.ComponentModel;

namespace KeySearchExample
{
    public class ViewModel:INotifyPropertyChanged
    {
        List<string> list;
        public ViewModel()
        {
            ViewSource = new CollectionViewSource();
             list=new List<string>(){
                "h","helo","height","move"

            };

             ViewSource.Source = list;
            ViewSource.Filter += ViewSource_Filter;
        }

        void ViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextFilter))
            {
                e.Accepted = list.Contains(TextFilter);
                Console.WriteLine(TextFilter);
            }

        }
        public CollectionViewSource ViewSource { get; set; }

        string mTextFilter;
        public string TextFilter
        {
            get { return mTextFilter; }
            set
            {
                mTextFilter = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("TextFilter"));
                }
                ViewSource.View.Refresh();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
