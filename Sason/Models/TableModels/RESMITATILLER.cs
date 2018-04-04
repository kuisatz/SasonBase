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
    public class RESMITATILLER : SasonBase.Sason.Tables.Table_RESMITATILLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<RESMITATILLER>
        {
            Dictionary<Decimal, RESMITATILLER> dict = new Dictionary<Decimal, RESMITATILLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<RESMITATILLER> items) : base(items) { }


            public RESMITATILLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public RESMITATILLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<RESMITATILLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<RESMITATILLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(RESMITATILLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(RESMITATILLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<RESMITATILLER> Select
        {
            get { return R.Query<RESMITATILLER>(); }
        }

        public static RESMITATILLER SelectItem(Decimal ID)
        {
            return R.Query<RESMITATILLER>().First(t => t.ID == ID);
        }

        public static List<RESMITATILLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<RESMITATILLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<RESMITATILLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<RESMITATILLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

