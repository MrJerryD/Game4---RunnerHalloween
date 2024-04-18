using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{
    public float speed = 2f;

    // pumpkin
    public List<Transform> points = new List<Transform>(); // список для монет
    public GameObject coin; // префаб коина

    private void Start()
    {
        // pumpkin
        int randomPoinIndex = Random.Range(0, points.Count); // выбираем рандомное размещение от 0 до количевства points
        GameObject newCoin = Instantiate(coin, points[randomPoinIndex].position, Quaternion.identity); // coint - что создаем | указываем точки points | повороты identity
        newCoin.transform.SetParent(transform);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
