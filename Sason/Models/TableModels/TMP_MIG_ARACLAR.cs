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
    public class TMP_MIG_ARACLAR : SasonBase.Sason.Tables.Table_TMP_MIG_ARACLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<TMP_MIG_ARACLAR>
        {
            Dictionary<String, TMP_MIG_ARACLAR> dict = new Dictionary<String, TMP_MIG_ARACLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<TMP_MIG_ARACLAR> items) : base(items) { }


            public TMP_MIG_ARACLAR this[String SASENO]
            {
                get { return dict.find(SASENO); }
            }

            public TMP_MIG_ARACLAR Get(String SASENO)
            {
                return dict.find(SASENO);
            }

            public List<TMP_MIG_ARACLAR> Gets(params String[] SASENOs)
            {
                return dict.findToList(SASENOs);
            }

            public List<TMP_MIG_ARACLAR> Gets(IEnumerable<String> SASENOs)
            {
                return dict.findToList(SASENOs);
            }

            protected override void OnBeforeInsert(TMP_MIG_ARACLAR item, ref bool cancel)
            {
                dict.set(item.SASENO, item, out cancel);
            }

            protected override void OnAfterRemove(TMP_MIG_ARACLAR item)
            {
                dict.remove(item.SASENO);
            }
        }




        public static IOrderedQueryable<TMP_MIG_ARACLAR> Select
        {
            get { return R.Query<TMP_MIG_ARACLAR>(); }
        }

        public static TMP_MIG_ARACLAR SelectItem(String SASENO)
        {
            return R.Query<TMP_MIG_ARACLAR>().First(t => t.SASENO == SASENO);
        }

        public static List<TMP_MIG_ARACLAR> SelectItems(params String[] SASENOs)
        {
            return R.Query<TMP_MIG_ARACLAR>().Where(t => t.SASENO.In(SASENOs)).ToList();
        }

        public static List<TMP_MIG_ARACLAR> SelectItems(IEnumerable<String> SASENOs)
        {
            return R.Query<TMP_MIG_ARACLAR>().Where(t => t.SASENO.In(SASENOs)).ToList();
        }

    }
}

