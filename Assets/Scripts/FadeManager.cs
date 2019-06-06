using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    private OVRScreenFade screenFade;

    private float fadeTimer;

    // Start is called before the first frame update
    void Start()
    {
        screenFade = GetComponentInChildren<OVRScreenFade>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitiateTeleport(Vector3 Position)
    {

    }
}
