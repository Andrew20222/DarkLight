using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 _screenBounds;
    private bool _isFreeze;
    public bool IsFreeze => _isFreeze;
    public void UpdateFreezeTime(bool value) => _isFreeze = value;


    private void Awake()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,
            Screen.height,
            Camera.main.transform.position.z));
    }

    private void Update()
    {
        if (_isFreeze == false)
        {
            Move();
            Check();

        }
    }

    private void Move()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.position = ray.origin;
    }

    private void Check()
    {
        var viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -_screenBounds.x, _screenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, -_screenBounds.y, _screenBounds.y);
        transform.position = viewPos;
    }
}