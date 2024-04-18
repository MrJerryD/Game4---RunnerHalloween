using UnityEngine;

public class MoveStart : MonoBehaviour
{
    public float speed = 2f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

}
