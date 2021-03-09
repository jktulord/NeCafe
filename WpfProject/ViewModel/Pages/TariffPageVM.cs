using Console_prototype;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfProject.Model;
using WpfProject.Model.Tariff_Model;
using WpfProject.ViewModel.Other;
using static WpfProject.Model.ConstLib;

namespace WpfProject.ViewModel.Pages
{
    class TariffPageVM : ViewModelBase
    {
        private ObservableCollection<Tariff> _TariffList;
        public ObservableCollection<Tariff> TariffList
        {
            get { return _TariffList; }
            set
            {
                _TariffList = value;
                RaisePropertyChanged(() => TariffList);
            }
        }

        private Tariff _SelectedTariff;
        public Tariff SelectedTariff
        {
            get { return _SelectedTariff; }
            set
            {
                _SelectedTariff = value;
                RaisePropertyChanged(() => SelectedTariff);
            }
        }

        private CalculationTypes _calculation_types;
        public  CalculationTypes calculation_types
        {
            get { return _calculation_types; }
            set
            {
                _calculation_types = value;
                RaisePropertyChanged(() => calculation_types);
            }
        }

        private ConditionTypes _condition_types;
        public ConditionTypes condition_types
        {
            get { return _condition_types; }
            set
            {
                _condition_types = value;
                RaisePropertyChanged(() => condition_types);
            }
        }

        private ConditionResultTypes _condition_result_types;
        public ConditionResultTypes condition_result_types
        {
            get { return _condition_result_types; }
            set
            {
                _condition_result_types = value;
                RaisePropertyChanged(() => condition_result_types);
            }
        }

        private TarrifStateManager _state;
        public TarrifStateManager state
        {
            get { return _state; }
            set
            {
                _state = value;
                RaisePropertyChanged(() => state);
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


        public ICommand Add_command
        {
            get
            {
                return new DelegateCommand((obj) => {
                    SelectedTariff = TariffMethods.get_def_tariff();
                    state.SwitchToAddMenu();
                });
            }
        }
        public ICommand Edit_command
        {
            get
            {
                return new DelegateCommand((obj) => {
                    state.SwitchToFinalise();
                });
            }
        }
        public ICommand Cancel_command
        {
            get
            {
                return new DelegateCommand((obj) => {
                    state.SwitchToListBox();
                });
            }
        }
        public ICommand Confirm_command
        {
            get
            {
                return new DelegateCommand((obj) => {
                    TariffList.Add(SelectedTariff);
                    state.SwitchToListBox();
                });
            }
        }

        public ICommand Save_command
        {
            get
            {
                return new DelegateCommand((obj) => {
                    TariffMethods.Save(TariffList);
                });
            }
        }

       public void Autoload()
        {
            try
            {
                TariffList = TariffMethods.Load();
                SaveText.Value = "Data Loaded";
            }
            catch
            {

                SaveText.Value = "Data created";
                TariffList = new ObservableCollection<Tariff>();
                TariffList.Add(TariffMethods.get_def_tariff());
                TariffList.Add(TariffMethods.get_def_tariff());
                TariffList.Add(TariffMethods.get_def_tariff());
            }
        }
        public TariffPageVM()
        {
            calculation_types = new CalculationTypes();
            condition_types = new ConditionTypes();
            condition_result_types = new ConditionResultTypes();
            SaveText = new TextLine();
            state = new TarrifStateManager();
            Autoload();

            int UpdateTime = 100;
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(UpdateTime).Wait();
                    TariffMethods.Update(TariffList);
                }
            });
        }
    }
}
