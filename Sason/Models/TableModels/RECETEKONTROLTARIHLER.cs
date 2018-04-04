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
    public class RECETEKONTROLTARIHLER : SasonBase.Sason.Tables.Table_RECETEKONTROLTARIHLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<RECETEKONTROLTARIHLER>
        {
            Dictionary<Decimal, RECETEKONTROLTARIHLER> dict = new Dictionary<Decimal, RECETEKONTROLTARIHLER>();
            Dictionary<decimal, Dictionary<long, RECETEKONTROLTARIHLER>> tarihDict = new Dictionary<decimal, Dictionary<long, RECETEKONTROLTARIHLER>>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<RECETEKONTROLTARIHLER> items) : base(items) { }


            public RECETEKONTROLTARIHLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public RECETEKONTROLTARIHLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<RECETEKONTROLTARIHLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<RECETEKONTROLTARIHLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public RECETEKONTROLTARIHLER Get(decimal receteId, DateTime kontrolTarihi)
            {
                return tarihDict.find(receteId).find(kontrolTarihi.toLongD());
            }

            protected override void OnBeforeInsert(RECETEKONTROLTARIHLER item, ref bool cancel)
            {
                tarihDict.check(item.RECETEID).set(item.TARIH.toLongD(), item, out cancel);
                if (!cancel)
                    dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(RECETEKONTROLTARIHLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<RECETEKONTROLTARIHLER> Select
        {
            get { return R.Query<RECETEKONTROLTARIHLER>(); }
        }

        public static RECETEKONTROLTARIHLER SelectItem(Decimal ID)
        {
            return R.Query<RECETEKONTROLTARIHLER>().First(t => t.ID == ID);
        }

        public static List<RECETEKONTROLTARIHLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<RECETEKONTROLTARIHLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<RECETEKONTROLTARIHLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<RECETEKONTROLTARIHLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

