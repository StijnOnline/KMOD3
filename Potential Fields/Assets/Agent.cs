using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {

    [SerializeField] private float movespeed = 0.1f;

    void Update() {
        transform.Translate(movespeed * Grid.GetDirection(transform.position));
    }
}
