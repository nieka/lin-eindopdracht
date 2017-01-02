using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lin_eindopdracht
{
    public class Vector3D
    {
        public float x { get; set; }
        public float y { get; set; }

        public float z { get; set; }
       

        public Vector3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void schaal(int factor)
        {
            x = x * factor;
            y = y * factor;
            z = z * factor;
        }

        public static Vector3D multiply(Vector3D vector1, Vector3D vector2)
        {
            float x = vector1.x + vector2.x;
            float y = vector2.y + vector2.y;
            float z = vector1.z + vector2.z;
            return new Vector3D(x, y,z);
        }

        public static Vector3D subtract(Vector3D vector1, Vector3D vector2)
        {
            float x = vector1.x - vector2.x;
            float y = vector2.y - vector2.y;
            float z = vector1.z - vector2.z;
            return new Vector3D(x, y, z);
        }

        public void normalize()
        {
            float lengte = (float) Math.Sqrt(x * x + y * y);
            x = x / lengte;
            y = y / lengte;
        }

        public static double inProduct(Vector3D vectorA, Vector3D vectorB)
        {
            return vectorA.x * vectorB.x + vectorA.y * vectorB.y + vectorA.z * vectorB.z;
        }

        public static Vector3D uitProduct(Vector3D vectorA, Vector3D vectorB)
        {
            return new Vector3D(
                    vectorA.y * vectorB.z - vectorB.y * vectorA.z,
                    vectorB.x * vectorA.z - vectorA.x * vectorB.z,
                    vectorA.x * vectorB.y - vectorB.x * vectorA.y
                );
        } 
    }
}
