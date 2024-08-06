using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonEvent : MonoBehaviour
{
   public void Change() 
    {
        PersonManager.Instance.chooseNewCase();
    }
}
