using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfCustomers_New.Models
{
    class TypeOfTransfers
    {
        public string ID { get; set; }
        public string TypeName { get; set; }
       
        public static ObservableCollection<TypeOfTransfers> ListOfTransfers { get; set; }

        private TypeOfTransfers(string id, string typeName)
        {
            this.ID = id;
            this.TypeName = typeName;
        }

        public static ObservableCollection<TypeOfTransfers> GetTypeOfTransfers() 
        {
            ObservableCollection<TypeOfTransfers> lst = new ObservableCollection<TypeOfTransfers>(); 
            lst.Add(new TypeOfTransfers("1", "Deposit"));
            lst.Add(new TypeOfTransfers("2", "Transfer"));
            ListOfTransfers = lst;

            return ListOfTransfers;
        }

        public static TypeOfTransfers Get_By_ID(string ID)
        {
            var result = ListOfTransfers.Where(x=>x.ID.Equals(ID)).FirstOrDefault();
            return result;
        }


    }

}
