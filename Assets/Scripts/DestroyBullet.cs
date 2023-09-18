using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public float timetodestroy;
    void Start(){
        Destroy(this.gameObject, timetodestroy);
    }
}
