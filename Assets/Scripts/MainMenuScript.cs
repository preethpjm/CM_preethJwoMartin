using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private bool muted;
    [SerializeField] TextMeshProUGUI[] soundTxt;
    [SerializeField] GameObject Logo;
    [SerializeField] GameObject topHud;
    [SerializeField] GameObject spawnObject;
    [SerializeField] GameObject player;
    [SerializeField] GameObject joystick;
    [SerializeField] GameObject menuePanel;
    [SerializeField] GameObject gameplayCamera;
    private string audioText;
    // Start is called before the first frame update
    void Start()
    {
        menuePanel.SetActive(true);
        gameplayCamera.SetActive(false);
        topHud.SetActive(false);
        spawnObject.SetActive(false);
        joystick.SetActive(false);
        player.GetComponent<PlayerController>().enabled = false;
    }
    public void PlayGame()
    {
        //sfxSource.clip = buttonClick;
        SfxManager._insatnce.Play_ButtonClick();
        menuePanel.SetActive(false);
        gameplayCamera.SetActive(true);
        topHud.SetActive(true);
        Logo.SetActive(false);
        spawnObject.SetActive(true);
        joystick.SetActive(true);
        player.GetComponent<PlayerController>().enabled = true;
    }
    public void AudioToggle()
    {
        SfxManager._insatnce.Play_ButtonClick();
        if (muted == false)
        {
            muted = true;
            audioText = "SOUND OFF";
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            audioText = "SOUND ON";
            AudioListener.pause = false;
        }
        AudioTextChanger();
    }
    public void QuitGame()
    {
        SfxManager._insatnce.Play_ButtonClick();
        Application.Quit();
    }
    
    public void ReloadLevel()
    {
        SfxManager._insatnce.Play_ButtonClick();
        SceneManager.LoadScene("GameScene");
    }
    public void AudioTextChanger()
    {
        for (int i = 0; i < soundTxt.Length; i++)
        {
            soundTxt[i].text = audioText;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
