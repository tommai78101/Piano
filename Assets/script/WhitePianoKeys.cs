using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WhitePianoKeys : MonoBehaviour {
	public GameObject keyPrefab;
	public GameObject noteImageUI;
	public GameObject noteParent;
	public float horizontalOffset;

	public void Start() {
		foreach (Transform t in this.transform) {
			MonoBehaviour.Destroy(t.gameObject);
		}

		this.horizontalOffset += 1.15f;
		int octaveCount = 1;
		int counter = 0;
		for (int i = 0; i < 37; i++) {
			GameObject obj = MonoBehaviour.Instantiate(this.keyPrefab) as GameObject;
			obj.transform.SetParent(this.transform, false);
			RectTransform rectTrans = obj.GetComponent<RectTransform>();
			if (rectTrans != null) {
				rectTrans.localScale = Vector3.one;
				rectTrans.position = new Vector3(this.horizontalOffset, -5, 0);
				this.horizontalOffset += (float) (Screen.width / Screen.height) / 2.09f;
			}
			KeyNote note = obj.GetComponent<KeyNote>();
			if (note != null) {
				note.noteObject = MonoBehaviour.Instantiate(this.noteImageUI) as GameObject;
				note.noteObject.transform.SetParent(this.noteParent.transform, false);
				Image image = note.noteObject.GetComponent<Image>();
				if (image != null) {
					image.overrideSprite = Resources.Load<Sprite>("image/note.png");
					Debug.Log("Load note success.");
				}
				switch (counter) {
					case 0:
						note.note = Note.C;
						break;
					case 1:
						note.note = Note.D;
						break;
					case 2:
						note.note = Note.E;
						break;
					case 3:
						note.note = Note.F;
						break;
					case 4:
						note.note = Note.G;
						break;
					case 5:
						note.note = Note.A;
						break;
					case 6:
						note.note = Note.B;
						break;
				}
				note.octave = octaveCount;
				counter++;
				if (counter >= 7) {
					counter = 0;
					octaveCount++;
				}
			}
		}
	}
}
