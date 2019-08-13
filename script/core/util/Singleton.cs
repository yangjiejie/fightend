using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Core.Util
{
    public class Singleton<T> where T : new()
    {
        private static T _Instance = default(T);
        public static T Instance
        {
            get
            {
                if ((_Instance as object) == null)
                {
                    _Instance = new T();
                }
                return _Instance;
            }
        }

        protected Singleton()
        {

        }
    }
    

    
}
