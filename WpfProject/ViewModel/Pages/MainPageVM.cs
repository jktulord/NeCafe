using Console_prototype;
using DevExpress.Mvvm;
using Model.Customer_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfProject.Model;
using WpfProject.ViewModel;

namespace WpfProject.ViewModel.Pages
{
    public class MainPageVM : ViewModelBase
    {

        private ObservableCollection<Customer> _CustomerList;
        public ObservableCollection<Customer> CustomerList
        {
            get { return _CustomerList; }
            set
            {
                _CustomerList = value;
                RaisePropertyChanged(() => CustomerList);
            }
        }

        private Customer _NewCustomer;
        public Customer NewCustomer
        {
            get { return _NewCustomer; }
            set
            {
                _NewCustomer = value;
                RaisePropertyChanged(() => NewCustomer);
            }
        }

        private Customer _SelectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _SelectedCustomer; }
            set
            {
                _SelectedCustomer = value;
                RaisePropertyChanged(() => CustomerList);
            }
        }

        private Customer _EditCustomer;
        public Customer EditCustomer
        {
            get { return _EditCustomer; }
            set
            {
                _EditCustomer = value;
                RaisePropertyChanged(() => EditCustomer);
            }
        }

        public String EditCustomerStartTimeString 
        {
            get 
            { 
                return EditCustomer.start_time.ToShortTimeString(); 
            }
        }
        public String EditCustomerElapsedTimeDouble
        {
            get
            {
                return Convert.ToString(Math.Round(EditCustomer.elapsed_time.TotalMinutes, 2))+" мин.";
            }
        }



        private int _UpdateTime;
        public int UpdateTime
        {
            get { return _UpdateTime; }
            set
            {
                _UpdateTime = value;
                RaisePropertyChanged(() => UpdateTime);
            }
        }

        private string _ListBoxVisibility;
        public string ListBoxVisibility
        {
            get { return _ListBoxVisibility; }
            set
            {
                _ListBoxVisibility = value;
                RaisePropertyChanged(() => ListBoxVisibility);
            }
        }

        private string _AddMenuVisibility;
        public string AddMenuVisibility
        {
            get { return _AddMenuVisibility; }
            set
            {
                _AddMenuVisibility = value;
                RaisePropertyChanged(() => AddMenuVisibility);
            }
        }

        private string _FinaliseMenuVisibility;
        public string FinaliseMenuVisibility
        {
            get { return _FinaliseMenuVisibility; }
            set
            {
                _FinaliseMenuVisibility = value;
                RaisePropertyChanged(() => FinaliseMenuVisibility);
            }
        }

        private bool _HourTariffIsChecked;
        public bool HourTariffIsChecked
        {
            get { return _HourTariffIsChecked; }
            set
            {
                _HourTariffIsChecked = value;
                RaisePropertyChanged(() => HourTariffIsChecked);
            }
        }

        private bool _MinuteTariffIsChecked;
        public bool MinuteTariffIsChecked
        {
            get { return _MinuteTariffIsChecked; }
            set
            {
                _MinuteTariffIsChecked = value;
                RaisePropertyChanged(() => MinuteTariffIsChecked);
            }
        }


        private TextLine _SaveText;
        public TextLine SaveText
        {
            get { return _SaveText; }
            set
            {
                _SaveText = value;
                RaisePropertyChanged(() => SaveText);
            }
        }

        // Команды сортировки
        public ICommand ClickSortById
        {
            get
            {
                return new DelegateCommand((obj) => {
                    CustomerSort.ById(CustomerList, false);
                });
            }
        }

        // Команды в главном подокне
        public ICommand ClickAdd
        {
            get
            {
                return new DelegateCommand((obj) => { 
                    ListBoxVisibility = ConstLib.Hidden;
                    FinaliseMenuVisibility = ConstLib.Hidden;
                    AddMenuVisibility = ConstLib.Visible;
                    NewCustomer = new Customer();
                });
            }
        }
        public ICommand ClickDelete
        {
            get
            {   
                return new DelegateCommand((obj) => {
                    if (SelectedCustomer != null)
                    {
                        CustomerList.Remove(CustomerList.Where(i => i.id == SelectedCustomer.id).Single());
                        CustomerMethods.Id_Restruct(CustomerList);
                    }
                });
            }
        }
        public ICommand ClickStop
        {
            get
            {
                return new DelegateCommand((obj) => { SelectedCustomer.Active = SelectedCustomer.Active ? false : true; });
            }
        }
        public ICommand ClickEdit
        {
            get
            {
                return new DelegateCommand((obj) => {
                    SwitchToFinalise();
                    EditCustomer = SelectedCustomer;
                });
            }
        }
        public ICommand ClickSave
        {
            get
            {
                return new DelegateCommand((obj) => { CustomerMethods.Save(CustomerList, SaveText); });
            }
        }
        public ICommand ClickLoad
        {
            get
            {
                return new DelegateCommand((obj) => { CustomerList = CustomerMethods.Load(CustomerList); });
            }
        }
        // Команды в подокне добавления
        public ICommand ClickAddingFinish
        {
            get
            {
                return new DelegateCommand((obj) => {
                    CustomerMethods.Add_Custom_Customer(CustomerList, NewCustomer, MinuteTariffIsChecked, HourTariffIsChecked);
                    SwitchToListBox(); 
                });
            }
        }
        public ICommand ClickBack
        {
            get
            {
                return new DelegateCommand((obj) => {
                    SwitchToListBox();
                });
            }
        }
        public ICommand ClickEditStop
        {
            get
            {
                return new DelegateCommand((obj) => { EditCustomer.Active = EditCustomer.Active ? false : true; });
            }
        }
        // Переключение подокон
        public void SwitchToListBox()
        {
            ListBoxVisibility = ConstLib.Visible;
            FinaliseMenuVisibility = ConstLib.Hidden;
            AddMenuVisibility = ConstLib.Hidden;
        }
        public void SwitchToAddMenu()
        {
            ListBoxVisibility = ConstLib.Hidden;
            FinaliseMenuVisibility = ConstLib.Hidden;
            AddMenuVisibility = ConstLib.Visible;
        }
        public void SwitchToFinalise()
        {
            ListBoxVisibility = ConstLib.Hidden;
            FinaliseMenuVisibility = ConstLib.Visible;
            AddMenuVisibility = ConstLib.Hidden;
        }
        public void Autoload()
        {
            try
            {
                CustomerList = CustomerMethods.Load(CustomerList);
                SaveText.Value = "Data Loaded";
            }
            catch
            {

                SaveText.Value = "Data created";
                CustomerList = CustomerMethods.Init_Customer();
            }
        }

        public MainPageVM()
        {
            SaveText = new TextLine();
            SwitchToAddMenu();
            UpdateTime = 10;
            CustomerList = CustomerMethods.Init_Customer();
            Autoload();
            EditCustomer = new Customer("Иван", 0, DateTime.Now, new Model.Tariff_Model.Tariff());


            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(UpdateTime).Wait();
                    CustomerMethods.Update(CustomerList);
                    RaisePropertyChanged(() => EditCustomerElapsedTimeDouble);
                    RaisePropertyChanged(() => EditCustomerStartTimeString);
                }
            });
        }
    }
}
