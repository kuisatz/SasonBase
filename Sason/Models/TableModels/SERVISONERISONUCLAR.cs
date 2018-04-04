using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Table;
using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Extensions;

namespace SasonBase.Sason.Models.TableModels
{
    [Serializable()]
    public class SERVISONERISONUCLAR : SasonBase.Sason.Tables.Table_SERVISONERISONUCLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISONERISONUCLAR>
        {
            Dictionary<Decimal, SERVISONERISONUCLAR> dict = new Dictionary<Decimal, SERVISONERISONUCLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISONERISONUCLAR> items) : base(items) { }


            public SERVISONERISONUCLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISONERISONUCLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISONERISONUCLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISONERISONUCLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISONERISONUCLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISONERISONUCLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISONERISONUCLAR> Select
        {
            get { return R.Query<SERVISONERISONUCLAR>(); }
        }

        public static SERVISONERISONUCLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISONERISONUCLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISONERISONUCLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISONERISONUCLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISONERISONUCLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISONERISONUCLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

