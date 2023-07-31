using UnityEngine;
using UnityEngine.UIElements;

public class Saw : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime);
    }
}
