using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueEnemy : AbstractEnemy
{
   private void OnDestroy()
   {
      EnemyManager.enemies.Remove(this);
   }
}
