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
    public class ESASUPERSESSION : SasonBase.Sason.Tables.Table_ESASUPERSESSION.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ESASUPERSESSION>
        {
            Dictionary<String, ESASUPERSESSION> dict = new Dictionary<String, ESASUPERSESSION>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ESASUPERSESSION> items) : base(items) { }


            public ESASUPERSESSION this[String MATNR]
            {
                get { return dict.find(MATNR); }
            }

            public ESASUPERSESSION Get(String MATNR)
            {
                return dict.find(MATNR);
            }

            public List<ESASUPERSESSION> Gets(params String[] MATNRs)
            {
                return dict.findToList(MATNRs);
            }

            public List<ESASUPERSESSION> Gets(IEnumerable<String> MATNRs)
            {
                return dict.findToList(MATNRs);
            }

            protected override void OnBeforeInsert(ESASUPERSESSION item, ref bool cancel)
            {
                dict.set(item.MATNR, item, out cancel);
            }

            protected override void OnAfterRemove(ESASUPERSESSION item)
            {
                dict.remove(item.MATNR);
            }
        }




        public static IOrderedQueryable<ESASUPERSESSION> Select
        {
            get { return R.Query<ESASUPERSESSION>(); }
        }

        public static ESASUPERSESSION SelectItem(String MATNR)
        {
            return R.Query<ESASUPERSESSION>().First(t => t.MATNR == MATNR);
        }

        public static List<ESASUPERSESSION> SelectItems(params String[] MATNRs)
        {
            return R.Query<ESASUPERSESSION>().Where(t => t.MATNR.In(MATNRs)).ToList();
        }

        public static List<ESASUPERSESSION> SelectItems(IEnumerable<String> MATNRs)
        {
            return R.Query<ESASUPERSESSION>().Where(t => t.MATNR.In(MATNRs)).ToList();
        }

    }
}

