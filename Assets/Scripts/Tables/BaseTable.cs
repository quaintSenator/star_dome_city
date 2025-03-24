using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public class BaseTable
    {
        
    }
}
