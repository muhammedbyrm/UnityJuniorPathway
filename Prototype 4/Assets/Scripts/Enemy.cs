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
        //normalize ederek enemy'nin uzaklýktan baðýmsýz olarak sürekli ayný hýzda player'ý takip etmesini saðlýyoruz
        //aksi halde uzaklýk arttýkça enemy daha hýzlý takip eder

        if(transform.position.y < -10)
        {
            Destroy(gameObject); //scriptin olduðu/atandýðý game objecti yok ediyor
        }
    }
}
