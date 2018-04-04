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
    public class ILCELER : SasonBase.Sason.Tables.Table_ILCELER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<ILCELER>
        {
            Dictionary<Decimal, ILCELER> dict = new Dictionary<Decimal, ILCELER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<ILCELER> items) : base(items) { }


            public ILCELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public ILCELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<ILCELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<ILCELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public ILCELER GetFromName(ILLER il, string ilceAdi)
            {
                ILCELER ret = null;
                if (il.isNull())
                    return ret;
                
                //return Items.first(t => t.ILID == il.ID && t.AD.trim().ToLower().like(ilAdi.trim().ToLower()));

                string searchStr = ilceAdi.trim().split(' ').first().removeTrChars();

                ret = Items.first(t => t.ILID == il.ID && (t.AD.trim().removeTrChars().like(searchStr) || searchStr.like(t.AD)));
                return ret;
            }


            protected override void OnBeforeInsert(ILCELER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(ILCELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<ILCELER> Select
        {
            get { return R.Query<ILCELER>(); }
        }

        public static ILCELER SelectItem(Decimal ID)
        {
            return R.Query<ILCELER>().First(t => t.ID == ID);
        }

        public static List<ILCELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<ILCELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<ILCELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<ILCELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

