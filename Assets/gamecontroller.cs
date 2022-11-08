using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gamecontroller : MonoBehaviour
{
    public float time = 20f;
    public GameObject text;
    bool gameover = false;
    bool gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {

            time -= Time.deltaTime;
            text.GetComponent<TextMeshProUGUI>().text = ((int)time).ToString();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            gameStarted = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            gameover = true;
        }
    }
}
