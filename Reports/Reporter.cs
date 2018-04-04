using Antibiotic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase.Reports
{
    public abstract class Reporter : IDisposable
    {
        Dictionary<string, ReporterParameter> dictionary = new Dictionary<string, ReporterParameter>();

        public Reporter()
        {
            SasonBaseApplicationPool sasonBaseApplicationPool = AppPool;
        }

        public string Text { get; set; }
        public string SubjectCode { get; set; }
        public string ReportFileCode { get; set; }
        public decimal ServisId { get; set; }
        public bool Disabled { get; set; }

        protected void AddParameter(ReporterParameter parameter)
        {
            dictionary.set(parameter.Name, parameter);
        }

        public ReporterParameter GetParameter(string name)
        {
            return dictionary.find(name);
        }

        public virtual ReporterParameter SetParameterIncomingValue(string parameterName, object value)
        {
            ReporterParameter teknisyenReporterParameter = GetParameter(parameterName);
            if (teknisyenReporterParameter.isNotNull())
                teknisyenReporterParameter.IncomingValue = value;
            return teknisyenReporterParameter;
        }

        public ReporterParameter SetParameterReporterValue(string parameterName, object value)
        {
            ReporterParameter teknisyenReporterParameter = GetParameter(parameterName);
            if (teknisyenReporterParameter.isNotNull())
                teknisyenReporterParameter.ReporterValue = value;
            return teknisyenReporterParameter;
        }

        public List<ReporterParameter> GetParameters
        {
            get { return dictionary.values().toList(); }
        }


        bool customAppPool = false;
        SasonBaseApplicationPool _AppPool = null;
        protected SasonBaseApplicationPool AppPool
        {
            get
            {
                customAppPool = false;
                _AppPool = R.AppPool as SasonBaseApplicationPool;
                if (_AppPool.isNull())
                {
                    _AppPool = SasonBaseApplicationPool.Create;
                    customAppPool = true;
                }
                return _AppPool;
            }
        }

        protected void CloseCustomAppPool()
        {
            if (customAppPool && _AppPool != null)
                _AppPool.Dispose();
        }

        public virtual object ExecuteReport(MethodReturn refMr = null)
        {
            return null;
        }

        public void Dispose()
        {
            CloseCustomAppPool();
        }
    }
}