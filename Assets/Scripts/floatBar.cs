using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatBar : MonoBehaviour, IFloat
{
    private float m_Max, m_Width;
    public ListenResources m_Listener;
    void Start()
    {
        m_Max = Resources.Find(m_Listener.resourceName).GetMaxValue();
       
        m_Width = GetComponent<RectTransform>().rect.width;

    }

    // Update is called once per frame
    public void Use(float value)
    {
        transform.localPosition = new Vector3((value / m_Max - 1) * m_Width, 0, 0);
    }
}
