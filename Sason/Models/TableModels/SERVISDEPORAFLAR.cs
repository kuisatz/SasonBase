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
    public class SERVISDEPORAFLAR : SasonBase.Sason.Tables.Table_SERVISDEPORAFLAR.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISDEPORAFLAR>
        {
            Dictionary<Decimal, SERVISDEPORAFLAR> dict = new Dictionary<Decimal, SERVISDEPORAFLAR>();
            Dictionary<decimal, Dictionary<string, SERVISDEPORAFLAR>> dkodDict = new Dictionary<decimal, Dictionary<string, SERVISDEPORAFLAR>>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<SERVISDEPORAFLAR> items) : base(items) { }


            public SERVISDEPORAFLAR this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public SERVISDEPORAFLAR Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<SERVISDEPORAFLAR> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<SERVISDEPORAFLAR> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            public SERVISDEPORAFLAR GetFromKod(decimal depoId, string rafKodu)
            {
                return dkodDict.find(depoId).find(rafKodu);
            }

            protected override void OnBeforeInsert(SERVISDEPORAFLAR item, ref bool cancel)
            {
                dkodDict.check(item.SERVISDEPOID).set(item.KOD, item);
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(SERVISDEPORAFLAR item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<SERVISDEPORAFLAR> Select
        {
            get { return R.Query<SERVISDEPORAFLAR>(); }
        }

        public static SERVISDEPORAFLAR SelectItem(Decimal ID)
        {
            return R.Query<SERVISDEPORAFLAR>().First(t => t.ID == ID);
        }

        public static List<SERVISDEPORAFLAR> SelectItems(params Decimal[] IDs)
        {
            return R.Query<SERVISDEPORAFLAR>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<SERVISDEPORAFLAR> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<SERVISDEPORAFLAR>().Where(t => t.ID.In(IDs)).ToList();
        }



        public static MethodReturn RepairDepoRaf(SERVISDEPOLAR depo, string strRaf, decimal servisId)
        {
            MethodReturn ret = new MethodReturn();
            if (depo == null)
                return ret;

            if (strRaf.isNullOrWhiteSpace())
                strRaf = "1.Raf";

            SERVISDEPORAFLAR foundRaf = R.Query<SERVISDEPORAFLAR>(ret).First(t => t.SERVISDEPOID == depo.ID && t.AD == strRaf).createIsNull();

            if (ret.ok() && foundRaf.IsNew())
            {
                decimal seqId = Convert.ToDecimal(SasonBase.SasonBaseApplicationPool.Get.EbaTestConnector.ExecuteScalar("select SERVISDEPORAFLAR_SEQ.NEXTVAL from dual", ret));
                if (ret.ok())
                {
                    foundRaf.ID           = seqId;
                    foundRaf.KOD          = strRaf;
                    foundRaf.AD           = strRaf;
                    foundRaf.SERVISDEPOID = depo.ID;
                    foundRaf.DURUMID      = 1;

                    ret = foundRaf.Update();
                }
            }

            return ret;
        }

        public static SERVISDEPORAFLAR CreateRaf(SERVISDEPOLAR depo, string strRaf, decimal servisId, MethodReturn mr = null)
        {
            SERVISDEPORAFLAR foundRaf = R.Query<SERVISDEPORAFLAR>(mr).First(t => t.SERVISDEPOID == depo.ID && t.AD == strRaf).createIsNull();
            if (mr.ok() && foundRaf.IsNew())
            {
                decimal seqId = Convert.ToDecimal(SasonBase.SasonBaseApplicationPool.Get.EbaTestConnector.ExecuteScalar("select SERVISDEPORAFLAR_SEQ.NEXTVAL from dual", mr));
                if (mr.ok())
                {
                    foundRaf.ID = seqId;
                    foundRaf.KOD = strRaf;
                    foundRaf.AD = strRaf;
                    foundRaf.SERVISDEPOID = depo.ID;
                    foundRaf.DURUMID = 1;

                    mr = foundRaf.Update();
                }
            }
            return foundRaf;
        }

    }
}

