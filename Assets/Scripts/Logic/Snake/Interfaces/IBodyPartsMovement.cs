using System.Collections.Generic;
using UnityEngine;

namespace Logic.Snake
{
    public interface IBodyPartsMovement
    {
        public void Move(GameObject go, List<PlayerBodyPart> bodyObjects);
    }

   
}