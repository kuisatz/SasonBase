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
    public class SERVISTEKNISYENLER : SasonBase.Sason.Tables.Table_SERVISTEKNISYENLER.PublicItem
    {
        //public class CONTAINER : Antibiotic.Collections.ListContainer<SERVISTEKNISYENLER>
        //{
        //    Dictionary<Decimal, SERVISTEKNISYENLER> dict = new Dictionary<Decimal, SERVISTEKNISYENLER>();

        //    public CONTAINER() { }

        //    public CONTAINER(IEnumerable<SERVISTEKNISYENLER> items) : base(items) { }


        //    public SERVISTEKNISYENLER this[Decimal ID]
        //    {
        //        get { return dict.find(ID); }
        //    }

        //    public SERVISTEKNISYENLER Get(Decimal ID)
        //    {
        //        return dict.find(ID);
        //    }

        //    public List<SERVISTEKNISYENLER> Gets(params Decimal[] IDs)
        //    {
        //        return dict.findToList(IDs);
        //    }

        //    public List<SERVISTEKNISYENLER> Gets(IEnumerable<Decimal> IDs)
        //    {
        //        return dict.findToList(IDs);
        //    }

        //    protected override void OnBeforeInsert(SERVISTEKNISYENLER item, ref bool cancel)
        //    {
        //        dict.set(item.ID, item, out cancel);
        //    }

        //    protected override void OnAfterRemove(SERVISTEKNISYENLER item)
        //    {
        //        dict.remove(item.ID);
        //    }
        //}




        //public static IOrderedQueryable<SERVISTEKNISYENLER> Select
        //{
        //    get { return R.Query<SERVISTEKNISYENLER>(); }
        //}

        //public static SERVISTEKNISYENLER SelectItem(Decimal ID)
        //{
        //    return R.Query<SERVISTEKNISYENLER>().First(t => t.ID == ID);
        //}

        //public static List<SERVISTEKNISYENLER> SelectItems(params Decimal[] IDs)
        //{
        //    return R.Query<SERVISTEKNISYENLER>().Where(t => t.ID.In(IDs)).ToList();
        //}

        //public static List<SERVISTEKNISYENLER> SelectItems(IEnumerable<Decimal> IDs)
        //{
        //    return R.Query<SERVISTEKNISYENLER>().Where(t => t.ID.In(IDs)).ToList();
        //}
    }

   

}