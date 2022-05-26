using UnityEngine;

namespace CultureFMP
{
    public class SpeechBubbleManager : MonoBehaviour
    {
        [SerializeField] private GameObject _yelowBubble;
        [SerializeField] private GameObject _whiteBubble;
        private Camera cam;

        private void Start()
        {
            cam = Camera.main;
        }

        public void Update()
        {
            transform.LookAt(cam.transform);
        }

        public void YellowToWhite()
        {
            _yelowBubble.SetActive(false) ;
            _whiteBubble.SetActive(true);
        }

        public void WhiteToYellow()
        {
            _yelowBubble.SetActive(true);
            _whiteBubble.SetActive(false);
        }

        public void NoBubbles()
        {
            _yelowBubble.SetActive(false);
            _whiteBubble.SetActive(false);
        }
    }
}