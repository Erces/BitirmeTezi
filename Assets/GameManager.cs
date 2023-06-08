using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public TMP_Text goldText;
    public static GameManager i;
    public CinemachineVirtualCamera camera;
    public CinemachineTransposer _transposer;
    public float zoomScale;
    public GameObject normalTurret;
    public GameObject stickyTurret;
    public GameObject laserTurret;
    public GameObject selectedTurret;
    public int gold;
    public float counter;
    public float gameTime;
    public float winTime;
    public bool gameEnded;
    public GameObject endPanel;
    public GameObject winUI;
    public GameObject loseUI;
    private void Awake()
    {
        i = this;
        DOTween.Init();
    }
    private void Start()
    {
        gameTime = 0;
        gold = 100;
        _transposer = camera.GetCinemachineComponent<CinemachineTransposer>();
        InvokeRepeating("CheckGameEnd", 10, 1);
    }
    public void CheckGameEnd()
    {
        if(gameTime > winTime && !gameEnded)
        {
            gameEnded = true;
            Time.timeScale = 0;
            ToggleWin();
        }
        if(GridTemplates.i.deathCount >= 3 && !gameEnded)
        {
            gameEnded = true;

            ToggleLose();
        }
    }
    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        

    }
    public void ToggleWin()
    {
        endPanel.SetActive(true);
        winUI.SetActive(true);

    }
    public void ToggleLose()
    {
        endPanel.SetActive(true);
        loseUI.SetActive(true);


    }
    private void Update()
    {
        gameTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedTurret = normalTurret;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedTurret = stickyTurret;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedTurret = laserTurret;
        }
        counter += Time.deltaTime;
        if(counter >= 1)
        {
            counter = 0;
            gold += 10;
        }
        
        goldText.text = gold.ToString();
        Vector3 offset = _transposer.m_FollowOffset;
       
        offset.z = Input.mouseScrollDelta.y * zoomScale;
        _transposer.m_FollowOffset.z -= offset.z;
        offset.y = 14;
    }
    public void DoTweenCamShake(float duration, float str, int vibrato, float randomness = 90)
    {
        Debug.Log("Cam Shake");
        //camShakeTimer = 0.35f;
        Camera.main.transform.DOShakePosition(duration, str, vibrato, randomness);
        // cam.transform.DOShakePosition(0.2f, 0.1f,60);
    }
    public bool CanBuy(int price)
    {
        if(gold>= price)
        {
            gold -= price;
            return true;
        }
        else
        {
            return false;
        }
    }
}
