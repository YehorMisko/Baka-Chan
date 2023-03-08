using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
//A script for the Hint Animation
public class HintAnim : MonoBehaviour
{
    private int toggle;
    void Start()
    {
        toggle = 1;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (toggle >= 0 && toggle <= 100)
        {
            toggle += 1;
            transform.localScale += new Vector3(1 * 0.01f, 1 * 0.01f, 0);
        }
        else if (toggle < 0)
        {
            toggle += 1;
            transform.localScale -= new Vector3(1 * 0.01f, 1 * 0.01f, 0);
            
           
        }
        else
        {
            toggle = -100;
        }
    }

}
