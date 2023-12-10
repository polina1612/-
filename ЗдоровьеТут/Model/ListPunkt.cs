using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЗдоровьеТут.Model
{
    public class ListPunkt : ObservableCollection<Пункт_Выдачи>
    {
        public static АптекаEntities DataEntitiesPunkt { get; set; }
        public ListPunkt()
        {
            DataEntitiesPunkt = new АптекаEntities();
            var punkts = DataEntitiesPunkt.Пункт_Выдачи;
            var queryPolzovatel = from punkt in punkts select punkt;
            foreach (Пункт_Выдачи pu in queryPolzovatel)
            {
                this.Add(pu);
            }
        }
    }
}