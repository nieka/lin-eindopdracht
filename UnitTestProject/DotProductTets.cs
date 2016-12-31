using lin_eindopdracht;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class DotProductTets
    {
        [TestMethod]
        public void DotProductTestPsitiveNumbers()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { 1, 2, 3});
            matrixLijst1.Add(new List<double> { 4, 5, 6 });
            matrixLijst1.Add(new List<double> { 7, 8, 9 });
            List<List<double>> matrixLijst2 = new List<List<double>>();
            matrixLijst2.Add(new List<double> { 1, 2, 3 });
            matrixLijst2.Add(new List<double> { 4, 5, 6 });
            matrixLijst2.Add(new List<double> { 7, 8, 9 });

            List<List<double>>  uitkomst = new List<List<double>>();
            uitkomst.Add(new List<double> { 30, 36,  42 });
            uitkomst.Add(new List<double> { 66, 81, 96 });
            uitkomst.Add(new List<double> { 102, 126, 150 });
            
            Assert.AreEqual(MatrixAreEquel(Matrix3D.vermenigvuldig(matrixLijst1, matrixLijst2), uitkomst), true);
        }

        [TestMethod]
        public void DotProductTestNegativeNumber()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { -1, -2, -3 });
            matrixLijst1.Add(new List<double> { -4, -5, -6 });
            matrixLijst1.Add(new List<double> { -7, -8, -9 });
            List<List<double>> matrixLijst2 = new List<List<double>>();
            matrixLijst2.Add(new List<double> { -1, -2, -3 });
            matrixLijst2.Add(new List<double> { -4, -5, -6 });
            matrixLijst2.Add(new List<double> { -7, -8, -9 });

            List<List<double>> uitkomst = new List<List<double>>();
            uitkomst.Add(new List<double> { 30, 36, 42 });
            uitkomst.Add(new List<double> { 66, 81, 96 });
            uitkomst.Add(new List<double> { 102, 126, 150 });

            Assert.AreEqual(MatrixAreEquel(Matrix3D.vermenigvuldig(matrixLijst1, matrixLijst2), uitkomst), true);
        }

        [TestMethod]
        public void DotProductEmptyListsTest()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            List<List<double>> matrixLijst2 = new List<List<double>>();

            List<List<double>> uitkomst = new List<List<double>>();

            Assert.AreEqual(MatrixAreEquel(Matrix3D.vermenigvuldig(matrixLijst1, matrixLijst2), uitkomst), true);
        }

        [TestMethod]
        public void DotProductTestNotEquelMatrixes()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { -1, -2 });
            matrixLijst1.Add(new List<double> { -4, -5 });
            matrixLijst1.Add(new List<double> { -7, -8 });

            List<List<double>> matrixLijst2 = new List<List<double>>();
            matrixLijst2.Add(new List<double> { -1, -2, -3 });
            matrixLijst2.Add(new List<double> { -4, -5, -6 });
            matrixLijst2.Add(new List<double> { -7, -8, -9 });

            List<List<double>> uitkomst = new List<List<double>>();

            Assert.AreEqual(MatrixAreEquel(Matrix3D.vermenigvuldig(matrixLijst1, matrixLijst2), uitkomst), true);
        }

        private bool MatrixAreEquel(List<List<double>> matrix1 , List<List<double>> matrix2)
        {
            if (matrix1.Count != matrix2.Count)
            {
                return false;
            }

            //test if they are the inner list are the same lengt
            for(int i=0; i< matrix1.Count; i++)
            {
                if(matrix1[i].Count != matrix2[i].Count)
                {
                    return false;
                }
            }

            //check if the numbers are equal
            for (int i = 0; i < matrix1.Count; i++)
            {
                for(int j=0; j < matrix1[i].Count; j++)
                {
                    if(matrix1[i][j] != matrix2[i][j])
                    {
                        return false;
                    }
                }
            }

            return true;
        } 
    }
}
