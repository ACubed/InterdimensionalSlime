using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    public int GetWeight()
    {
        MainBlobScaler mainBlobScaler = GetComponent<MainBlobScaler>();
        if (mainBlobScaler != null)
        {
            if (mainBlobScaler.splitEffects.split)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
        else
        {
            return 1;
        }
    }
}
