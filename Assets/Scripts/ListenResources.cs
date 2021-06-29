using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFloat
{
    void Use(float f);
}

public class ListenResources : MonoBehaviour
{
    public string resourceName = "gold";
    private IFloat[] users;
    private void Start()
    {
        Resources.Find(resourceName).ChangeEvent += UseValue;
        users = GetComponentsInChildren<IFloat>();
    }
    private void UseValue(float value)
    {
        foreach (var user in users)
            user.Use(value);
    }
}
