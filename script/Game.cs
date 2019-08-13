using UnityEngine;
using Core.Util;
using System.Collections.Generic;

namespace XGAME
{
    public class Game : Singleton<Game>
    {
        public List<IMgrBase> mgrlist;
        public string name = "game";
        public void Awake()
        {
            Debug.Log("awake");
            mgrlist = new List<IMgrBase>();
            //初始化各个模块 各个系统 管理器 
            mgrlist.Add(new ResMgr());
        }
        public void Update()
        {
            for (int i = 0; i < mgrlist.Count; i++)
            {
                mgrlist[i].Update();
            }
        }

        public void Start()
        {
            for(int i = 0; i < mgrlist.Count; i++)
            {
                mgrlist[i].Start();
            }
        }
        public IMgrBase GetMgr(MgrDefine define)
        {
            int id = (int)define;
            if(mgrlist == null || id >= mgrlist.Count || id < 0 )
            {
                return null;
            }
            return mgrlist[id];
        }

        
    }
}
