using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QLKS.DATA;
using QLKS.Model;

namespace QLKS.ViewModel
{
    public class EditRoomCategoryViewModel : BaseViewModel
    {
        public ICommand EditCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        private CATEGORY_ROOM _category { get; set; }

        public CATEGORY_ROOM category { get => _category; set { _category = value; OnPropertyChanged(); } }

        private bool _check { get; set; }
        public bool check { get => _check; set { _check = value; OnPropertyChanged(); } }

        private bool _IsClose { get; set; }
        public bool IsClose { get => _IsClose; set { _IsClose = value; OnPropertyChanged(); } }
        public EditRoomCategoryViewModel(CATEGORY_ROOM cate)
        {
            GetModel get = new GetModel();
            EditCommand = new RelayCommand<wd_EditCategoryRoom>(
                (p) =>
                {

                    var Temp = DataProvider.Ins.DB.CATEGORY_ROOM.Where(x => x.Name == p.txbName.Text);
                    if ((Temp == null || Temp.Count() != 0) && p.txbName.Text != cate.Name) return false;
                    if (string.IsNullOrEmpty(p.txbName.Text) || string.IsNullOrEmpty(p.txbBeds.Text) || string.IsNullOrEmpty(p.txbPriceDay.Text) || string.IsNullOrEmpty(p.txbPriceHour.Text))
                        return false;
                    if (p.txbName.Text == cate.Name && p.txbBeds.Text == cate.Beds.ToString() && p.txbPriceHour.Text == cate.Price_Hour.ToString() && p.txbPriceDay.Text == cate.Price_Day.ToString()) return false;
                    Regex regex = new Regex(@"^[0-9]+$");
                    if (cate == null) return false;
                    return true;

                },
                (p) =>
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin loại phòng", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        var List = get.getCategoryRoom(cate.IdCategoryRoom);
                        EditModel editModel=new EditModel();
                        editModel.EditCategoryRoom(List,p.txbName.Text, p.txbBeds.Text, p.txbPriceHour.Text, p.txbPriceDay.Text);
                        OnPropertyChanged("List");
                        IsClose = false;
                        p.Close();
                    }
                }
                );

            CloseCommand = new RelayCommand<wd_EditCategoryRoom>(
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
