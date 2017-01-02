using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lin_eindopdracht;

namespace UnitTestProject
{
    [TestClass]
    public class NormalizeTests
    {
        [TestMethod]
        public void NormalisePositiveNumbers()
        {
            Vector3D vector = new Vector3D(3, 2, 1);
            vector.normalize();
            Vector3D uitkomst = new Vector3D(0.8017837f, 0.5345225f, 0.267261237f);

            Assert.AreEqual(TestMethodes.VectorsAreEqeul(vector, uitkomst), true);

        }

        [TestMethod]
        public void NormaliseNegativeNumbers()
        {
            Vector3D vector = new Vector3D(3, 2, -1);
            vector.normalize();
            Vector3D uitkomst = new Vector3D(0.8017837f, 0.5345225f, -0.267261237f);

            Assert.AreEqual(TestMethodes.VectorsAreEqeul(vector, uitkomst), true);

        }
    }
}
