using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MirrorsUnitTests
{

    /// <summary>
    /// All basic SetValue tests.
    /// </summary>
    [TestClass]
    public class SetValue
    {
        /// <summary>
        /// Make sure GetValue works with case-sensitive mode.
        /// </summary>
        [TestMethod]
        public void SetValueCaseSensitiveOk()
        {
            // create test object
            TestObj test = new TestObj();

            // test setting field
            {
                Mirrors.Mirrors.SetValue(test, "int_field", 999);
                Assert.AreEqual(999, test.int_field);
            }

            // test setting property with read / write
            {
                Mirrors.Mirrors.SetValue(test, "int_property_rw", 999);
                Assert.AreEqual(999, test.int_property_rw);
            }

            // test setting property with just write
            {
                Mirrors.Mirrors.SetValue(test, "int_property_w", 999);
                Assert.AreEqual(999, test.int_property_rw);
            }
        }

        /// <summary>
        /// Make sure SetValue works with case-insensitive mode.
        /// </summary>
        [TestMethod]
        public void SetValueCaseInsensitiveOk()
        {
            // create test object
            TestObj test = new TestObj();

            // test setting field
            {
                Mirrors.Mirrors.SetValue(test, "Int_fielD", 999, true);
                Assert.AreEqual(999, test.int_field);
            }

            // test setting property with read / write
            {
                Mirrors.Mirrors.SetValue(test, "Int_propertY_rw", 999, true);
                Assert.AreEqual(999, test.int_property_rw);
            }

            // test setting property with just write
            {
                Mirrors.Mirrors.SetValue(test, "Int_propertY_w", 999, true);
                Assert.AreEqual(999, test.int_property_rw);
            }
        }

        /// <summary>
        /// Test what happens if we try to set a non-existing field (we should get the right exception).
        /// </summary>
        [TestMethod]
        public void SetValueNotFound()
        {
            // create test object
            TestObj test = new TestObj();

            // test setting field with wrong name due to case-sensitive
            {
                try
                {
                    Mirrors.Mirrors.SetValue(test, "inT_fielD", 123);
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

            // test setting field with wrong name even with case-insensitive
            {
                try
                {
                    Mirrors.Mirrors.SetValue(test, "inT_fielDddd", 123);
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
        /// Test what happens if we try to set wrong type (we should get an exception).
        /// </summary>
        [TestMethod]
        public void SetValueWrongType()
        {
            // create test object
            TestObj test = new TestObj();

            // test setting field with wrong type
            {
                try
                {
                    Mirrors.Mirrors.SetValue(test, "int_field", "wrong_type!");
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
        /// Test what happens if we try to set value to read-only property (we should get an exception).
        /// </summary>
        [TestMethod]
        public void SetValueFromWriteOnly()
        {
            // create test object
            TestObj test = new TestObj();

            // test setting write-only property
            {
                try
                {
                    Mirrors.Mirrors.SetValue(test, "int_property_r", 123);
                    Assert.Fail("Didn't get PropertyNotReadableException exception!");
                }
                catch (Mirrors.PropertyNotWritableException)
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
