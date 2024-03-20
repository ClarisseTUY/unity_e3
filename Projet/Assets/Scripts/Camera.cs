using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Le transform du joueur que la cam�ra doit suivre
    public Vector3 offset = new Vector3(0, 5, -10); // Offset par rapport au joueur

    void LateUpdate()
    {
        //la cible (le joueur) est d�finie, si non : 
        if (target == null)
        {
            return;
        }

        // on deplace la cam�ra pour suivre le joueur avec l'offset
        transform.position = target.position + offset;

        // on fait en sorte que la cam�ra regarde toujours le joueur
        transform.LookAt(target);
    }
}
