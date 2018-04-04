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
    public class ISCILIKUYGULAMALAR : SasonBase.Sason.Tables.Table_ISCILIKUYGULAMALAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISCILIKUYGULAMALAR>
        {
            Dictionary<Decimal, ISCILIKUYGULAMALAR> dict = new Dictionary<Decimal, ISCILIKUYGULAMALAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISCILIKUYGULAMALAR> items) : base(items) { }


            public ISCILIKUYGULAMALAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISCILIKUYGULAMALAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISCILIKUYGULAMALAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISCILIKUYGULAMALAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISCILIKUYGULAMALAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISCILIKUYGULAMALAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISCILIKUYGULAMALAR> Select
        {
            get { return R.Query<ISCILIKUYGULAMALAR>(); }
        }

        public static ISCILIKUYGULAMALAR SelectItem(Decimal ID)
        {
            return R.Query<ISCILIKUYGULAMALAR>().First(t => t.ID == ID);
        }

        public static List<ISCILIKUYGULAMALAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISCILIKUYGULAMALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISCILIKUYGULAMALAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISCILIKUYGULAMALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

