using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Detection : MonoBehaviour
{
    public event Action OnChange;
    static public bool IsDetection = false;
    [SerializeField] private Light2D light2D;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            IsDetection = true;
            light2D.enabled = true;
            OnChange?.Invoke();
        }
        
    }
}
