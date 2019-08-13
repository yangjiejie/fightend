using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace XGAME
{
    public delegate void LoadResCallBack(UnityEngine.Object res);
    public class ResMgr : IMgrBase // 这个是需要慢慢迭代的 一开始资源不会很多不考虑分层 
    {
       
        public Dictionary<string, ResNode> pathResMap;
        public Queue resRequestQueue = new Queue();
        // Use this for initialization
        public void Start() // start自身的 awake别人的 
        {
            pathResMap = new Dictionary<string, ResNode>();
        }

        // Update is called once per frame
        public void Update()
        {
            if(resRequestQueue.Count >0 )
            {
                var node = resRequestQueue.Dequeue() as ResNode;
                LoadImp(node);
            }
        }
        public ResNode Load(string path, LoadResCallBack cb) // 加载预设 程序不要在内部实例化 这个工作交给外部
        {
            path = "Assets/"+ path;
            ResNode tmpNode = null;
            if (!pathResMap.ContainsKey(path))
            {
                tmpNode = new ResNode();
                tmpNode.asset = null;
                tmpNode.path = path;
                pathResMap.Add(path, tmpNode);
                tmpNode.AddCallBack(cb);
            }
            else
            {
                tmpNode = pathResMap[path];
                
                tmpNode.AddRef();
                tmpNode.AddCallBack(cb);
            }
           
            //将请求缓存起来 
            resRequestQueue.Enqueue(tmpNode);
            return tmpNode;
        }

        public void LoadImp(ResNode resNode)
        {
            if(resNode.asset != null)
            {
                return;
                
            }
            else
            {
#if UNITY_EDITOR
                resNode.asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(resNode.path);
#endif
            }
            //回调 
            resNode.TriggerCallback();
        }


        public void UnLoad(string path)
        {
            path = "Assets/" + path;
            if (!pathResMap.ContainsKey(path))
            {
                return;
            }
            int rst = pathResMap[path].Release();
            if(rst == 1)
            {
                pathResMap.Remove(path);
            }

        }

    }
}



