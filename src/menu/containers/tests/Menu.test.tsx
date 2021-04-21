import { ShallowWrapper, shallow, mount } from 'enzyme'

import { FormSelectOption } from '../../../controls/formSelect/FormSelect'
import { getEmptyRootState } from '../../../testUtils'
import * as selectors from '../../selectors'
import * as menuActions from '../../actions'
import { Menu, mapStateToProps, mapDispatchToProps } from '../Menu'

describe('src/menu/containers', () => {
	describe('Menu', () => {
		let getDinnerMenuOptionsSpy: jest.SpyInstance<FormSelectOption[] | undefined>
		describe('mapStateToProps', () => {
			beforeEach(() => {
				getDinnerMenuOptionsSpy = jest.spyOn(selectors, 'getDinnerMenuOptions')
				
			})

			afterEach(() => {
				getDinnerMenuOptionsSpy.mockReset()
			})

			it('should map dinnerOptions with the selector', () => {
				const mockedDinnerOptions = [{ value: '1', label: 'Duck with Apricot Chutney' }]
				getDinnerMenuOptionsSpy.mockReturnValue(mockedDinnerOptions)
				const result = mapStateToProps(getEmptyRootState())
				expect(result.dinnerOptions).toEqual(mockedDinnerOptions)
			})
			

		})

		describe('mapDispatchToProps', () => {
			const dispatchSpy = jest.fn()

			it('should have the correct action list', () => {
				const result = mapDispatchToProps(dispatchSpy)
				expect(result.actionList).toEqual([ menuActions.getDinnerOptions() ])
			})

			it('should dispatch saveMenu when onSubmit is called', () => {
				const result = mapDispatchToProps(dispatchSpy)
				const formValues = {
					sundayDinner: ''
				}
				result.onSubmit(formValues)
				expect(dispatchSpy).toHaveBeenCalledWith(menuActions.saveMenu(formValues))
			})
		})
	})
})