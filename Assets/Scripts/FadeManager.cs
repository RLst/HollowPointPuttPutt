using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    private OVRScreenFade screenFade;

    private float fadeTimer;
    private float fadeCountDown = 0;
    private Vector3 nextPosition;

    // Start is called before the first frame update
    void Start()
    {
        nextPosition = transform.position;
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
        else if (transform.position != nextPosition)
        {
            transform.position = nextPosition;
            screenFade.FadeIn();
            fadeCountDown = 0;
        }
    }

    public void InitiateTeleport(Vector3 Position)
    {
        fadeCountDown = fadeTimer;
        nextPosition = Position;
    }
}
