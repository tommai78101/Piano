using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlackPianoKeys : MonoBehaviour {
	public GameObject keyPrefab;
	public GameObject noteImageUI;
	public GameObject noteParent;
	public float horizontalOffset;

	public static readonly float CONSTANT = (float)(Screen.width / Screen.height) / 2.09f;

	public void Start () {
		foreach (Transform child in this.transform) {
			MonoBehaviour.Destroy(child.gameObject);
		}
		this.horizontalOffset += (CONSTANT / 2f) + 1.225f;
		int counter = 0;
		int octaveCount = 1;
		for (int i = 0; i < 11; i++) {
			int groups = (i % 2 == 1) ? 3 : 2;
			if (i == 10) {
				groups = 1;
			}
			for (int j = 0; j < groups; j++) {
				GameObject obj = MonoBehaviour.Instantiate(this.keyPrefab) as GameObject;
				obj.transform.SetParent(this.transform, false);
				RectTransform rectTrans = obj.GetComponent<RectTransform>();
				if (rectTrans != null) {
					rectTrans.localScale = new Vector3(0.64f, 0.8f, 1f);
					rectTrans.position = new Vector3(this.horizontalOffset, CONSTANT * -8.4f, 0);
					this.horizontalOffset += CONSTANT;
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
							note.note = Note.CSharp;
							break;
						case 1:
							note.note = Note.DSharp;
							break;
						case 2:
							note.note = Note.FSharp;
							break;
						case 3:
							note.note = Note.GSharp;
							break;
						case 4:
							note.note = Note.ASharp;
							break;
					}
					note.octave = octaveCount;
					counter++;
					if (counter >= 5) {
						counter = 0;
						octaveCount++;
					}
				}
			}
			this.horizontalOffset += CONSTANT;
		}
	}
}
