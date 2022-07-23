using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicAcma : MonoBehaviour
{
    public void OpenKinematic()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(1).GetChild(0).GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
        }

    }
}
