using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public float speedSide = 2.5f;
    public CharacterController player;
    private AudioSource audio;

    public Text text;
    private float pumpkins = 0;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        player.Move(Vector3.right * speedSide * Input.GetAxis("Horizontal") * Time.deltaTime );
    }

    // Обработка столкновений
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            pumpkins++;
            UpdateCountText();
            audio.Play();

        }

        if (other.CompareTag("Enemy"))
        {
            pumpkins--;
            UpdateCountText();
        }
    }

    void UpdateCountText()
    {
        text.text = "Score: " + pumpkins;
    }

}
