import { shallow, ShallowWrapper } from 'enzyme'
import renderer from 'react-test-renderer'
import { formikMenuFormValuesTestProps } from '../../../testUtils/formikHelper'
import { MenuComponent } from '../MenuComponent'

describe('src/menu/components', () => {
	describe('MenuComponent', () => {
		describe('rendering', () => {
			it('should render the form', () => {
				const Subject = renderer
				.create(<MenuComponent  dinnerOptions={[{ label: "", value: "" }]} {...formikMenuFormValuesTestProps } />)
				.toJSON()
				expect(Subject).toMatchSnapshot()
			})
		})

		describe('onSubmit', () => {
			it('should do nothing ... yet', () => {
				const Subject: ShallowWrapper = shallow(<MenuComponent  dinnerOptions={[{ label: "", value: "" }]} {...formikMenuFormValuesTestProps } />)
				const form = Subject.find('Formik')
				form.simulate('submit')
				
			})
		})
	})
})