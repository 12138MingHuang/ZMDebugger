using System;
using UnityEngine;

namespace UnityDebugger
{
    public class LogSystem : MonoBehaviour
    {
        private void Awake()
        {
            Debuger.InitLog(new LogConfig
            {
                openLog = true,
                openTime = true,
                showThreadID = true,
                showColorName = true
            });
            Debuger.Log("Log");
            Debuger.LogWarning("LogWarning");
            Debuger.LogError("LogError");
            Debuger.ColorLog(LogColor.Cyan, "ColorLog");
            Debuger.LogGreen("LogGreen");
            Debuger.LogYellow("LogYellow");
        }
    }
}
