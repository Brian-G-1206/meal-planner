import { withFormik } from "formik"
import { connect } from "react-redux"
import { Dispatch } from "redux"
import { FormSelectOption } from "../../controls/formSelect/FormSelect"
import { MenuComponent } from "../components/MenuComponent"
import { getDinnerMenuOptions } from "../selectors"
import * as menuActions from "../actions"
import { DispatchAndActions } from "../../utils/dispatchActionsOnMount"

export interface StateToProps {
	dinnerOptions: FormSelectOption[]
}

export interface DispatchToProps extends DispatchAndActions {
	onSubmit: (formValues: MenuFormValues) => void
}

export const mapStateToProps = (state: RootState): StateToProps => ({
	dinnerOptions: getDinnerMenuOptions(state),
})

export const mapDispatchToProps = (dispatch: Dispatch): DispatchToProps => ({
	actionList: [ menuActions.getDinnerOptions() ],
	onSubmit: (formValues: MenuFormValues) => dispatch(menuActions.saveMenu(formValues)),
	dispatch
})

const MenuConnect = connect(mapStateToProps)(MenuComponent)

/* istanbul ignore next */
export const Menu = withFormik<StateToProps & DispatchToProps, MenuFormValues>({
	handleSubmit(values, { props, setSubmitting}) {
		props.onSubmit(values)
	},
})(MenuConnect)