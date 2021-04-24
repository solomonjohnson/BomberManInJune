using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
  public BombController controller;

  // Start is called before the first frame update
  void OnEnable()
  {
    Invoke(nameof(ExplodeBomb), 5f);
  }

  void ExplodeBomb()
  {
    controller.bombActive = false;
    Destroy(this.gameObject);
  }
}
