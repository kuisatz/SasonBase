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
    public class WSGLBRACTT : SasonBase.Sason.Tables.Table_WSGLBRACTT.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<WSGLBRACTT>
        {
            Dictionary<String, WSGLBRACTT> dict = new Dictionary<String, WSGLBRACTT>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<WSGLBRACTT> items) : base(items) { }


            public WSGLBRACTT this[String ACTIVITY]
            {
                get { return dict.find(ACTIVITY); }
            }

            public WSGLBRACTT Get(String ACTIVITY)
            {
                return dict.find(ACTIVITY);
            }

            public List<WSGLBRACTT> Gets(params String[] ACTIVITYs)
            {
                return dict.findToList(ACTIVITYs);
            }

            public List<WSGLBRACTT> Gets(IEnumerable<String> ACTIVITYs)
            {
                return dict.findToList(ACTIVITYs);
            }

            protected override void OnBeforeInsert(WSGLBRACTT item, ref bool cancel)
            {
                dict.set(item.ACTIVITY, item, out cancel);
            }

            protected override void OnAfterRemove(WSGLBRACTT item)
            {
                dict.remove(item.ACTIVITY);
            }
        }




        public static IOrderedQueryable<WSGLBRACTT> Select
        {
            get { return R.Query<WSGLBRACTT>(); }
        }

        public static WSGLBRACTT SelectItem(String ACTIVITY)
        {
            return R.Query<WSGLBRACTT>().First(t => t.ACTIVITY == ACTIVITY);
        }

        public static List<WSGLBRACTT> SelectItems(params String[] ACTIVITYs)
        {
            return R.Query<WSGLBRACTT>().Where(t => t.ACTIVITY.In(ACTIVITYs)).ToList();
        }

        public static List<WSGLBRACTT> SelectItems(IEnumerable<String> ACTIVITYs)
        {
            return R.Query<WSGLBRACTT>().Where(t => t.ACTIVITY.In(ACTIVITYs)).ToList();
        }

    }
}

