using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Blocks;
    void Start()
    {
        StartCoroutine(spwanblock());
    }
    private IEnumerator spwanblock() {

        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            var random = Random.Range(0, Blocks.Length);
            var block = Instantiate(Blocks[random]);
            block.transform.position = this.transform.position+new Vector3((int)Random.Range(-6,3),0,0);
        }
    }
}
