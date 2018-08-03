using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chaso.Push.Client.Test
{
    [TestClass]
    public class ChasoPushClienteTest
    {
        [TestMethod]
        public void MustBeSentAPushToSpecificUrl()
        {
            string returnedSend = string.Empty;
            var url = "http://localhost:4478";
            using (IChasoPushClient pushClient = new ChasoPushClient("Test",url))
            {
                returnedSend = pushClient.Send("SourceIntegration", "EventIntegration"," {\"Data\" : {\"Code\":\"CodeSomeThing\" } }");
            }
            Assert.IsNotNull(returnedSend);
            Assert.AreEqual("Event EventIntegration on $SourceIntegration completed!. OK", returnedSend);
        }
    }
}
