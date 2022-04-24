using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public Material greenMat;
    public Material redMat;
    public int frame;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            print("HIT");
            GetComponent<Renderer>().material = redMat;
        }
    }

    private void Update()
    {
        frame++;

        if(frame == 500)
        {
            GetComponent<Renderer>().material = greenMat;
            frame = 0;
        }
    }
}
