using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMenuGoalObj : MonoBehaviour
{

        private SceneChanger sceneChanger;
        private GameEngine gameEngine;
        [SerializeField]
        public string sceneToChangeTo;
        [SerializeField]
        private string playerTag;
        private bool hasSwitched;
        [SerializeField]
        private Vector2 checkSize;
        [SerializeField]
        private LayerMask playerLayer;
        // Start is called before the first frame update
        void Start()
        {
            hasSwitched = false;
            sceneChanger = FindFirstObjectByType<SceneChanger>();
            gameEngine = FindFirstObjectByType<GameEngine>();

        }
        private void Update()
        {
            if (Physics2D.OverlapBox(transform.position, checkSize, 0, playerLayer) && hasSwitched == false)
            {
                hasSwitched = true;
                destroyFireBall();
                print("hitObj");
                gameEngine.StartEndScreen();
            }
        }
        // Update is called once per frame
        /*    private void OnCollisionEnter2D(Collision2D collision)
            {
                if (collision.gameObject.CompareTag(playerTag) && !hasSwitched)
                {
                    hasSwitched = true;
                    sceneChanger.SceneSelect(sceneToChangeTo);
                }
            }*/
        /*    private void OnCollisionExit2D(Collider2D collision)
            {
                if (collision.gameObject.CompareTag(playerTag) && !hasSwitched)
                {
                    hasSwitched = true;
                    sceneChanger.SceneSelect(sceneToChangeTo);
                }
            }*/
        public void OnClick()
        {
        }


        // DESTROY FIREBALL
        private void destroyFireBall()
        {
            if (GameObject.Find("FireBall(Clone)") != null)
            {
                Destroy(GameObject.Find("FireBall(Clone)"));
            }
        }
}
