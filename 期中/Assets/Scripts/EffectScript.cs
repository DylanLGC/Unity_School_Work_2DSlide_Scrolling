using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour
{
    float time= 1f;

    void Start()
    {
            
    }

    void Update() {
        if(time <= 0f)
        {   
            Destroy(gameObject);
        }else {
            time -= Time.deltaTime;
        }
    }

}
