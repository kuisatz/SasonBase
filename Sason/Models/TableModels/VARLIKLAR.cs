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
    public class VARLIKLAR : SasonBase.Sason.Tables.Table_VARLIKLAR.PublicItem
    {
        public override string ToString()
        {
            return $"{this.ID} : {this.AD}";
        }


        public class CONTAINER : Antibiotic.Collections.ListContainer<VARLIKLAR>
        {
            Dictionary<Decimal, VARLIKLAR> dict = new Dictionary<Decimal, VARLIKLAR>();
            Dictionary<string, VARLIKLAR> vnoDict = new Dictionary<string, VARLIKLAR>();


            public CONTAINER() { }
            public CONTAINER(IEnumerable<VARLIKLAR> items) : base(items) { }


            public VARLIKLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public VARLIKLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<VARLIKLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<VARLIKLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public VARLIKLAR GetFromVergiNo(string vergiNo)
            {
                return vnoDict.find(vergiNo);
            }

            public VARLIKLAR GetFromName(string name)
            {
                return Items.first(t => t.AD.removeTrChars().like(name.removeTrChars()));
            }

            protected override void OnBeforeInsert(VARLIKLAR item, ref bool cancel)
            {
                cancel = item.VERGINO.isNullOrWhiteSpace();
                if (!cancel)
                    vnoDict.set(item.VERGINO, item, out cancel);
                if (!cancel)
                    dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(VARLIKLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<VARLIKLAR> Select
        {
            get { return R.Query<VARLIKLAR>(); }
        }

        public static VARLIKLAR SelectItem(Decimal ID)
        {
            return R.Query<VARLIKLAR>().First(t => t.ID == ID);
        }

        public static List<VARLIKLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<VARLIKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<VARLIKLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<VARLIKLAR>().Where(t => t.ID.In(IDs)).ToList();
        }




    }
}

