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
    public class SERVISSTOKGRUPINDIRIMLER : SasonBase.Sason.Tables.Table_SERVISSTOKGRUPINDIRIMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSTOKGRUPINDIRIMLER>
        {
            Dictionary<Decimal, SERVISSTOKGRUPINDIRIMLER> dict = new Dictionary<Decimal, SERVISSTOKGRUPINDIRIMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISSTOKGRUPINDIRIMLER> items) : base(items) { }


            public SERVISSTOKGRUPINDIRIMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSTOKGRUPINDIRIMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSTOKGRUPINDIRIMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSTOKGRUPINDIRIMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISSTOKGRUPINDIRIMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSTOKGRUPINDIRIMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSTOKGRUPINDIRIMLER> Select
        {
            get { return R.Query<SERVISSTOKGRUPINDIRIMLER>(); }
        }

        public static SERVISSTOKGRUPINDIRIMLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISSTOKGRUPINDIRIMLER>().First(t => t.ID == ID);
        }

        public static List<SERVISSTOKGRUPINDIRIMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSTOKGRUPINDIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSTOKGRUPINDIRIMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSTOKGRUPINDIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

