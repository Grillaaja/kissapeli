using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{

    public float speed;
    Rigidbody2D rigidbody;
    public Text collectedText;
    public Text healtit;
    public static int collectedAmount = 0;
    public int hp;
    public static int hpUpdate = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        hpUpdate = hp;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        rigidbody.velocity = new Vector3(hor * speed, ver * speed, 0);
        collectedText.text = "Items collected: " + collectedAmount;
        healtit.text = "HP = " + hpUpdate;
    }
}
