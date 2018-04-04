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
    public class SERVISLERWS : SasonBase.Sason.Tables.Table_SERVISLERWS.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISLERWS>
        {
            Dictionary<Decimal, SERVISLERWS> dict = new Dictionary<Decimal, SERVISLERWS>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISLERWS> items) : base(items) { }


            public SERVISLERWS this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISLERWS Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISLERWS> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISLERWS> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISLERWS item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISLERWS item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISLERWS> Select
        {
            get { return R.Query<SERVISLERWS>(); }
        }

        public static SERVISLERWS SelectItem(Decimal ID)
        {
            return R.Query<SERVISLERWS>().First(t => t.ID == ID);
        }

        public static List<SERVISLERWS> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISLERWS>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static SERVISLERWS SelectServisWSInfo(string servisKodu, string servisSifresi, MethodReturn refMr)
        {
            return R.Query<SERVISLERWS>(refMr).First(t => t.WSKODU == servisKodu && t.WSSIFRE == servisSifresi);
        }

        public static List<SERVISLERWS> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISLERWS>().Where(t => t.ID.In(IDs)).ToList();
        }

    }
}