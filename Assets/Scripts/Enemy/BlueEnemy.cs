using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueEnemy : AbstractEnemy
{

   private void Start()
   {
      base.Start();
      speedFactor = 2f;
   }
   private void OnDestroy()
   {
      EnemyManager.enemies.Remove(this);
   }
}
