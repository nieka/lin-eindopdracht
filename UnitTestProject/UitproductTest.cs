using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lin_eindopdracht;

namespace UnitTestProject
{
    [TestClass]
    public class UitproductTest
    {
        [TestMethod]
        public void UitProductPositiveNumbers()
        {
            Vector3D vectorA = new Vector3D(1, 2, 3);
            Vector3D vectorB = new Vector3D(4, 5, 6);

            Vector3D uitkomst = new Vector3D(-3, 6, -3);

            Assert.AreEqual(TestMethodes.VectorsAreEqeul(Vector3D.uitProduct(vectorA, vectorB),uitkomst), true);
        }

        [TestMethod]
        public void UitProductNegativeNumbers()
        {
            Vector3D vectorA = new Vector3D(-1, -2, -3);
            Vector3D vectorB = new Vector3D(4, 5, 6);

            Vector3D uitkomst = new Vector3D(3, -6, 3);

            Assert.AreEqual(TestMethodes.VectorsAreEqeul(Vector3D.uitProduct(vectorA, vectorB), uitkomst), true);
        }

        [TestMethod]
        public void UitProductWidthZeroVectorNumbers()
        {
            Vector3D vectorA = new Vector3D(0, 0, 0);
            Vector3D vectorB = new Vector3D(4, 5, 6);

            Vector3D uitkomst = new Vector3D(0,0,0);

            Assert.AreEqual(TestMethodes.VectorsAreEqeul(Vector3D.uitProduct(vectorA, vectorB), uitkomst), true);
        }
    }
}
