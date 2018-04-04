using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Table;
using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Extensions;
using System.Collections;

namespace SasonBase.Sason.Models.TableModels
{
    [Serializable()]
    public class ILLER : SasonBase.Sason.Tables.Table_ILLER.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<ILLER>
        {
            Dictionary<Decimal, ILLER> dict = new Dictionary<Decimal, ILLER>();

            public CONTAINER() {  }
            public CONTAINER(IEnumerable<ILLER> items) : base(items) { }


            public ILLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ILLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ILLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ILLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public ILLER GetFromName(string ilAdi)
            {
                string searchStr = ilAdi.removeTrChars();
                if (ilAdi.isNullOrWhiteSpace())
                    return null;
                ILLER ret = Items.first(t => t.AD.trim().removeTrChars().like(searchStr)  || searchStr.like(t.AD));
                return ret;
            }

            protected override void OnBeforeInsert(ILLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ILLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ILLER> Select
        {
            get { return R.Query<ILLER>(); }
        }

        public static ILLER SelectItem(Decimal ID)
        {
            return R.Query<ILLER>().First(t => t.ID == ID);
        }

        public static List<ILLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ILLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ILLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ILLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

