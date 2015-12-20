using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;

public class Note {
	public static readonly Note C = new Note("C-", 1);
	public static readonly Note CSharp = new Note("C#", 2);
	public static readonly Note D = new Note("D-", 3);
	public static readonly Note DSharp = new Note("D#", 4);
	public static readonly Note E = new Note("E-", 5);
	public static readonly Note ESharp = new Note("E#", 6);
	public static readonly Note F = new Note("F-", 7);
	public static readonly Note FSharp = new Note("F#", 8);
	public static readonly Note G = new Note("G-", 9);
	public static readonly Note GSharp = new Note("G#", 10);
	public static readonly Note A = new Note("A-", 11);
	public static readonly Note ASharp = new Note("A#", 12);
	public static readonly Note B = new Note("B-", 13);
	public static readonly Note BSharp = new Note("B#", 14);

	private string mLetter;
	private int mValue;

	public static IEnumerable<Note> Values {
		get {
			yield return C;
			yield return CSharp;
			yield return D;
			yield return DSharp;
			yield return E;
			yield return ESharp;
			yield return F;
			yield return FSharp;
			yield return G;
			yield return GSharp;
			yield return A;
			yield return ASharp;
			yield return B;
			yield return BSharp;
		}
	}

	public string letter {
		set {
			this.mLetter = value;
		}
		get {
			return mLetter;
		}
	}

	public int value {
		set {
			this.mValue = value;
		}
		get {
			return this.mValue;
		}
	}

	public Note(string letter, int value) {
		this.letter = letter;
		this.value = value;
	}

	public override string ToString() {
		return this.letter;
	}
}

public class KeyNote : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
	public Note note;
	public int octave;
	public bool sharpFlag;
	public GameObject noteObject;
	public RectTransform notePosition;
	public bool pressed = false;

	public void Start() {
		if (this.noteObject != null) {
			this.notePosition = this.noteObject.GetComponent<RectTransform>();
		}
	}

	public void Update() {
		if (this.noteObject != null) {
			if (!this.pressed) {
				this.notePosition.localPosition = new Vector3(0, -400f, 0);
			}
			else {
				if (note.value % 2 == 1) {
					this.sharpFlag = false;
					Image[] noteSharp = this.noteObject.GetComponentsInChildren<Image>();
					if (noteSharp != null && noteSharp.Length == 2) {
						noteSharp[1].enabled = false;
					}
					int newHeight = octave * 7 + (note.value - 1) / 2;
					this.notePosition.localPosition = new Vector3(0, (float) (newHeight * (5.8f)), 0);
					Debug.Log(note.letter + octave);
				}
				else {
					int newHeight = octave * 7 + (note.value) / 2;
					this.notePosition.localPosition = new Vector3(0, (float) (newHeight * (5.8f)), 0);
					Debug.Log(note.letter + octave);
				}
			}
		}
	}

	public void OnPointerUp(PointerEventData eventData) {
		this.pressed = false;
	}

	public void OnPointerDown(PointerEventData eventData) {
		this.pressed = true;
	}
}
