using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Vector3 _screenBounds;
    static public bool _enabled = false;
    private void Awake()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,
            Screen.height,
            Camera.main.transform.position.z));
    }
    private void Update()
    {
        if (GameLogic.IsFreezeTime  == false || _enabled)
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