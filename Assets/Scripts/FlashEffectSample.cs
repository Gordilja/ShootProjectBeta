using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEffectSample : MonoBehaviour
{
    [SerializeField] public FlashEffect flashEffect;

    public void Flash() 
    {
        flashEffect.Flash();
    }
}
