using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionController : MonoBehaviour
{
    public void resFullHd()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void resHd()
    {
        Screen.SetResolution(1280, 720, true);
    }
}
