using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableItem : MonoBehaviour
{
    public string itemName; // Nom de l'objet collectable (optionnel)
    public TextMeshProUGUI messageText; // Référence au texte pour afficher le message au joueur

    private void OnTriggerEnter(Collider other)
    {
        // Vérifier si le joueur entre en collision avec cet objet
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
        // Ajoutez ici le code pour gérer le ramassage de cet objet
        Debug.Log("Item collected: " + itemName); // Afficher le nom de l'objet collecté (optionnel)
        // Vous pouvez ajouter d'autres actions comme ajouter cet objet à l'inventaire
        // ou déclencher des effets visuels, des sons, etc.
        Destroy(gameObject); // Détruire cet objet dans la scène après avoir été collecté
    }

    private void ShowMessage(string message, float duration)
    {
        // Affiche le message dans le texte spécifié pendant la durée spécifiée
        messageText.text = message;
        Invoke("ClearMessage", duration); // Efface le message après la durée spécifiée
    }

    private void ClearMessage()
    {
        // Efface le texte du message
        messageText.text = "";
    }
}
