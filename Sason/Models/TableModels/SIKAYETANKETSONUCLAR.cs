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
    public class SIKAYETANKETSONUCLAR : SasonBase.Sason.Tables.Table_SIKAYETANKETSONUCLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SIKAYETANKETSONUCLAR>
        {
            Dictionary<Decimal, SIKAYETANKETSONUCLAR> dict = new Dictionary<Decimal, SIKAYETANKETSONUCLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SIKAYETANKETSONUCLAR> items) : base(items) { }


            public SIKAYETANKETSONUCLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SIKAYETANKETSONUCLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SIKAYETANKETSONUCLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SIKAYETANKETSONUCLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SIKAYETANKETSONUCLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SIKAYETANKETSONUCLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SIKAYETANKETSONUCLAR> Select
        {
            get { return R.Query<SIKAYETANKETSONUCLAR>(); }
        }

        public static SIKAYETANKETSONUCLAR SelectItem(Decimal ID)
        {
            return R.Query<SIKAYETANKETSONUCLAR>().First(t => t.ID == ID);
        }

        public static List<SIKAYETANKETSONUCLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SIKAYETANKETSONUCLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SIKAYETANKETSONUCLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SIKAYETANKETSONUCLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

