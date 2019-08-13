using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace XGAME
{
    [CustomEditor(typeof(Test))]
    public class TestEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if(GUILayout.Button("测试资源加载"))
            {
                var tmp = target as Test;
                tmp.LoadRes("prefab/cube.prefab");
            }

            if (GUILayout.Button("测试资源卸载"))
            {
                var tmp = target as Test;
                tmp.UnLoad("prefab/cube.prefab");
            }

        }
    }

    public class Test : MonoBehaviour
    {

        private void Awake()
        {
           
        }

        public void LoadRes(string str)
        {
            ResMgr mgr = Game.Instance.GetMgr(MgrDefine.RES_MANAGER) as ResMgr;
            mgr.Load(str, (res) =>
            {
                Debug.Log("加载资源回调" + res.name);
                
            });
        }

        public void UnLoad(string str)
        {
            ResMgr mgr = Game.Instance.GetMgr(MgrDefine.RES_MANAGER) as ResMgr;
            mgr.UnLoad(str);
        }
        
    }
}
