using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class UICoolDonw : MonoBehaviour
{
    // Start is called before the first frame update
    public float CoolDown = 3;

    private Button _triggerButton;
    private Image _mask;
    private bool canSpell = true;

    void Start()
    {
        //assign value
        _triggerButton = GetComponent<Button>();
        _mask = transform.Find("Mask").GetComponent<Image>();
        //register event
        _triggerButton.onClick.AddListener(() =>
        {
            Debug.Log("IDinMain:"+Thread.CurrentThread.ManagedThreadId);
            if (canSpell)
            {
                _mask.fillAmount = 1;
                canSpell = false;
                //Start a recover thread to Corountine
                UniTask.RunOnThreadPool(async () =>
                {
                    float temp = 0;
                    while (temp<CoolDown)
                    {
                        Debug.Log("IDinThread:"+Thread.CurrentThread.ManagedThreadId);
                        await UniTask.Yield();
                        temp += Time.deltaTime;
                        _mask.fillAmount = (CoolDown - temp)/CoolDown;
                        Debug.Log("IDinThread:"+Thread.CurrentThread.ManagedThreadId);
                    }
                    canSpell = true;
                });
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
    }
}