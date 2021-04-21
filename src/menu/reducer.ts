import { AnyAction } from "redux"
import { SET_DINNER_OPTIONS } from "./actions"

const initialState: MenuState = {
	dinnerOptions: [],
}

export const reducer = (state: MenuState = initialState, action: AnyAction ): MenuState => {
	switch (action.type) {
		case SET_DINNER_OPTIONS:
			return {
				...state,
				dinnerOptions: action.payload,
			}
		default:
			return state
	}
}