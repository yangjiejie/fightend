using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XGAME
{
    public enum MgrDefine
    {
        RES_MANAGER = 0,
    }

    public interface IMgrBase
    {
        void Start();
        void Update();
        
    }
}
