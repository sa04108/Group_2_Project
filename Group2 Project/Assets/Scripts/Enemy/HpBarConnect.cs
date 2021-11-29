using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarConnect : MonoBehaviour
{
    public Slider slider;
    public GameObject obj;
    
    // Start is called before the first frame update
    void Start()
    {

         
    }

    // Update is called once per frame
    void Update()
    {
        int Hp = obj.GetComponent<DragonWingStatus>().WingHP;
        slider.value = Hp;

        //obj.GetComponent<DragonWingStatus>().WingHP
    }


}
