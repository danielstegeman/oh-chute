using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamecontroller : MonoBehaviour
{
    public float time = 20f;
    public GameObject text;
   public bool gameover = false;
    bool gameStarted = false;
    public GameObject Helptext;
    public GameObject parachute;
    public AudioSource wind;
    public bool isSafe;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        text.GetComponent<TextMeshProUGUI>().text = ((int)time).ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted && time > 0 && !isSafe)
        {

            time -= Time.deltaTime;
            text.GetComponent<TextMeshProUGUI>().text = ((int)time).ToString();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            //parachute.GetComponent<SpriteRenderer>().enabled = true;
            parachute.SetActive(true);
            Time.timeScale = 1;
            gameStarted = true;
            Helptext.SetActive(false);
            wind.Play();
        }
        if (gameover && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            wind.Stop();
            if (isSafe)
            {
                UpdateHelpText("You have landed Safely!\n Press space to restart");
            }
            else
            {
                GetComponent<AudioSource>().Play();
            UpdateHelpText("You fell to your death!\n Press space to restart.");
            }
            Time.timeScale = 0;
            gameover = true;
        }
    }
    public void UpdateHelpText(string text)
    {
        Helptext.GetComponent<TextMeshProUGUI>().text = text;
        Helptext.SetActive(true);
    }
    public void ToggleHelpText(bool value)
    {
        Helptext.SetActive(value);
    }
    
}
