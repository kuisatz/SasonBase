﻿using Antibiotic.Database.Relation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Models.ReportModels
{
    public class RptUlke : SasonBase.Sason.Tables.Table_ULKELER.RawItem
    {
        protected virtual Decimal ID { get; set; }
        //protected virtual String KOD { get; set; }

        [ReadOnlyMappedRelation]
        [RelationCondition("ID","ALANID")]
        [RelationCondition("app:LanguageId", "DILID")]
        [RelationCondition("3", "LISTEALANID")]
        RptCeviri Ceviri { get; set; }
        public string UlkeAdi { get { return Ceviri?.DEGER; } }
    }
}