using System;
using System.Text;
using System.Threading;

namespace UnityDebugger
{
    public class Debuger
    {
        public static LogConfig cfg;
        
        public static void InitLog(LogConfig config = null)
        {
            if (config == null)
                cfg = new LogConfig();
            else
                cfg = config;
        }

        #region 普通日志

        public static void Log(object obj)
        {
            if(!cfg.openLog) return;
            
            string log = GenerateLog(obj.ToString());
            UnityEngine.Debug.Log(log);
        }

        public static void Log(object obj, params object[] args)
        {
            if (!cfg.openLog) return;

            string content = string.Empty;
            if(args != null && args.Length > 0)
            {
                foreach (var item in args)
                {
                    content += item;
                }
            }
            string log = GenerateLog(obj + content);
            UnityEngine.Debug.Log(log);
        }
        
        public static void LogWarning(object obj)
        {
            if(!cfg.openLog) return;
            
            string log = GenerateLog(obj.ToString());
            UnityEngine.Debug.LogWarning(log);
        }

        public static void LogWarning(object obj, params object[] args)
        {
            if (!cfg.openLog) return;

            string content = string.Empty;
            if(args != null && args.Length > 0)
            {
                foreach (var item in args)
                {
                    content += item;
                }
            }
            string log = GenerateLog(obj + content);
            UnityEngine.Debug.LogWarning(log);
        }
        
        public static void LogError(object obj)
        {
            if(!cfg.openLog) return;
            
            string log = GenerateLog(obj.ToString());
            UnityEngine.Debug.LogError(log);
        }

        public static void LogError(object obj, params object[] args)
        {
            if (!cfg.openLog) return;

            string content = string.Empty;
            if(args != null && args.Length > 0)
            {
                foreach (var item in args)
                {
                    content += item;
                }
            }
            string log = GenerateLog(obj + content);
            UnityEngine.Debug.LogError(log);
        }
        
        #endregion
        
        private static string GenerateLog(string log, LogColor color = LogColor.None)
        {
            StringBuilder stringBuilder = new StringBuilder(cfg.logHeadFix, 100);
            if (cfg.openTime)
            {
                stringBuilder.AppendFormat(" {0:hh:mm:ss-fff}", DateTime.Now);
            }
            if (cfg.showThreadID)
            {
                stringBuilder.AppendFormat(" [ThreadID:{0}]", Thread.CurrentThread.ManagedThreadId);
            }
            if (cfg.showColorName)
            {
                stringBuilder.AppendFormat(" {0}", color.ToString());
            }
            stringBuilder.AppendFormat(" {0}", log);
            return stringBuilder.ToString();
        }
    }
}
