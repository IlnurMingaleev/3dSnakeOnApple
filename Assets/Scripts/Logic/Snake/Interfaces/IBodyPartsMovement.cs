using System.Collections.Generic;
using Logic.Snake.Views;
using UnityEngine;

namespace Logic.Snake.Interfaces
{
    public interface IBodyPartsMovement
    {
        public void Move(GameObject go, List<IPlayerBodyPartView> playerBodyParts);
    }

   
}