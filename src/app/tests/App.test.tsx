import { shallow, ShallowWrapper } from 'enzyme'
import { App } from '../App'
import { store } from '../../store'


describe('src/app/App', () => {
	it('should match snapshot', () => {
		const Subject: ShallowWrapper = shallow(<App store={store} />)
		expect(Subject).toMatchSnapshot()
	  })
	  
})
