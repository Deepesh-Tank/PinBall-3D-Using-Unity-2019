using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class plunger : MonoBehaviour
{
    float power;
    float maxPower = 10;
    float powerCountPerTick = 1;


    public Animator plugerAnim;


    Rigidbody ballRb;
    ContactPoint contact;
    bool ballReady;


    // Update is called once per frame
    void Update()
    {
        if(ballReady)
        {
            if(Input.GetKey(KeyCode.DownArrow))
            {
                if(power<=maxPower)
                {
                    power += powerCountPerTick * Time.deltaTime;
                }
                plugerAnim.SetBool("activate", true);
                Debug.Log(power);
            }
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            if(ballRb != null)
            {
                ballRb.AddForce(-1 * power * contact.normal, ForceMode.Impulse);
            }
            plugerAnim.SetBool("activate", false);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        ballReady = true;
        power = 0f;
        contact = col.contacts[0];
        ballRb = contact.otherCollider.attachedRigidbody;
    }

    void OnCollisionExit(Collision col)
    {
        ballReady = false;
        ballRb = null;
    }
}
