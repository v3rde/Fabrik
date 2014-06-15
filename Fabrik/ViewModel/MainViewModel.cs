using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Fabrik.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Fabrik.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            DbContext = new FabrikDb();
            //var o = DbContext.Workers.ToList();
        }
        FabrikDb DbContext { get; set; }

        public ObservableCollection<Worker> Workers { get { return DbContext.Workers.Local; } }
        public ObservableCollection<Product> Products { get { return DbContext.Products.Local; } }
        public ObservableCollection<Area> Areas { get { return DbContext.Areas.Local; } }

        private Area _area;

        public Area NewProductionArea
        {
            get { return _area; }
            set
            {
                _area = value;
                RaisePropertyChanged(() => NewProductionArea);
            }
        }
        private Worker _newProductionWorker;
        public Worker NewProductionWorker
        {
            get { return _newProductionWorker; }
            set
            {
                _newProductionWorker = value;
                RaisePropertyChanged(() => NewProductionWorker);
            }
        }
        private Product _newProductionProduct;
        public Product NewProductionProduct
        {
            get { return _newProductionProduct; }
            set
            {
                _newProductionProduct = value;
                RaisePropertyChanged(() => NewProductionProduct);
            }
        }

        private string _newProductionQuantity;
        public string NewProductionQuantity
        {
            get { return _newProductionQuantity; }
            set
            {
                _newProductionQuantity = value;
                RaisePropertyChanged(() => NewProductionQuantity);
            }
        }

        private DateTime _newProdictionDateTime;
        public DateTime NewProdictionDateTime
        {
            get { return _newProdictionDateTime; }
            set
            {
                _newProdictionDateTime = value;
                RaisePropertyChanged(() => NewProdictionDateTime);
            }
        }

        private string _newProductName;
        public string NewProductName
        {
            get { return _newProductName; }
            set
            {
                _newProductName = value;
                RaisePropertyChanged(() => NewProductName);
            }
        }

        private string _newProductMetric;
        public string NewProductMetric
        {
            get { return _newProductMetric; }
            set
            {
                _newProductMetric = value;
                RaisePropertyChanged(() => NewProductMetric);
            }
        }

        private string _newProductPrice;
        public string NewProductPrice
        {
            get { return _newProductPrice; }
            set
            {
                _newProductPrice = value;
                RaisePropertyChanged(() => NewProductPrice);
            }
        }

        private string _newWorkerName;
        public string NewWorkerName
        {
            get { return _newWorkerName; }
            set
            {
                _newWorkerName = value;
                RaisePropertyChanged(() => NewWorkerName);
            }
        }

        private string _newWorkerCode;
        public string NewWorkerCode
        {
            get { return _newWorkerCode; }
            set
            {
                _newWorkerCode = value;
                RaisePropertyChanged(() => NewWorkerCode);
            }
        }

        private string _newAreaName;
        public string NewAreaName
        {
            get { return _newAreaName; }
            set
            {
                _newAreaName = value;
                RaisePropertyChanged(() => NewAreaName);
            }
        }

        private string _newWorkshopName;
        public string NewWorkshopName
        {
            get { return _newWorkshopName; }
            set
            {
                _newWorkshopName = value;
                RaisePropertyChanged(() => NewWorkshopName);
            }
        }

        private Workshop _newAreaWorkshop;
        public Workshop NewAreaWorkshop
        {
            get { return _newAreaWorkshop; }
            set
            {
                _newAreaWorkshop = value;
                RaisePropertyChanged(() => NewAreaWorkshop);
            }
        }

        private RelayCommand _addProductCommand;
        public ICommand AddProductCommand
        {
            get { return _addProductCommand ?? (_addProductCommand = new RelayCommand(AddProduct)); }
        }
        private void AddProduct()
        {
            int newProductPriceInt;
            if (NewProductName.Length == 0 || NewProductMetric.Length == 0 || !int.TryParse(NewProductPrice, out newProductPriceInt)) return;

            DbContext.Products.Add(new Product { Name = NewProductName, Metric = NewProductMetric, Price = newProductPriceInt });
            DbContext.SaveChanges();

            NewProductPrice = string.Empty;
            NewProductMetric = string.Empty;
            NewProductName = string.Empty;
        }

        private RelayCommand _addProductionCommand;
        public ICommand AddProductionCommand
        {
            get { return _addProductionCommand ?? (_addProductionCommand = new RelayCommand(AddProduction)); }
        }
        private void AddProduction()
        {
            int newProductionQuantity;

            if (NewProductionQuantity.Length <= 0 || !int.TryParse(NewProductionQuantity, out newProductionQuantity)) return;

            DbContext.Productions.Add(new Production { Area = NewProductionArea, Product = NewProductionProduct, Worker = _newProductionWorker, Quantity = newProductionQuantity });
            DbContext.SaveChanges();

            NewProductionQuantity = string.Empty;
        }

        private RelayCommand _addWorkerCommand;
        public ICommand AddWorkerCommand
        {
            get { return _addWorkerCommand ?? (_addWorkerCommand = new RelayCommand(AddWorker)); }
        }
        private void AddWorker()
        {
            if (NewWorkerCode.Length == 0 || NewWorkerName.Length == 0) return;

            DbContext.Workers.Add(new Worker { Name = NewWorkerName, Code = NewWorkerCode });
            DbContext.SaveChanges();

            NewWorkerName = string.Empty;
            NewWorkerCode = string.Empty;
        }

        private RelayCommand _addAreaCommand;
        public ICommand AddAreaCommand
        {
            get { return _addAreaCommand ?? (_addAreaCommand = new RelayCommand(AddArea)); }
        }
        private void AddArea()
        {
            if (NewAreaName.Length <= 0) return;

            DbContext.Areas.Add(new Area { Name = NewAreaName, Workshop = NewAreaWorkshop });
            DbContext.SaveChanges();

            NewAreaName = string.Empty;
        }

        private RelayCommand _addWorkshopCommand;
        public ICommand AddWorkshopCommand
        {
            get { return _addWorkshopCommand ?? (_addWorkshopCommand = new RelayCommand(AddWorkshop)); }
        }
        private void AddWorkshop()
        {

            if (NewWorkshopName.Length <= 0) return;

            DbContext.Workshops.Add(new Workshop { Name = NewWorkshopName });
            DbContext.SaveChanges();

            NewWorkshopName = string.Empty;

        }

    }
}