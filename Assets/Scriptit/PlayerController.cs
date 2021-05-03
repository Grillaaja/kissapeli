using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{   
    //Komponentit
    public Rigidbody2D rgbody;
    private Camera cam;
    public Animator animator;
    public HealthBar healthBar;


    //UI tekstit
    public Text healtit;
    public Text damaget;
    public Text speedit;
    public Text aspeedit;
    public Text rahat;

    //Statsit
    public static int collectedAmount = 0;
    public float speed;
    public static float speedUpdate = 0;
    public int hp;
    public static int hpUpdate = 0;
    public float attSpeed;
    public static float attSpeedUpdate = 0;
    public int dmg;
    public static int dmgUpdate = 0;
    public static int maxHp = 0;
    public static int raha = 0;

    //Aikoja yms
    private float invincibilityTime = 100.5f;
    private bool isInvincible = false;
    

    //Ammus-modifierit
    public static bool poisonammo = false;
    public static bool tripleshot = false;
    public static bool tripleshot2 = false;
    public static bool tripleshot3 = false;
    public static bool explosiveshot = false;
    public static bool critical = false;


    public GameObject poison;
    public GameObject triple;
    public GameObject powder;
    public GameObject collar;

    Image poisonbg;
    Image triplebg;
    Image powderbg;
    Image collarbg;

    //Itemeiden taso-kertoimet
    public static int collarKerroin = 0;
    public static int gunPowderKerroin = 0;
    public static int ratPoisonKerroin = 0;

    //Teleporttien toiminta
    public static bool visitedshop = false;
    public static bool visitedboss = false;
    public static bool victory = false;





    void Start()
    {

        //Alustetaan staattiset pelin alkaessa uudestaan
        collectedAmount = 0;
        speedUpdate = 0;
        attSpeedUpdate = 0;
        dmgUpdate = 0;
        critical = false;
        explosiveshot = false;
        tripleshot3 = false;
        tripleshot2 = false;
        tripleshot = false;
        poisonammo = false;
        ratPoisonKerroin = 0;
        gunPowderKerroin = 0;
        collarKerroin = 0;
        visitedboss = false;
        visitedshop = false;
        victory = false;

        poisonbg = poison.GetComponent<Image>();
        triplebg = triple.GetComponent<Image>();
        powderbg = powder.GetComponent<Image>();
        collarbg = collar.GetComponent<Image>();

        poisonbg.color = new Color32(20, 14, 14, 107);
        triplebg.color = new Color32(20, 14, 14, 107);
        powderbg.color = new Color32(20, 14, 14, 107);
        collarbg.color = new Color32(20, 14, 14, 107);
        // Alustetaan pelaajan attribuutit
        hpUpdate = hp;
        attSpeedUpdate = attSpeed;
        speedUpdate = speed;
        dmgUpdate = dmg;
        cam = Camera.main;
        healthBar.SetMaxHealth(hp);
        maxHp = hp;
        raha = 0;
        
    }

    void Update()
    {


        //UI hommia
        if (tripleshot2)
        {
            triplebg.color = new Color32(255, 255, 255, 107);
        }
        if (tripleshot3)
        {
            triplebg.color = new Color32(253, 192, 0, 167);
        }
        if (ratPoisonKerroin == 2)
        {
            poisonbg.color = new Color32(255, 255, 255, 107);
        }
        if (ratPoisonKerroin == 3)
        {
            poisonbg.color = new Color32(253, 192, 0, 167);
        }
        if (gunPowderKerroin == 2)
        {
            powderbg.color = new Color32(255, 255, 255, 107);
        }
        if (gunPowderKerroin == 3)
        {
            powderbg.color = new Color32(253, 192, 0, 167);
        }
        if (collarKerroin == 2)
        {
            collarbg.color = new Color32(255, 255, 255, 107);
        }
        if (collarKerroin == 3)
        {
            collarbg.color = new Color32(253, 192, 0, 167);
        }

        //Alustetaan X ja Y akseleiden liikkumispainikkeet
        attSpeed = attSpeedUpdate;
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        //Alustetaan pelaajan nopeus "Speed" statsista ja näkyvät UI tekstit
        rgbody.velocity = new Vector3(hor * speedUpdate, ver * speedUpdate, 0);
        healtit.text = hpUpdate + "/" + hp;
        damaget.text = "DMG = " + dmgUpdate;
        speedit.text = "MS = " + speedUpdate;
        aspeedit.text = "AS = " + Mathf.Round(attSpeedUpdate * 100f) / 100f;
        rahat.text = "" + raha;
        healthBar.SetMaxHealth(hp);
        healthBar.SetHealth(hpUpdate);


        //Animaatioita varten suunnat ja muut
        animator.SetFloat("Horizontal", hor);
        animator.SetFloat("Vertical", ver);
        animator.SetFloat("Speed", rgbody.velocity.magnitude);


        //Jos pelaajan HP 0 tai alle, siirtymä Main menuun
        if (hpUpdate <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //Jos pelaajan hp menee maksimin yli, ne laskevat maksimiin
        if(hpUpdate > maxHp)
        {
            hpUpdate = maxHp;
        }



    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("invincible");
        isInvincible = true;

        yield return new WaitForSeconds(invincibilityTime);

        isInvincible = false;
        Debug.Log("not invincible");
    }

    public void LoseHealth(int amount)
    {
        if (isInvincible) return;
        animator.SetTrigger("TakeHit");
        hpUpdate -= amount;

        StartCoroutine(BecomeTemporarilyInvincible());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shop")
        {
            visitedshop = true;
        }
        else if( collision.tag == "BossRoom")
        {
            visitedshop = false;
            visitedboss = true;
        }
        else if (collision.tag == "MainRoom")
        {
            visitedshop = false;
            visitedboss = false;
        }
    }

    private void FixedUpdate()
    {
        if (tripleshot2)
        {
            tripleshot = false;
        }
        if (tripleshot3)
        {
            tripleshot2 = false;
            tripleshot = false;
        }
    }

}
