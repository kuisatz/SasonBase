using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antibiotic.Extensions;

public static class SasonUnitValueController
{
    static Dictionary<string, Type> _UnitTypes = null;
    static Dictionary<string, Type> UnitTypes
    {
        get
        {
            if (_UnitTypes.isNull())
            {
                _UnitTypes = new Dictionary<string, Type>();
                _UnitTypes.Add("FAS", typeof(int));
                _UnitTypes.Add("TAF", typeof(int));
                _UnitTypes.Add("STD", typeof(int));
                _UnitTypes.Add("ST", typeof(int));
                _UnitTypes.Add("SAT", typeof(int));
                _UnitTypes.Add("BOT", typeof(int));
                _UnitTypes.Add("SET", typeof(int));
                _UnitTypes.Add("PK", typeof(int));
                _UnitTypes.Add("PAA", typeof(int));
                _UnitTypes.Add("CM", typeof(decimal));
                _UnitTypes.Add("M3", typeof(decimal));
                _UnitTypes.Add("M2", typeof(decimal));
                _UnitTypes.Add("CM3", typeof(decimal));
                _UnitTypes.Add("L", typeof(decimal));
                _UnitTypes.Add("M", typeof(decimal));
                _UnitTypes.Add("GR", typeof(decimal));
                _UnitTypes.Add("KG", typeof(decimal));
                _UnitTypes.Add("DM", typeof(decimal));
            }
            return _UnitTypes;
        }
    }

    public static bool IsUnitValue(this object value, string unitCode)
    {
        Boolean result = true;
        Type valueType = null;

        string valueStr = value.toString();

        if (value.isNotNullorDbNull() && UnitTypes.TryGetValue(unitCode, out valueType))
        {
            if (valueType.Equals(typeof(int)))
            {
                int virgulIndex = valueStr.IndexOf(",");
                result = virgulIndex < 0 || virgulIndex == valueStr.Length-1;
            }
        }
        return result;
    }

    public static string unformattedCode(this string source)
    {
        return source.Replace(".", "").Replace("-", "");
    }

    public static string KodToMalzemelerKod(this string source)
    {
        return source.Replace("(*)", "").TrimEnd('Y').unformattedCode();
    }
}