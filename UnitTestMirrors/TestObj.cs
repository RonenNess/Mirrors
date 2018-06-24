
namespace MirrorsUnitTests
{
    /// <summary>
    /// Class for testing.
    /// </summary>
    class TestObj
    {
        /// <summary>
        /// Int value field.
        /// </summary>
        public int int_field = 1;

        /// <summary>
        /// Int property with get / set.
        /// </summary>
        public int int_property_rw { get; set; } = 2;

        /// <summary>
        /// Int property with just get.
        /// </summary>
        public int int_property_r { get { return 3; } }


        /// <summary>
        /// Int property with just set.
        /// </summary>
        public int int_property_w { set { int_property_w__val = value; } }

        /// <summary>
        /// Provide access to the value in 'int_property_w'.
        /// </summary>
        public int int_property_w__val = 4;

        /// <summary>
        /// Private int field.
        /// </summary>
        private int int_private_field = 5;

        /// <summary>
        /// Provide access to the value in 'int_private_field'.
        /// </summary>
        public int int_private_field__val { get { return int_private_field; } }

        /// <summary>
        /// Field of type self.
        /// </summary>
        public TestObj self_field;
    }
}
