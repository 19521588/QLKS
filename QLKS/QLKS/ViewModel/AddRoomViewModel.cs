using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.ViewModel;
using QLKS.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Text.RegularExpressions;

namespace QLKS.ViewModel
{
    public class AddRoomViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        private ObservableCollection<CATEGORY_ROOM> _ListCategory { get; set; }

        public ObservableCollection<CATEGORY_ROOM> ListCategory { get => _ListCategory; set { _ListCategory = value; OnPropertyChanged(); } }

        private ROOM _room { get; set; }

        public ROOM room { get => _room; set { _room = value; OnPropertyChanged(); } }

        private CATEGORY_ROOM _SelectedCategory { get; set; }

        public CATEGORY_ROOM SelectedCategory { get => _SelectedCategory; set { _SelectedCategory = value; OnPropertyChanged(); } }

        private bool _check { get; set; }
        public bool check { get => _check; set { _check = value; OnPropertyChanged(); } }

        private bool _IsClose { get; set; }
        public bool IsClose { get => _IsClose; set { _IsClose = value; OnPropertyChanged(); } }
        public AddRoomViewModel()
        {
            ListCategory = new ObservableCollection<CATEGORY_ROOM>(DataProvider.Ins.DB.CATEGORY_ROOM);
            AddCommand = new RelayCommand<wd_AddNewRoom>(
                (p) =>
                {
                    var List = DataProvider.Ins.DB.ROOMs.Where(x => x.Name == p.txbName.Text);
                    if (List == null || List.Count() != 0) return false;
                    if (string.IsNullOrEmpty(p.txbName.Text) || string.IsNullOrEmpty(p.cbCategory.Text))
                        return false;
                    Regex regex = new Regex(@"^[0-9]+$");

                    return true;
                },
                (p) =>
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn thêm phòng mới", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        room = new ROOM() { Name = p.txbName.Text, IdCategoryRoom = SelectedCategory.IdCategoryRoom, Status = "Trống", Clean = "Không" };
                        DataProvider.Ins.DB.ROOMs.Add(room);
                        DataProvider.Ins.DB.SaveChanges();
                        check = true;
                        IsClose = false;
                        p.Close();
                    }
                });
            CloseCommand = new RelayCommand<wd_AddNewRoom>(
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
