import { FormikProps } from "formik";

export const formikMenuFormValuesTestProps: FormikProps<MenuFormValues> = {
	values: {
		sundayDinner: '',
	},
	errors: {},
	touched: {},
	isSubmitting: false,
	isValidating: false,
	submitCount: 0,
	setStatus: () => {},
	setSubmitting: () => {},
	setTouched: () => {},
	setErrors: () => {},
	setValues: () => {},
	setFieldError: () => {},
	setFieldValue: () => {},
	setFieldTouched: () => {},
	setFormikState: () => {},
	validateField: () => {},
	resetForm: () => {},
	submitForm: async () => {},
	validateForm: async (values: any) => ({
		sundayDinner: '',
	}),
	handleSubmit: () => {},
	handleBlur: () => {},
	handleReset: () => {},
	handleChange: () => {},
	dirty: false, 
	initialTouched: {},
	isValid: true,
	initialValues: {
		sundayDinner: '',
	},
	initialErrors: {},
	//I have no idea if any of this is right, I just want to run some tests
	registerField: () => {},
	unregisterField: () => {},
	getFieldProps: <Value = any>( props: any) => ({name: '', onChange: () => {}, onBlur: () => {}, value: props}),
	getFieldMeta: <Value>(name: any) => ({name, onChange: () => {}, onBlur: () => {}, value: name, touched: false, initialTouched: false }),
	getFieldHelpers: <Value>(name: any) => ({name, onChange: () => {}, onBlur: () => {}, value: name, touched: false, initialTouched: false, setValue: () => {}, setTouched: () => {}, setError: () => {} }),

}