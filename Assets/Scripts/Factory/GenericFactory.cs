using UnityEngine;

public class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T prefab;
    [SerializeField] private Transform pointToSpawn;

    public T GetNewInstance()
    {
        var position = pointToSpawn.position;
        var pos = new Vector3(position.x, position.y, position.z);

        var enemy = Instantiate(prefab, pos, Quaternion.identity);
        return enemy;
    }
}
