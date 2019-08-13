using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace XGAME
{
    //public class  CallBackPool
    //{
    //    public delegate void LoadResCallBack(UnityEngine.Object res);
    //    public CallBackPool()
    //    {
    //        callStack = new Stack<LoadResCallBack>();
    //    }
        

    //    public void Release()
    //    {

    //    }

    //    public void Get()
    //    {
    //        if(callStack.Count > 0)
    //        {
    //            var newCallBack = callStack.Pop();
    //        }
    //    }

    //    public Stack<LoadResCallBack> callStack;
    //}

    public class ResNode  //资源结点定义 
    {
        public LinkedList<LoadResCallBack> m_callbacks;
        
        public UnityEngine.Object asset;
        public string path; // 唯一确定这个资源
        public int refCount; // 引用技术 
        public ResNode()
        {
            this.refCount = 1;
            path = "";
            asset = null;
            m_callbacks = new LinkedList<LoadResCallBack>();
        }
        public void AddRef()
        {
            ++refCount;
        }
        public void DelRef()
        {
            if(refCount > 0)
            {
                --refCount;
            }
        }
        public int Release()
        {
            DelRef();
            if(refCount == 0)
            {
                //卸载ab 
#if UNITY_EDITOR
                Debug.Log("卸载AB");
                return 1;
#endif          
            }
            return 0;
        }

        public void AddCallBack(LoadResCallBack cb)
        {
            m_callbacks.AddLast(cb);
        }
        public void TriggerCallback()
        {
            if(m_callbacks.First != null)
            {
                var call = m_callbacks.First.Value;
                call(this.asset);
                m_callbacks.RemoveFirst();
            }
        }
    }
}


