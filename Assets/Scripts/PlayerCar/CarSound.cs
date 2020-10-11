using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    public AudioClip carStartRevLoop;
    public AudioClip carEngineStart;
    public AudioClip gearChange;
    public AudioClip engineLoad;
    public AudioClip engineUnload;
    public AudioSource[] carSounds =  new AudioSource[2];
    private AudioSource carSound;
    private AudioSource engineSound;
    CarMovement carMovement;

    
    // Start is called before the first frame update
    void Start()
    {
        carSound = carSounds[0];
        engineSound = carSounds[1];
        carMovement = GetComponent<CarMovement>();
        if (!carMovement)
            Debug.Log("cant find car movement script!");
        //carSound = GetComponent<AudioSource>();
        carSound.clip = carEngineStart;
        carSound.Play();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(carMovement.isAccelerating)
        {
            engineSound.Pause();
            engineSound.clip = engineLoad;
            //engineSound.pitch = 1;
            engineSound.Play();
        }else if(!carMovement.isAccelerating && carMovement.hasStartedMovement)
        {
            engineSound.Pause();
            engineSound.clip = engineUnload;
            engineSound.Play();
        }
        
        if (!carSound.isPlaying)
        {
            carSound.clip = carStartRevLoop;
            carSound.Play();
            carSound.loop = true;
        }
     
    }
}
