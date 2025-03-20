using System.Collections.Generic;

namespace Config
{
    public class SingletonBase<T> where T : new()
    {
        private static T instance;
        protected SingletonBase() { } // 保护构造函数，防止外部直接实例化
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
        //
        List<int> numbers = new List<int>(new int[] { 1, 2, 3, 4, 5 });

        #endregion auto_generate_end
    }
}