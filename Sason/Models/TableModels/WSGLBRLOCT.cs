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
    public class WSGLBRLOCT : SasonBase.Sason.Tables.Table_WSGLBRLOCT.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<WSGLBRLOCT>
        {
            Dictionary<String, WSGLBRLOCT> dict = new Dictionary<String, WSGLBRLOCT>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<WSGLBRLOCT> items) : base(items) { }


            public WSGLBRLOCT this[String LOCATION]
            {
                get { return dict.find(LOCATION); }
            }

            public WSGLBRLOCT Get(String LOCATION)
            {
                return dict.find(LOCATION);
            }

            public List<WSGLBRLOCT> Gets(params String[] LOCATIONs)
            {
                return dict.findToList(LOCATIONs);
            }

            public List<WSGLBRLOCT> Gets(IEnumerable<String> LOCATIONs)
            {
                return dict.findToList(LOCATIONs);
            }

            protected override void OnBeforeInsert(WSGLBRLOCT item, ref bool cancel)
            {
                dict.set(item.LOCATION, item, out cancel);
            }

            protected override void OnAfterRemove(WSGLBRLOCT item)
            {
                dict.remove(item.LOCATION);
            }
        }




        public static IOrderedQueryable<WSGLBRLOCT> Select
        {
            get { return R.Query<WSGLBRLOCT>(); }
        }

        public static WSGLBRLOCT SelectItem(String LOCATION)
        {
            return R.Query<WSGLBRLOCT>().First(t => t.LOCATION == LOCATION);
        }

        public static List<WSGLBRLOCT> SelectItems(params String[] LOCATIONs)
        {
            return R.Query<WSGLBRLOCT>().Where(t => t.LOCATION.In(LOCATIONs)).ToList();
        }

        public static List<WSGLBRLOCT> SelectItems(IEnumerable<String> LOCATIONs)
        {
            return R.Query<WSGLBRLOCT>().Where(t => t.LOCATION.In(LOCATIONs)).ToList();
        }

    }
}

