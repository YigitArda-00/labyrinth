using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tophareket : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Text zaman,durum,can;
    public UnityEngine.UI.Image died;
   private Rigidbody rg;
   public float Hiz = 1.5f;
    float zamansayaci = 30;
    int cansayaci = 5;
    bool oyundevam = true;
    bool oyuntamam = false;
    void Start()
    {
        can.text = cansayaci + "";
        rg = GetComponent<Rigidbody>();

    }
    void Update()
    {
        if (oyundevam && !oyuntamam)
        {
            zamansayaci -= Time.deltaTime;
            zaman.text = (int)zamansayaci + "";
        }else if (!oyuntamam)
        {
            
            btn.gameObject.SetActive(true);
        }
        if (zamansayaci < 0)
        {
            oyundevam = false;
        }
    }
    void FixedUpdate()
    {
        if (oyundevam && !oyuntamam){
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
            rg.AddForce(kuvvet * Hiz);
        } else
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
    }
    void OnCollisionEnter(Collision cls)
    {
        string objIsmi = cls.gameObject.name;
        if (objIsmi.Equals("bitis"))
        {
            SceneManager.LoadScene("yiid");
            //print("Oyun Tamamland�");
            //oyuntamam = true;
            
            btn.gameObject.SetActive(true);
        } else if (!objIsmi.Equals("labirentzemini") && !objIsmi.Equals("zemin"))
        {
            cansayaci -= 1;
            can.text = cansayaci + "";
            if (cansayaci == 0)
            {
                oyundevam = false;
            }
        }
              
    }
    
}
