using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] animalPrefabs;

    private float spawnRangeX = 20;
    private float spawnPosZ = 20;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);

        /*InvokeRepeating() metodu belirli aral�klarla bir fonksiyonu �al��t�rmam�s� sa�lar, 3 tane parametre al�r;
        �al��t�rmak istedi�imiz fonksiyonumuz, ilk �a��raca�� s�re ve hangi aral�klarla tekrar etmesi gerekti�i belirten s�re.*/
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
