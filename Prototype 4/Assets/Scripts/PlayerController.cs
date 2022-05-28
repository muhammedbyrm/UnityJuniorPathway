using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerupIndicator;

    [SerializeField] float speed = 5.0f;
    public bool hasPowerup = false;
    private float powerUpStrength = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            //Courutine ile bir iþlemi belli bir süre yapýp sonra kaldýðýmýz yerden devam edebiliriz

            //In Unity, a coroutine is a method that can pause execution and return control to Unity but then
            //continue where it left off on the following frame.

            powerupIndicator.gameObject.SetActive(true); //scenede gözükmeyen/inaktif olan objeyi aktif/göstermek için

        }
    }

    IEnumerator PowerupCountdownRoutine()  // IEnumerator : Enumator interface'si
    {
        // IEnumerator Update fonksiyonu dýþýnda süre sayma gerektiren iþlemleri yapmak için kullanýþlýdýr.
        
        // Bizim kodumuzdea IEnumerator Update dýþýnda yeni bir thread oluþturacak

        yield return new WaitForSeconds(7);
        
        //yield ile Update fonksiyonu dýþýnda timer ý çalýþtýrmamýza yarar

        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false); //scenede gözüken/aktif olanobjeyi inaktif/göstermemek için
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position) - transform.position;
            //objenin geldiði direction ý bu þekilde buluyoruz

            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}
