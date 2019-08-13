using UnityEngine;
using UnityEditor;

namespace XGAME
{
    public class PrefabLoader : Loader
    {
        public void Load(string path,LoadResCallBack cb)
        {
            ResMgr mgr = Game.Instance.GetMgr(MgrDefine.RES_MANAGER) as ResMgr;
            path = "Assets/" + path;
            mgr.Load(path, (res)=>
            {
                var go  =  GameObject.Instantiate(res) as GameObject;
                
                cb(go);
            });
        }
    }
}

