using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        rigidbody.velocity = new Vector3(hor * speed, ver * speed, 0);
        
    }
}
