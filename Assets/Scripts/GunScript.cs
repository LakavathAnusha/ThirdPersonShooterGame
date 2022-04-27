using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Range(0.5f,1.5f)]
    float fireRate = 1f;
    [SerializeField]
    [Range(1f, 10f)]
    int damageRate = 1;
    float timer;
    public Transform firePoint;
    [SerializeField]
    ParticleSystem particleSystem;
    public Transform bulletDirection;
    public AudioClip audio;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if(timer>=fireRate)
        {
            if(Input.GetButton("Fire1"))
            {
                audioSource.Play();
                timer = 0f;
                ToFireGun();
            }
        }

    }

    private void ToFireGun()
    {
        particleSystem.Play();
        //To add audio source
        Debug.DrawRay(firePoint.position, transform.forward*100,Color.red,5f);
        Ray ray = new Ray(firePoint.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100f))
        {
            Debug.Log("In Raycast");
            //need to Shoot the enemy 
          var health =  hitInfo.collider.GetComponent<EnemyScripts>();
            Debug.Log(health);
            if (health != null)
            {
                health.DamageMethod(damageRate);
            }
        }
    }
}
