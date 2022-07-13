using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Map
{
    public class Door : MonoBehaviour
    {
        public void Open()
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

}
