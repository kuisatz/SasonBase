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
    public class SERVISESAWEBSERVISISTEKLER : SasonBase.Sason.Tables.Table_SERVISESAWEBSERVISISTEKLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISESAWEBSERVISISTEKLER>
        {
            Dictionary<Decimal, SERVISESAWEBSERVISISTEKLER> dict = new Dictionary<Decimal, SERVISESAWEBSERVISISTEKLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISESAWEBSERVISISTEKLER> items) : base(items) { }


            public SERVISESAWEBSERVISISTEKLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISESAWEBSERVISISTEKLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISESAWEBSERVISISTEKLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISESAWEBSERVISISTEKLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISESAWEBSERVISISTEKLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISESAWEBSERVISISTEKLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISESAWEBSERVISISTEKLER> Select
        {
            get { return R.Query<SERVISESAWEBSERVISISTEKLER>(); }
        }

        public static SERVISESAWEBSERVISISTEKLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISESAWEBSERVISISTEKLER>().First(t => t.ID == ID);
        }

        public static List<SERVISESAWEBSERVISISTEKLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISESAWEBSERVISISTEKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISESAWEBSERVISISTEKLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISESAWEBSERVISISTEKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

