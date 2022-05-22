using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetting : MonoBehaviour
{
    public Text timeText;
    public float time = 15f;

    public Camera mainCamera;
    public Camera winningCamera;

    private void Start()
    {
        mainCamera.enabled = true;
        winningCamera.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        

        timeText.text = Mathf.Ceil(time).ToString();

        if(time <= 0)
        {
            mainCamera.enabled = false;
            winningCamera.enabled = true;
            timeText.text = "You Win!";
            Time.timeScale = 0;
        }
    }
}
