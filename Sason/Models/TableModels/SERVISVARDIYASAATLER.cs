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
    public class SERVISVARDIYASAATLER : SasonBase.Sason.Tables.Table_SERVISVARDIYASAATLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISVARDIYASAATLER>
        {
            Dictionary<Decimal, SERVISVARDIYASAATLER> dict = new Dictionary<Decimal, SERVISVARDIYASAATLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISVARDIYASAATLER> items) : base(items) { }


            public SERVISVARDIYASAATLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISVARDIYASAATLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISVARDIYASAATLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISVARDIYASAATLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISVARDIYASAATLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISVARDIYASAATLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISVARDIYASAATLER> Select
        {
            get { return R.Query<SERVISVARDIYASAATLER>(); }
        }

        public static SERVISVARDIYASAATLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISVARDIYASAATLER>().First(t => t.ID == ID);
        }

        public static List<SERVISVARDIYASAATLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISVARDIYASAATLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISVARDIYASAATLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISVARDIYASAATLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

