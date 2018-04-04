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
    public class SERVISVARLIKLAR : SasonBase.Sason.Tables.Table_SERVISVARLIKLAR.PublicItem
    {

        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISVARLIKLAR>
        {
            Dictionary<Decimal, SERVISVARLIKLAR> dict = new Dictionary<Decimal, SERVISVARLIKLAR>();
            Dictionary<string, SERVISVARLIKLAR> vnoDict = new Dictionary<string, SERVISVARLIKLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISVARLIKLAR> items) : base(items) { }


            public SERVISVARLIKLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISVARLIKLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISVARLIKLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISVARLIKLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public SERVISVARLIKLAR GetFromVergiNo(string vergiNo)
            {
                return vnoDict.find(vergiNo);
            }

            protected override void OnBeforeInsert(SERVISVARLIKLAR item, ref bool cancel)
            {
                cancel = item.VERGINO.isNullOrWhiteSpace();

                if (!cancel)
                    vnoDict.set(item.VERGINO, item, out cancel);

                if (!cancel)
                    dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISVARLIKLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISVARLIKLAR> Select
        {
            get { return R.Query<SERVISVARLIKLAR>(); }
        }

        public static SERVISVARLIKLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISVARLIKLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISVARLIKLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISVARLIKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISVARLIKLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISVARLIKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISVARLIKLAR> SelectServisVarliklar(decimal servisId, MethodReturn refMr)
        {
            return R.Query<SERVISVARLIKLAR>(refMr).Where(t => t.SERVISID == servisId).ToList();
        }

    }
}

