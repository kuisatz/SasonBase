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
    public class WSGLBRCONT : SasonBase.Sason.Tables.Table_WSGLBRCONT.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<WSGLBRCONT>
        {
            Dictionary<String, WSGLBRCONT> dict = new Dictionary<String, WSGLBRCONT>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<WSGLBRCONT> items) : base(items) { }


            public WSGLBRCONT this[String CONDITION]
            {
                get { return dict.find(CONDITION); }
            }

            public WSGLBRCONT Get(String CONDITION)
            {
                return dict.find(CONDITION);
            }

            public List<WSGLBRCONT> Gets(params String[] CONDITIONs)
            {
                return dict.findToList(CONDITIONs);
            }

            public List<WSGLBRCONT> Gets(IEnumerable<String> CONDITIONs)
            {
                return dict.findToList(CONDITIONs);
            }

            protected override void OnBeforeInsert(WSGLBRCONT item, ref bool cancel)
            {
                dict.set(item.CONDITION, item, out cancel);
            }

            protected override void OnAfterRemove(WSGLBRCONT item)
            {
                dict.remove(item.CONDITION);
            }
        }




        public static IOrderedQueryable<WSGLBRCONT> Select
        {
            get { return R.Query<WSGLBRCONT>(); }
        }

        public static WSGLBRCONT SelectItem(String CONDITION)
        {
            return R.Query<WSGLBRCONT>().First(t => t.CONDITION == CONDITION);
        }

        public static List<WSGLBRCONT> SelectItems(params String[] CONDITIONs)
        {
            return R.Query<WSGLBRCONT>().Where(t => t.CONDITION.In(CONDITIONs)).ToList();
        }

        public static List<WSGLBRCONT> SelectItems(IEnumerable<String> CONDITIONs)
        {
            return R.Query<WSGLBRCONT>().Where(t => t.CONDITION.In(CONDITIONs)).ToList();
        }

    }
}

