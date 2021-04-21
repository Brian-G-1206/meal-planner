import { configureStore } from "@reduxjs/toolkit"
import { reducer as menuReducer } from './menu/reducer'

const initialState: RootState = {
	menu: {
		dinnerOptions: [],
	}
}
export const store = configureStore({
	reducer: {
		menu: menuReducer
	},
	devTools: true,
	preloadedState: initialState,
})