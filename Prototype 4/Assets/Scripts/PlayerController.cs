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
            //Courutine ile bir i�lemi belli bir s�re yap�p sonra kald���m�z yerden devam edebiliriz

            //In Unity, a coroutine is a method that can pause execution and return control to Unity but then
            //continue where it left off on the following frame.

            powerupIndicator.gameObject.SetActive(true); //scenede g�z�kmeyen/inaktif olan objeyi aktif/g�stermek i�in

        }
    }

    IEnumerator PowerupCountdownRoutine()  // IEnumerator : Enumator interface'si
    {
        // IEnumerator Update fonksiyonu d���nda s�re sayma gerektiren i�lemleri yapmak i�in kullan��l�d�r.
        
        // Bizim kodumuzdea IEnumerator Update d���nda yeni bir thread olu�turacak

        yield return new WaitForSeconds(7);
        
        //yield ile Update fonksiyonu d���nda timer � �al��t�rmam�za yarar

        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false); //scenede g�z�ken/aktif olanobjeyi inaktif/g�stermemek i�in
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position) - transform.position;
            //objenin geldi�i direction � bu �ekilde buluyoruz

            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}
