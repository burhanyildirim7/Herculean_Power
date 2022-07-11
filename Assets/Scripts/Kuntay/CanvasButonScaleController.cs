using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasButonScaleController : MonoBehaviour
{
    [SerializeField] Canvas MainCanvas;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(MainCanvas.GetComponent<RectTransform>().sizeDelta.y * 0.267f / 0.5785f, MainCanvas.GetComponent<RectTransform>().sizeDelta.y * 0.267f );
    }
}
