using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDircetion = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDircetion * speed);
        //normalize ederek enemy'nin uzakl�ktan ba��ms�z olarak s�rekli ayn� h�zda player'� takip etmesini sa�l�yoruz
        //aksi halde uzakl�k artt�k�a enemy daha h�zl� takip eder

        if(transform.position.y < -10)
        {
            Destroy(gameObject); //scriptin oldu�u/atand��� game objecti yok ediyor
        }
    }
}
