using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfCustomers_New.Models
{
    class TypesOfTurnOver
    {
        public string ID { get; set; }
        public string TypeName { get; set; }
        public static ObservableCollection<TypesOfTurnOver> ListOfTurnOvers { get; set; }

        public TypesOfTurnOver(string id, string typeName)
        {
            this.ID = id;
            this.TypeName = typeName;
        }

        public static ObservableCollection<TypesOfTurnOver> GetTypeOfTyrnovers()
        {
            ObservableCollection<TypesOfTurnOver> lst = new ObservableCollection<TypesOfTurnOver>();
            lst.Add(new TypesOfTurnOver("1", "Income"));
            lst.Add(new TypesOfTurnOver("2", "Expense"));
            ListOfTurnOvers = lst;

            return ListOfTurnOvers;
        }

        public static TypesOfTurnOver Get_By_ID(string ID)
        {
            var result = ListOfTurnOvers.Where(x => x.ID.Equals(ID)).FirstOrDefault();
            return result;
        }



    }
}
