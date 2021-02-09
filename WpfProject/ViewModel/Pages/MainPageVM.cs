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

        private Customer _FinalisedCustomer;
        public Customer FinalisedCustomer
        {
            get { return _FinalisedCustomer; }
            set
            {
                _FinalisedCustomer = value;
                RaisePropertyChanged(() => FinalisedCustomer);
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
        public ICommand ClickFinalise
        {
            get
            {
                return new DelegateCommand((obj) => {
                    SwitchToFinalise();
                    FinalisedCustomer = SelectedCustomer;
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
                return new DelegateCommand((obj) => { CustomerList = CustomerMethods.Load(CustomerList, SaveText); });
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
        public ICommand ClickAddingBack
        {
            get
            {
                return new DelegateCommand((obj) => {
                    SwitchToListBox();
                });
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
            ListBoxVisibility = ConstLib.Visible;
            FinaliseMenuVisibility = ConstLib.Visible;
            AddMenuVisibility = ConstLib.Hidden;
        }

        public MainPageVM()
        {
            SaveText = new TextLine();
            ListBoxVisibility = ConstLib.Visible;
            FinaliseMenuVisibility = ConstLib.Hidden;
            AddMenuVisibility = ConstLib.Hidden;
            //ListBoxVisibility = "Hidden";
            //FinaliseMenuVisibility = "Visible";
            UpdateTime = 10;
            CustomerList = CustomerMethods.Init_Customer();
            //CustomerList = CustomerMethods.Load(CustomerList, SaveText);

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(UpdateTime).Wait();
                    CustomerMethods.Update(CustomerList);
                }
            });
        }
    }
}
