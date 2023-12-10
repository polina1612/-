using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЗдоровьеТут.Model
{
    public class ListStatus: ObservableCollection<Статус_заказа>
    {
        public static АптекаEntities DataEntitiesStatus { get; set; }
        public ListStatus()
        {
            DataEntitiesStatus = new АптекаEntities();
            var statuses = DataEntitiesStatus.Статус_заказа;
            var queryStatus = from status in statuses select status;
            foreach(Статус_заказа stat in queryStatus)
            {
                this.Add(stat);
            }
        }
    }
}
