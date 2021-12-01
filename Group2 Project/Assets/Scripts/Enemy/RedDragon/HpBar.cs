using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField] GameObject Hp_Bar_Prefebs = null;

    [SerializeField] List<Transform> m_objectList = new List<Transform>();
    [SerializeField] List<GameObject> m_hpBarList = new List<GameObject>();

    Camera m_cam = null;

    // Start is called before the first frame update
    void Awake()
    {
        m_cam = Camera.main;

        GameObject[] t_objects = GameObject.FindGameObjectsWithTag("Wing");
        for(int i = 0; i < t_objects.Length; i++)
        {
            m_objectList.Add(t_objects[i].transform);
            GameObject t_hpbar = Instantiate(Hp_Bar_Prefebs, t_objects[i].transform.position, Quaternion.identity, transform);
            m_hpBarList.Add(t_hpbar);
            //m_hpBarList[i].transform.GetChild(0).gameObject.GetComponent<HpBarConnect>().obj = t_objects[i];
            t_objects[i].GetComponent<DragonWingStatus>().obj = m_hpBarList[i];
        }
        /*
        GameObject[] d_objects = GameObject.FindGameObjectsWithTag("dragon");
        for (int i = 0; i < t_objects.Length; i++)
        {
            m_objectList.Add(d_objects[i].transform);
            GameObject t_hpbar = Instantiate(Hp_Bar_Prefebs, d_objects[i].transform.position, Quaternion.identity, transform);
            m_hpBarList.Add(t_hpbar);
            m_hpBarList[i].transform.GetChild(0).gameObject.GetComponent<HpBarConnect>().obj = d_objects[i];
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<m_objectList.Count; i++)
        {
            m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_objectList[i].position + new Vector3(0, 1f, 0));
        }
    }

    public void removeHpBar()
    {
        Transform[] childList = GetComponentsInChildren<Transform>(true);
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject); Debug.Log("dd");
            }
        }
    }
}
