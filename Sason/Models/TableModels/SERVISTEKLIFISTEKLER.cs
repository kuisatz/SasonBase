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
    public class SERVISTEKLIFISTEKLER : SasonBase.Sason.Tables.Table_SERVISTEKLIFISTEKLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISTEKLIFISTEKLER>
        {
            Dictionary<Decimal, SERVISTEKLIFISTEKLER> dict = new Dictionary<Decimal, SERVISTEKLIFISTEKLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISTEKLIFISTEKLER> items) : base(items) { }


            public SERVISTEKLIFISTEKLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISTEKLIFISTEKLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISTEKLIFISTEKLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISTEKLIFISTEKLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISTEKLIFISTEKLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISTEKLIFISTEKLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISTEKLIFISTEKLER> Select
        {
            get { return R.Query<SERVISTEKLIFISTEKLER>(); }
        }

        public static SERVISTEKLIFISTEKLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISTEKLIFISTEKLER>().First(t => t.ID == ID);
        }

        public static List<SERVISTEKLIFISTEKLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISTEKLIFISTEKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISTEKLIFISTEKLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISTEKLIFISTEKLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

