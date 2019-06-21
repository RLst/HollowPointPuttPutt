using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    private OVRScreenFade screenFade;

    private float fadeTimer;
    public float fadeCountDown = 0;
    private Transform nextTransform;
    
    void Start()
    {
        nextTransform = transform;
        screenFade = GetComponentInChildren<OVRScreenFade>();
        fadeTimer = screenFade.fadeTime;
    }

    void Update()
    {
        if(fadeCountDown > 0)
        {
            if (fadeCountDown == fadeTimer)
                screenFade.FadeOut();

            fadeCountDown -= Time.deltaTime;
        }
        else if (transform.position != nextTransform.position)
        {
            transform.SetPositionAndRotation(nextTransform.position, nextTransform.rotation);
            
            //transform.position = nextTransform.position;
            screenFade.FadeIn();
            fadeCountDown = 0;
        }
    }

    public void InitiateTeleport(Transform towerTransform)
    {
        fadeCountDown = fadeTimer;
        nextTransform = towerTransform;
    }
}
