using System.Collections.Generic;
using Helpers;
using Logic.Snake.Views;
using UnityEngine;

namespace Logic.Snake.Controllers
{
    public class BodyPartsMovement : Interfaces.IBodyPartsMovement
    {

        public void Move(GameObject go, List<IPlayerBodyPartView> playerBodyParts)
        {
            if (playerBodyParts != null)
            {
                for (var index = 0; index < playerBodyParts.Count; index++)
                {
                    var bodyObject = playerBodyParts[index];
                    var followObject = go;

                    bodyObject.Transform.LookAt(followObject.transform);
                    if (Vector3.Distance(bodyObject.Transform.position, followObject.transform.position) >
                        Constants._distance)
                        bodyObject.Rigidbody.MovePosition(bodyObject.Rigidbody.position +
                                                          bodyObject.Transform.forward *
                                                          (Constants._five * Time.fixedDeltaTime));
                }
            }
        }
    }
}