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
    public class SERVISSTOKBIRIMLER : SasonBase.Sason.Tables.Table_SERVISSTOKBIRIMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISSTOKBIRIMLER>
        {
            Dictionary<Decimal, SERVISSTOKBIRIMLER> dict = new Dictionary<Decimal, SERVISSTOKBIRIMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISSTOKBIRIMLER> items) : base(items) { }


            public SERVISSTOKBIRIMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISSTOKBIRIMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISSTOKBIRIMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISSTOKBIRIMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISSTOKBIRIMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISSTOKBIRIMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISSTOKBIRIMLER> Select
        {
            get { return R.Query<SERVISSTOKBIRIMLER>(); }
        }

        public static SERVISSTOKBIRIMLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISSTOKBIRIMLER>().First(t => t.ID == ID);
        }

        public static List<SERVISSTOKBIRIMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISSTOKBIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISSTOKBIRIMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISSTOKBIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

