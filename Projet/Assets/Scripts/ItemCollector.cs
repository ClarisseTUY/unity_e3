using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    public TextMeshProUGUI messageText; // Référence au texte pour afficher le message au joueur
    public float messageDuration = 8f; // Durée d'affichage du message en secondes

    private void Start()
    {
        // Au démarrage, effacer le texte initial
        ClearMessage();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'objet est collectable
        CollectableItem item = other.GetComponent<CollectableItem>();
        if (item != null)
        {
            // Afficher le message temporaire
            ShowMessage("Tu as ramassé : " + item.itemName);

            // Détruire l'objet dans la scène
            Destroy(other.gameObject);
        }
    }

    private void ShowMessage(string message)
    {
        // Afficher le message dans le texte spécifié
        messageText.text = message;

        // Appeler la méthode pour effacer le message après la durée spécifiée
        Invoke("ClearMessage", messageDuration);
    }

    private void ClearMessage()
    {
        // Effacer le texte du message
        messageText.text = "";
    }
}
