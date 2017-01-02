using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lin_eindopdracht;

namespace UnitTestProject
{
    [TestClass]
    public class InporductTests
    {
        [TestMethod]
        public void InproductPositieveNumbers()
        {
            Vector3D vectorA = new Vector3D(1, 2, 3);
            Vector3D vectorB = new Vector3D(4, 5, 6);

            Assert.AreEqual(Vector3D.inProduct(vectorA, vectorB), 32);
        }

        [TestMethod]
        public void InproductNegativeNumbers()
        {
            Vector3D vectorA = new Vector3D(-1, -2, -3);
            Vector3D vectorB = new Vector3D(4, 5, 6);

            Assert.AreEqual(Vector3D.inProduct(vectorA, vectorB), -32);
        }

        [TestMethod]
        public void InproductWidthZeroVectorNumbers()
        {
            Vector3D vectorA = new Vector3D(0, 0, 0);
            Vector3D vectorB = new Vector3D(4, 5, 6);

            Assert.AreEqual(Vector3D.inProduct(vectorA, vectorB), 0);
        }
    }
}
