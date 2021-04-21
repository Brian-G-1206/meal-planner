import { getEmptyMenuState } from '../../testUtils'
import { SET_DINNER_OPTIONS } from '../actions'
import { reducer } from '../reducer'

describe('src/menu/reducer', () => {
	const initialState: MenuState = getEmptyMenuState()

	describe('SET_DINNER_OPTIONS', () => {
		it('should return state with some dinner options', () => {
			const dinnerOptions = [
				{ value: "1", label: "Crown Roast of Pork with Mushroom Dressing" },
			] 
			const result = reducer(initialState, { type: SET_DINNER_OPTIONS, payload: dinnerOptions})

			expect(result.dinnerOptions).toEqual(dinnerOptions)
		})
	})

	describe('default', () => {
		it('should return state without changes', () => {
			const result = reducer(initialState, { type: "THIS_IS_A_FAKE_ACTION" })

			expect(result).toEqual(initialState)
		})
	})
})