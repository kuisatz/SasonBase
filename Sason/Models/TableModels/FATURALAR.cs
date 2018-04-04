using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Table;
using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace SasonBase.Sason.Models.TableModels
{
    [Serializable()]
    public class FATURALAR : Tables.Table_FATURALAR.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<FATURALAR>
        {
            Dictionary<Decimal, FATURALAR> dict = new Dictionary<Decimal, FATURALAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<FATURALAR> items) : base(items) { }


            public FATURALAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public FATURALAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<FATURALAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<FATURALAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(FATURALAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(FATURALAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<FATURALAR> Select
        {
            get { return R.Query<FATURALAR>(); }
        }

        public static FATURALAR SelectItem(Decimal ID)
        {
            return R.Query<FATURALAR>().First(t => t.ID == ID);
        }

        public static List<FATURALAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<FATURALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<FATURALAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<FATURALAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}