using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    private OVRScreenFade screenFade;

    private float fadeTimer;
    private float fadeCountDown = 0;
    private Transform nextTransform;

    // Start is called before the first frame update
    void Start()
    {
        nextTransform = transform;
        screenFade = GetComponentInChildren<OVRScreenFade>();
        fadeTimer = screenFade.fadeTime;
    }

    // Update is called once per frame
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
            
            transform.position = nextTransform.position;
            screenFade.FadeIn();
            fadeCountDown = 0;
        }
    }

    public void InitiateTeleport(Transform Position)
    {
        fadeCountDown = fadeTimer;
        nextTransform = Position;
    }
}
