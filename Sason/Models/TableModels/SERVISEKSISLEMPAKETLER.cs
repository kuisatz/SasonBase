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
    public class SERVISEKSISLEMPAKETLER : SasonBase.Sason.Tables.Table_SERVISEKSISLEMPAKETLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISEKSISLEMPAKETLER>
        {
            Dictionary<Decimal, SERVISEKSISLEMPAKETLER> dict = new Dictionary<Decimal, SERVISEKSISLEMPAKETLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISEKSISLEMPAKETLER> items) : base(items) { }


            public SERVISEKSISLEMPAKETLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISEKSISLEMPAKETLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISEKSISLEMPAKETLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISEKSISLEMPAKETLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISEKSISLEMPAKETLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISEKSISLEMPAKETLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISEKSISLEMPAKETLER> Select
        {
            get { return R.Query<SERVISEKSISLEMPAKETLER>(); }
        }

        public static SERVISEKSISLEMPAKETLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISEKSISLEMPAKETLER>().First(t => t.ID == ID);
        }

        public static List<SERVISEKSISLEMPAKETLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISEKSISLEMPAKETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISEKSISLEMPAKETLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISEKSISLEMPAKETLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

