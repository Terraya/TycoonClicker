using UnityEngine;

namespace TDSStudio.Control {
    public class BombGenerator : GoldGenerator {

        [Header ("Bomb Instantiate Setup")]
        public GameObject ObjectToInstantiate;
        public GameObject SpawnPoint;

        private void Update()
        {
            if (RunningTimer >= 0.1) return;
            if (Level < 0) return;
            InstantiateObject();
        }

        public void InstantiateObject () {
            if(!ObjectToInstantiate || !SpawnPoint) return;
            var newObject = Instantiate (ObjectToInstantiate, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        }
    }
}