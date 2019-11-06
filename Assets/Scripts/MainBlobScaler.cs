using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBlobScaler : MonoBehaviour
{
    public SplitEffects splitEffects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (splitEffects.split)
        {
            transform.localScale = new Vector3(3.25f, 3.25f, 3.25f);
        }
        else
        {
            transform.localScale = new Vector3(4f, 4f, 4f);
        }
    }
}
