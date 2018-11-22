﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petShikongParser
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            beforeRun preview = new beforeRun();
            preview.ShowDialog();
            if(preview.bComplete)
            {
                Application.Run(new parserMain(preview));
            }
        }
    }
}
