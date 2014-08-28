using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH10
{
    class Program
    {
        static void Main(string[] args)
        {
            // 範例一
            // PreVersion();

            // 範例二
            // DebugAndTrace();

            // 範例三
            // MsgLevel();

            // 範例四
            //  // 應該從資料庫取得
            //  int UnitQty = 1000;
            //  double UnitCost = 1200;
            //  // 開發時期的驗證
            //  DegubStatus(UnitQty, UnitCost);
            //  Console.ReadLine();

            // 範例五
            // 需配合 App.config / web.config 組態
            //TextWriterTraceListener textListener =
            //    new TextWriterTraceListener(System.IO.File.CreateText("Debug.txt"));
            //Debug.Listeners.Add(textListener);
            //
            //int UnitQty = 1000;
            //double UnitCost = 1200;
            //DegubStatus(UnitQty, UnitCost);
            //Debug.Flush();

            // 範例六
            // 需配合 App.config / web.config 組態
            //EventLogTraceListener eventLog =
            //    new EventLogTraceListener("Application");
            //Trace.Listeners.Add(eventLog);
            //Trace.TraceInformation("Send trace info test.");
            //Console.ReadLine();

        }

        static void PreVersion()
        {
#if (Version1)
        Console.WriteLine("Version1 Code");
#endif
#if (Version2)
            Console.WriteLine("Version2 Code");
#endif
            Console.ReadLine();
        }

        static void DebugAndTrace()
        {
            Debug.WriteLine("Debug Information.");
            Trace.WriteLine("Trace Information.");
            int x = 7, y = 2;
            Trace.WriteIf(x > y, "x 大於 y.");
            Console.ReadLine();
        }

        static void MsgLevel()
        {
            Trace.WriteLine("一般訊息。"); 			//灰色（Write相同）
            Trace.TraceInformation("告知性訊息。");	//藍色
            Trace.TraceWarning("警告訊息。");		//深黃
            Trace.TraceError("錯誤訊息。");
            Console.ReadLine();
        }

        [Conditional("DEBUG")]
        static void DegubStatus(int UnitQty, double UnitCost)
        {
            // 計算
            Debug.WriteLine("總成本：" + (UnitQty * UnitCost));
            // 條件
            Debug.WriteLineIf(UnitQty > 100, "庫存 > 100 本。");
            Debug.WriteLineIf(UnitQty < 100, "庫存 < 100 本。");
            // 驗證
            Debug.Assert(!(UnitCost > 1000), "成本 > 1000 太貴了！");
            Debug.Assert(!(UnitCost < 100), "成本 < 1 不合理！");
        }

    }
}
