using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCollision : MonoBehaviour
{
    public Text timeText;
    public GameObject originalText;
    public Camera mainCamera;
    public Camera LoseCamera;

    // Start is called before the first frame update
    void Start()
    {
        LoseCamera.enabled = false;
        timeText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            LoseCamera.enabled = true;
            mainCamera.enabled = false;
            timeText.text = "You Lose";

            Invoke("setTimeZero", 0.1f);
        }
    }

    private void setTimeZero()
    {
        originalText.SetActive(false);
        Time.timeScale = 0;
    }
}
