using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Documents;
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
            var productions = DbContext.Productions
                .Include("Worker")
                .Include("Product")
                .Include("Area.Workshop")
                .ToList();
            var workers = DbContext.Workers.ToList();
            var products = DbContext.Products.ToList();
            var areas = DbContext.Areas.ToList();
            var workshops = DbContext.Workshops.ToList();

            ReportStartDate = DateTime.Today.AddYears(-1);
            NewProdictionDateTime = ReportEndDate = DateTime.Today;
        }
        FabrikDb DbContext { get; set; }

        public ObservableCollection<Worker> Workers { get { return DbContext.Workers.Local; } }
        public ObservableCollection<Product> Products { get { return DbContext.Products.Local; } }
        public ObservableCollection<Area> Areas { get { return DbContext.Areas.Local; } }
        public ObservableCollection<Workshop> Workshops { get { return DbContext.Workshops.Local; } }

        private List<Worker> _report;

        public List<Worker> Report
        {
            get { return _report; }
            set
            {
                _report = value;
                RaisePropertyChanged(() => Report);
            }
        }

        private void UpdateReport()
        {
            Report = DbContext.Productions.Local.Where(
                pro => pro.DateTime <= ReportEndDate && pro.DateTime >= ReportStartDate && pro.Product == ReportProduct)
                .Select(pro => pro.Worker)
                .Distinct().ToList();
        }
        private Product _reportProduct;

        public Product ReportProduct
        {
            get { return _reportProduct; }
            set
            {
                _reportProduct = value;
                RaisePropertyChanged(() => ReportProduct);
                UpdateReport();
            }
        }

        private DateTime _reportStartDate;

        public DateTime ReportStartDate
        {
            get { return _reportStartDate; }
            set
            {
                _reportStartDate = value;
                RaisePropertyChanged(() => ReportStartDate);
                UpdateReport();
            }
        }

        private DateTime _reportEndDate;

        public DateTime ReportEndDate
        {
            get { return _reportEndDate; }
            set
            {
                _reportEndDate = value;
                RaisePropertyChanged(() => ReportEndDate);
                UpdateReport();
            }
        }

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