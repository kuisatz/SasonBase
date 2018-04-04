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
    public class SERVISSIPARISEKSIKMLZLER : SasonBase.Sason.Tables.Table_SERVISSIPARISEKSIKMLZLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSIPARISEKSIKMLZLER>
        {
            Dictionary<Decimal, SERVISSIPARISEKSIKMLZLER> dict = new Dictionary<Decimal, SERVISSIPARISEKSIKMLZLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISSIPARISEKSIKMLZLER> items) : base(items) { }


            public SERVISSIPARISEKSIKMLZLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSIPARISEKSIKMLZLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSIPARISEKSIKMLZLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSIPARISEKSIKMLZLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISSIPARISEKSIKMLZLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSIPARISEKSIKMLZLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSIPARISEKSIKMLZLER> Select
        {
            get { return R.Query<SERVISSIPARISEKSIKMLZLER>(); }
        }

        public static SERVISSIPARISEKSIKMLZLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISSIPARISEKSIKMLZLER>().First(t => t.ID == ID);
        }

        public static List<SERVISSIPARISEKSIKMLZLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSIPARISEKSIKMLZLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSIPARISEKSIKMLZLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSIPARISEKSIKMLZLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

