using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public int hinta;
    public Text conditionalText;
    public void PickGunpowder()
    {
        if (PlayerController.raha > hinta)
        {
            PlayerController.raha = PlayerController.raha - hinta;
            Destroy(gameObject);
        }
        else
        {
            conditionalText.text = "Not enough fish!";
        }
    }
    public void PickRatpoison()
    {
        if (PlayerController.raha > hinta)
        {
            PlayerController.raha = PlayerController.raha - hinta;
            Destroy(gameObject);
        }
        else
        {
            conditionalText.text = "Not enough fish!" ;
        }
    }
}
