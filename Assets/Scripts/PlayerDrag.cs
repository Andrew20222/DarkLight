using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrag : MonoBehaviour
{
    static public bool _enabled = false;
    public void Drag()
    {
        if (_enabled)
        {
            PlayerMove._enabled = true;
        }
    }
}
