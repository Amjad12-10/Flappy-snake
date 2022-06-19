using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Blocks;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spwanblock());
    }
    private IEnumerator spwanblock() {

        while (true)
        {
            yield return new WaitForSeconds(2);
            var random = Random.Range(0, Blocks.Length);
            var block = Instantiate(Blocks[random]);
            block.transform.position = this.transform.position;
        }
    }
}
