using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlcamera : MonoBehaviour
{
    public GameObject target;

    public float derechaMax;
    public float izquierdaMax;

    public float alturaMax;
    public float alturaMin;

    public float speed;
    public bool encendido = true;

    private void Awake()
    {
        if (target != null)
        {
            float targetPosX = target.transform.position.x;
            float targetPosY = target.transform.position.y;

            float posX = targetPosX;
            float posY = targetPosY;

            if (posX < derechaMax)
                posX = derechaMax;
            else if (posX > izquierdaMax)
                posX = izquierdaMax;

            if (posY < alturaMin)
                posY = alturaMin;
            else if (posY > alturaMax)
                posY = alturaMax;

            transform.position = new Vector3(posX, posY, -1);
        }
    }

    void MoveCam()
    {
        if (encendido && target != null)
        {
            float targetPosX = target.transform.position.x;
            float targetPosY = target.transform.position.y;

            float posX = targetPosX;
            float posY = targetPosY;

            if (posX < derechaMax)
                posX = derechaMax;
            else if (posX > izquierdaMax)
                posX = izquierdaMax;

            if (posY < alturaMin)
                posY = alturaMin;
            else if (posY > alturaMax)
                posY = alturaMax;

            transform.position = Vector3.Lerp(transform.position, new Vector3(posX, posY, -1), speed * Time.deltaTime);
        }
    }

    void LateUpdate()
    {
        MoveCam();
    }
}
