using System.Collections;
using UnityEngine;

namespace Infrustructure
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator coroutine);
  }
}