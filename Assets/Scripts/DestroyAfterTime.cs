using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    private float _time = 1.0f;

    private void Update()
    {
        if (_time < 0)
            Destroy(gameObject);
        _time -= Time.deltaTime;
    }
}