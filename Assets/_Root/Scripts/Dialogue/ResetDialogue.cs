using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CultureFMP.Dialogue
{
    public class ResetDialogue : MonoBehaviour
    {
        private VIDE_Assign _videAssign;

        public bool overrideStartingDialogue;

        public string startingDialogue;
        void Start()
        {
            _videAssign = GetComponent<VIDE_Assign>();

            _videAssign.overrideStartNode = -1;

            if (overrideStartingDialogue)
                _videAssign.assignedDialogue = startingDialogue;
        }

    }
}
