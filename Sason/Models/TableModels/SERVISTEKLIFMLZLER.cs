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
    public class SERVISTEKLIFMLZLER : SasonBase.Sason.Tables.Table_SERVISTEKLIFMLZLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISTEKLIFMLZLER>
        {
            Dictionary<Decimal, SERVISTEKLIFMLZLER> dict = new Dictionary<Decimal, SERVISTEKLIFMLZLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISTEKLIFMLZLER> items) : base(items) { }


            public SERVISTEKLIFMLZLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISTEKLIFMLZLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISTEKLIFMLZLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISTEKLIFMLZLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISTEKLIFMLZLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISTEKLIFMLZLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISTEKLIFMLZLER> Select
        {
            get { return R.Query<SERVISTEKLIFMLZLER>(); }
        }

        public static SERVISTEKLIFMLZLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISTEKLIFMLZLER>().First(t => t.ID == ID);
        }

        public static List<SERVISTEKLIFMLZLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISTEKLIFMLZLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISTEKLIFMLZLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISTEKLIFMLZLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

