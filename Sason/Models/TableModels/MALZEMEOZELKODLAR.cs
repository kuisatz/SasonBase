using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Table;
using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Database.Row;

namespace SasonBase.Sason.Models.TableModels
{
    [Serializable()]
    public class MALZEMEOZELKODLAR : Tables.Table_MALZEMEOZELKODLAR.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<MALZEMEOZELKODLAR>
        {
            Dictionary<Decimal, MALZEMEOZELKODLAR> dict = new Dictionary<Decimal, MALZEMEOZELKODLAR>();
            Dictionary<string, MALZEMEOZELKODLAR> kodDict = new Dictionary<string, MALZEMEOZELKODLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<MALZEMEOZELKODLAR> items) : base(items) { }


            #region Indexers
            public MALZEMEOZELKODLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public MALZEMEOZELKODLAR this[string KOD]
            {
                get { return kodDict.find(KOD); }
            }
            #endregion


            #region Get / Gets
            public MALZEMEOZELKODLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<MALZEMEOZELKODLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<MALZEMEOZELKODLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public MALZEMEOZELKODLAR Get(string KOD)
            {
                return kodDict.find(KOD);
            }

            public List<MALZEMEOZELKODLAR> Gets(params string[] KODs)
            {
                return kodDict.findToList(KODs);
            }

            public List<MALZEMEOZELKODLAR> Gets(IEnumerable<string> KODs)
            {
                return kodDict.findToList(KODs);
            } 
            #endregion


            protected override void OnBeforeInsert(MALZEMEOZELKODLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
                if (!cancel)
                    kodDict.set(item.KOD, item);
            }

            protected override void OnAfterRemove(MALZEMEOZELKODLAR item)
            {
                dict.remove(item.ID);
                kodDict.remove(item.KOD);
            }
        }




        public static IOrderedQueryable<MALZEMEOZELKODLAR> Select
        {
            get { return R.Query<MALZEMEOZELKODLAR>(); }
        }

        public static List<MALZEMEOZELKODLAR> SelectAll()
        {
            return Select.ToList();
        }

        public static MALZEMEOZELKODLAR SelectItem(Decimal ID)
        {
            return R.Query<MALZEMEOZELKODLAR>().First(t => t.ID == ID);
        }

        public static List<MALZEMEOZELKODLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<MALZEMEOZELKODLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<MALZEMEOZELKODLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<MALZEMEOZELKODLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

