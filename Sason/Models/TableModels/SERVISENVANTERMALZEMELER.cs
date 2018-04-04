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
    public class SERVISENVANTERMALZEMELER : SasonBase.Sason.Tables.Table_SERVISENVANTERMALZEMELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISENVANTERMALZEMELER>
        {
            Dictionary<Decimal, SERVISENVANTERMALZEMELER> dict = new Dictionary<Decimal, SERVISENVANTERMALZEMELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISENVANTERMALZEMELER> items) : base(items) { }


            public SERVISENVANTERMALZEMELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISENVANTERMALZEMELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISENVANTERMALZEMELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISENVANTERMALZEMELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISENVANTERMALZEMELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISENVANTERMALZEMELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISENVANTERMALZEMELER> Select
        {
            get { return R.Query<SERVISENVANTERMALZEMELER>(); }
        }

        public static SERVISENVANTERMALZEMELER SelectItem(Decimal ID)
        {
            return R.Query<SERVISENVANTERMALZEMELER>().First(t => t.ID == ID);
        }

        public static List<SERVISENVANTERMALZEMELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISENVANTERMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISENVANTERMALZEMELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISENVANTERMALZEMELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

