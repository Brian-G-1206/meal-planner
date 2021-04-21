import React from 'react'
import { mount, ReactWrapper } from 'enzyme'

import { dispatchActionsOnMount } from '..'
import { AnyAction } from 'redux'

describe('dispatchActionsOnMount', () => {
    let UnmountedComponent: any
    let wrapper: ReactWrapper<any>
    const dispatchSpy = jest.fn()
    const actionList: Array<AnyAction> = []
    const fakeComponent: React.SFC<{ otherProp: string }> = props =>
        <div>
            {props.otherProp}
        </div>

    beforeEach(() => {
        UnmountedComponent = dispatchActionsOnMount(fakeComponent)
        wrapper = mount(<UnmountedComponent dispatch={dispatchSpy} actionList={actionList} otherProp={'abc123'} />)
    })

    afterEach(() => {
        dispatchSpy.mockReset()
    })

    it('should pass down the props', () => {
        expect(wrapper.find('div').text()).toBe('abc123')
    })

    describe('componentDidMount', () => {
        it('should dispatch the passed actions', () => {
            const passedActions = [
                { type: 'abc' },
                { type: 'zyx' },
            ]
            const Result = dispatchActionsOnMount(fakeComponent)
            mount(<Result dispatch={dispatchSpy} actionList={passedActions} />)
            expect(dispatchSpy).toHaveBeenCalledWith({ type: 'abc' })
            expect(dispatchSpy).toHaveBeenCalledWith({ type: 'zyx' })
            expect(dispatchSpy).toHaveBeenCalledTimes(2)
        })
    })
})
