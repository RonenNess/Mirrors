using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MirrorsUnitTests
{

    /// <summary>
    /// All basic get keys / names tests.
    /// </summary>
    [TestClass]
    public class GetKeysAndNames
    {
        /// <summary>
        /// Make sure Keys() work.
        /// </summary>
        [TestMethod]
        public void GetKeys()
        {
            // create test object
            TestObjForNames test = new TestObjForNames();

            // test getting public + private keys
            {
                var keys = Mirrors.Mirrors.Keys(test, false);
                HashSet<string> expectedKeys = new HashSet<string>(new string[] {
                    "pub_field",
                    "prv_field",
                    "pub_prop",
                    "prv_prop",
                    "pub_func",
                    "prv_func",
                    "ToString"
                });
                foreach (var mustHave in expectedKeys)
                    Assert.IsTrue(keys.Contains(mustHave), "Missing key: " + mustHave);
            }

            // test getting public keys
            {
                var keys = Mirrors.Mirrors.Keys(test, true);
                HashSet<string> expectedKeys = new HashSet<string>(new string[] {
                    "pub_field",
                    "pub_prop",
                    "pub_func",
                    "ToString"
                });
                foreach (var mustHave in expectedKeys)
                    Assert.IsTrue(keys.Contains(mustHave), "Missing key: " + mustHave);
                Assert.IsFalse(keys.Contains("prv_field"), "prv_field should not appear when asking only public members!");
            }

            // test getting public + private keys, only declared
            {
                var keys = Mirrors.Mirrors.Keys(test, false, true);
                HashSet<string> expectedKeys = new HashSet<string>(new string[] {
                    "pub_field",
                    "prv_field",
                    "pub_prop",
                    "prv_prop",
                    "pub_func",
                    "prv_func"
                });
                foreach (var mustHave in expectedKeys)
                    Assert.IsTrue(keys.Contains(mustHave), "Missing key: " + mustHave);
                Assert.IsFalse(keys.Contains("ToString"), "ToString should not appear when asking only declared members!");
            }

            // test getting public keys, only declared
            {
                var keys = Mirrors.Mirrors.Keys(test, true, true);
                HashSet<string> expectedKeys = new HashSet<string>(new string[] {
                    "pub_field",
                    "pub_prop",
                    "pub_func"
                });
                foreach (var mustHave in expectedKeys)
                    Assert.IsTrue(keys.Contains(mustHave), "Missing key: " + mustHave);
                Assert.IsFalse(keys.Contains("prv_field"), "prv_field should not appear when asking only public members!");
                Assert.IsFalse(keys.Contains("ToString"), "ToString should not appear when asking only declared members!");
            }
        }
    }
}
