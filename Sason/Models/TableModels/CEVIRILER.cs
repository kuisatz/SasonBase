using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Database.Table;
using Antibiotic.Database.Field;
using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Extensions;
using System.Data;

namespace SasonBase.Sason.Models.TableModels
{
    [Serializable()]
    public class CEVIRILER : SasonBase.Sason.Tables.Table_CEVIRILER.PublicItem
    {



        public class CONTAINER : Antibiotic.Collections.ListContainer<CEVIRILER>
        {
            Dictionary<Decimal, CEVIRILER> dict = new Dictionary<Decimal, CEVIRILER>();

            public CONTAINER() { }

            public CONTAINER(IEnumerable<CEVIRILER> items) : base(items) { }


            public CEVIRILER this[Decimal ID]
            {
                get { return dict.find(ID); }
            }

            public CEVIRILER Get(Decimal ID)
            {
                return dict.find(ID);
            }

            public List<CEVIRILER> Gets(params Decimal[] IDs)
            {
                return dict.findToList(IDs);
            }

            public List<CEVIRILER> Gets(IEnumerable<Decimal> IDs)
            {
                return dict.findToList(IDs);
            }

            protected override void OnBeforeInsert(CEVIRILER item, ref bool cancel)
            {
                dict.set(item.ID, item, out cancel);
            }

            protected override void OnAfterRemove(CEVIRILER item)
            {
                dict.remove(item.ID);
            }
        }




        public static IOrderedQueryable<CEVIRILER> Select
        {
            get { return R.Query<CEVIRILER>(); }
        }

        public static CEVIRILER SelectItem(Decimal ID)
        {
            return R.Query<CEVIRILER>().First(t => t.ID == ID);
        }

        public static List<CEVIRILER> SelectItems(params Decimal[] IDs)
        {
            return R.Query<CEVIRILER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static List<CEVIRILER> SelectItems(IEnumerable<Decimal> IDs)
        {
            return R.Query<CEVIRILER>().Where(t => t.ID.In(IDs)).ToList();
        }

        public static MethodReturn RepairTRCeviri(string tableName, decimal ownerId, string dilKarsiligiDeger)
        {
            return RepairTRCeviri(tableName, "AD", ownerId, dilKarsiligiDeger);
        }

        public static MethodReturn RepairTRCeviri(string tableName, string columnName, decimal ownerId, string dilKarsiligiDeger)
        {
            //exec ceviri_pkg.ekle2 (0, 'BAKIMDEGISIMKALEMLER', 'AD', 676, 'Alçak basýnç Gaz Tahliye Hortumu', 'Turkish');
            MethodReturn mr = new MethodReturn();

            SasonBaseApplicationPool appPool = SasonBaseApplicationPool.Get;
            DataTable dtb = appPool.EbaTestConnector.GetDataTable($@"SELECT  CEV.ID AS CEVIRILER_ID, LID.ID AS LISTELER_ID, LAID.ID AS LISTEALAN_ID FROM 
                (SELECT ID FROM LISTELER WHERE KOD = '{tableName}') LID
                    LEFT JOIN LISTEALANLAR LAID ON LAID.LISTEID = LID.ID AND LAID.KOD = '{columnName}'
                    LEFT JOIN CEVIRILER CEV ON CEV.LISTEALANID = LAID.ID AND CEV.DILID = 0 AND CEV.ALANID = {ownerId}", mr);

            decimal ceviriId = 0;
            decimal listeAlanId = 0;
            if (dtb.IsNotEmpty())
            {
                ceviriId = dtb.FirstRow()["CEVIRILER_ID"].cto<decimal>();
                listeAlanId = dtb.FirstRow()["LISTEALAN_ID"].cto<decimal>();
            }
            else
            {
                return mr;
            }

            if (mr.ok())
            {
                CEVIRILER ceviri = Select.First(t => t.ID == ceviriId);
                if (ceviri.isNull())
                {
                    decimal seqId = Convert.ToDecimal(appPool.EbaTestConnector.ExecuteScalar("select CEVIRILER_SEQ.NEXTVAL from dual", mr));
                    if (mr.ok())
                    {
                        ceviri = new CEVIRILER()
                        {
                            ID = seqId,
                            LISTEALANID = listeAlanId,
                            DILID = 0,
                            ALANID = ownerId,
                        };
                    }
                }

                ceviri.DEGER = dilKarsiligiDeger;

                if (mr.ok())
                    mr = ceviri.Update();
            }

            return mr;

            /*
SELECT 
    CEV.ID 
FROM 
    (SELECT ID FROM LISTELER WHERE KOD = 'BAKIMDEGISIMKALEMLER') LID
        LEFT JOIN LISTEALANLAR LAID ON LAID.LISTEID = LID.ID AND LAID.KOD = 'AD'
        LEFT JOIN CEVIRILER CEV ON CEV.LISTEALANID = LAID.ID AND CEV.DILID = 0 AND CEV.ALANID = 676
             */

        }


    }
}

