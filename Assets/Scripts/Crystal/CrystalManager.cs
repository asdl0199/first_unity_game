using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    public int c1_count = 0;
    public int c2_count = 0;

    public int c_l=1;


    public int Gnc()//get now cost
    {
        return c_l * 50 + 50;
    }

    public void GetC1(int a)
    {
        c1_count = c1_count + a;
    }

    public void GetC2(int a)
    {
        c2_count = c1_count + a;
    }

    public bool SpendC1(int a)
    {
        if (a<=c1_count)
        {
            c1_count = c1_count - a;
            c_l++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool SpendC2(int a)
    {
        if (a <= c2_count)
        {
            c2_count = c2_count - a;
            c_l++;
            return true;
        }
        else
        {
            return false;
        }
    }



}
