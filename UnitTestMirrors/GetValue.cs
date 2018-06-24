using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MirrorsUnitTests
{

    /// <summary>
    /// All basic GetValue tests.
    /// </summary>
    [TestClass]
    public class GetValue
    {
        /// <summary>
        /// Make sure GetValue works with case-sensitive mode.
        /// </summary>
        [TestMethod]
        public void GetValueCaseSensitiveOk()
        {
            // create test object
            TestObj test = new TestObj();

            // test getting field
            {
                int gotVal = Mirrors.Mirrors.GetValue<int>(test, "int_field");
                Assert.AreEqual(gotVal, test.int_field);
            }

            // test getting property with read / write
            {
                int gotVal = Mirrors.Mirrors.GetValue<int>(test, "int_property_rw");
                Assert.AreEqual(gotVal, test.int_property_rw);
            }

            // test getting property with just read
            {
                int gotVal = Mirrors.Mirrors.GetValue<int>(test, "int_property_r");
                Assert.AreEqual(gotVal, test.int_property_r);
            }
        }

        /// <summary>
        /// Make sure GetValue works with case-insensitive mode.
        /// </summary>
        [TestMethod]
        public void GetValueCaseInsensitiveOk()
        {
            // create test object
            TestObj test = new TestObj();

            // test getting field
            {
                int gotVal = Mirrors.Mirrors.GetValue<int>(test, "inT_fielD", true);
                Assert.AreEqual(gotVal, test.int_field);
            }

            // test getting property with read / write
            {
                int gotVal = Mirrors.Mirrors.GetValue<int>(test, "inT_propertY_rw", true);
                Assert.AreEqual(gotVal, test.int_property_rw);
            }

            // test getting property with just read
            {
                int gotVal = Mirrors.Mirrors.GetValue<int>(test, "inT_propertY_r", true);
                Assert.AreEqual(gotVal, test.int_property_r);
            }
        }

        /// <summary>
        /// Test what happens if we try to get a non-existing field (we should get the right exception).
        /// </summary>
        [TestMethod]
        public void GetValueNotFound()
        {
            // create test object
            TestObj test = new TestObj();

            // test getting field with wrong name due to case-sensitive
            {
                try
                {
                    int gotVal = Mirrors.Mirrors.GetValue<int>(test, "inT_fielD", false);
                    Assert.Fail("Didn't get FieldNotFound exception!");
                }
                catch (Mirrors.FieldNotFoundException)
                {
                    Assert.IsTrue(true);
                }
                catch (Exception e)
                {
                    Assert.Fail("Got wrong exception type! Expected FieldNotFound exception.");
                }
            }

            // test getting field with wrong name even with case-insensitive
            {
                try
                {
                    int gotVal = Mirrors.Mirrors.GetValue<int>(test, "inT_fielDddd", true);
                    Assert.Fail("Didn't get FieldNotFound exception!");
                }
                catch (Mirrors.FieldNotFoundException)
                {
                    Assert.IsTrue(true);
                }
                catch (Exception e)
                {
                    Assert.Fail("Got wrong exception type! Expected FieldNotFound exception.");
                }
            }
        }

        /// <summary>
        /// Test what happens if we try to get wrong type (we should get an exception).
        /// </summary>
        [TestMethod]
        public void GetValueWrongType()
        {
            // create test object
            TestObj test = new TestObj();

            // test getting field with wrong type
            {
                try
                {
                    string gotVal = Mirrors.Mirrors.GetValue<string>(test, "int_field", false);
                    Assert.Fail("Didn't get WrongTypeException exception!");
                }
                catch (Mirrors.WrongTypeException)
                {
                    Assert.IsTrue(true);
                }
                catch (Exception e)
                {
                    Assert.Fail("Got wrong exception type! Expected WrongTypeException exception.");
                }
            }
        }

        /// <summary>
        /// Test what happens if we try to get value from write-only property (we should get an exception).
        /// </summary>
        [TestMethod]
        public void GetValueFromWriteOnly()
        {
            // create test object
            TestObj test = new TestObj();

            // test getting write-only property
            {
                try
                {
                    int gotVal = Mirrors.Mirrors.GetValue<int>(test, "int_property_w", false);
                    Assert.Fail("Didn't get PropertyNotReadableException exception!");
                }
                catch (Mirrors.PropertyNotReadableException)
                {
                    Assert.IsTrue(true);
                }
                catch (Exception e)
                {
                    Assert.Fail("Got wrong exception type! Expected PropertyNotReadableException exception.");
                }
            }
        }
    }
}
