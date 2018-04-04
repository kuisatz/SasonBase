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
    public class WSGLBRVRST : SasonBase.Sason.Tables.Table_WSGLBRVRST.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<WSGLBRVRST>
        {
            Dictionary<String, WSGLBRVRST> dict = new Dictionary<String, WSGLBRVRST>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<WSGLBRVRST> items) : base(items) { }


            public WSGLBRVRST this[String VERSION]
            {
                get { return dict.find(VERSION); }
            }

            public WSGLBRVRST Get(String VERSION)
            {
                return dict.find(VERSION);
            }

            public List<WSGLBRVRST> Gets(params String[] VERSIONs)
            {
                return dict.findToList(VERSIONs);
            }

            public List<WSGLBRVRST> Gets(IEnumerable<String> VERSIONs)
            {
                return dict.findToList(VERSIONs);
            }

            protected override void OnBeforeInsert(WSGLBRVRST item, ref bool cancel)
            {
                dict.set(item.VERSION, item, out cancel);
            }

            protected override void OnAfterRemove(WSGLBRVRST item)
            {
                dict.remove(item.VERSION);
            }
        }




        public static IOrderedQueryable<WSGLBRVRST> Select
        {
            get { return R.Query<WSGLBRVRST>(); }
        }

        public static WSGLBRVRST SelectItem(String VERSION)
        {
            return R.Query<WSGLBRVRST>().First(t => t.VERSION == VERSION);
        }

        public static List<WSGLBRVRST> SelectItems(params String[] VERSIONs)
        {
            return R.Query<WSGLBRVRST>().Where(t => t.VERSION.In(VERSIONs)).ToList();
        }

        public static List<WSGLBRVRST> SelectItems(IEnumerable<String> VERSIONs)
        {
            return R.Query<WSGLBRVRST>().Where(t => t.VERSION.In(VERSIONs)).ToList();
        }

    }
}

