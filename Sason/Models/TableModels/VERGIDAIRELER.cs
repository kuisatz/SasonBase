using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Table;
using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Extensions;
using System.Collections;

namespace SasonBase.Sason.Models.TableModels
{
    [Serializable()]
    public class VERGIDAIRELER : SasonBase.Sason.Tables.Table_VERGIDAIRELER.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<VERGIDAIRELER>
        {
            Dictionary<Decimal, VERGIDAIRELER> dict = new Dictionary<Decimal, VERGIDAIRELER>();
            Hashtable hasTable = new Hashtable();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<VERGIDAIRELER> items) : base(items) { }


            public VERGIDAIRELER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public VERGIDAIRELER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<VERGIDAIRELER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<VERGIDAIRELER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }



            public VERGIDAIRELER GetFromName(string vergiDaireAdi)
            {
                //return hasTable[vergiDaireAdi] as VERGIDAIRELER;
                return Items.first(t => t.AD.removeTrChars().like(getVdName(vergiDaireAdi)));
            }

            public VERGIDAIRELER GetFromNameEx(string vergiDaireAdi, ILLER il)
            {
                VERGIDAIRELER ret = null;
                string vdName = getVdName(vergiDaireAdi);
                if (il.isNull())
                    ret = GetFromName(vdName);
                else
                {
                    ret = base.Items.first(t => t.ILID == il.ID && t.AD.removeTrChars().like(vdName));
                    if (ret.isNull())
                        ret = GetFromName(vdName);
                }
                return ret;
            }

            string getVdName(string vdName)
            {
                return vdName.split(' ').first().removeTrChars();
            }

            //public VERGIDAIRELER GetFromNameEx2(string vergiDaireAdi)
            //{
            //    List<string> vdOpt = vergiDaireAdi.split(' ');
            //    return hasTable[vergiDaireAdi] as VERGIDAIRELER;
            //}


            protected override void OnBeforeInsert(VERGIDAIRELER item, ref bool cancel)
            {
                if (hasTable.ContainsKey(item.AD) == false)
                    hasTable.Add(item.AD, item);
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(VERGIDAIRELER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<VERGIDAIRELER> Select
        {
            get { return R.Query<VERGIDAIRELER>(); }
        }

        public static VERGIDAIRELER SelectItem(Decimal ID)
        {
            return R.Query<VERGIDAIRELER>().First(t => t.ID == ID);
        }

        public static List<VERGIDAIRELER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<VERGIDAIRELER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<VERGIDAIRELER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<VERGIDAIRELER>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}

