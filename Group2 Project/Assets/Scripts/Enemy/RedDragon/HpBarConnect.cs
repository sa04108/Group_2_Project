using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarConnect : MonoBehaviour
{
    public Slider slider;
    
    
    // Start is called before the first frame update
    void Start()
    {

         
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if(obj.tag == "dragon")
        {
            int Hp = obj.GetComponent<DragonStatus>().HP;
            slider.value = Hp;
            
        }*/
        
        //obj.GetComponent<DragonWingStatus>().WingHP
    }

    public void HpToUi(int wingHp)
    {
        
        slider.value = wingHp;
    }
}
