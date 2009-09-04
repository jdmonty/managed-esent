﻿//-----------------------------------------------------------------------
// <copyright file="DictionaryComparisonFixture.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Isam.Esent.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EsentCollectionsTests
{
    /// <summary>
    /// Compare a PersistentDictionary against a generic dictionary.
    /// </summary>
    [TestClass]
    public class DictionaryComparisonFixture
    {
        /// <summary>
        /// Where the dictionary will be located.
        /// </summary>
        private const string DictionaryLocation = "DictionaryComparisonFixture";

        /// <summary>
        /// A generic dictionary that we will use as the oracle.
        /// </summary>
        private Dictionary<string, string> expected;

        /// <summary>
        /// The dictionary we are testing.
        /// </summary>
        private PersistentDictionary<string, string> actual;

        /// <summary>
        /// Test initialization.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            this.expected = new Dictionary<string, string>();
            this.actual = new PersistentDictionary<string, string>(DictionaryLocation);
        }

        /// <summary>
        /// Cleanup after the test.
        /// </summary>
        [TestCleanup]
        public void Teardown()
        {
            this.actual.Dispose();
            if (Directory.Exists(DictionaryLocation))
            {
                Directory.Delete(DictionaryLocation, true);
            }
        }

        /// <summary>
        /// Compare two empty dictionaries.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void TestEmptyDictionary()
        {
            this.CompareDictionaries();
        }

        /// <summary>
        /// Insert one item into the dictionary.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void TestInsert()
        {
            this.expected["foo"] = this.actual["foo"] = "1";
            this.CompareDictionaries();
        }

        /// <summary>
        /// Replace an item.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void TestReplace()
        {
            this.expected["foo"] = this.actual["foo"] = "1";
            this.expected["foo"] = this.actual["foo"] = "2";
            this.CompareDictionaries();
        }

        /// <summary>
        /// Delete an item.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void TestDelete()
        {
            this.expected["foo"] = this.actual["foo"] = "1";
            this.expected["bar"] = this.actual["bar"] = "2";
            this.expected.Remove("foo");
            this.actual.Remove("foo");
            this.CompareDictionaries();
        }

        /// <summary>
        /// Insert several items into the dictionary.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void TestAdds()
        {
            for (int i = 0; i < 10; ++i )
            {
                this.expected.Add(i.ToString(), i.ToString());
                this.actual.Add(i.ToString(), i.ToString());
            }
            this.CompareDictionaries();
        }

        /// <summary>
        /// Clear the dictionary.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void TestClear()
        {
            for (int i = 0; i < 10; ++i)
            {
                this.expected.Add(i.ToString(), i.ToString());
                this.actual.Add(i.ToString(), i.ToString());
            }
            this.expected.Clear();
            this.actual.Clear();
            this.CompareDictionaries();
        }

        /// <summary>
        /// Determine if two enumerations are equivalent. Enumerations are
        /// equivalent if they contain the same members in any order.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <param name="c1">The first enumeration.</param>
        /// <param name="c2">The second enumeration.</param>
        /// <returns>True if the enumerations are equivalent.</returns>
        private static bool AreEquivalent<T>(IEnumerable<T> c1, IEnumerable<T> c2)
        {
            var s1 = c1.OrderBy(x => x);
            var s2 = c2.OrderBy(x => x);
            return s1.SequenceEqual(s2);
        }

        /// <summary>
        /// Compare the expected and actual dictionaries.
        /// </summary>
        private void CompareDictionaries()
        {
            Assert.AreEqual(this.expected.Count, this.actual.Count);
            Assert.AreEqual(this.expected.Keys.Count, this.actual.Keys.Count);
            Assert.AreEqual(this.expected.Keys.Count, this.actual.Keys.Count);

            Assert.IsTrue(AreEquivalent(this.expected.Keys, this.actual.Keys));
            Assert.IsTrue(AreEquivalent(this.expected.Values, this.actual.Values));

            var enumeratedKeys = from i in this.actual select i.Key;
            Assert.IsTrue(AreEquivalent(this.expected.Keys, enumeratedKeys));

            var enumeratedValues = from i in this.actual select i.Value;
            Assert.IsTrue(AreEquivalent(this.expected.Values, enumeratedValues));

            foreach (string k in this.expected.Keys)
            {
                Assert.IsTrue(this.actual.ContainsKey(k));
                Assert.IsTrue(this.actual.Keys.Contains(k));

                string v;
                Assert.IsTrue(this.actual.TryGetValue(k, out v));
                Assert.AreEqual(this.expected[k], v);
                Assert.AreEqual(this.expected[k], this.actual[k]);

                Assert.IsTrue(this.actual.Contains(new KeyValuePair<string, string>(k, v)));
            }
        }
    }
}
