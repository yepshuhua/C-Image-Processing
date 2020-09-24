using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImgGrayTest
{
    internal class HiPerfTimer
    {
        //引用Win32API中的QueryperformanceCounter()方法
        //该查询方法以用来查询任意时刻高精度计时器的实际值
        [DllImport("kernel32.dll")]
        public extern static bool QueryPerformanceCounter(out long x);
        [DllImport("kernel32.dll")]
        public extern static bool QueryPerformanceFrequency(out long x);
        private long startTime, stopTimer;
        private long freq;
        public HiPerfTimer()
        {
            startTime = 0;
            stopTimer = 0;
            if (QueryPerformanceFrequency(out freq) == false)
            {
                throw new Win32Exception();
            }

        }
        public void Start()
        {
            Thread.Sleep(0);
            QueryPerformanceCounter(out startTime);
        }
        public void Stop()
        {
            QueryPerformanceCounter(out stopTimer);
        }
        public double Duration
        {
            get
            {
                return (double)(stopTimer - startTime) * 1000 / (double)freq;
            }
        }
    }
}
