using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.Find("Canvas").GetComponent<UIManager>();
            }
            return instance;
        }
    }

    [SerializeField] private Slider ammoSlider;
    [SerializeField] private Color g_color;
    [SerializeField] private Color m_color;
    [SerializeField] private Color l_color;
    [SerializeField] private Image ammoImage;

    [SerializeField] private Slider changeSlider;
    [SerializeField] private Slider HPS;

    [SerializeField] private GameObject s_Panel;
    [SerializeField] private GameObject ov_Panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ChangeAmmoSlider(float p)
    {
        if (p>=.7)
        {
            ammoImage.color = g_color;
        }
        else if (p>=.4&&p<.7)
        {
            ammoImage.color = m_color;
        }
        else if (p>=0&&p<.4)
        {
            ammoImage.color = l_color;
        }
        ammoSlider.value = p;
    }


    public void ChangeReloadSlider(float p)
    {

        changeSlider.value = p;
    }

    public void ChangeHpSlider(float p)
    {
        HPS.value = p;
    }

    public void SelectPanelShow()
    {
        s_Panel.SetActive(true);
        Time.timeScale = 0;
    }


    public void SelectPanelHide()
    {
        s_Panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Select_Speed()
    {
        GameObject.Find("Weapons_0").GetComponent<Weapon_Rifle>().AddS();
        SelectPanelHide();
    }

    public void Select_Damage()
    {
        GameObject.Find("Weapons_0").GetComponent<Weapon_Rifle>().AddD();
        SelectPanelHide();
    }

    public void Select_Capacity()
    {
        GameObject.Find("Weapons_0").GetComponent<Weapon_Rifle>().AddC();
        SelectPanelHide();
    }

    public void ShowOverPanel()
    {
        ov_Panel.SetActive(true);
    }

    public void Restart_b()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitG_b()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
