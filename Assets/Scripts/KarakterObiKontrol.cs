using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using DG.Tweening;



public class KarakterObiKontrol : MonoBehaviour
{
    [SerializeField] private List<GameObject> _ipler = new List<GameObject>();
    [SerializeField] private List<GameObject> _kupler = new List<GameObject>();

    public void IpleriKopart()
    {
        /*
        if (_ipler[0].GetComponent<ObiParticleAttachment>().attachmentType == ObiParticleAttachment.AttachmentType.Static)
        {
            _ipler[0].GetComponent<ObiParticleAttachment>().attachmentType = ObiParticleAttachment.AttachmentType.Dynamic;
        }
        else
        {

        }

        if (_ipler[1].GetComponent<ObiParticleAttachment>().attachmentType == ObiParticleAttachment.AttachmentType.Static)
        {
            _ipler[1].GetComponent<ObiParticleAttachment>().attachmentType = ObiParticleAttachment.AttachmentType.Dynamic;
        }
        else
        {

        }
        */

        _ipler[0].GetComponent<Rigidbody>().isKinematic = false;
        _ipler[1].GetComponent<Rigidbody>().isKinematic = false;

        _kupler[0].transform.DOMoveZ(1, 0.1f).OnComplete(() => _kupler[0].transform.DOMoveZ(3, 0.1f));
        _kupler[1].transform.DOMoveZ(1, 0.1f).OnComplete(() => _kupler[1].transform.DOMoveZ(3, 0.1f));

    }
}
