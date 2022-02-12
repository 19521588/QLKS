using QLKS.UserControlss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class DialogCustomsViewModel:BaseViewModel
    {
        #region
        public ICommand BtnNoCommand { get; set; }
        public ICommand BtnYesCommand { get; set; }
        public ICommand BtnOkCommand { get; set; }
        private bool _VisBtnOk { get; set; }
        public bool VisBtnOk { get => _VisBtnOk; set { _VisBtnOk = value; OnPropertyChanged(); } }
        private bool _VisBtnYes { get; set; }
        public bool VisBtnYes { get => _VisBtnYes; set { _VisBtnYes = value; OnPropertyChanged(); } }
        private bool _VisBtnNo { get; set; }
        public bool VisBtnNo { get => _VisBtnNo; set { _VisBtnNo = value; OnPropertyChanged(); } }
        private string _MESS { get; set; }
        public string MESS { get => _MESS; set { _MESS = value; OnPropertyChanged(); } }
        #endregion

        public DialogCustomsViewModel()
        {
      
        }
        public DialogCustomsViewModel(string mess, string title, int mode) : this()
        {
            BtnNoCommand = new RelayCommand<DialogCustoms>((p) => { return true; }, (p) =>
            {
                p.Close();
            });
            BtnYesCommand = new RelayCommand<DialogCustoms>((p) => { return true; }, (p) =>
            {
                p.Close();
            });
            BtnOkCommand = new RelayCommand<DialogCustoms>((p) => { return true; }, (p) =>
            {
                p.Close();
            });
            try
            {
                MESS = mess;
                if (mode == 1)
                {
                    VisBtnOk = false;
                    VisBtnYes = true;
                    VisBtnNo = true;
                }
                else
                {
                    VisBtnOk = true;
                    VisBtnYes = false;
                    VisBtnNo = false;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Lỗi DialogCustom :" + ex.Message);
            }

        }
       
    }
}
