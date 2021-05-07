using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollUi : MonoBehaviour
{
    public Transform mRoot;
    public GameObject mTemplete;
    // Start is called before the first frame update
    void Start()
    {
        mTemplete.SetActive(false);
        DateTime dtNow = DateTime.Now;
        for (int i = 0; i < 50; ++i)
        {
            int rank = i + 1;
            GameObject obj = GameObject.Instantiate(this.mTemplete);
            obj.SetActive(true);
            obj.transform.SetParent(mRoot);
            obj.transform.localScale = Vector3.one;
            obj.transform.Find("Content/Rank").GetComponent<Text>().text = "排名" + rank;
            int score = UnityEngine.Random.Range(20000, 10000000);
            obj.transform.Find("Content/Score").GetComponent<Text>().text = score.ToString();
            int level = UnityEngine.Random.Range(1, 99);
            obj.transform.Find("Content/Level").GetComponent<Text>().text = "等级" + level;
            int randomAdd = UnityEngine.Random.Range(-100, 100);
            DateTime dt = dtNow.AddDays(randomAdd).AddSeconds(i * randomAdd);
            obj.transform.Find("Content/Date").GetComponent<Text>().text = dt.ToUniversalTime().ToString();
        }
    }
}
