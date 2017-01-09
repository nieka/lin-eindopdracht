using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lin_eindopdracht
{
    class Kogel
    {
        private Vector3D richtingsVector;
        private Vector3D locatie;
        private float kogelLength = 5;
        public int liveSpan { get; private set; }

        public Kogel(Vector3D richtingsVector, Vector3D startPunt)
        {
            this.richtingsVector = richtingsVector;
            locatie = startPunt;
            liveSpan = 0;
        }

        public Matrix3D getKogelMatrix()
        {liveSpan++;
            Vector3D endPoint = Vector3D.add(locatie, Vector3D.multiply(new Vector3D(kogelLength, kogelLength, kogelLength), richtingsVector));

            List<List<double>> kogelMatrix = new List<List<double>>{
                new List<double> {locatie.x, endPoint.x}, //x
                new List<double> {locatie.y,endPoint.y}, //y
                new List<double> {locatie.z,endPoint.z}  //z
            };

            //add one to the livespan of the bullet
            
            //the endpoint is now the new location of the bullet
            locatie = endPoint;

            return new Matrix3D(kogelMatrix);

        }
    }
}
