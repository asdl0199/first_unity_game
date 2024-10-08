using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Em_Generate : MonoBehaviour
{
    [SerializeField] private GameObject[] lists;

    [SerializeField] private int nowLevel = 1;
    [SerializeField] private float next_Time = 5f;
    [SerializeField] private int next_Count = 10;
    [SerializeField] private GameObject[] monster_Prefab;

    [SerializeField] private GameObject su_Prefab;

    private Vector2 bottomLeft = new Vector2(-50, -28);
    private Vector2 topRight = new Vector2(60, 68);
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector2[] GenerateRandomPoints(int numberOfPoints)
    {
        Vector2[] vc2 = new Vector2[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            float randomX = Random.Range(bottomLeft.x, topRight.x);
            float randomY = Random.Range(bottomLeft.y, topRight.y);
            Vector2 randomPoint = new Vector2(randomX, randomY);
            vc2[i] = randomPoint;
        }
        return vc2;
    }
    // Update is called once per frame
    void Update()
    {
        if (next_Time>0)
        {
            next_Time -= Time.deltaTime;
        }
        else if (next_Time<=0)
        {
            for (int i = 0; i < next_Count; i++)
            {
                int now_select = Random.Range(0, lists.Length);
                Vector2 sp = lists[now_select].transform.position;
                int r_x = Random.Range(-10, 10);
                int r_y = Random.Range(-10, 10);
                int now_select_m = Random.Range(0, monster_Prefab.Length);
                GameObject mons = ObjectPool.Instance.GetObject(monster_Prefab[now_select_m]);
                mons.transform.position = sp+new Vector2(r_x, r_y);
                mons.GetComponent<Em>().Init(Random.value > 0.5f, nowLevel);
                //ObjectPool.Instance.PushObject(mon);
            }
            Vector2[] vc2=GenerateRandomPoints(nowLevel*2+3);
            for (int j = 0; j < vc2.Length; j++)
            {
                GameObject sup = ObjectPool.Instance.GetObject(su_Prefab);
                sup.transform.position = vc2[j];
            }
            UIManager.Instance.SelectPanelShow();
            nowLevel++;
            next_Time = 5f + nowLevel * 7;
            next_Count = 10 + nowLevel * 15;
        }
    }
}
