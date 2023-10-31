using System.Collections.Generic;
using Helpers;
using Logic.Snake.Views;
using UnityEngine;

namespace Logic.Snake.Controllers
{
    public class BodyPartsMovement : Interfaces.IBodyPartsMovement
    {

        public void Move(GameObject playerGO, List<IPlayerBodyPartView> playerBodyParts)
        {
            if (playerBodyParts != null)
            {
                for (var index = 0; index < playerBodyParts.Count; index++)
                {
                    var bodyObject = playerBodyParts[index];
                    var followObject = index-1 >= 0 ? playerBodyParts[index-1].GameObject : playerGO;

                    bodyObject.Transform.LookAt(followObject.transform);
                    if (Vector3.Distance(bodyObject.Transform.position, followObject.transform.position) >
                        Constants._distance)
                        bodyObject.Rigidbody.MovePosition(bodyObject.Rigidbody.position +
                                                          bodyObject.Transform.forward *
                                                          (Constants._bodyPartMoveSpeed * Time.fixedDeltaTime));
                }
            }
        }
    }
}