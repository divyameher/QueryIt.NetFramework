﻿using System;
//using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReflectIt.Tests
{
    [TestClass]
    public class IoCTests
    {
        [TestMethod]
        public void Can_Resolve_Types()
        {
            var ioc = new Container();
            ioc.For<ILogger>().Use<SqlServerLogger>();
            var logger = ioc.Resolve<ILogger>();
            Assert.AreEqual(typeof(SqlServerLogger), logger.GetType());
        }
    }
}
