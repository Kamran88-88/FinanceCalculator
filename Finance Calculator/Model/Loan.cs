using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Finance_Calculator.Model
{
   public class Loan:INotifyPropertyChanged
    {
       
        public ObservableCollection<int> Periods { get; set; }
        public Loan()
        {
            
            Periods = new ObservableCollection<int>
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,34,35,36
            };
        }

        private double ltv;

        public double LTV
        {
            get { return ltv; }
            set { ltv = value;
                OnPropertyChanged();
            }
        }

        private string ltvstring;

        public string LTVstring
        {
            get { return ltvstring; }
            set { ltvstring = value;
                OnPropertyChanged();
            }
        }



        private double comission;
        public double Comission
        {
            get { return comission; }
            set { comission = value;
                OnPropertyChanged();
            }
        }

        private double period;
        public double Period
        {
            get { return period; }
            set { period = value;
                OnPropertyChanged();
            }
        }

        private double percent;
        public double Percent
        {
            get { return percent; }
            set
            {
                percent = value;
                OnPropertyChanged();
            }
        }

        private double sum;
        public double Sum
        {
            get { return sum; }
            set
            {
                sum = value;
                OnPropertyChanged();
            }
        }

        private double pledgesumm;
        public double PledgeSumm
        {
            get { return pledgesumm; }
            set
            {
                pledgesumm = value;
                OnPropertyChanged();
            }
        }






        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
