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
    public class ISCILIKMONTAJDURUMLAR : SasonBase.Sason.Tables.Table_ISCILIKMONTAJDURUMLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ISCILIKMONTAJDURUMLAR>
        {
            Dictionary<Decimal, ISCILIKMONTAJDURUMLAR> dict = new Dictionary<Decimal, ISCILIKMONTAJDURUMLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ISCILIKMONTAJDURUMLAR> items) : base(items) { }


            public ISCILIKMONTAJDURUMLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ISCILIKMONTAJDURUMLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ISCILIKMONTAJDURUMLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ISCILIKMONTAJDURUMLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ISCILIKMONTAJDURUMLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ISCILIKMONTAJDURUMLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ISCILIKMONTAJDURUMLAR> Select
        {
            get { return R.Query<ISCILIKMONTAJDURUMLAR>(); }
        }

        public static ISCILIKMONTAJDURUMLAR SelectItem(Decimal ID)
        {
            return R.Query<ISCILIKMONTAJDURUMLAR>().First(t => t.ID == ID);
        }

        public static List<ISCILIKMONTAJDURUMLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ISCILIKMONTAJDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ISCILIKMONTAJDURUMLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ISCILIKMONTAJDURUMLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

