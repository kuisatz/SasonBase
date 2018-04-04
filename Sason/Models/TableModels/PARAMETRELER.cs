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
    public class PARAMETRELER : SasonBase.Sason.Tables.Table_PARAMETRELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<PARAMETRELER>
        {
            Dictionary<String, PARAMETRELER> dict = new Dictionary<String, PARAMETRELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<PARAMETRELER> items) : base(items) { }


            public PARAMETRELER this[String AD]
            {
                get { return dict.find(AD); }
            }

            public PARAMETRELER Get(String AD)
            {
                return dict.find(AD);
            }

            public List<PARAMETRELER> Gets(params String[] ADs)
            {
                return dict.findToList(ADs);
            }

            public List<PARAMETRELER> Gets(IEnumerable<String> ADs)
            {
                return dict.findToList(ADs);
            }

            protected override void OnBeforeInsert(PARAMETRELER item, ref bool cancel)
            {
                dict.set(item.AD, item, out cancel);
            }

            protected override void OnAfterRemove(PARAMETRELER item)
            {
                dict.remove(item.AD);
            }
        }




        public static IOrderedQueryable<PARAMETRELER> Select
        {
            get { return R.Query<PARAMETRELER>(); }
        }

        public static PARAMETRELER SelectItem(String AD)
        {
            return R.Query<PARAMETRELER>().First(t => t.AD == AD);
        }

        public static List<PARAMETRELER> SelectItems(params String[] ADs)
        {
            return R.Query<PARAMETRELER>().Where(t => t.AD.In(ADs)).ToList();
        }

        public static List<PARAMETRELER> SelectItems(IEnumerable<String> ADs)
        {
            return R.Query<PARAMETRELER>().Where(t => t.AD.In(ADs)).ToList();
        }

    }
}

