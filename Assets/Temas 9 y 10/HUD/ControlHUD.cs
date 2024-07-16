using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlHUD : MonoBehaviour
{
    public GameObject panelLose;
    public Slider sliderHUD;
    public Image imgHUD;
    public TextMeshProUGUI tmpHUD;
    public Button btnHUD;
    public Sprite newSprite;
    public float damage = 20;
    public float health = 10;
    private float playerHP = 100;
    public GameObject fillArea;
    //timer 1
    private float timer;
    //timer 2
    private int secondsToCount = 1;
    private float seconds = 0;
    private int number;
    private int minutes;
    private void Awake()
    {
        //timer 3
        //InvokeRepeating(funcion que llamaremos, retraso inicial en segundos, intervalo entre cada repeticion en segundos)
        //InvokeRepeating("UsingInvokeRepeating", 1, 1);
    }
    private void Start()
    {
        imgHUD.sprite = newSprite;
    }
    private void UsingInvokeRepeating()
    {
        number++;
    }

    // Update is called once per frame
    void Update()
    {

        //timer 1
        timer += Time.deltaTime;
        //tmpHUD.text = "Time: " + timer.ToString("00:00");
        minutes = Mathf.FloorToInt(timer / 60);//8.2=8 | 9.8=9
        //30 / 60 = 0,....=0 minutos | 150 / 60 = 2,....=2 minutos
        seconds = Mathf.FloorToInt(timer % 60); //30 % 60 = 30 segundos
        //150 % 60=30 segundos | 176 % 60= 56 segundos | 240%60=0
        tmpHUD.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        //=======================================================
        //timer 2
        //seconds += Time.deltaTime;
        //if (seconds >= secondsToCount)//1.0001>=1? si
        //{
        //    seconds = 0;
        //    number++;//number=0+1=1 | 1+1=2
        //}
        //tmpHUD.text = "Time: " + number.ToString();
        //=======================================================
        //timer 3
        //tmpHUD.text = "Time: " + number.ToString();


        //=======================================================
        //Cambiar vida del slider con clicks
        //if (Input.GetButtonDown("Fire1") && playerHP > 0)
        //{
        //    playerHP -= damage;
        //    sliderHUD.value = (playerHP / 100);
        //    Debug.Log("left click");
        //}
        //else if (Input.GetButtonDown("Fire2") && playerHP > 0)
        //{
        //    playerHP += health;
        //    sliderHUD.value = (playerHP / 100);
        //    Debug.Log("right click");
        //}
        //panelLose.activeSelf:
        //true: el panelLose esta activado
        //false: el panelLose esta desactivado
        if (playerHP <= 0 && !panelLose.activeSelf)//panelLose.activeSelf == false
        {
            fillArea.SetActive(false);
            panelLose.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Perdiste manco");
        }
    }
    public void LoseHP()
    {
        if (playerHP > 0)//playerHP=100 >0 ? Si | 10>0? Si
        {
            playerHP -= damage;//playerHP=100-20=80 | playerHP=10-20=-10
            if (playerHP < 0) playerHP = 0;
            sliderHUD.value = (playerHP / 100);//80/100=0.8 | -10/100=-0.1
        }
    }
    public void GainHP()
    {
        if (playerHP < 100 && playerHP > 0)//0<99<100? Si
        {
            playerHP += health;//99+10=109
            if (playerHP > 100) playerHP = 100;
            sliderHUD.value = (playerHP / 100);//109/100=1.09
        }
    }

    public void PrintText()
    {
        Debug.Log("cambio de vida");
    }
}