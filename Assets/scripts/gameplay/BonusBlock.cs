using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block
{
    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();

        points = ConfigurationUtils.BonusBlockPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
