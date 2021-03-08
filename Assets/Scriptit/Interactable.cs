using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public SpriteRenderer sp;
    public Text interactText;
    public int id;
    public int hinta;

    void Start()
    {
        
    }

    void Update()
    {
        if(isInRange)
        {
            sp.color = new Color(1f, 1f, 1f, .75f);
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
        if(!isInRange)
        {
            sp.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && id == 0)
        {
            interactText.text = "Buy Gunpowder? (" + hinta + ")";
            isInRange = true;
            Debug.Log("Player now in range");
        }
        if (collision.tag == "Player" && id == 1)
        {
            interactText.text = "Buy Rat Poison? (" + hinta + ")";
            isInRange = true;
            Debug.Log("Player now in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactText.text = "";
            isInRange = false;
            Debug.Log("Player now not in range");
        }
    }


}
