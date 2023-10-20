using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrag : MonoBehaviour
{
    static public bool _enabled = false;
    [SerializeField] private PlayerMove playerMove;


    private void OnMouseDown()
    {
        if (_enabled)
        {
            playerMove.UpdateFreezeTime(false);
        }
    }
}
