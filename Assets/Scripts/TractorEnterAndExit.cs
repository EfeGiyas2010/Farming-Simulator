using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TractorEnterAndExit : MonoBehaviour
{
    public GameObject kam, krkt, driveUI, speedometerUI, tractor = null;
    public Transform sp;
    TractorController Tractor;
    Flashlight flashlight;
    public bool calýsýyor = false;
    public float closeDistance = 15f;

    [SerializeField] private SphereCollider _SphereCollider;

    [SerializeField]
    private List<Wheel> wheels;

    void Start()
    {
        Tractor = GetComponent<TractorController>();
        Tractor.enabled = false;
        driveUI.SetActive(false);
        speedometerUI.SetActive(false);
        Tractor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        flashlight = GetComponent<Flashlight>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (calýsýyor)
            {
                Cýk();

            }

            else if (CarNearby())//if out of car
            {
                Bin();

            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            driveUI.SetActive(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            driveUI.SetActive(false);
        }
    }

    private bool CarNearby()
    {
        driveUI.SetActive(false);
        Collider[] cols = Physics.OverlapSphere(krkt.transform.position
        + krkt.transform.InverseTransformDirection(Vector3.forward * (closeDistance * .5f)), closeDistance); //do the check in front of the player

        for (int i = 0; i < cols.Length; i++)
        {
            //This doesn't work if the vehicle is the child of something.
            if (cols[i].transform.root.TryGetComponent(out Tractor))
            {
                tractor = cols[i].transform.root.gameObject;
                return true;
            }

        }
        return false;
    }

    void Bin()
    {
        calýsýyor = true;
        Tractor.enabled = true;
        kam.SetActive(true);
        krkt.SetActive(false);
        speedometerUI.SetActive(true);
        Tractor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        foreach (var wheel in wheels)
        {
            wheel.collider.brakeTorque = 0f;

        }

        if (flashlight == false)
        {

        }

        else
        {
            flashlight.enabled = true;

        }


    }

    void Cýk()
    {
        calýsýyor = false;
        Tractor.enabled = false;
        kam.SetActive(false);
        krkt.SetActive(true);
        krkt.transform.position = sp.position;
        speedometerUI.SetActive(false);
        Tractor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        foreach (var wheel in wheels)
        {
            wheel.collider.brakeTorque = 5000;

        }

        if (flashlight == true)
        {
            flashlight.enabled = true;

        }

        else
        {

        }

    }

}
