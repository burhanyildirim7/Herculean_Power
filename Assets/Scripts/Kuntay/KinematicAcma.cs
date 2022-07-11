using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicAcma : MonoBehaviour
{
    public void OpenKinematic()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
        }

    }
}
