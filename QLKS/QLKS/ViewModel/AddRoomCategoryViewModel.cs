using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class AddRoomCategoryViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        private CATEGORY_ROOM _category { get; set; }

        public CATEGORY_ROOM category { get => _category; set { _category = value; OnPropertyChanged(); } }

        private bool _check { get; set; }
        public bool check { get => _check; set { _check = value; OnPropertyChanged(); } }

        private bool _IsClose { get; set; }
        public bool IsClose { get => _IsClose; set { _IsClose = value; OnPropertyChanged(); } }

        public AddRoomCategoryViewModel()
        {
            AddCommand = new RelayCommand<wd_AddNewCategoryRoom>(
                (p) =>
                {
                    var List = DataProvider.Ins.DB.ROOMs.Where(x => x.Name == p.txbName.Text);
                    if (List == null || List.Count() != 0) return false;
                    if (string.IsNullOrEmpty(p.txbName.Text) || string.IsNullOrEmpty(p.txbBeds.Text) || string.IsNullOrEmpty(p.txbPriceDay.Text) || string.IsNullOrEmpty(p.txbPriceHour.Text))
                        return false;
                    Regex regex = new Regex(@"^[0-9]+$");
                    return true;
                },
                (p) =>
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn thêm loại phòng mới", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        category = new CATEGORY_ROOM() { Name = p.txbName.Text, Beds = Int32.Parse(p.txbBeds.Text), Price_Day = Int32.Parse(p.txbPriceDay.Text), Price_Hour = Int32.Parse(p.txbPriceHour.Text) };
                        DataProvider.Ins.DB.CATEGORY_ROOM.Add(category);
                        DataProvider.Ins.DB.SaveChanges();
                        check = true;
                        IsClose = false;
                        p.Close();
                    }
                });
            CloseCommand = new RelayCommand<wd_AddNewCategoryRoom>(
            (p) =>
            { return true; },
            (p) =>
            {

                p.Close();
            }
            );
        }


    }
}
