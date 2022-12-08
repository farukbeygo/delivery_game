using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float rotate_speed = 1f;
    [SerializeField] float move_speed = 20f;
    [SerializeField] float slow_speed = 15f;
    [SerializeField] float boosted_speed = 30f;


    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * rotate_speed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * move_speed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Booster")
        {
            move_speed = boosted_speed;

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        move_speed = slow_speed;
    }


}
