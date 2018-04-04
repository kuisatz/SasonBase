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
    public class BAKIMGRUPLAR : SasonBase.Sason.Tables.Table_BAKIMGRUPLAR.PublicItem
    {
        public string SplitKod1
        {
            get
            {
                return KOD.Replace(" ", "").split('-').value(0);
            }
        }

        public string SplitKod2
        {
            get
            {
                return KOD.Replace(" ", "").split('-').value(1);
            }
        }


        public class CONTAINER : Antibiotic.Collections.ListContainer<BAKIMGRUPLAR>
        {
            Dictionary<Decimal, BAKIMGRUPLAR> dict = new Dictionary<Decimal, BAKIMGRUPLAR>();
            Dictionary<string, BAKIMGRUPLAR> kodDict = new Dictionary<string, BAKIMGRUPLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BAKIMGRUPLAR> items) : base(items) { }


            public BAKIMGRUPLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BAKIMGRUPLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BAKIMGRUPLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BAKIMGRUPLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }


            public BAKIMGRUPLAR GetFromCode(string kod)
            {
                return kodDict.find(kod);
            }

            protected override void OnBeforeInsert(BAKIMGRUPLAR item, ref bool cancel)
            {
                kodDict.set(item.KOD, item, out cancel);
                if (!cancel)
                    dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BAKIMGRUPLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BAKIMGRUPLAR> Select
        {
            get { return R.Query<BAKIMGRUPLAR>(); }
        }

        public static BAKIMGRUPLAR SelectItem(Decimal ID)
        {
            return R.Query<BAKIMGRUPLAR>().First(t => t.ID == ID);
        }

        public static List<BAKIMGRUPLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BAKIMGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BAKIMGRUPLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BAKIMGRUPLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

