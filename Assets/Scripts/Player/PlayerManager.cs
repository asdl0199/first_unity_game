using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int MAX_HP = 200;
    public int NOW_HP = 200;





    public float GetPlayerHPPresent()
    {
        return (NOW_HP != 0 && MAX_HP != 0) ? (float)NOW_HP / (float)MAX_HP : 0;
    }


    public void AddPlayerComponents()
    {

    }



}
