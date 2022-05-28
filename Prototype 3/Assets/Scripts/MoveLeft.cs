using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 15.0f;
    private PlayerController playerControllerScript;
    //Ba�ka bir scriptte ula�mak i�in �ncelikle o scriptten bir obje �retiyoruz

    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //Daha sonra �retti�imiz objeyi oyunda istedi�imiz game objesi �zerinde olan scripte e�itliyoruz.
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false) // oyun bitmedi�i s�rece bu i�lemi yap
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            //gameObject ile scriptin oldu�u game objesine ula��yorum
        }

        
    }
}
