import { FormSelectOption } from '../../controls/formSelect/FormSelect'
import { getEmptyMenuState, getEmptyRootState } from '../../testUtils'
import * as selectors from '../selectors'

describe('src/meny/selectors', () => {
	const initialState = getEmptyRootState()

	describe('getMenuState', () => {
		it('should return menu state', () => {
			const expectedMenuState: MenuState = {
				...getEmptyMenuState(),
				dinnerOptions: [
					{ label: "Pizza", value: "Pizza" }
				]
			}
			
			const loadedRootState: RootState = {
				...getEmptyRootState,
				menu: expectedMenuState
			}
			const result = selectors.getMenuState(loadedRootState)
			expect(result).toEqual(expectedMenuState)
		})	
	})

	describe('getDinnerMenuOptions', () => {
		it('should return menu state', () => {
			const menuState: MenuState = {
				...getEmptyMenuState(),
				dinnerOptions: [
					{ label: "Pizza", value: "Pizza" }
				]
			}
			
			const expectedOptions: FormSelectOption[] = [
				{ label: "Pizza", value: "Pizza" }
			]
			const result = selectors.getDinnerMenuOptions.resultFunc(menuState)
			expect(result).toEqual(expectedOptions)
		})	
	})
})