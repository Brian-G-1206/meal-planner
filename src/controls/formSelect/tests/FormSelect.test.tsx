import { Formik } from 'formik'
import renderer from 'react-test-renderer'
import { FormSelect } from '../FormSelect'

describe('src/controls/formSelect', () => {
	it('should match snapshot', () => {
		// TODO: this cannot be the right way to do this, but it's "working" ...
		let Subject = renderer
			.create(
				<Formik initialValues={{fieldName: ''}} onSubmit={() => {}} >
					<FormSelect fieldName="fieldName" options={[ {value: "1", label: "One"}, {value: "1", label: "One"} ]} />
				</Formik>)
			.toJSON()
		expect(Subject).toMatchSnapshot()
	})
})
