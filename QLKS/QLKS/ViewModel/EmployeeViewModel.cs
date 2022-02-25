using QLKS.Convert;
using QLKS.Model;
using QLKS.UserControlss;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class EmployeeViewModel : BaseViewModel
    {
        public ICommand OpenAddCommand { get; set; }

        public ICommand OpenEditCommand { get; set; }

        public ICommand SearchCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        private string _Name { get; set; }

        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private ObservableCollection<EMPLOYEE> _ListEmployee { get; set; }

        public ObservableCollection<EMPLOYEE> ListEmployee { get => _ListEmployee; set { _ListEmployee = value; OnPropertyChanged(); } }

        private EMPLOYEE _SelectedItem { get; set; }
        public EMPLOYEE SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (_SelectedItem != null)
                {
                    Name = _SelectedItem.Name.ToString();

                }
                OnPropertyChanged();
            }
        }

        public EmployeeViewModel()
        {
            Load();
            OpenAddCommand = new RelayCommand<MainWindow>((p) => true, (p) =>
            {

                wd_AddEmployee wdAddEmployee= new wd_AddEmployee();

                
                wdAddEmployee.ShowDialog();

                AddEmployeeViewModel add = wdAddEmployee.DataContext as AddEmployeeViewModel;
                if (add.check)
                    ListEmployee.Insert(0, add.employee);
            });
            OpenEditCommand = new RelayCommand<MainWindow>((p) => {
                if (SelectedItem == null) return false;
                return true;
            }, (p) =>
            {
                wd_EditEmployee wdEditEmployee = new wd_EditEmployee(SelectedItem);

                wdEditEmployee.txbName.Text = SelectedItem.Name;
                wdEditEmployee.txbCCCD.Text = SelectedItem.CCCD.ToString();
                wdEditEmployee.txbPhone.Text = SelectedItem.Phone.ToString();
                wdEditEmployee.txbAddress.Text = SelectedItem.Address.ToString();
                wdEditEmployee.txbPosition.Text = SelectedItem.Position.ToString();
                wdEditEmployee.txbSalary.Text = SelectedItem.Salary.ToString();
                wdEditEmployee.cbSex.Text = SelectedItem.Sex.ToString();
                wdEditEmployee.dtpBirth.SelectedDate = SelectedItem.BirthDay;
                wdEditEmployee.ShowDialog();
                Load();
            });
            DeleteCommand = new RelayCommand<MainWindow>((p) =>
            {
                if (SelectedItem == null) return false;
                return true;
            }, (p) =>
            {
                ObservableCollection<RESERVATION> list = new ObservableCollection<RESERVATION>(DataProvider.Ins.DB.RESERVATIONs.Where(x => x.IdEmployee == SelectedItem.IdEmployee));
                if(list.Count == 0)
                {
                    MessageBox.Show("Không thể xóa nhân viên này", "Thông báo", MessageBoxButton.OK);
                }
                else
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?","Xóa nhân viên", MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        DeleteModel delete = new DeleteModel();
                        delete.EMPLOYEE(SelectedItem);
                        ListEmployee.Remove(SelectedItem);
                    }    
                }    
            });
            SearchCommand = new RelayCommand<uc_Employee>((p) =>
            {
                return true;
            }, (p) =>
            {
                UnicodeConvert uni = new UnicodeConvert();

                ObservableCollection<EMPLOYEE> _ListTemp = new ObservableCollection<EMPLOYEE>();
                ObservableCollection<EMPLOYEE> _ListNew = new ObservableCollection<EMPLOYEE>(DataProvider.Ins.DB.EMPLOYEEs);

                foreach (var item in _ListNew)
                {
                    if ((string.IsNullOrEmpty(p.txbNameSearch.Text) || (!string.IsNullOrEmpty(p.txbNameSearch.Text) && uni.RemoveUnicode(item.Name).ToLower().Contains(uni.RemoveUnicode(p.txbNameSearch.Text).ToLower())))
                        && (string.IsNullOrEmpty(p.txbPhoneSearch.Text) || (!string.IsNullOrEmpty(p.txbPhoneSearch.Text) && uni.RemoveUnicode(item.Phone).ToLower().Contains(uni.RemoveUnicode(p.txbPhoneSearch.Text).ToLower()))))
                    {
                        _ListTemp.Add(item);
                    }
                }
                ListEmployee = _ListTemp;
            });
            RefreshCommand = new RelayCommand<MainWindow>((p) =>
            {
                return true;
            }, (p) =>
            {
                Load();
            });
        }
        void Load()
        {
            ListEmployee = new ObservableCollection<EMPLOYEE>(DataProvider.Ins.DB.EMPLOYEEs);
        }
    }
}
