using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dotlib.Parser.Tests
{
    [TestClass]
    public class RoleParserTest
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("")]
        [DataRow(":")]
        [DataRow("invalid")]
        [DataRow(null)]
        public void ParseInvalid1(string roles)
        {
            var parser = new RoleParser(roles);
            Assert.IsFalse(parser.IsParsed());
        }

        [TestMethod]
        public void ParseInvalid2()
        {
            var parser = new RoleParser();
            Assert.IsFalse(parser.IsParsed());
        }

        [TestMethod]
        public void ParseInvalid6()
        {
            var parser = new RoleParser("ApplicationName:");
            Assert.IsFalse(parser.IsParsed());
        }

        [TestMethod]
        public void ParseInvalid7()
        {
            var parser = new RoleParser(":Role1,Role2,Role3");
            Assert.IsFalse(parser.IsParsed());
        }

        [TestMethod]
        public void ParseValid3()
        {
            var parser = new RoleParser("ApplicationName:Role1,Role2,Role3");

            Assert.IsTrue(parser.IsParsed());
            Assert.AreEqual(3, parser.Roles.Count);

            Assert.AreEqual("ApplicationName", parser.ApplicationName);
            Assert.AreEqual("Role1", parser.Roles[0]);
            Assert.AreEqual("Role2", parser.Roles[1]);
            Assert.AreEqual("Role3", parser.Roles[2]);
        }

        [TestMethod]
        public void ParseValid4()
        {
            var parser = new RoleParser("ApplicationName:Role1");

            Assert.IsTrue(parser.IsParsed());
            Assert.AreEqual(1, parser.Roles.Count);

            Assert.AreEqual("ApplicationName", parser.ApplicationName);
            Assert.AreEqual("Role1", parser.Roles[0]);
        }

        [TestMethod]
        public void ParseValid5()
        {
            var parser = new RoleParser("ApplicationName:Role1,");

            Assert.IsTrue(parser.IsParsed());
            Assert.AreEqual(1, parser.Roles.Count);

            Assert.AreEqual("ApplicationName", parser.ApplicationName);
            Assert.AreEqual("Role1", parser.Roles[0]);
        }
    }
}
