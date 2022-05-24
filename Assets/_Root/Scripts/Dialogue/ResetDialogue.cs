using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CultureFMP.Dialogue
{
    public class ResetDialogue : MonoBehaviour
    {
        public VIDE_Assign videAssign;
        void Start()
        {
            videAssign = GetComponent<VIDE_Assign>();
            videAssign.overrideStartNode = -1;
        }
        
    }
}
