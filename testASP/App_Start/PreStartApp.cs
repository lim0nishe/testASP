using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testASP.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PreStartApp), "Start")]
namespace testASP.App_Start
{
    public static class PreStartApp
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Start()
        {
            logger.Info("Application PreStart");
        }
    }
}