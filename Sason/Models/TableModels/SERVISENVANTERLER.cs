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
    public class SERVISENVANTERLER : SasonBase.Sason.Tables.Table_SERVISENVANTERLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISENVANTERLER>
        {
            Dictionary<Decimal, SERVISENVANTERLER> dict = new Dictionary<Decimal, SERVISENVANTERLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISENVANTERLER> items) : base(items) { }


            public SERVISENVANTERLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISENVANTERLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISENVANTERLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISENVANTERLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISENVANTERLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISENVANTERLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISENVANTERLER> Select
        {
            get { return R.Query<SERVISENVANTERLER>(); }
        }

        public static SERVISENVANTERLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISENVANTERLER>().First(t => t.ID == ID);
        }

        public static List<SERVISENVANTERLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISENVANTERLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISENVANTERLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISENVANTERLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

