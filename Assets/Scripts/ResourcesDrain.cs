using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesDrain : MonoBehaviour
{
    private Resources m_Resources;
    public string m_ResourcesName = "playerWater";
    public float m_DrainSpeed = 1;
    // Start is called before the first frame update
    private void Start()
    {
        m_Resources = Resources.Find(m_ResourcesName);
    }

    // Update is called once per frame
    void Update()
    {
        m_Resources.Change(-m_DrainSpeed * Time.deltaTime);
    }
}
