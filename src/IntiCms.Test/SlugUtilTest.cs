using System.Collections.Generic;

using IntiCms.BusinessLogic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntiCms.Test
{
    [TestClass]
    public class SlugUtilTest
    {
        [TestMethod]
        public void FixSlug_Samples_AsExpected()
        {
            var samples = new Dictionary<string, string>
                {
                    {"simple", "simple"},
                    {"word chain", "word-chain"},
                    {"spaces  and\t\ttabs", "spaces-and-tabs"},
                    {" one ", "one-"},
                    {"~ one", "one"},
                    {" one! ", "one-"},
                    {" one &^%%$^$ 123456-7890", "one-123456-7890"},
                    {"dots.and.others", "dots-and-others"},
                };

            foreach (var kvp in samples)
            {
                var actual = kvp.Key.FixSlug();
                Assert.AreEqual(kvp.Value, actual, "Expected <{0}>, Actual <{1}> from <{2}>", kvp.Value, actual, kvp.Key);
            }
        }
    }
}