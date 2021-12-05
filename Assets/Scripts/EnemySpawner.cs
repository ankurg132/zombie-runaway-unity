using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftpos, rightpos;

    private int randomIndex;
    private int randomSide;

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while(true){
            yield return new WaitForSeconds(Random.Range(1, 3));
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monsterReference[randomIndex]);
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftpos.position;
                spawnedMonster.GetComponent<Monsters>().speed = Random.Range(6, 10);
            }
            else
            {
                spawnedMonster.transform.position = rightpos.position;
                spawnedMonster.GetComponent<Monsters>().speed = -Random.Range(6, 10);
                spawnedMonster.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
