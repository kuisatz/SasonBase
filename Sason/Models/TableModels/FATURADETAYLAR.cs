using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Table;
using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;

namespace SasonBase.Sason.Models.TableModels
{
    [Serializable()]
    public class FATURADETAYLAR : Tables.Table_FATURADETAYLAR.PublicItem
    {
        public void ClearManKartPuanFields()
        {
            MANKARTORAN = 0;
            MANKARTPUAN = 0;
            MANKARTHARCANAN = 0;
        }

        #region CONTAINER
        public class CONTAINER : Antibiotic.Collections.ListContainer<FATURADETAYLAR>
        {
            Dictionary<Decimal, FATURADETAYLAR> dict = new Dictionary<Decimal, FATURADETAYLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<FATURADETAYLAR> items) : base(items) { }


            public FATURADETAYLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public FATURADETAYLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<FATURADETAYLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<FATURADETAYLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(FATURADETAYLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(FATURADETAYLAR item)
            {
                dict.remove(item.ID);
            }
        }
        #endregion

        #region Static Methods
        public static IOrderedQueryable<FATURADETAYLAR> Select
        {
            get { return R.Query<FATURADETAYLAR>(); }
        }

        public static FATURADETAYLAR SelectItem(Decimal ID)
        {
            return R.Query<FATURADETAYLAR>().First(t => t.ID == ID);
        }

        public static List<FATURADETAYLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<FATURADETAYLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<FATURADETAYLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<FATURADETAYLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<FATURADETAYLAR> SelectItemsFromFaturaId(decimal faturaId)
        {
            return Select.Where(t => t.FATURAID == faturaId).ToList();
        } 
        #endregion
    }
}