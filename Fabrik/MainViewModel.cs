using Fabrik.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrik
{
   public  class MainViewModel
    {
       public MainViewModel()
       {
           dbContext = new FabrikDb();
           var o = dbContext.Workers.ToList();
       }
       FabrikDb dbContext { get; set; }

       public ObservableCollection<Worker> Workers { get { return dbContext.Workers.Local; } }

       public void AddPerson(string name,string code)
       {
           dbContext.Workers.Add(new Models.Worker() { Name = name , Code = code});
           dbContext.SaveChanges();
       }
    }
}
