using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports
{
    public enum ParameterValueType
    {
        String,
        DateTime,
        TeknisyenSecimi,
    }

    public class ReporterParameter
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Html { get; set; }
        public string Js { get; set; }
        public object IncomingValue { get; set; }
        public object ReporterValue { get; set; }
        public ParameterValueType ValueType { get; set; }
    }
}