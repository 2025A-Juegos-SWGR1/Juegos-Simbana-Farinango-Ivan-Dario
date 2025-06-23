using System.Collections.Generic;
using UnityEngine;

namespace Sprits
{
    public class NewEmptyCSharpScript:MonoBehaviour
    {
        public Renderer fondo;
        public GameObject col;
        public float velocidad = 2;
        public GameObject piedra1;
        public GameObject piedra2;
        public List<GameObject> cols ;
        public List<GameObject> obstaculos;

        void Start()
        {
            cols = new List<GameObject>();
            obstaculos = new List<GameObject>();
            
            for (int i = 0; i < 21; i++)
            {
                cols.Add(Instantiate(col, new Vector2(-10+i,-3), Quaternion.identity));
            }
            
            GameObject p1 = Instantiate(piedra1, new Vector3(8, -0.7f, -1), Quaternion.identity);
            GameObject p2 = Instantiate(piedra2, new Vector3(10, -0.7f, -1), Quaternion.identity);

            Debug.Log("Piedra1 creada en: " + p1.transform.position);
            Debug.Log("Piedra2 creada en: " + p2.transform.position);

            obstaculos.Add(p1);
            obstaculos.Add(p2);
        }

        void Update()
        {
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.015f, 0) * Time.deltaTime;

            for (int i = 0; i < cols.Count; i++)
            {
                if (cols[i].transform.position.x < -10)
                {
                    cols[i].transform.position = new Vector3(10,-3,0);
                }
                
                cols[i].transform.position = cols[i].transform.position + new Vector3(-1, 0, 0) * (Time.deltaTime * velocidad);
            }
            
            
            for (int i = 0; i < obstaculos.Count; i++)
            {
                if (obstaculos[i].transform.position.x < -10)
                {
                    float randomObs = Random.Range(5, 16);
                    obstaculos[i].transform.position = new Vector3(randomObs, -0.7f, 0);
                }
                
                obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * (Time.deltaTime * velocidad);
            }
           
        }
    }
}
