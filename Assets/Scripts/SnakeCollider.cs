using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace MJ
{
    public class SnakeCollider : MonoBehaviour
    {
        [SerializeField] private List<GameObject> SnakeHeads;
        [SerializeField] private float offsetTime = 5;

        // Use this for initialization
        void Start()
        {
            SnakeHeads.Add(this.gameObject);
        }
        private void Update()
        {
            if(SnakeHeads.Count > 1)
                for(int i = 1; i < SnakeHeads.Count; i++)
                {
                    var previous = SnakeHeads[i - 1].transform;
                    var current = SnakeHeads[i].transform;

                    current.position = Vector3.Lerp(current.position, previous.position, Time.deltaTime * offsetTime);
                    current.transform.right = previous.transform.position - current.transform.position;
                }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SnakeHeads.Add(collision.gameObject);
                collision.gameObject.tag = "Untagged";
            }
        }
    }
}