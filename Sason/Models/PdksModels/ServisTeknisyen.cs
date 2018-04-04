using Antibiotic.Database.Relation.Attributes;
using Antibiotic.Extensions;
using SasonBase.Sason.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.PdksModels
{
    public class ServisTeknisyen : TableModels.SERVISTEKNISYENLER
    {
        [ReadOnlyMappedRelation()]
        [RelationCondition("TEKNISYENID", "ID")]
        public TEKNISYENLER Teknisyen { get; set; }

        public string AdiSoyadi { get { return $"{Teknisyen?.AD} {Teknisyen?.SOYAD}"; } }

        public override string ToString()
        {
            return $"ServisTeknisyenId : {this.ID}, TeknisyenId : {Teknisyen?.ID}, Teknisyen Adi Soyadi : {Teknisyen?.AD} {Teknisyen?.SOYAD}";
        }
    }

    public class ServisTeknisyenContainer : Antibiotic.Collections.ListContainer<ServisTeknisyen>
    {
        Dictionary<Decimal, ServisTeknisyen> dict = new Dictionary<Decimal, ServisTeknisyen>();

        public ServisTeknisyenContainer() { }

        public ServisTeknisyenContainer(IEnumerable<ServisTeknisyen> items) : base(items) { }


        public ServisTeknisyen this[Decimal servisTeknisyenId]
        {
            get { return dict.find(servisTeknisyenId); }
        }

        public ServisTeknisyen Get(Decimal servisTeknisyenId)
        {
            return dict.find(servisTeknisyenId);
        }

        public List<ServisTeknisyen> Gets(params Decimal[] servisTeknisyenIds)
        {
            return dict.findToList(servisTeknisyenIds);
        }

        public List<ServisTeknisyen> Gets(IEnumerable<Decimal> servisTeknisyenIds)
        {
            return dict.findToList(servisTeknisyenIds);
        }

        protected override void OnBeforeInsert(ServisTeknisyen item, ref bool cancel)
        {
            dict.set(item.ID, item, out cancel);
        }

        protected override void OnAfterRemove(ServisTeknisyen item)
        {
            dict.remove(item.ID);
        }
    }

}