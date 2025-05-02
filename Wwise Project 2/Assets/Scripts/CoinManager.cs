using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{

    public int coinCount;
    public TMP_Text coinText;
    public GameObject Door;
    private Collider2D DoorBox;
   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DoorBox = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        coinText.text = ":" + coinCount.ToString();
        if (coinCount == 4) 
        {
            DoorBox.enabled = false;
            // door needs box collider 2d
        }
    }


}
