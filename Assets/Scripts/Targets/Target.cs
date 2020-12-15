using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [HideInInspector]public bool isOut; //
    Animator anim;
    Collider col;

    TargetSet set;
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider>();
        set = gameObject.GetComponentInParent<TargetSet>();
        Activate(true);
    }

    public void Activate(bool on)
    {
        if (anim != null)
        {
            isOut = on;
            col.enabled = on;
            anim.SetBool("activate", on);
        }
    }

    void OnCollisionEnter(Collision _col)
    {
        Activate(false);
        //SAET CHECk Here
        set.CheckForReset();
    }
}
