using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFieldManager : MonoBehaviour {

	private TextMeshProUGUI textField;

	private float leftSide;
	private float rightSide;
	private Operators currOperator;

	private void Start() {
		this.textField = GetComponent<TextMeshProUGUI>();
		this.leftSide = 0f;
		this.rightSide = 0f;
	}


	public void AppendText(string text) {
		//TODO: Check if this needs some validation
		this.textField.text += text;
	}

	public void SendOperator(Operators op) {
		if (op == Operators.Equals) {
			this.SetRight();
			this.textField.text = CalculateResult().ToString();
			return;
		}
		//Otherwise, it is any other op
		if (this.leftSide == 0f) {
			//Side has not beeen set, set it
			this.SetLeft();
			this.currOperator = op;
		}
	}

	public float CalculateResult() {
		switch (currOperator) {
			case Operators.Plus:
				return this.leftSide + this.rightSide;
			case Operators.Minus:
				return this.leftSide - this.rightSide;
			case Operators.Multiply:
				return this.leftSide * this.rightSide;
			case Operators.Divide:
				return this.leftSide / this.rightSide;
			case Operators.None:
			default:
				throw new System.NotImplementedException();
		}
	}


	private void SetLeft() {
		string noOpString = this.textField.text.Remove(this.textField.text.Length - 1, 1);
		this.leftSide = float.Parse(noOpString);
		this.textField.text = "";
	}

	private void SetRight() {
		string noOpString = this.textField.text.Remove(this.textField.text.Length - 1, 1);
		this.rightSide = float.Parse(noOpString);
		this.textField.text = "";
	}

}
