using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MirrorsUnitTests
{

    /// <summary>
    /// Test misc stuff
    /// </summary>
    [TestClass]
    public class TestMiscs
    {
        /// <summary>
        /// Make sure ClassName works.
        /// </summary>
        [TestMethod]
        public void GetClassname()
        {
            TestObjForNames test = new TestObjForNames();
            Assert.AreEqual(Mirrors.Mirrors.ClassName(test), "TestObjForNames");
        }

        /// <summary>
        /// Make sure Invoke works.
        /// </summary>
        [TestMethod]
        public void TestInvoke()
        {
            TestObjForNames test = new TestObjForNames();
            Assert.AreEqual(Mirrors.Mirrors.Invoke(test, "pub_func"), test.pub_func());
        }
    }
}
