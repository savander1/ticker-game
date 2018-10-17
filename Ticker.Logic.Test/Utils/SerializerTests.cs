using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticker.Logic.Utils;

namespace Ticker.Logic.Test.Utils
{
    [TestClass]
    public class SerializerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctr_NullPassed_ThrowsException()
        {
            new Serializer(null);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void Workflow_ValidConfigPassed_CanSerializeAndDeserializeValue()
        {
            var id = Guid.NewGuid();
            try
            {
                var config = new SerializerConfig
                {
                    SerializerPath = AppContext.BaseDirectory,
                    Id = id
                };

                var boo = "boo";

                var serializer = new Serializer(config);
                serializer.Serialize(boo);

                var result = serializer.Deserialize<string>();

                Assert.AreEqual(boo, result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                File.Delete(Path.Combine(AppContext.BaseDirectory, id.ToString()));
            }
        }
    }
}
