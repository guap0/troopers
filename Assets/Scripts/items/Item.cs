using UnityEngine;

[System.Serializable]
public class Item {

    protected float visionRange = 5.0f;
    public float VisionRange {
        get {
            return visionRange;
        }
        protected set {
            visionRange = value;
        }
    }

    protected float movespeed = 1.0f;
    public float Movespeed {
        get {
            return movespeed;
        }
        protected set {
            movespeed = value;
        }
    }

	void PrimaryUp() {

	}

	void PrimaryDown() {

	}

	void SecondaryUp() {

	}

	void SecondaryDown() {

	}
}
