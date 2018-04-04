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
    public class RECETEEKSIKNEDENLER : SasonBase.Sason.Tables.Table_RECETEEKSIKNEDENLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<RECETEEKSIKNEDENLER>
        {
            Dictionary<Decimal, RECETEEKSIKNEDENLER> dict = new Dictionary<Decimal, RECETEEKSIKNEDENLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<RECETEEKSIKNEDENLER> items) : base(items) { }


            public RECETEEKSIKNEDENLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public RECETEEKSIKNEDENLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<RECETEEKSIKNEDENLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<RECETEEKSIKNEDENLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(RECETEEKSIKNEDENLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(RECETEEKSIKNEDENLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<RECETEEKSIKNEDENLER> Select
        {
            get { return R.Query<RECETEEKSIKNEDENLER>(); }
        }

        public static RECETEEKSIKNEDENLER SelectItem(Decimal ID)
        {
            return R.Query<RECETEEKSIKNEDENLER>().First(t => t.ID == ID);
        }

        public static List<RECETEEKSIKNEDENLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<RECETEEKSIKNEDENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<RECETEEKSIKNEDENLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<RECETEEKSIKNEDENLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

