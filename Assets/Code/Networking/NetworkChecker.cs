using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using SocketIO;

namespace Project.Networking 
{
    public class NetworkChecker : SocketIOComponent
    {   
        public static bool hasConnection = false;
        private bool messageFromServer = false;
        
        public UnityEvent successfulConnection;
        public UnityEvent failedConnection;
        
        public override void Start()
        {

            base.Start();

            SetupEvents();        
            StartCoroutine (simpleTimer());
        }

        public override void Update() {
            base.Update();
        }

        private void SetupEvents() {
            On("open", (E) => {
                messageFromServer = true;
            });
        }
        
        IEnumerator simpleTimer() {
            //Wait to ensure proper connection
            //I have future ideas, this is just easy for a quick demo version
            yield return new WaitForSeconds(5f);        

            if(messageFromServer) {
                hasConnection = true;
                successfulConnection.Invoke();
            }
            else {
                failedConnection.Invoke();
            }
        }
    }
}
