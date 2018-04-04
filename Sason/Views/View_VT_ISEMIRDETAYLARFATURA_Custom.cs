using Antibiotic.Database.Index;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Views
{
    [DbIndex("CUSTOM_PK", DbIndexType.PrimaryKey, DbIndexFlags.Unique, new string[] { "REFERANSID" })]
    public abstract partial class View_VT_ISEMIRDETAYLARFATURA
    {
    }
}