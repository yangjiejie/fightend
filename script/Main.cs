using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace XGAME
{
    public class Main  : MonoBehaviour
    {
        
        private void Awake()
        {
            Game.Instance.Awake();    
        }

        private void Update() // 游戏更新源头
        {
            Game.Instance.Update();
        }
        private void Start()
        {
            Game.Instance.Start();
        }
    }
}
