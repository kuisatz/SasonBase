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
    public class AYRISTIRMADETAYLAR : SasonBase.Sason.Tables.Table_AYRISTIRMADETAYLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<AYRISTIRMADETAYLAR>
        {
            Dictionary<Decimal, AYRISTIRMADETAYLAR> dict = new Dictionary<Decimal, AYRISTIRMADETAYLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<AYRISTIRMADETAYLAR> items) : base(items) { }


            public AYRISTIRMADETAYLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public AYRISTIRMADETAYLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<AYRISTIRMADETAYLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<AYRISTIRMADETAYLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(AYRISTIRMADETAYLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(AYRISTIRMADETAYLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<AYRISTIRMADETAYLAR> Select
        {
            get { return R.Query<AYRISTIRMADETAYLAR>(); }
        }

        public static AYRISTIRMADETAYLAR SelectItem(Decimal ID)
        {
            return R.Query<AYRISTIRMADETAYLAR>().First(t => t.ID == ID);
        }

        public static List<AYRISTIRMADETAYLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<AYRISTIRMADETAYLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<AYRISTIRMADETAYLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<AYRISTIRMADETAYLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

