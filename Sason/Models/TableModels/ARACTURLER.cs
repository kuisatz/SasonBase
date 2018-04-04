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
    public class ARACTURLER : SasonBase.Sason.Tables.Table_ARACTURLER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ARACTURLER>
        {
            Dictionary<Decimal, ARACTURLER> dict = new Dictionary<Decimal, ARACTURLER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ARACTURLER> items) : base(items) { }


            public ARACTURLER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ARACTURLER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ARACTURLER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ARACTURLER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(ARACTURLER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ARACTURLER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ARACTURLER> Select
        {
            get { return R.Query<ARACTURLER>(); }
        }

        public static ARACTURLER SelectItem(Decimal ID)
        {
            return R.Query<ARACTURLER>().First(t => t.ID == ID);
        }

        public static List<ARACTURLER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ARACTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ARACTURLER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ARACTURLER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

