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
    public class SERVISTEKLIFLER : SasonBase.Sason.Tables.Table_SERVISTEKLIFLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISTEKLIFLER>
        {
            Dictionary<Decimal, SERVISTEKLIFLER> dict = new Dictionary<Decimal, SERVISTEKLIFLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISTEKLIFLER> items) : base(items) { }


            public SERVISTEKLIFLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISTEKLIFLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISTEKLIFLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISTEKLIFLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISTEKLIFLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISTEKLIFLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISTEKLIFLER> Select
        {
            get { return R.Query<SERVISTEKLIFLER>(); }
        }

        public static SERVISTEKLIFLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISTEKLIFLER>().First(t => t.ID == ID);
        }

        public static List<SERVISTEKLIFLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISTEKLIFLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISTEKLIFLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISTEKLIFLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

