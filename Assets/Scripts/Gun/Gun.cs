using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip laserSound;
    public GameObject laser;
    public GameObject[] lasers;
    public Transform barrelLocation;
    public Transform playerLocation;
    private OVRGrabbable ovrGrabbable;
    public OVRInput.Button shootButton;
    public float force = 1500;
    public float velocity = 2000f;
    public ParticleSystem muzzleFlash;

    // Start is called before the first frame update
    [Obsolete]
    void Start()
    {
        laser = lasers[0];
        audioSource = GetComponent<AudioSource>();
        ovrGrabbable = GetComponent<OVRGrabbable>();
        audioSource.clip = laserSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (ovrGrabbable.isGrabbed && OVRInput.GetDown(shootButton, ovrGrabbable.grabbedBy.GetController()))
        {
            audioSource.Play();
            // leaving muzzle flash off until colors are figured out
            //muzzleFlash.Play();
            if (!laser) { return; }

            var rotation = barrelLocation.rotation;
            rotation.x = 0;

            GameObject projectile = Instantiate(laser, barrelLocation.position, transform.rotation);
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
            projectileRigidbody.AddForce(barrelLocation.right * force);
            projectile.GetComponent<Rigidbody>().AddForce(barrelLocation.right * force);
            //projectile.GetComponent<Rigidbody>().velocity *= velocity;
        }
    }

    [Obsolete]
    public void upgradeGun(int level)
    {
        laser = lasers[level];
    }
}

