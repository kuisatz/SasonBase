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
    public class TMP_MDTST1 : SasonBase.Sason.Tables.Table_TMP_MDTST1.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<TMP_MDTST1>
        {
            Dictionary<Decimal, TMP_MDTST1> dict = new Dictionary<Decimal, TMP_MDTST1>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<TMP_MDTST1> items) : base(items) { }


            public TMP_MDTST1 this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public TMP_MDTST1 Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<TMP_MDTST1> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<TMP_MDTST1> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(TMP_MDTST1 item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(TMP_MDTST1 item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<TMP_MDTST1> Select
        {
            get { return R.Query<TMP_MDTST1>(); }
        }

        public static TMP_MDTST1 SelectItem(Decimal ID)
        {
            return R.Query<TMP_MDTST1>().First(t => t.ID == ID);
        }

        public static List<TMP_MDTST1> SelectItems(params Decimal[] IDs)
        {
            return R.Query<TMP_MDTST1>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<TMP_MDTST1> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<TMP_MDTST1>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

