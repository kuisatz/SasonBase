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
    public class ESAWEBSERVISISTEKLER : SasonBase.Sason.Tables.Table_ESAWEBSERVISISTEKLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ESAWEBSERVISISTEKLER>
        {
            Dictionary<Decimal, ESAWEBSERVISISTEKLER> dict = new Dictionary<Decimal, ESAWEBSERVISISTEKLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ESAWEBSERVISISTEKLER> items) : base(items) { }


            public ESAWEBSERVISISTEKLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ESAWEBSERVISISTEKLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ESAWEBSERVISISTEKLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ESAWEBSERVISISTEKLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ESAWEBSERVISISTEKLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ESAWEBSERVISISTEKLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ESAWEBSERVISISTEKLER> Select
        {
            get { return R.Query<ESAWEBSERVISISTEKLER>(); }
        }

        public static ESAWEBSERVISISTEKLER SelectItem(Decimal ID)
        {
            return R.Query<ESAWEBSERVISISTEKLER>().First(t => t.ID == ID);
        }

        public static List<ESAWEBSERVISISTEKLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ESAWEBSERVISISTEKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ESAWEBSERVISISTEKLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ESAWEBSERVISISTEKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

