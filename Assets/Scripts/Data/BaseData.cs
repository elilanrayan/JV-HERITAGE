using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseData  
{
    public string label;
    [TextArea] public string caption;

    public virtual void DisplayName()
    {
        Debug.Log("Base" + label);
    }

    public BaseData(string label,string caption) {
        this.label = label;
        this.caption=caption;
    }
}
