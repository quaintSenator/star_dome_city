using System.Collections.Generic;

namespace Config
{
    public class SingletonBase<T> where T : new()
    {
        private static T instance;

        protected SingletonBase()
        {
        } // 保护构造函数，防止外部直接实例化

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }
    }

    public class MatterTable : SingletonBase<MatterTable>
    {
        #region auto_generate_start

        List<int> matterIDs = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7 });

        List<string> names = new List<string>(new string[] { "H2", "O2", "H20", "C02", "CH4", "CH3OH", "N2" });

        List<double> specific_heat_capacitys =
            new List<double>(new double[] { 14.3, 0.918, 4.1816, 0.839, 2.191, 2.14, 1.04 });

        List<double> molecular_weights =
            new List<double>(new double[] { 2.016, 31.998, 18.015, 44.009, 16.043, 32.042, 28.014 });

        List<double> densitys = new List<double>(new double[] { 0.09, 1.428, 1, 1.96, 0.7162, 1.4304, 1.25 });

        #endregion auto_generate_end
    }
}