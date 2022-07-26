using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using DG.Tweening;



public class KarakterObiKontrol : MonoBehaviour
{
    [SerializeField] private List<GameObject> _ipler = new List<GameObject>();
    [SerializeField] private List<GameObject> _kupler = new List<GameObject>();

    [SerializeField] private List<GameObject> _solKancaListesi = new List<GameObject>();
    [SerializeField] private List<GameObject> _sagKancaListesi = new List<GameObject>();

    private void Start()
    {
        //IpleriYerlestir();
    }


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

        _kupler[0].transform.DOMoveZ(1, 0.1f).OnComplete(() => _kupler[0].transform.DOMoveZ(5, 0.1f));
        _kupler[1].transform.DOMoveZ(1, 0.1f).OnComplete(() => _kupler[1].transform.DOMoveZ(5, 0.1f));



    }

    public void IpleriYerlestir()
    {
        _ipler[0].GetComponent<Rigidbody>().isKinematic = true;
        _ipler[1].GetComponent<Rigidbody>().isKinematic = true;

        if (PlayerPrefs.GetInt("SutunSirasi") < 18)
        {
            _ipler[0].transform.position = _solKancaListesi[PlayerPrefs.GetInt("SutunSirasi")].transform.position;
            _ipler[1].transform.position = _sagKancaListesi[PlayerPrefs.GetInt("SutunSirasi")].transform.position;
        }
        else
        {
            _ipler[0].transform.position = _solKancaListesi[18].transform.position;
            _ipler[1].transform.position = _sagKancaListesi[18].transform.position;
        }


        _kupler[0].transform.DOMoveX(IncrementalControlScript.instance._solSutunListesi[0].transform.position.x, 0.1f);
        _kupler[1].transform.DOMoveX(IncrementalControlScript.instance._sagSutunListesi[0].transform.position.x, 0.1f);
    }
}
