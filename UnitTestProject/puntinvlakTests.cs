using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using lin_eindopdracht;

namespace UnitTestProject
{
    [TestClass]
    public class puntinvlakTests
    {
        [TestMethod]
        public void PuntIsinVlak()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { -3, 1, 2 });
            matrixLijst1.Add(new List<double> { -1, 3, 3 });
            matrixLijst1.Add(new List<double> { 2, 4, 2});

            Matrix3D matrix = new Matrix3D(matrixLijst1);
            Vector3D punt = new Vector3D(-2, 13, 5);
            Equals(Matrix3D.puntInVlak(punt, matrix));
        }

        [TestMethod]
        public void PuntIsNietinVlak()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { -3, 1, 2 });
            matrixLijst1.Add(new List<double> { -1, 3, 3 });
            matrixLijst1.Add(new List<double> { 2, 4, 2 });

            Matrix3D matrix = new Matrix3D(matrixLijst1);
            Vector3D punt = new Vector3D(0,0,0);
            Equals(!Matrix3D.puntInVlak(punt, matrix));
        }

        [TestMethod]
        public void PuntIsNietinVlak2()
        {
            List<List<double>> matrixLijst1 = new List<List<double>>();
            matrixLijst1.Add(new List<double> { -3, 1, 2 });
            matrixLijst1.Add(new List<double> { -1, 3, 3 });
            matrixLijst1.Add(new List<double> { 2, 4, 2 });

            Matrix3D matrix = new Matrix3D(matrixLijst1);
            Vector3D punt = new Vector3D(34, -136, 17);
            Equals(!Matrix3D.puntInVlak(punt, matrix));
        }
    }
}
