using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CJFinc.UItools {

/*
	Class: UIStateGroupControl
	<UIStateGroupControl> extends <UIStateGroup> into the group of items with only one item selected.

	(see UIStateGroupControl-editor.png)

	<UIStateGroupControl> works with active and inactive states of <UIStateItem>.
	It reacts to any <UIStateItem> state change and controls that only one item should be selected at the same time.

	(see UIStateGroupControl-editor-hierarchy.gif)


	There are two modes available
	- one active
	- one inactive

	In "one active" <UIStateGroupControl> controls that only one item is active.

	And "one inactive" has an inverse behavior when only one item could be inactive.
*/

[DisallowMultipleComponent]
public class UIStateGroupControl : UIStateGroup {

	void Start() {
		if (initOnStart) Init (true);
	}

	protected override void RichInit() {
		base.RichInit(); // as first line - call base initialization

		// your initialization here
		// Flush();
	}



	// editor
	[SerializeField] bool isStateGroupControlExpanded;



	/*
		Enum: STATE_GROUP_CONTROL_MODE
		Enumeration of possible group modes

		- OneActive
		- OneInActive
	*/
	public enum STATE_GROUP_CONTROL_MODE {
		OneActive = 0,
		OneInActive = 1
	}



	/*
		Prop: Mode
		Current group mode <STATE_GROUP_CONTROL_MODE>
	*/
	public STATE_GROUP_CONTROL_MODE Mode { get { return mode; } }
	[SerializeField] STATE_GROUP_CONTROL_MODE mode;


	/*
		Prop: SelectedItem
		Currently selected <UIStateItem> item
	*/
	public UIStateItem SelectedItem { get { return selectedItem; } }
	/*
		Prop: SelectedItemName
		Currently selected <UIStateItem> item name
	*/
	public string SelectedItemName { get { return (selectedItem == null) ? "" : selectedItem.itemName; } }
	[SerializeField] UIStateItem selectedItem;



	// state group mode
	/*
		Func: SetMode (newMode)
		Change group mode and set items to initial states

		(start code)
		GetComponent<UIStateGroupControl>().SetMode(STATE_GROUP_CONTROL_MODE.OneInActive);
		(end code)

		Parameters:
			newMode - <STATE_GROUP_CONTROL_MODE> new group mode
	*/
	public void SetMode(STATE_GROUP_CONTROL_MODE newMode) {
		mode = newMode;
		SelectFirstItem();
	}


	/*
		Func: ItemStateChanged (itemName)
		Internal function. Called automatically from <UIStateItem> for each state change

		See <UIStateGroup.ItemStateChanged (itemName)> for details.

		Parameters:
			itemName - item name
	*/
	public override void ItemStateChanged(string itemName) {
		UIStateItem stateItem = GetStateItem(itemName);
		if (stateItem == null) return;

		//		if Mode - one active
		//			if item active
		//				set others to inactive
		if (Mode == STATE_GROUP_CONTROL_MODE.OneActive) {
			if (stateItem.CurrentState == UIStateItem.STATE_ACTIVE) {
				selectedItem = stateItem;

				for (int i=0; i<StateItems.Length; i++) {
					if (StateItems[i].itemName != itemName)
						StateItems[i].SetState(UIStateItem.STATE_INACTIVE);
				}
			}
			else {
				if (SelectedItemName == itemName) {
					stateItem.SetStateActive();
				}
			}
		}

		//		if Mode - one inactive
		//			if item inactive
		//				set others to active
		if (Mode == STATE_GROUP_CONTROL_MODE.OneInActive) {
			if (stateItem.CurrentState == UIStateItem.STATE_INACTIVE) {
				selectedItem = stateItem;

				for (int i=0; i<StateItems.Length; i++) {
					if (StateItems[i].itemName != itemName)
						StateItems[i].SetState(UIStateItem.STATE_ACTIVE);
				}
			}
			else {
				if (SelectedItemName == itemName) {
					stateItem.SetStateInactive();
				}
			}
		}

		if (OnStateChange != null) OnStateChange.Invoke(); // call OnStateChange event
	}

	/*
		Func: SetItemActive(itemName)
		Change item with given name to state UIStateItem.STATE_ACTIVE

		(start code)
		GetComponent<UIStateGroupControl>().SetItemActive("item (2)");
		(end code)

		Parameters:
			itemName - <UIStateItem> item name
	*/
	public void SetItemActive(string itemName) {
		UIStateItem stateItem = GetStateItem(itemName);
		if (stateItem == null) return;

		// Don't deselect item
		if (IsItemSelected(itemName)) return;

		stateItem.SetStateActive();
	}

	/*
		Func: SetItemInactive(itemName)
		Change item with given name to state UIStateItem.STATE_INACTIVE

		(start code)
		GetComponent<UIStateGroupControl>().SetItemInactive("item (2)");
		(end code)

		Parameters:
			itemName - <UIStateItem> item name
	*/
	public void SetItemInactive(string itemName) {
		UIStateItem stateItem = GetStateItem(itemName);
		if (stateItem == null) return;

		// Don't deselect item
		if (IsItemSelected(itemName)) return;

		stateItem.SetStateInactive();
	}

	/*
		Func: SelectFirstItem()
		Flushes state for all items and makes active the first one

		(start code)
		// Example - selecting first item in group init
		// NOTE: Make sure to disable Init on start for all items, to let group control init state

		void Awake() {
			GetComponent<UIStateGroupControl>().OnInitFinish.AddListener(OnRadioGroupInitFinished);
		}

		void OnRadioGroupInitFinished() {
			GetComponent<UIStateGroupControl>().SelectFirstItem();
		}
		(end code)
	*/
	public void SelectFirstItem() {
		if (items.Length == 0) return;

		Flush();
        SetStateForItem(
            Mode == UIStateGroupControl.STATE_GROUP_CONTROL_MODE.OneActive ? "active" : "inactive", 
            items[0].itemName
        );
	}

	/*
		Func: Flush()
		Flush all items for default state according to current <Mode>

		(start code)
		GetComponent<UIStateGroupControl>().Flush();
		(end code)
	*/
	public void Flush() {
		if (OnStateChange != null) OnStateChange.Invoke(); // call OnStateChange event

		switch (Mode) {
			case STATE_GROUP_CONTROL_MODE.OneActive:
				selectedItem = null;
				for (int i=0; i<StateItems.Length; i++)
					StateItems[i].SetStateInactive();
				break;

			case STATE_GROUP_CONTROL_MODE.OneInActive:
				selectedItem = null;
				for (int i=0; i<StateItems.Length; i++)
					StateItems[i].SetStateActive();
				break;
		}
	}

	bool IsItemSelected(string itemName) {
		UIStateItem stateItem = GetStateItem(itemName);
		if (stateItem == null) return false;

		if (Mode == STATE_GROUP_CONTROL_MODE.OneActive) {
			if (stateItem.CurrentState == UIStateItem.STATE_ACTIVE)
				return true;
		}

		if (Mode == STATE_GROUP_CONTROL_MODE.OneInActive) {
			if (stateItem.CurrentState == UIStateItem.STATE_INACTIVE)
				return true;
		}

		return false;
	}

}
}
