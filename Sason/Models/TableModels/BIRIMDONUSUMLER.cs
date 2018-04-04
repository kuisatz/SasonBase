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
    public class BIRIMDONUSUMLER : SasonBase.Sason.Tables.Table_BIRIMDONUSUMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<BIRIMDONUSUMLER>
        {
            Dictionary<Decimal, BIRIMDONUSUMLER> dict = new Dictionary<Decimal, BIRIMDONUSUMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<BIRIMDONUSUMLER> items) : base(items) { }


            public BIRIMDONUSUMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public BIRIMDONUSUMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<BIRIMDONUSUMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<BIRIMDONUSUMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(BIRIMDONUSUMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(BIRIMDONUSUMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<BIRIMDONUSUMLER> Select
        {
            get { return R.Query<BIRIMDONUSUMLER>(); }
        }

        public static BIRIMDONUSUMLER SelectItem(Decimal ID)
        {
            return R.Query<BIRIMDONUSUMLER>().First(t => t.ID == ID);
        }

        public static List<BIRIMDONUSUMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<BIRIMDONUSUMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<BIRIMDONUSUMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<BIRIMDONUSUMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

