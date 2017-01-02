using lin_eindopdracht;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    class TestMethodes
    {
        public static bool MatrixAreEquel(List<List<double>> matrix1, List<List<double>> matrix2)
        {
            if (matrix1.Count != matrix2.Count)
            {
                return false;
            }

            //test if they are the inner list are the same lengt
            for (int i = 0; i < matrix1.Count; i++)
            {
                if (matrix1[i].Count != matrix2[i].Count)
                {
                    return false;
                }
            }

            //check if the numbers are equal
            for (int i = 0; i < matrix1.Count; i++)
            {
                for (int j = 0; j < matrix1[i].Count; j++)
                {
                    if (Math.Round(matrix1[i][j],9) != Math.Round(matrix2[i][j],9))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool VectorsAreEqeul(Vector3D vectora, Vector3D vectorb)
        {
            if(vectora.x != vectorb.x)
            {
                return false;
            }

            if(vectora.y != vectorb.y)
            {
                return false;
            }

            if(vectora.z != vectorb.z)
            {
                return false;
            }

            return true;
        }
    }
}
