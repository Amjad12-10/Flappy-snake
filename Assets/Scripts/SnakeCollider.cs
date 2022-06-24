using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace MJ
{
    public class SnakeCollider : MonoBehaviour
    {
        // SnakeBodyParts
        [SerializeField] private List<GameObject> SnakeHeads;
        // SnakeBodyPart Position Offset
        [SerializeField] private float offsetTime = 5;

        [SerializeField] private UIManager Manager;
        void Start()
        {
            // Adding head to the SnakeBodyParts
            SnakeHeads.Add(this.gameObject);
        }
        private void Update()
        {

            if(SnakeHeads.Count > 1)
                for(int i = 1; i < SnakeHeads.Count; i++)
                {
                    var previous = SnakeHeads[i - 1].transform;
                    var current = SnakeHeads[i].transform;
                    // BodyPart Position
                    current.position = Vector3.Lerp(current.position, previous.position, Time.deltaTime * offsetTime);
                    // BodyPart Rotation
                    current.right = previous.position - current.position;
                }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Collide with Bodypart
            if (collision.gameObject.CompareTag("Player"))
            {
                Manager.UpdateScore();
                SnakeHeads.Add(collision.gameObject);
                collision.gameObject.tag = "Untagged";
                collision.transform.DOPunchScale(-1f * Vector3.one, 0.25f, 10, 1);
            }
            // Score Update
            if (collision.gameObject.CompareTag("Score"))
            {
                Manager.UpdateScore();
            }
            // Snake Dead
            if (collision.gameObject.CompareTag("Finish"))
            {
                Manager.OnGameOver();
                var SnakeHeadInstace = this.GetComponent<SnakeHead>();
                SnakeHeadInstace.speed = 0;
            }
        }
    }
}