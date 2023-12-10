using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЗдоровьеТут.Model
{
    public class ListPolzovatel : ObservableCollection<Пользователь>
    {
        public static АптекаEntities DataEntitiesPolzovatel { get; set; }
        public ListPolzovatel()
        {
            DataEntitiesPolzovatel = new АптекаEntities();
            var pols = DataEntitiesPolzovatel.Пользователь;
            var queryPolzovatel = from pol in pols select pol;
            foreach (Пользователь p in queryPolzovatel)
            {
                this.Add(p);
            }
        }
    }
}