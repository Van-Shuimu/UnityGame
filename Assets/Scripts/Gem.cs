using UnityEngine;

public class Gem : MonoBehaviour
{
    public float value = 1;
    public string resName = "gold";
    public void Collect()
    {
        Resources.Find(resName).Change(value);
        Destroy(gameObject);
    }
}
