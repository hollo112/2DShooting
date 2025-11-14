using System.Collections;
using UnityEngine;

public interface IBossPattern
{
   public void Execute(Transform firePoint);
   
   float FireInterval { get; }
   float PatternDuration { get; }
   float RestTime { get; }
}
