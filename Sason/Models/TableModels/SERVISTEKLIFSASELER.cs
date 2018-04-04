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
    public class SERVISTEKLIFSASELER : SasonBase.Sason.Tables.Table_SERVISTEKLIFSASELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISTEKLIFSASELER>
        {
            Dictionary<Decimal, SERVISTEKLIFSASELER> dict = new Dictionary<Decimal, SERVISTEKLIFSASELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISTEKLIFSASELER> items) : base(items) { }


            public SERVISTEKLIFSASELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISTEKLIFSASELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISTEKLIFSASELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISTEKLIFSASELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISTEKLIFSASELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISTEKLIFSASELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISTEKLIFSASELER> Select
        {
            get { return R.Query<SERVISTEKLIFSASELER>(); }
        }

        public static SERVISTEKLIFSASELER SelectItem(Decimal ID)
        {
            return R.Query<SERVISTEKLIFSASELER>().First(t => t.ID == ID);
        }

        public static List<SERVISTEKLIFSASELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISTEKLIFSASELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISTEKLIFSASELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISTEKLIFSASELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

