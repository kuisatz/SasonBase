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
    public class DOSYALAR : SasonBase.Sason.Tables.Table_DOSYALAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<DOSYALAR>
        {
            Dictionary<Decimal, DOSYALAR> dict = new Dictionary<Decimal, DOSYALAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<DOSYALAR> items) : base(items) { }


            public DOSYALAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public DOSYALAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<DOSYALAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<DOSYALAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(DOSYALAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(DOSYALAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<DOSYALAR> Select
        {
            get { return R.Query<DOSYALAR>(); }
        }

        public static DOSYALAR SelectItem(Decimal ID)
        {
            return R.Query<DOSYALAR>().First(t => t.ID == ID);
        }

        public static List<DOSYALAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<DOSYALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<DOSYALAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<DOSYALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

