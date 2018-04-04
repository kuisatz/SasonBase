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
    public class SERVISTEKLIFISTEKMLZLER : SasonBase.Sason.Tables.Table_SERVISTEKLIFISTEKMLZLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISTEKLIFISTEKMLZLER>
        {
            Dictionary<Decimal, SERVISTEKLIFISTEKMLZLER> dict = new Dictionary<Decimal, SERVISTEKLIFISTEKMLZLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISTEKLIFISTEKMLZLER> items) : base(items) { }


            public SERVISTEKLIFISTEKMLZLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISTEKLIFISTEKMLZLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISTEKLIFISTEKMLZLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISTEKLIFISTEKMLZLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISTEKLIFISTEKMLZLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISTEKLIFISTEKMLZLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISTEKLIFISTEKMLZLER> Select
        {
            get { return R.Query<SERVISTEKLIFISTEKMLZLER>(); }
        }

        public static SERVISTEKLIFISTEKMLZLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISTEKLIFISTEKMLZLER>().First(t => t.ID == ID);
        }

        public static List<SERVISTEKLIFISTEKMLZLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISTEKLIFISTEKMLZLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISTEKLIFISTEKMLZLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISTEKLIFISTEKMLZLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

