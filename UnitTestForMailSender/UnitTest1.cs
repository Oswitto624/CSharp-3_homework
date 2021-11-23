using NUnit.Framework;
using WpfTestMailSender;

namespace UnitTestForMailSender
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            WpfTestMailSender.Model.Security cipher = new WpfTestMailSender.Model.Security();
            string pass = "admin1";
            var encryptedText = cipher.Encrypt(pass, pass.Length);
            var decryptedText = cipher.Decrypt(encryptedText, encryptedText.Length);

            Assert.AreEqual(pass, decryptedText);

            //Assert.Pass();
        }
    }
}