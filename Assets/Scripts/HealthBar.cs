using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Health Source;
    public GameObject Bar;
    private float FullWidth;

    private void Start()
    {
        FullWidth = Bar.transform.localScale.x;    
    }

    void Update()
    {
        var healthPercentage = Source.Current / Source.Max;
        Bar.transform.localScale = new Vector3(FullWidth * healthPercentage, Bar.transform.localScale.y, Bar.transform.transform.localScale.z);
    }
}
