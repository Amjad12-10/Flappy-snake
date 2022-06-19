using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MJ
{
    public class Camerafollower : MonoBehaviour
    {
        
        [SerializeField] private Transform Target;
        private Vector3 offset;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            offset = Target.position - transform.position;
            transform.position += new Vector3(0, offset.y, 0) * Time.deltaTime * 10;
        }
    }
}
