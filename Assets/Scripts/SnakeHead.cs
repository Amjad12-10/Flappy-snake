using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MJ
{
    public class SnakeHead : MonoBehaviour
    {
        // Head
        public int speed = 10;
        public int rotSpeed = 180;
        // Head Fixed
        public float maxRotate = 45;
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
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5, 5), transform.position.y);

        }
        //--------- Limiting the Rotation
        private void limitRot()
        {
            Vector3 Rot = this.transform.rotation.eulerAngles;

            Rot.z = (Rot.z > 180) ? Rot.z - 360 : Rot.z;
            Rot.z = Mathf.Clamp(Rot.z, -maxRotate, maxRotate);

            this.transform.rotation = Quaternion.Euler(Rot);
        }
    }
}
