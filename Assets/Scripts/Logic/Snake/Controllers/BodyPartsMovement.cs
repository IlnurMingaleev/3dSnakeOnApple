using System.Collections.Generic;
using Helpers;
using UnityEngine;

namespace Logic.Snake
{
    public class BodyPartsMovement : IBodyPartsMovement
    {

        public void Move(GameObject go, List<PlayerBodyPart> bodyObjects)
        {
            if (bodyObjects != null)
            {
                for (var index = 0; index < bodyObjects.Count; index++)
                {
                    var bodyObject = bodyObjects[index];
                    var followObject = go;

                    bodyObject.transform.LookAt(followObject.transform);
                    if (Vector3.Distance(bodyObject.transform.position, followObject.transform.position) >
                        Constants._distance)
                        bodyObject.rigidbody.MovePosition(bodyObject.rigidbody.position +
                                                          bodyObject.transform.forward *
                                                          (Constants._five * Time.fixedDeltaTime));
                }
            }
        }
    }
}