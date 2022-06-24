using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MJ
{
    public class Camerafollower : MonoBehaviour
    {
        [SerializeField] private Transform Target;
        private Vector3 offset;
        // Update is called once per frame
        void Update()
        {
            offset = Target.position - transform.position;
            transform.position += Vector3.up * offset.y * Time.deltaTime * 10;
        }
    }
}
