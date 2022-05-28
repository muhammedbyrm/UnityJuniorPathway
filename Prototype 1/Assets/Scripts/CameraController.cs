using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    [SerializeField] Vector3 offset = new Vector3(0, 5, -9);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Arabam update fonksiyonuyla hareket ediyor, hem araba hem kamera update fonksiyonu ile hareket ederse
        // kamera da titreme oluþuyor, bu yüzden kamerayý late update koyuyoruz.
        //Böylelikle öncelikle araba updat eile hareket ediyor daha sonra late update fonksiyonuyla kamera takip ediyor
        transform.position = player.transform.position + offset; 
    }
}
