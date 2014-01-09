using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Medlemsregister;

namespace WhiteBox
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestClass()
        {
            Member m = new Member();

            m.FirstName = "Hej";
            m.LastName = "Andersson";
            m.PhoneNumber = 123;
            m.MemberNumber = 123;

            m.CreateMemberNumber();
            string tempString = m.PrintDetailedToString();
            tempString = m.PrintToString();

            int tempNumber = m.MemberNumber;
            tempNumber = m.PhoneNumber;

            tempString = m.LastName;
            tempString = m.FirstName;

        }
    }
}
