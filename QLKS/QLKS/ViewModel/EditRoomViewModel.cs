using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class EditRoomViewModel : BaseViewModel
    {
        public ICommand EditCommand { get; set; }
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

        public EditRoomViewModel(ROOM room)
        {
            ListCategory = new ObservableCollection<CATEGORY_ROOM>(DataProvider.Ins.DB.CATEGORY_ROOM);
            var Cate = DataProvider.Ins.DB.CATEGORY_ROOM.Where(x => x.IdCategoryRoom == room.IdCategoryRoom).SingleOrDefault();
            SelectedCategory = room.CATEGORY_ROOM;

            EditCommand = new RelayCommand<wd_EditRoom>(
                (p) =>
                {

                    var Temp = DataProvider.Ins.DB.ROOMs.Where(x => x.Name == p.txbName.Text);
                    if ((Temp == null || Temp.Count() != 0) && p.txbName.Text != room.Name) return false;
                    if (string.IsNullOrEmpty(p.txbName.Text) || string.IsNullOrEmpty(p.cbCategory.Text))
                        return false;
                    if (p.txbName.Text == room.Name && SelectedCategory == room.CATEGORY_ROOM) return false;
                    Regex regex = new Regex(@"^[0-9]+$");
                    if (room == null) return false;
                    return true;

                },
                (p) =>
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin phụ tùng", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        var List = DataProvider.Ins.DB.ROOMs.Where(x => x.IdRoom == room.IdRoom).SingleOrDefault();
                        List.Name = p.txbName.Text;
                        List.IdCategoryRoom = SelectedCategory.IdCategoryRoom;
                        DataProvider.Ins.DB.SaveChanges();
                        OnPropertyChanged("List");
                        IsClose = false;
                        p.Close();
                    }
                }
                );
        }

    }
}
