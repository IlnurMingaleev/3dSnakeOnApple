using System.Collections.Generic;
using Logic.Consumables;
using UnityEngine;

namespace Logic.Snake
{
    public interface IPlayerBodySpawner
    {
        public void AddBodyPart(List<PlayerBodyPart> bodyObjects);
        public void RespawnConsumable(Collision other,List<PlayerBodyPart> bodyObjects, IConsumablesSpawner consumablesSpawner);
    }
}