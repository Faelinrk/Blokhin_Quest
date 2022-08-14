using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletone : MonoBehaviour
{
    private static Singletone instance = null;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
