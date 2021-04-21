import React, { FunctionComponent } from 'react'
import { Provider } from 'react-redux'
import {Switch, BrowserRouter as Router, Route } from "react-router-dom"
import { Store } from 'redux'
import { Menu } from '../menu/containers/Menu'
import './App.less'

export const App: FunctionComponent<{store: Store<RootState>}> = ( props ) => (
	<Provider store={props.store}>
	<Router>
		<div>
			<Switch>
				<Route exact path="/" component={Menu} />
			</Switch>
		</div>
	</Router>
	</Provider>
)
