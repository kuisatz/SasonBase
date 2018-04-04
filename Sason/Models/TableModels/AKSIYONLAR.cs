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
    public class AKSIYONLAR : SasonBase.Sason.Tables.Table_AKSIYONLAR.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<AKSIYONLAR>
        {
            Dictionary<Decimal, AKSIYONLAR> dict = new Dictionary<Decimal, AKSIYONLAR>();
            Dictionary<string, AKSIYONLAR> aksiyonNoDict = new Dictionary<string, AKSIYONLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<AKSIYONLAR> items) : base(items) { }


            public AKSIYONLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public AKSIYONLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<AKSIYONLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<AKSIYONLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public AKSIYONLAR GetFromAksiyonNo(string aksiyonNo)
            {
                return aksiyonNoDict.find(aksiyonNo.trim().ToUpper());
            }

            protected override void OnBeforeInsert(AKSIYONLAR item, ref bool cancel)
            {
                aksiyonNoDict.set(item.AKSIYONNO.trim().ToUpper(), item, out cancel);
                if (!cancel)
                    dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(AKSIYONLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<AKSIYONLAR> Select
        {
            get { return R.Query<AKSIYONLAR>(); }
        }

        public static AKSIYONLAR SelectItem(Decimal ID)
        {
            return R.Query<AKSIYONLAR>().First(t => t.ID == ID);
        }

        public static List<AKSIYONLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<AKSIYONLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<AKSIYONLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<AKSIYONLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}