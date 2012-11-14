using System;
using System.Linq;

using IntiCms.BusinessLogic;
using IntiCms.ValueObjects;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntiCms.Test
{
    [TestClass]
    public class MongoDbEntryAdapterTest
    {
        private static MongoDbEntryAdapter GetTarget()
        {
            var target = new MongoDbEntryAdapter("mongodb://localhost", "test");
            return target;
        }

        private static Entry GetSampleEntry()
        {
            var date = new DateTime(2012, 11, 1).ToUniversalTime();
            var expected = new Entry
                {
                    Author = "Bob",
                    Body = "***Hello World!***",
                    Created = date,
                    Slug = "the quick red fox",
                    Summary = "in short",
                    Tags = new[] { "news", "blog" },
                    Title = "Now this",
                    VisibleOn = date
                };
            return expected;
        }

        [TestMethod]
        public void Save_Entry_Saves()
        {
            var target = GetTarget();
            var expected = GetSampleEntry();

            target.Save(expected);

            var actual = target.All().SingleOrDefault(e => e.Slug == expected.Slug);
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void Save_NullEntry_Throws()
        {
            var target = GetTarget();

            try
            {
                target.Save(null);
                Assert.Fail("Expected arguement null exception");
            }
            catch (ArgumentNullException)
            {
                // good.
            }
        }

        [TestMethod]
        public void All_ByTag_ReturnsEntries()
        {
            var target = GetTarget();
            var expected = GetSampleEntry();
            expected.Slug = "All_ByTag_ReturnsEntries";

            target.Save(expected);

            //act
            var actual = target.All().Where(e => e.Tags.Contains("blog")).ToArray();

            Assert.IsNotNull(actual);
            Assert.AreNotEqual(0, actual.Length);
        }
        [TestMethod]
        public void One_Existing_ReturnsIt()
        {
            var target = GetTarget();
            var expected = GetSampleEntry();
            expected.Slug = "One_Existing_ReturnsIt";

            target.Save(expected);

            var actual = target.One(expected.Slug);

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void Delete_Existing_Deletes()
        {
            var target = GetTarget();
            var expected = GetSampleEntry();
            expected.Slug = "Delete_Existing_Deletes";

            target.Save(expected);

            var actual = target.One(expected.Slug);

            Assert.IsNotNull(actual);

            target.Delete(expected.Slug);

            actual = target.One(expected.Slug);

            Assert.IsNull(actual);
        }




    }
}