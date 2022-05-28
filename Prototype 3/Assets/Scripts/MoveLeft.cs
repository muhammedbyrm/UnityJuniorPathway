using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 15.0f;
    private PlayerController playerControllerScript;
    //Baþka bir scriptte ulaþmak için öncelikle o scriptten bir obje üretiyoruz

    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //Daha sonra ürettiðimiz objeyi oyunda istediðimiz game objesi üzerinde olan scripte eþitliyoruz.
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false) // oyun bitmediði sürece bu iþlemi yap
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            //gameObject ile scriptin olduðu game objesine ulaþýyorum
        }

        
    }
}
