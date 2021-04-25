using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrownEnemy : AbstractEnemy
{
   private void Start()
   {
      base.Start();
      speedFactor = 0.5f;
   }
   private void OnDestroy()
   {
      EnemyManager.enemies.Remove(this);
   }
}
