using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip clickSubmit;
    [SerializeField] AudioClip cancel;
    [SerializeField] AudioClip move;

    VisualElement root;
    int cancelCount = 0;

    private void OnEnable(){
        root = GetComponent<UIDocument>().rootVisualElement;

        root.RegisterCallback<ClickEvent>(ev => AudioSource.PlayClipAtPoint(clickSubmit, Camera.main.transform.position));
        root.RegisterCallback<NavigationSubmitEvent>(ev => AudioSource.PlayClipAtPoint(clickSubmit, Camera.main.transform.position));
        root.RegisterCallback<NavigationCancelEvent>(ev => {   
            AudioSource.PlayClipAtPoint(cancel, Camera.main.transform.position);
            cancelCount++;
            root.Q<Label>("cancelCount").text = "CANCEL EVENTS CALLED (BACKSPACE): " + cancelCount.ToString();
        });
        root?.RegisterCallback<NavigationMoveEvent>(ev => AudioSource.PlayClipAtPoint(move, Camera.main.transform.position));
    }
}
