using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Funzilla
{
    public class GeneratorMesh : MonoBehaviour
    {
        //[SerializeField] private float speedScaleUp = 10f;
        //[SerializeField] private float speedScaleDown = 100f;
        //[SerializeField] private float maxScale = 3;
    
        [SerializeField] private CotTru _meshGenegator;
    
        internal void SetMeshGenegator(CotTru meshGenegator)
        {
            _meshGenegator = meshGenegator;
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Draw(_meshGenegator);
            }
            /*if (Input.GetKey(KeyCode.Mouse0))
            {
                if (transform.localScale.z < maxScale)
                {
                    ScaleUp();
                }
                else
                {
                    
                }
            }
            else
            {
                if (transform.localScale.z > Mathf.Epsilon)
                {
                    ScaleDown(); 
                }
                
            }*/
        }
    
        private void ScaleUp()
        {
            transform.localScale += Vector3.forward  * Time.deltaTime;//* speedScaleUp
            var position = transform.localPosition;
            transform.localPosition = new Vector3(position.x, position.y, transform.localScale.z/2);
        }
    
        private void ScaleDown()
        {
            transform.localScale -= Vector3.forward  * Time.deltaTime;//* speedScaleDown
            var position = transform.localPosition;
            transform.localPosition = new Vector3(position.x, position.y, transform.localScale.z/2);
        }
    
        private void Draw(CotTru meshGenegator)
        {
            meshGenegator.AddShape();
        }
    }
}

