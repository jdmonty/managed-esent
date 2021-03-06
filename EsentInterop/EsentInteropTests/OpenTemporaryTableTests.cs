﻿//-----------------------------------------------------------------------
// <copyright file="OpenTemporaryTableTests.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.
// </copyright>
//-----------------------------------------------------------------------

using System.Runtime.InteropServices;
using Microsoft.Isam.Esent.Interop;
using Microsoft.Isam.Esent.Interop.Vista;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InteropApiTests
{
    /// <summary>
    /// Test conversion to NATIVE_OPENTEMPORARYTABLE
    /// </summary>
    [TestClass]
    public class OpenTemporaryTableTests
    {
        private JET_OPENTEMPORARYTABLE managed;

        /// <summary>
        /// The native structure created from the JET_OPENTEMPORARYTABLE
        /// object.
        /// </summary>
        private NATIVE_OPENTEMPORARYTABLE native;

        /// <summary>
        /// Setup the test fixture. This creates a native structure and converts
        /// it to a managed object.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            this.managed = new JET_OPENTEMPORARYTABLE()
                           {
                              ccolumn = 2,
                              grbit = TempTableGrbit.SortNullsHigh,
                              cbKeyMost = 3,
                              cbVarSegMac = 4,
                           };
            this.native = this.managed.GetNativeOpenTemporaryTable();
        }

        /// <summary>
        /// Check the conversion to a NATIVE_OPENTEMPORARYTABLE sets the structure size
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void VerifyConversionToNativeSetsCbStruct()
        {
            Assert.AreEqual((uint)Marshal.SizeOf(this.native), this.native.cbStruct);
        }

        /// <summary>
        /// Check the conversion to a NATIVE_OPENTEMPORARYTABLE sets ccolumn
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void VerifyConversionToNativeSetsCcolumn()
        {
            Assert.AreEqual((uint) 2, this.native.ccolumn);
        }

        /// <summary>
        /// Check the conversion to a NATIVE_OPENTEMPORARYTABLE sets grbit
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void VerifyConversionToNativeSetsGrbit()
        {
            Assert.AreEqual((uint) TempTableGrbit.SortNullsHigh, this.native.grbit);
        }

        /// <summary>
        /// Check the conversion to a NATIVE_OPENTEMPORARYTABLE sets cbKeyMost
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void VerifyConversionToNativeSetsCbKeyMost()
        {
            Assert.AreEqual((uint) 3, this.native.cbKeyMost);
        }

        /// <summary>
        /// Check the conversion to a NATIVE_OPENTEMPORARYTABLE sets cbVarSegMac
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void VerifyConversionToNativeSetsCbVarSegMac()
        {
            Assert.AreEqual((uint) 4, this.native.cbVarSegMac);
        }
    }
}