using Finance_Calculator.Model;
using Finance_Calculator.MyRelayCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Finance_Calculator.ViewModel
{
    public class LTVViewModel : INotifyPropertyChanged
    {
        public Loan Loan { get; set; }
        public RelayCommand ClickCommand { get; set; }
        public RelayCommand CheckCommand { get; set; }
        public RelayCommand AutoRegimeCommand { get; set; }
        public RelayCommand ManualRegimeCommand { get; set; }


        private bool checking;
        public bool Checking
        {
            get { return checking; }
            set { checking = value; OnPropertyChanged(); }
        }



        private bool isenable = true;
        public bool IsEnable
        {
            get { return isenable; }
            set
            {
                isenable = value;
                OnPropertyChanged();
            }
        }

        private bool isenable2 = false;
        public bool IsEnable2
        {
            get { return isenable2; }
            set
            {
                isenable2 = value;
                OnPropertyChanged();
            }
        }

        private bool manual=false;
        public bool Manual
        {
            get { return manual; }
            set { manual = value; }
        }


        public LTVViewModel()
        {
            Loan = new Loan();
            ClickCommand = new RelayCommand(Click);
            CheckCommand = new RelayCommand(ToCheck);
            AutoRegimeCommand = new RelayCommand(AutoRegime);
            ManualRegimeCommand = new RelayCommand(ManualRegime);
        }

        void ManualRegime(object a)
        {
            Manual = true;

            IsEnable = true;
            IsEnable2 = true;
        }

        void AutoRegime(object a)
        {
                Manual = false;
            ToCheck(a);
        }

        void ToCheck(object a)
        {
            if (Checking)
            {
                IsEnable = false;
                IsEnable2 = true;
            }
            else
            {
                IsEnable = true;
                IsEnable2 = false;
            }
        }

        void Click(object a)
        {
            if (IsEnable&& Manual == false) { 
            try
            {
                Loan.PledgeSumm = Loan.Sum;
                while (true)
                {
                    Loan.PledgeSumm++;
                    Loan.LTV = -(double)Math.Round((Financial.Pmt(Loan.Percent / 1200, Loan.Period, Loan.Sum) * Loan.Period - Loan.Comission) / Loan.PledgeSumm * 10000) / 100;
                    if (Loan.LTV <= 70)
                    {
                        break;
                    }
                }
            }
            catch (Exception)
            {
            }
           
            }
            else if(Manual==false)
            {
                try
                {
                    Loan.Sum = Loan.PledgeSumm;
                    while (true)
                    {
                        Loan.Sum--;
                        Loan.LTV = -(double)Math.Round((Financial.Pmt(Loan.Percent / 1200, Loan.Period, Loan.Sum) * Loan.Period - Loan.Comission) / Loan.PledgeSumm * 10000) / 100;
                        if (Loan.LTV <= 70)
                        {
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {               
                try
                {
                        Loan.LTV = -(double)Math.Round((Financial.Pmt(Loan.Percent / 1200, Loan.Period, Loan.Sum) * Loan.Period - Loan.Comission) / Loan.PledgeSumm * 10000) / 100;
                }
                catch (Exception)
                {
                }
            }

            Loan.LTVstring = Loan.LTV.ToString() + " %";
            if (Loan.LTV > 70)
            {
                MessageBox.Show("LTV əmsalı icazə verilən həddən yuxarıdır!");
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
