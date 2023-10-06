using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Detection : MonoBehaviour
{
    public event Action OnChange;
    
    [SerializeField] private Light2D light2D;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            light2D.enabled = true;
            OnChange?.Invoke();
        }
    }
}
