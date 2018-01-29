using UnityEngine;

[System.Serializable]
public class Weapon : Item {

	protected float aimVisionRange = 7.0f;
    public float AimVisionRange {
        get {
            return aimVisionRange;
        }
        protected set {
            aimVisionRange = value;
        }
    }

	protected bool secondaryDown = false;


	void SecondaryUp() {
		secondaryDown = false;
	}

	void SecondaryDown() {
		secondaryDown = true;
	}

	public float getVisionRange() {
		return secondaryDown ? aimVisionRange: visionRange;
	}
}
