using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public float jumpForce = 15.0f;
    public float gravityModifier = 2f;
    public bool isOnGround = true;
    public bool gameOver = false;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //Rigidbody b�t�n game objectlerde ortak olmad��� i�in do�rudan eri�emiyoruz, GetComponent metodu ile bu t�r �zellikleri alabiliyoruz.
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            /* ForceMode.Impulse:
             Apply the impulse force instantly with a single function call. This mode depends on the mass of rigidbody 
            so more force must be applied to push or twist higher-mass objects the same amount as lower-mass objects.This mode 
            is useful for applying forces that happen instantly, such as forces from explosions or collisions. In this mode, 
            the unit of the force parameter is applied to the rigidbody as mass*distance/time. */

            //Translate metodu bir objenin direkt olarak x,y,z de�erini de�i�tirmeye yarar bir nevi obbjeyi s�r�kler 
            //Ancak AddForce bir objeyi ger�ekteki gibi fiziksel g�� uygulayarak hareket ettirir.
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();

            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();

            Debug.Log("Game Over!!!");
        }       
    }

    
}
