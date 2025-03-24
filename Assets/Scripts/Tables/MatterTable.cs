using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Config
{
    [Serializable()]
    public class MatterTable : SingletonBase<MatterTable>
    {
        public int testField { get; set; }

        #region auto_generate_start

        List<int> IDs { get; set; } = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7 });

        List<string> names { get; set; } =
            new List<string>(new string[] { "H2", "O2", "H20", "C02", "CH4", "CH3OH", "N2" });

        List<double> specific_heat_capacitys { get; set; } =
            new List<double>(new double[] { 14.3, 0.918, 4.1816, 0.839, 2.191, 2.14, 1.04 });

        List<double> molecular_weights { get; set; } = new List<double>(new double[]
            { 2.016, 31.998, 18.015, 44.009, 16.043, 32.042, 28.014 });

        List<double> densitys { get; set; } =
            new List<double>(new double[] { 0.09, 1.428, 1, 1.96, 0.7162, 1.4304, 1.25 });
        #endregion auto_generate_end

        public void testFunc()
        {
            var t = GetType();
            var props = t.GetFields(BindingFlags.NonPublic |
                                    BindingFlags.GetProperty |
                                    BindingFlags.Public | BindingFlags.Instance);
            Debug.Log(props.Length);
            foreach (var prop in props)
            {
                Debug.Log(prop.Name);
                if (prop.Name.Contains("names"))
                {
                    var list = (List<string>)prop.GetValue(this);
                    Debug.Log(list[1]);
                }
            }
        }

        public T getTableValue<T>(string TabName, int ID)
        {
            var t = GetType();
            var props = t.GetProperties(BindingFlags.NonPublic |
                                        BindingFlags.GetProperty |
                                        BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                if (prop.Name.Contains("names"))
                {
                    var list = (List<T>)prop.GetValue(this);
                    return list[ID - 1];
                }
            }
            return default(T);
        }
    }
}