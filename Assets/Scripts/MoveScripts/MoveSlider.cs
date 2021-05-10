using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSlider : MonoBehaviour
{
    public Vector3 positionDisplacement;
    public Vector3 positionOrigin;
    public Vector3 resetPos;
    private float _timePassed;
    public Slider choiceSLide;
    public float slideValue;
    public bool sliderMove;
    public GameObject handle;
    public float value;

    private void Start()
    {
        sliderMove = true;
        //float randomDistance = Random.Range(-10f, 10f);
        slideValue = 150;
        positionDisplacement = new Vector3(slideValue, 0, 0);
        positionOrigin = transform.position;
        resetPos = positionOrigin;
        value = positionOrigin.x;

        if (positionOrigin == null)
        {
            return;
        }
    }

    private void Update()
    {
        if (sliderMove)
        {
            value = handle.transform.position.x;
            _timePassed += Time.deltaTime * 2;
            transform.position = Vector3.Lerp(positionOrigin, positionOrigin + positionDisplacement, Mathf.PingPong(_timePassed, 1));
        }
        else if (!sliderMove) 
        {
            return;
        }
    }
}
