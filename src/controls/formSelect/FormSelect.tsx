import { Field } from "formik"
import React, { FunctionComponent } from "react"

export interface FormSelectProps {
	fieldName: string
	options: FormSelectOption[]
}

export interface FormSelectOption {
	label: string
	value: string
}

export const FormSelect: FunctionComponent<FormSelectProps> = ( props: FormSelectProps ) => 
<Field as="select" name={props.fieldName} >
	{props.options.map(( opt, key ) => <option key={key} value={opt.value}>{opt.label}</option>)}
</Field>