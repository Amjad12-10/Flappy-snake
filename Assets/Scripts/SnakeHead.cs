using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MJ
{
    public class SnakeHead : MonoBehaviour
    {
        public int speed = 10;

        private float maxRotate = 45;
        private Vector3 to;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                to = Vector3.forward;
            }
            else
            {
                to = Vector3.back;
            }

            transform.Rotate(to * 90 * Time.deltaTime);

            limitRot();

            var Pos = speed * Time.deltaTime * transform.up;
            transform.position += Pos;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10, 5), transform.position.y);

        }
        private void limitRot()
        {
            Vector3 Rot = this.transform.rotation.eulerAngles;

            Rot.z = (Rot.z > 180) ? Rot.z - 360 : Rot.z;
            Rot.z = Mathf.Clamp(Rot.z, -maxRotate, maxRotate);

            this.transform.rotation = Quaternion.Euler(Rot);
        }
    }
}
