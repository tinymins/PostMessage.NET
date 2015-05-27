using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace PostMessage.NET {
partial class Program {
    struct Key {
        public IntPtr nKCode;
        public int nPress;
        public int nDelay;
    }
    static void Main(string[] args) {
        // args = new string[] { "31212", "54,2000,2000" };
        // Check arguments
        if (args.Length != 2) {
            Console.WriteLine("Wrong numbers of arguments! 2 expected, got " + args.Length + "!");
            return;
        }
        // Parse keylist
        int nProcessId = int.Parse(args[0]);
        string[] list = args[1].Split(';');
        Key[] keylist = new Key[list.Length];
        for (int i = 0; i < list.Length; i++) {
            string[] line = list[i].Split(',');
            if (line.Length != 3) {
                Console.WriteLine("Error when parse keylist around \"" + list[i] + "\"!");
                return;
            }
            keylist[i].nKCode = (IntPtr)int.Parse(line[0]);
            keylist[i].nPress = int.Parse(line[1]);
            keylist[i].nDelay = int.Parse(line[2]);
        }
        // Try to post message
        try {
            Process p = Process.GetProcessById(nProcessId);
            IntPtr h = p.MainWindowHandle;
            while (true) {
                foreach (Key key in keylist) {
                    PostMessage(h, WM_KEYDOWN, key.nKCode, IntPtr.Zero);
                    Console.WriteLine("Process \"" + p.ProcessName + "\" post message KEYDOWN with key code " + key.nKCode + ".");
                    System.Threading.Thread.Sleep(key.nPress);
                    Console.WriteLine("Process \"" + p.ProcessName + "\" KEYPRESSING for " + key.nPress + "ms.");
                    PostMessage(h, WM_KEYUP, key.nKCode, IntPtr.Zero);
                    Console.WriteLine("Process \"" + p.ProcessName + "\" post message KEYUP with key code " + key.nKCode + ".");
                    System.Threading.Thread.Sleep(key.nDelay);
                    Console.WriteLine("Process \"" + p.ProcessName + "\" DELAYING for " + key.nDelay + "ms.");
                }
            }
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
            return;
        }
    }
}
}
