using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dice : MonoBehaviour
{
    public TextMeshProUGUI number;
    bool rolling = false;
    int maxNumber = 6;

    WaitForSecondsRealtime time = new WaitForSecondsRealtime(0.15f);

    public void Init()
    {
        number.text = maxNumber.ToString();
    }

    private void Start()
    {
        //StartRolling();
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    if(rolling)
        //    {
        //        StopRolling(6);
                
        //    }
        //    else
        //    {
        //        StartRolling();
        //    }
            
        //}
    }

    public void StartRolling()
    {
        StartCoroutine(Rolling());
    }

    public void StopRolling(int value)
    {
        StopCoroutine(Rolling());
        rolling = !rolling;
        number.text = value.ToString();
    }


    IEnumerator Rolling()
    {
        rolling = true;
        while(rolling)
        {
            number.text = Random.Range(1, maxNumber + 1).ToString();
            yield return time;
        }
    }
}
