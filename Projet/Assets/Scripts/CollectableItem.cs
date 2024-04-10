using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableItem : MonoBehaviour
{
    public string itemName; // Nom de l'objet collectable (optionnel)
    public TextMeshProUGUI messageText; // R�f�rence au texte pour afficher le message au joueur

    private void OnTriggerEnter(Collider other)
    {
        // V�rifier si le joueur entre en collision avec cet objet
        if (other.CompareTag("Player"))
        {
            // Ramasser l'objet par le joueur
            Collect();

            // Afficher un message pendant quelques secondes
            ShowMessage("Item collected: " + itemName, 2f); // Affiche le message pendant 2 secondes
        }
    }

    private void Collect()
    {
        // Ajoutez ici le code pour g�rer le ramassage de cet objet
        Debug.Log("Item collected: " + itemName); // Afficher le nom de l'objet collect� (optionnel)
        // Vous pouvez ajouter d'autres actions comme ajouter cet objet � l'inventaire
        // ou d�clencher des effets visuels, des sons, etc.
        Destroy(gameObject); // D�truire cet objet dans la sc�ne apr�s avoir �t� collect�
    }

    private void ShowMessage(string message, float duration)
    {
        // Affiche le message dans le texte sp�cifi� pendant la dur�e sp�cifi�e
        messageText.text = message;
        Invoke("ClearMessage", duration); // Efface le message apr�s la dur�e sp�cifi�e
    }

    private void ClearMessage()
    {
        // Efface le texte du message
        messageText.text = "";
    }
}
