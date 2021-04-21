import { Form, Formik, FormikProps } from "formik"
import React, { FunctionComponent } from "react"
import { FormSelectOption } from "../../controls/formSelect/FormSelect"

export interface MenuProps {
	dinnerOptions: FormSelectOption[],
}

export const MenuComponent: FunctionComponent<MenuProps & FormikProps<MenuFormValues>> = ( props ) => 
<div>
	<h1>Menu</h1>
	<Formik
		initialValues = {{ sundayDinner: "" }}
		onSubmit={(values, actions) => {}}
	>
	</Formik>
</div>