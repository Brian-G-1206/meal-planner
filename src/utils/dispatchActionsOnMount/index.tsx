import React from 'react'
import { AnyAction, Dispatch } from 'redux'

export interface DispatchAndActions { dispatch: Dispatch<any>, actionList: Array<AnyAction> }

export const dispatchActionsOnMount: <P extends DispatchAndActions>(ComponentClass: React.ComponentType<any>) => React.ComponentType<P> =
    ComponentClass =>
        class DispatchingWrapper<P extends DispatchAndActions> extends React.Component<P, {}> {
            private dispatch: Dispatch<any>
            private actionList: Array<AnyAction>

            constructor(props: P) {
                super(props)
                const { dispatch, actionList } = props
                this.dispatch = dispatch
                this.actionList = actionList
            }

            public componentDidMount() {
                this.actionList.forEach(a => this.dispatch(a))
            }

            public render() {
                // eslint-disable-next-line @typescript-eslint/no-unused-vars
                const { dispatch, actionList, ...propsWithoutStuffs } = this.props as any
                return <ComponentClass {...propsWithoutStuffs} />
            }
        }
