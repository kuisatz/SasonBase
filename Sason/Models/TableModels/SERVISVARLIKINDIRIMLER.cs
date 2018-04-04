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
    public class SERVISVARLIKINDIRIMLER : SasonBase.Sason.Tables.Table_SERVISVARLIKINDIRIMLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISVARLIKINDIRIMLER>
        {
            Dictionary<Decimal, SERVISVARLIKINDIRIMLER> dict = new Dictionary<Decimal, SERVISVARLIKINDIRIMLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISVARLIKINDIRIMLER> items) : base(items) { }


            public SERVISVARLIKINDIRIMLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISVARLIKINDIRIMLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISVARLIKINDIRIMLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISVARLIKINDIRIMLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISVARLIKINDIRIMLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISVARLIKINDIRIMLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISVARLIKINDIRIMLER> Select
        {
            get { return R.Query<SERVISVARLIKINDIRIMLER>(); }
        }

        public static SERVISVARLIKINDIRIMLER SelectItem(Decimal ID)
        {
            return R.Query<SERVISVARLIKINDIRIMLER>().First(t => t.ID == ID);
        }

        public static List<SERVISVARLIKINDIRIMLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISVARLIKINDIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISVARLIKINDIRIMLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISVARLIKINDIRIMLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

