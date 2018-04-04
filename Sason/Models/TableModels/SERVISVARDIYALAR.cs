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
    public class SERVISVARDIYALAR : SasonBase.Sason.Tables.Table_SERVISVARDIYALAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISVARDIYALAR>
        {
            Dictionary<Decimal, SERVISVARDIYALAR> dict = new Dictionary<Decimal, SERVISVARDIYALAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISVARDIYALAR> items) : base(items) { }


            public SERVISVARDIYALAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISVARDIYALAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISVARDIYALAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISVARDIYALAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISVARDIYALAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISVARDIYALAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISVARDIYALAR> Select
        {
            get { return R.Query<SERVISVARDIYALAR>(); }
        }

        public static SERVISVARDIYALAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISVARDIYALAR>().First(t => t.ID == ID);
        }

        public static List<SERVISVARDIYALAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISVARDIYALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISVARDIYALAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISVARDIYALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

