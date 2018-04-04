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
    public class SIKAYETYONLENDIRMETURLER : SasonBase.Sason.Tables.Table_SIKAYETYONLENDIRMETURLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SIKAYETYONLENDIRMETURLER>
        {
            Dictionary<Decimal, SIKAYETYONLENDIRMETURLER> dict = new Dictionary<Decimal, SIKAYETYONLENDIRMETURLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SIKAYETYONLENDIRMETURLER> items) : base(items) { }


            public SIKAYETYONLENDIRMETURLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SIKAYETYONLENDIRMETURLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SIKAYETYONLENDIRMETURLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SIKAYETYONLENDIRMETURLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SIKAYETYONLENDIRMETURLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SIKAYETYONLENDIRMETURLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SIKAYETYONLENDIRMETURLER> Select
        {
            get { return R.Query<SIKAYETYONLENDIRMETURLER>(); }
        }

        public static SIKAYETYONLENDIRMETURLER SelectItem(Decimal ID)
        {
            return R.Query<SIKAYETYONLENDIRMETURLER>().First(t => t.ID == ID);
        }

        public static List<SIKAYETYONLENDIRMETURLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SIKAYETYONLENDIRMETURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SIKAYETYONLENDIRMETURLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SIKAYETYONLENDIRMETURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

