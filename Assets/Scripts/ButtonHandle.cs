using UnityEngine;
using TMPro;


public enum InputType {
	Operator,
	Digit
};

public enum Operators {
	Plus = '+',
	Minus = '-',
	Multiply = '*',
	Divide = '/',
	Equals = '=',
	None = '0',
}

[RequireComponent(typeof(TextMeshProUGUI))]
public class ButtonHandle : MonoBehaviour {

	private const string TARGET_FIELD_TAG = "TargetField";

	private TextMeshProUGUI contentText;
	private TextFieldManager textFieldManager;

	public InputType inputType = InputType.Digit;

	public string CurrentText => contentText.text;

	private void Start() {
		this.contentText = GetComponent<TextMeshProUGUI>();
		//Find the target text mesh
		this.textFieldManager = FindTargetField();
	}


	//TODO: make string and operator, maybe with overload
	public void SendButtonPress() {
		//Validate afterwards
		this.textFieldManager.AppendText(CurrentText.Trim());
		if (this.inputType == InputType.Operator) {
			//Get our current operator
			char firstChar = CurrentText[0];
			int opChar = (int)firstChar;
			Operators currOp = (Operators)opChar;
			Debug.Log($"Current operator: {currOp}");
			this.textFieldManager.SendOperator(currOp);
		}
	}

	private TextFieldManager FindTargetField() {
		var targetObj = GameObject.FindGameObjectWithTag(TARGET_FIELD_TAG);
		if (targetObj == null) {
			throw new System.Exception($"Target object with the tag name {TARGET_FIELD_TAG} was not found in the scene!");
		}
		return targetObj.GetComponent<TextFieldManager>(); //Could be broken if the txtfielManager is not in the obj
	}

}