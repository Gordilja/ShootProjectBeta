using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSlider : MonoBehaviour
{
    private Vector3 positionDisplacement;
    private Vector3 positionOrigin;
    private float _timePassed;
    public Slider choiceSLide;
    private void Start()
    {
        //float randomDistance = Random.Range(-10f, 10f);
        float slideValue = 150;
        positionDisplacement = new Vector3(slideValue, 0, 0);
        positionOrigin = transform.position;
    }

    private void Update()
    {
        _timePassed += Time.deltaTime;
        transform.position = Vector3.Lerp(positionOrigin, positionOrigin + positionDisplacement,
        Mathf.PingPong(_timePassed, 1));
    }
}
