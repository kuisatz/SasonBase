﻿using Antibiotic.Database.Index;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Sason.Views
{
    [DbIndex("CUSTOM_PK", DbIndexType.PrimaryKey, DbIndexFlags.Unique, new string[] { "KURID" })]
    public abstract partial class Table_VT_KURLAR
    {
    }
}
