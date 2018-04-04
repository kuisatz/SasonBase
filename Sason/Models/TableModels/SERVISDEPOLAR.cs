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
    public class SERVISDEPOLAR : SasonBase.Sason.Tables.Table_SERVISDEPOLAR.PublicItem
    {
        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISDEPOLAR>
        {
            Dictionary<Decimal, SERVISDEPOLAR> dict = new Dictionary<Decimal, SERVISDEPOLAR>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISDEPOLAR> items) : base(items) { }


            public SERVISDEPOLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISDEPOLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISDEPOLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISDEPOLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(SERVISDEPOLAR item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISDEPOLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISDEPOLAR> Select
        {
            get { return R.Query<SERVISDEPOLAR>(); }
        }

        public static SERVISDEPOLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISDEPOLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISDEPOLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISDEPOLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISDEPOLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISDEPOLAR>().Where(t => t.ID.In(IDs)).ToList();
        }


        public static void ModifyDepolar(MethodReturn refMr, decimal servisId, List<string> depolar)
        {
            foreach (string depo in depolar)
            {
                CheckAndGetDefaultDepo(refMr, servisId, depo);
                if (refMr.error())
                    break;
            }
        }

        public static SERVISDEPOLAR CheckAndGetDefaultDepo(MethodReturn refMr, decimal servisId, string depoAdi = "")
        {
            refMr = refMr.createIsNull();

            string writeDepoKodu = "001";
            string writeDepoAdi = "Ana Depo";

            SERVISDEPOLAR defaultDepo = null;
            if (depoAdi.isNullOrWhiteSpace())
            {
                defaultDepo = Select.OrderBy(t => t.KOD).First(t => t.SERVISID == servisId);
            }
            else
            {
                writeDepoKodu = depoAdi;
                writeDepoAdi = depoAdi;
                defaultDepo = Select.First(t=> t.AD == writeDepoAdi && t.SERVISID == servisId);
            }

            if (defaultDepo.isNull())
            {
                decimal seqId = Convert.ToDecimal(SasonBaseApplicationPool.Get.EbaTestConnector.ExecuteScalar("select SERVISDEPOLAR_SEQ.NEXTVAL from dual", refMr));
                if (refMr.ok())
                {
                    defaultDepo = new SERVISDEPOLAR()
                    {
                        ID               = seqId,
                        KOD              = writeDepoKodu,// "001",
                        AD               = writeDepoAdi,// "Ana Depo",
                        SERVISDEPOGRUPID = null,
                        DEPOTIPID        = 0,
                        RAFSIZ           = 0,
                        DURUMID          = 1,
                        SERVISID         = servisId,
                    };

                    refMr = defaultDepo.Update();
                }
                if (refMr.error())
                    defaultDepo = null;
            }
            return defaultDepo;
        }
        


    }
}

