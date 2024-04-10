using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    public TextMeshProUGUI messageText; // R�f�rence au texte pour afficher le message au joueur
    public float messageDuration = 8f; // Dur�e d'affichage du message en secondes

    private void Start()
    {
        // Au d�marrage, effacer le texte initial
        ClearMessage();
    }

    private void OnTriggerEnter(Collider other)
    {
        // V�rifier si l'objet est collectable
        CollectableItem item = other.GetComponent<CollectableItem>();
        if (item != null)
        {
            // Afficher le message temporaire
            ShowMessage("Tu as ramass� : " + item.itemName);

            // D�truire l'objet dans la sc�ne
            Destroy(other.gameObject);
        }
    }

    private void ShowMessage(string message)
    {
        // Afficher le message dans le texte sp�cifi�
        messageText.text = message;

        // Appeler la m�thode pour effacer le message apr�s la dur�e sp�cifi�e
        Invoke("ClearMessage", messageDuration);
    }

    private void ClearMessage()
    {
        // Effacer le texte du message
        messageText.text = "";
    }
}
